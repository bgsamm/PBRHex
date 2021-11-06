using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security;
using System.Windows.Forms;
using PBRHex.Dialogs;
using PBRHex.Files;
using PBRHex.Utils;

namespace PBRHex.CodeEditor
{
    public partial class CodeEditorWindow : Form
    {
        private int CurrentSection => sectionSelectDropdown.SelectedIndex;
        private uint CurrentSectionAddress => DOL.GetSectionMemAddr(CurrentSection);
        private int CurrentSectionSize => DOL.GetSectionSize(CurrentSection);

        public CodeEditorWindow() {
            InitializeComponent();

            // double buffer
            PropertyInfo prop = GetType().GetProperty("DoubleBuffered",
              BindingFlags.Instance | BindingFlags.NonPublic);
            prop.SetValue(codeView, true, null);
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            // only first 7 sections can contain code (apparently)
            for(int i = 0; i < 7; i++) {
                if(DOL.SectionHasData(i))
                    sectionSelectDropdown.Items.Add($"Section {i}");
            }
            sectionSelectDropdown.SelectedIndex = 0;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch(keyData) {
                case Keys.Control | Keys.G:
                    var input = new InputDialog() { Prompt = "Enter address:" };
                    if(input.ShowDialog() == DialogResult.OK)
                        GoTo(input.Response);
                    return true;
                case Keys.Control | Keys.S:
                    DOL.Write();
                    return true;
                //case Keys.Control | Keys.Z:
                //    CurrentFile.Undo();
                //    return true;
                //case Keys.Control | Keys.Y:
                //case Keys.Control | Keys.Shift | Keys.Z:
                //    CurrentFile.Redo();
                //    return true;
                case Keys.Shift | Keys.Space:
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private uint RowToAddress(int row) {
            return CurrentSectionAddress + (uint)(4 * row);
        }

        private void GoTo(string hex) {
            try {
                uint address = HexUtils.HexToUInt(hex);
                codeView.FirstDisplayedScrollingRowIndex = (int)(address - CurrentSectionAddress) / 4;
                codeView.Invalidate();
            }
            catch(FormatException) {
                var alert = new AlertDialog()
                {
                    Message = "Invalid address."
                };
                alert.ShowDialog();
            }
            catch(ArgumentOutOfRangeException) {
                var alert = new AlertDialog()
                {
                    Message = "Address out of bounds."
                };
                alert.ShowDialog();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);

            var confirm = new ConfirmDialog()
            {
                Message = "You have unsaved changes.\n" +
                "Would you like to save before closing?"
            };
            var result = confirm.ShowDialog();
            if(result == DialogResult.Yes)
                DOL.Write();
            else if(result != DialogResult.No)
                e.Cancel = true;
            return;
        }

        private void SectionSelectDropdown_SelectedIndexChanged(object sender, EventArgs e) {
            int i = sectionSelectDropdown.SelectedIndex;
            Program.NotifyWaiting();
            codeView.Rows.Clear();
            if(i == 0 || i == 1) {
                codeView.AllowUserToAddRows = false;
                codeView.AllowUserToDeleteRows = false;
                codeView.RowCount = CurrentSectionSize / 4;
            }
            else {
                codeView.AllowUserToAddRows = true;
                codeView.AllowUserToDeleteRows = true;
                codeView.RowCount = CurrentSectionSize / 4 + 1;
            }
            codeView.Invalidate();
            Program.NotifyDone();
        }

        private void NewSectionButton_Click(object sender, EventArgs e) {
            var input = new InputDialog()
            {
                Prompt = "Memory address:"
            };
            if(input.ShowDialog() == DialogResult.OK) {
                try {
                    uint address = HexUtils.HexToUInt(input.Response);
                    int i = DOL.AddSection(address);
                    sectionSelectDropdown.Items.Insert(i, $"Section {i}");
                    sectionSelectDropdown.SelectedIndex = i;
                }
                catch(FormatException) {
                    var alert = new AlertDialog()
                    {
                        Message = "Invalid address."
                    };
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
            if(e.ColumnIndex == 2) {
                DOL.Comments[RowToAddress(e.RowIndex)] = e.Value.ToString();
                return;
            }
            try {
                uint address = RowToAddress(e.RowIndex),
                    instruction = AssemblyUtils.Assemble(e.Value.ToString(), address);
                DOL.WriteInstruction(address, instruction);
            }
            catch {
                new AlertDialog() { Message = "Invalid instruction." }.ShowDialog();
            }
        }

        private void CodeView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            uint address = RowToAddress(e.RowIndex);
            if(!DOL.IsAddrInBounds(address)) 
                return;
            if(e.ColumnIndex == 0) {
                string asm = codeView[e.ColumnIndex + 1, e.RowIndex].Value.ToString();
                e.Value = HexUtils.IntToHex(AssemblyUtils.Assemble(asm, RowToAddress(e.RowIndex)));
            }
            else if(e.ColumnIndex == 1) {
                e.Value = AssemblyUtils.Disassemble(DOL.GetInstruction(address), RowToAddress(e.RowIndex));
            }
            else if(e.ColumnIndex == 2) {
                if(DOL.Comments.ContainsKey(address))
                    e.Value = DOL.Comments[address];
                else
                    e.Value = "";
            }
        }

        private void CodeView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            // row headers
            if(e.ColumnIndex == -1 && e.RowIndex >= 0) {
                e.PaintBackground(e.CellBounds, true);
                e.Graphics.DrawString(
                    RowToAddress(e.RowIndex).ToString("X8"), 
                    e.CellStyle.Font,
                    Brushes.Black,
                    new PointF(e.CellBounds.Left + 8, e.CellBounds.Top + 6));
                e.Handled = true;
            }
            else if(e.ColumnIndex == -1) {
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
            if(e.ColumnIndex >= 0 && e.RowIndex >= 0)
                codeView.CurrentCell = codeView[e.ColumnIndex, e.RowIndex];
            if(e.Button == MouseButtons.Right)
                codeViewContextMenu.Show(MousePosition);
        }

        private void LoadButton_Click(object sender, EventArgs e) {
            new AlertDialog() { Message = "This functionality is not currently implemented." }.ShowDialog();
            //if(openFileDialog.ShowDialog() == DialogResult.OK) {
            //    try {
            //        Program.NotifyWaiting();
            //        codeView.FirstDisplayedScrollingRowIndex = 0;

            //        var lines = File.ReadAllLines(openFileDialog.FileName);
            //        // Delete existing section
            //        DOL.DeleteRange(CurrentSection.Item1, CurrentSection.Item2);

            //        for(int i = 0; i < lines.Length; i++) {
            //            uint op = AssemblyUtils.Assemble(lines[i], CurrentSectionAddress + (uint)i * 4);
            //            DOL.InsertRange(CurrentSection.Item1 + i * 4, HexUtils.IntToBytes(op));
            //        }
            //        Program.NotifyDone();
            //    }
            //    catch(SecurityException ex) {
            //        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
            //        $"Details:\n\n{ex.StackTrace}");
            //    }
            //}
        }
    }
}
