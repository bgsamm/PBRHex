using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using PBRHex.Dialogs;
using PBRHex.Files;
using PBRHex.Utils;

namespace PBRHex
{
    public partial class CodeEditor : Form
    {
        private int CurrentSection => sectionSelectDropdown.SelectedIndex;
        private uint CurrentSectionAddress => DOL.GetSectionMemAddr(CurrentSection);
        private int CurrentSectionSize => DOL.GetSectionSize(CurrentSection);

        public CodeEditor() {
            InitializeComponent();

            // double buffer
            PropertyInfo prop = GetType().GetProperty("DoubleBuffered",
              BindingFlags.Instance | BindingFlags.NonPublic);
            prop.SetValue(codeView, true, null);
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            // only first 7 sections can contain code (apparently)
            for (int i = 0; i < 7; i++) {
                if (DOL.SectionHasData(i))
                    sectionSelectDropdown.Items.Add($"Section {i}");
            }
            sectionSelectDropdown.SelectedIndex = 0;
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            Save();
        }

        private void Save() {
            DOL.Write();
        }

        private void GoTo(uint address) {
            int index = DOL.GetSectionIndex(address);
            sectionSelectDropdown.SelectedIndex = index;
            codeView.FirstDisplayedScrollingRowIndex = (int)(address - CurrentSectionAddress) / 4;
            codeView.Invalidate();
        }

        private bool IsAddressInbounds(uint address) {
            return DOL.IsAddrInBounds(address);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.Control | Keys.G:
                    var input = new HexInputDialog("Enter address:");
                    if (input.ShowDialog() == DialogResult.OK) {
                        uint addr = (uint)input.Response;
                        if (!IsAddressInbounds(addr))
                            new AlertDialog("Address out of bounds.").ShowDialog();
                        else
                            GoTo(addr);
                    }
                    return true;
                case Keys.Control | Keys.S:
                    Save();
                    return true;
                case Keys.Shift | Keys.Space:
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private uint RowToAddress(int row) {
            return CurrentSectionAddress + (uint)(4 * row);
        }

        private void SectionSelectDropdown_SelectedIndexChanged(object sender, EventArgs e) {
            int i = sectionSelectDropdown.SelectedIndex;
            Program.NotifyWaiting();
            codeView.Rows.Clear();
            if (i == 0 || i == 1) {
                codeView.AllowUserToAddRows = false;
                codeView.AllowUserToDeleteRows = false;
                codeView.RowCount = CurrentSectionSize / 4;
            } else {
                codeView.AllowUserToAddRows = true;
                codeView.AllowUserToDeleteRows = true;
                codeView.RowCount = CurrentSectionSize / 4 + 1;
            }
            codeView.Invalidate();
            Program.NotifyDone();
        }

        private void NewSectionButton_Click(object sender, EventArgs e) {
            var input = new InputDialog("Memory address:");
            if (input.ShowDialog() == DialogResult.OK) {
                try {
                    uint address = HexUtils.HexToUInt(input.Response);
                    int i = DOL.AddSection(address);
                    sectionSelectDropdown.Items.Insert(i, $"Section {i}");
                    sectionSelectDropdown.SelectedIndex = i;
                } catch (FormatException) {
                    var alert = new AlertDialog("Invalid address.");
                    alert.ShowDialog();
                }
            }
        }

        private void InsertInstructionMenuItem_Click(object sender, EventArgs e) {
            uint instruction = AssemblyUtils.Assemble("nop");
            DOL.InsertInstruction(RowToAddress(codeView.CurrentRow.Index), instruction);
        }

        private void DeleteInstructionMenuItem_Click(object sender, EventArgs e) {
            DOL.DeleteInstruction(RowToAddress(codeView.CurrentRow.Index));
        }

        private void CodeView_CellParsing(object sender, DataGridViewCellParsingEventArgs e) {
            if (e.ColumnIndex == 2) {
                DOL.Comments[RowToAddress(e.RowIndex)] = e.Value.ToString();
                return;
            }
            try {
                uint address = RowToAddress(e.RowIndex),
                    instruction = AssemblyUtils.Assemble(e.Value.ToString(), address);
                DOL.WriteInstruction(address, instruction);
            } catch {
                new AlertDialog("Invalid instruction.").ShowDialog();
            }
        }

        private void CodeView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            uint address = RowToAddress(e.RowIndex);
            if (!DOL.IsAddrInBounds(address))
                return;
            if (e.ColumnIndex == 0)
                e.Value = HexUtils.IntToHex(DOL.GetInstruction(address));
            else if (e.ColumnIndex == 1)
                e.Value = AssemblyUtils.Disassemble(DOL.GetInstruction(address), RowToAddress(e.RowIndex));
            else if (e.ColumnIndex == 2)
                e.Value = DOL.Comments.ContainsKey(address) ? DOL.Comments[address] : "";
        }

        private void CodeView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            // row headers
            if (e.ColumnIndex == -1 && e.RowIndex >= 0) {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.DrawString(
                    RowToAddress(e.RowIndex).ToString("X8"),
                    e.CellStyle.Font,
                    Brushes.Black,
                    new PointF(e.CellBounds.Left + 8, e.CellBounds.Top + 6));
                e.Handled = true;
            } else if (e.ColumnIndex == -1) {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.DrawString(
                    "Address",
                    e.CellStyle.Font,
                    Brushes.Black,
                    new PointF(e.CellBounds.Left + 12, e.CellBounds.Top + 4));
                e.Handled = true;
            }
        }

        private void CodeView_UserDeletedRow(object sender, DataGridViewRowEventArgs e) {
            DOL.DeleteInstruction(RowToAddress(e.Row.Index));
        }

        private void CodeView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                codeView.CurrentCell = codeView[e.ColumnIndex, e.RowIndex];
            if (e.Button == MouseButtons.Right)
                codeViewContextMenu.Show(MousePosition);
        }

        private void LoadButton_Click(object sender, EventArgs e) {
            var dialog = new ConfirmDialog("This will overwrite all data in the current section.\n" +
                "Are you sure you wish to continue?");
            if (dialog.ShowDialog() != DialogResult.Yes)
                return;
            //new AlertDialog( "This functionality is not currently implemented." ).ShowDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                Program.NotifyWaiting();
                codeView.FirstDisplayedScrollingRowIndex = 0;

                var bin = new FileBuffer(openFileDialog.FileName);
                DOL.OverwriteSection(CurrentSection, bin.GetBytes());
                codeView.RowCount = CurrentSectionSize / 4 + 1;
                codeView.Invalidate();
                Program.NotifyDone();
            }
        }
    }
}
