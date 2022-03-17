using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PBRHex.Commands.FileCommands;
using PBRHex.Commands.FsysCommands;
using PBRHex.Dialogs;
using PBRHex.Events;
using PBRHex.Files;
using PBRHex.HexLabels;
using PBRHex.Tables;
using PBRHex.Utils;

/*
 * TODO:
 * -Implement "Find All" search command
 * -Undo/redo deleting + adding files (just need to figure out interacting with the ContainingArchive's edit history)
 * -Renumber filenames on delete
 * -Highlight full match when searching
 * -Select entire labels in data view (double click? click on number?)
 * -Visually convey whether a file has unsaved changes
 * -Implement 'Add row'
 * -Make ASCII view linked to Hex Grid, instead of sending it a new array of bytes everytime something changes
 */

namespace PBRHex.HexEditor
{
    public partial class HexEditorWindow : Form, IFileEditor, IFsysEditor
    {
        public Tape<int> LocationHistory => CurrentFile.LocationHistory;
        public Tape<Command> EditHistory => CurrentFile.EditHistory;

        /// <summary>
        /// An array containing the files open in the editor.
        /// </summary>
        private readonly List<FileBuffer> Files;
        /// <summary>
        /// The currently selected file in FileSelect
        /// </summary>
        private FileBuffer CurrentFile => Files[fileSelectDropdown.SelectedIndex];
        private FSYS ContainingArchive => ArchiveName != null ? FSYSTable.GetFile(ArchiveName) : null;
        private readonly string ArchiveName;

        public HexEditorWindow(FileBuffer[] files) {
            InitializeComponent();
            Files = new List<FileBuffer>(files);
            ArchiveName = files[0].ContainingArchive;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            // populate file select dropdown
            fileSelectDropdown.Items.AddRange(Files.ToArray());
            // select first file
            fileSelectDropdown.SelectedIndex = 0;

            openFileMenuItem.Enabled = ContainingArchive != null;
            newFileMenuItem.Enabled = ContainingArchive != null;
            deleteFileMenuItem.Enabled = ContainingArchive != null;
            hexGrid.Select();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);

            foreach (var file in Files) {
                if (file.SaveHead != file.EditHistory.Position) {
                    var confirm = new ConfirmDialog(
                        "You have unsaved changes.\n" +
                        "Would you like to save before closing?"
                    );
                    var result = confirm.ShowDialog();
                    if (result == DialogResult.Yes)
                        Save();
                    else if (result != DialogResult.No)
                        e.Cancel = true;
                    if (ContainingArchive != null)
                        FSYSTable.CloseFile(ContainingArchive.Name);
                    return;
                }
            }
        }

        public void ExecuteCommand(Command command) {
            if (command.Execute()) {
                EditHistory.Insert(command);
                RefreshUndoRedoButtons();
            }
        }

        private void Save() {
            foreach (var file in Files) {
                file.Save();
            }
            if (ContainingArchive != null)
                FSYSTable.WriteFile(ContainingArchive.Name);
            else
                FileUtils.WriteToISO(CurrentFile);
            Console.WriteLine("Changes saved");
        }

        private void Undo() {
            if (EditHistory.HasPast()) {
                EditHistory.GetCurrent().Undo();
                EditHistory.MoveBackward();
                RefreshUndoRedoButtons();
            }
        }

        private void Redo() {
            if (EditHistory.HasFuture()) {
                EditHistory.MoveForward().Redo();
                RefreshUndoRedoButtons();
            }
        }

        private void LoadSelectedFile() {
            // update hex view
            hexGrid.File = CurrentFile;
            hexGrid.ColumnCount = 16;
            UpdateHexGrid();

            // update ascii view
            asciiView.UpdateView(hexGrid.GetDisplayedBytes());

            // load labels list
            labelsListBox.Items.Clear();
            foreach (var label in CurrentFile.Labels) {
                labelsListBox.AddItem(label);
            }

            // load notes
            notesTextBox.Text = CurrentFile.Notes;

            RefreshHistoryButtons();
            RefreshUndoRedoButtons();
        }

        public void GoTo(int address, bool record = false) {
            if (!IsAddressInbounds(address))
                new AlertDialog("Address out of bounds.").ShowDialog();
            else
                hexGrid.GoTo(address);

            if (record) {
                LocationHistory.Insert(address);
                RefreshHistoryButtons();
            }
        }

        public bool SearchHex(string hex, out int address, int start = 0, bool reverse = false) {
            Program.NotifyWaiting();
            var result = CurrentFile.Search(HexUtils.HexToBytes(hex), out address, start, reverse);
            Program.NotifyDone();
            return result;
        }

        // is this the best implementation? I don't know. But it works :) (mostly; see catch)
        public void Paste() {
            try {
                string data = Clipboard.GetText();
                var rows = data.Split(new char[] { '\n' });
                int address = GetSelectionRange().X;
                // copying pads to fit a rectangle, so need to figure out
                // where data actually starts and ends
                int first;
                var firstRow = rows[0].Split(new char[] { '\t' });
                for (first = 0; first < firstRow.Length; first++) {
                    if (firstRow[first].Length > 0)
                        break;
                }
                int last = 0;
                var lastRow = rows.Last().Split(new char[] { '\t' });
                for (int i = 0; i < lastRow.Length; i++) {
                    if (lastRow[i].Length > 0)
                        last = i;
                }

                var temp = new List<byte>();
                for (int r = 0; r < rows.Length; r++) {
                    int offset = address + r * 16 - first;
                    var vals = rows[r].Split(new char[] { '\t' });
                    for (int c = 0; c < vals.Length; c++) {
                        if ((r == 0 && c < first) || (r == rows.Length - 1 && c > last))
                            continue;
                        if (vals[c].Trim().Length > 0)
                            temp.Add(Convert.ToByte(vals[c].Trim(), 16));
                        else
                            temp.Add(GetRange(offset + c, 1)[0]);
                        // fill in gaps with pre-existing values
                        if (vals[c].EndsWith("\r"))
                            temp.AddRange(GetRange(offset + c + 1, 15 - c));
                    }
                }
                ExecuteCommand(new SetRangeCommand(this, CurrentFile, address, temp.ToArray()));
            }
            catch {
                // main points of failure are a) trying to paste invalid hex,
                // or b) trying to paste past the end of the file
            }
        }

        public void AddFile(FileBuffer file) {
            Files.Add(file);
            fileSelectDropdown.Items.Add(file);
            fileSelectDropdown.SelectedIndex = fileSelectDropdown.Items.Count - 1;
        }

        public void ReplaceFile(FileBuffer oldFile, FileBuffer newFile) {
            int i = fileSelectDropdown.Items.IndexOf(oldFile);
            Files[i] = newFile;
            fileSelectDropdown.Items[i] = newFile;
            fileSelectDropdown.SelectedIndex = i;
            hexGrid.Invalidate();
        }

        public void RemoveFile(FileBuffer file) {
            int i = fileSelectDropdown.Items.IndexOf(file);
            Files.RemoveAt(i);
            fileSelectDropdown.Items.RemoveAt(i);
            fileSelectDropdown.SelectedIndex = i < fileSelectDropdown.Items.Count ? i : i - 1;
        }

        public void AddLabel(HexLabel label) {
            labelsListBox.AddItem(label);
            labelsListBox.Invalidate();
            hexGrid.Invalidate();
        }

        public void RemoveLabel(HexLabel label) {
            labelsListBox.RemoveItem(label);
            labelsListBox.Invalidate();
            hexGrid.Invalidate();
        }

        public void RenameLabel(HexLabel label, string name) {
            labelsListBox.Invalidate();
        }

        public void InsertRange(int address, byte[] bytes) {
            UpdateHexGrid();
            hexGrid.SelectCell(address);
            //GoTo(address);
        }

        public void DeleteRange(int address, int size) {
            UpdateHexGrid();
            // handle deleting at EOF
            if (address / 16 == hexGrid.RowCount)
                address -= 16;
            hexGrid.SelectCell(address);
            //GoTo(address);
        }

        public void SetRange(int address, byte[] bytes) {
            hexGrid.Invalidate();
            asciiView.UpdateView(hexGrid.GetDisplayedBytes());
        }

        public byte[] GetRange(int address, int size) {
            return CurrentFile.GetRange(address, size);
        }

        public void RefreshHistoryButtons() {
            backArrowMenuItem.Enabled = LocationHistory.HasPast();
            forwardArrowMenuItem.Enabled = LocationHistory.HasFuture();
        }

        public void RefreshUndoRedoButtons() {
            undoMenuItem.Enabled = EditHistory.HasPast();
            redoMenuItem.Enabled = EditHistory.HasFuture();
        }

        public void UpdateHexGrid() {
            hexGrid.RowCount = 0;
            hexGrid.RowCount = CurrentFile.Size / 16 + 1;
            hexGrid.Invalidate();
            // not sure that this entirely belongs in here, but generally speaking,
            // if the hex grid needs to be invalidated, the ascii view needs to be updated
            asciiView.UpdateView(hexGrid.GetDisplayedBytes());
        }

        public Point GetSelectionRange() {
            return new Point(hexGrid.GetAddress(hexGrid.FirstSelectedCell), hexGrid.GetAddress(hexGrid.LastSelectedCell));
        }

        public byte[] GetSelection() {
            return hexGrid.GetSelectedBytes();
        }

        public bool IsAddressInbounds(int address) {
            return address / 16 < hexGrid.Rows.Count;
        }

        public bool IsAddressLabeled(int address) {
            return CurrentFile.Labels.ContainsAddress(address);
        }

        public bool IsCellSelected(int address) {
            return hexGrid[address % 16, address / 16].Selected;
        }

        public bool IsSelectionContiguous() {
            return hexGrid.IsSelectionContiguous();
        }

        private bool PromptAddLabel(LabelType type, out string name) {
            name = "";
            if (!IsSelectionContiguous()) {
                new AlertDialog("Invalid selection.").ShowDialog();
                return false;
            }
            int address = GetSelectionRange().X;
            if (IsAddressLabeled(address)) {
                new AlertDialog("A label already exists at this address.").ShowDialog();
                return false;
            }
            var input = new InputDialog("Label name:");

            byte[] selection = GetSelection();
            if (type == LabelType.Float && selection.Length == 4)
                input.Default = HexUtils.BytesToFloat(selection).ToString();
            else
                input.Default = $"0x{address:X8}";

            if (input.ShowDialog() == DialogResult.OK) {
                name = input.Response;
                return true;
            }
            return false;
        }

        private bool PromptRenameLabel(HexLabel label, out string name) {
            name = "";
            var input = new InputDialog("Enter label name")
            {
                Default = label.Name
            };
            if (input.ShowDialog() == DialogResult.OK) {
                name = input.Response;
                return true;
            }
            return false;
        }

        private bool PromptFillRange(out byte[] bytes) {
            bytes = new byte[0];
            var selectionRange = GetSelectionRange();
            if (selectionRange.Y >= CurrentFile.Size) {
                new AlertDialog("Invalid selection.").ShowDialog();
                return false;
            }
            var input = new HexInputDialog("Fill value:")
            {
                Default = "00"
            };
            if (input.ShowDialog() == DialogResult.OK && input.Response != null) {
                int value = (int)input.Response;
                if (value < 0 || value > 0xff) {
                    new AlertDialog("Invalid fill value.").ShowDialog();
                    return false;
                }
                Program.NotifyWaiting();
                int size = selectionRange.Y - selectionRange.X + 1,
                    address = GetSelectionRange().X;
                var range = GetRange(address, size);
                bytes = new byte[size];
                for (int i = 0; i < size; i++) {
                    if (IsCellSelected(address + i))
                        bytes[i] = (byte)value;
                    else
                        bytes[i] = range[i];
                }
                Program.NotifyDone();
                return true;
            }
            return false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.Control | Keys.F:
                    searchTextBox.Focus();
                    return true;
                case Keys.Control | Keys.G:
                    var input = new HexInputDialog("Enter address:");
                    if (input.ShowDialog() == DialogResult.OK && input.Response != null) {
                        int address = (int)input.Response;
                        GoTo(address, true);
                    }
                    return true;
                case Keys.Control | Keys.S:
                    Save();
                    return true;
                case Keys.Control | Keys.V:
                    if (hexGrid.Focused) {
                        Paste();
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                case Keys.Control | Keys.Z:
                    if (hexGrid.Focused) {
                        Undo();
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                case Keys.Control | Keys.Y:
                case Keys.Control | Keys.Shift | Keys.Z:
                    if (hexGrid.Focused) {
                        Redo();
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);

                // labels
                case Keys.Control | Keys.Alt | Keys.E:
                case Keys.Control | Keys.Alt | Keys.P:
                case Keys.Control | Keys.Alt | Keys.I:
                case Keys.Control | Keys.Alt | Keys.F:
                case Keys.Control | Keys.Alt | Keys.S:
                case Keys.Control | Keys.Alt | Keys.C:
                    LabelType type = LabelType.None;
                    if (keyData.HasFlag(Keys.E))
                        type = LabelType.Empty;
                    else if (keyData.HasFlag(Keys.P))
                        type = LabelType.Pointer;
                    else if (keyData.HasFlag(Keys.I))
                        type = LabelType.Int;
                    else if (keyData.HasFlag(Keys.F))
                        type = LabelType.Float;
                    else if (keyData.HasFlag(Keys.S))
                        type = LabelType.String;
                    else if (keyData.HasFlag(Keys.C))
                        type = LabelType.Color;
                    if (PromptAddLabel(type, out string name)) {
                        int address = GetSelectionRange().X,
                            size = GetSelection().Length;
                        var label = new HexLabel(address, size, type, name);
                        ExecuteCommand(new AddLabelCommand(this, CurrentFile, label));
                    }
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void SaveToFileButton_Click(object sender, EventArgs e) {
            Save();
        }

        private void FileSelectDropdown_SelectedIndexChanged(object sender, EventArgs e) {
            LoadSelectedFile();
        }

        private void HexView_Scroll(object sender, ScrollEventArgs e) {
            asciiView.UpdateView(hexGrid.GetDisplayedBytes());
        }

        private void BackArrowMenuItem_Click(object sender, EventArgs e) {
            if (LocationHistory.HasPast()) {
                GoTo(LocationHistory.MoveBackward());
                RefreshHistoryButtons();
            }
        }

        private void ForwardArrowMenuItem_Click(object sender, EventArgs e) {
            if (LocationHistory.HasFuture()) {
                GoTo(LocationHistory.MoveForward());
                RefreshHistoryButtons();
            }
        }

        private void UndoMenuItem_Click(object sender, EventArgs e) {
            Undo();
        }

        private void RedoMenuItem_Click(object sender, EventArgs e) {
            Redo();
        }

        private void PreviousMatchButton_Click(object sender, EventArgs e) {
            int start = GetSelectionRange().X - 1;
            if (SearchHex(searchTextBox.Text, out int address, start, true))
                GoTo(address);
        }

        private void NextMatchButton_Click(object sender, EventArgs e) {
            int start = GetSelectionRange().X + 1;
            if (SearchHex(searchTextBox.Text, out int address, start))
                GoTo(address);
        }

        private void OpenFileMenuItem_Click(object sender, EventArgs e) {
            var dialog = new ConfirmDialog("This will replace the contents of the current file. Are you sure you wish to continue?");
            if (dialog.ShowDialog() == DialogResult.Yes) {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    ExecuteCommand(new ReplaceFileCommand(this, ContainingArchive, CurrentFile, openFileDialog.FileName));
            }
        }

        private void NewFileMenuItem_Click(object sender, EventArgs e) {
            var confirm = new ConfirmDialog("Add a new file to the archive?");
            if (confirm.ShowDialog() == DialogResult.Yes)
                ExecuteCommand(new CreateFileCommand(this, ContainingArchive));
        }

        private void DeleteFileMenuItem_Click(object sender, EventArgs e) {
            if (ContainingArchive.Files.Count == 1) {
                new AlertDialog("Cannot delete only file in the archive.").ShowDialog();
                return;
            }
            var confirm = new ConfirmDialog("Delete the current file from the archive?");
            if (confirm.ShowDialog() == DialogResult.Yes)
                ExecuteCommand(new RemoveFileCommand(this, ContainingArchive, CurrentFile));
        }

        private void NotesBox_TextChanged(object sender, EventArgs e) {
            CurrentFile.Notes = notesTextBox.Text;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e) {
            searchTextBox.TextChanged -= SearchBox_TextChanged;
            searchTextBox.Text = searchTextBox.Text.ToUpper();
            searchTextBox.Text = Regex.Replace(searchTextBox.Text, @"[^A-F\d]", "");
            searchTextBox.TextChanged += SearchBox_TextChanged;

            if (searchTextBox.Text.Length > 0 && SearchHex(searchTextBox.Text, out int address)) {
                searchTextBox.ForeColor = Color.Black;
                GoTo(address);
                //ExecuteCommand(new GoToCommand(this, address));
                previousMatchButton.Enabled = true;
                nextMatchButton.Enabled = true;
            }
            else {
                searchTextBox.ForeColor = Color.Red;
                previousMatchButton.Enabled = false;
                nextMatchButton.Enabled = false;
            }

            searchTextBox.Focus();
            searchTextBox.SelectionStart = searchTextBox.Text.Length;
        }

        //private void HexGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) {
        //    if(e.ColumnIndex >= 0 && e.RowIndex >= 0 && !hexGrid[e.ColumnIndex, e.RowIndex].Selected)
        //        hexGrid.SelectCell(e.RowIndex, e.ColumnIndex);
        //}

        // Right-clicks do not select so need to do it manually
        // Right-clicking does not fire MouseClick, so use MouseUp
        private void LabelsListBox_MouseUp(object sender, MouseEventArgs e) {
            int index = labelsListBox.IndexFromPoint(e.Location);
            if (e.Button == MouseButtons.Right && index >= 0)
                labelsListBox.SelectedIndex = index;
        }

        private void LabelsListBox_MouseMove(object sender, MouseEventArgs e) {
            int i = labelsListBox.IndexFromPoint(e.Location);
            // the '+ 20' is totally hard-coded, not sure where it comes from, margins maybe? Scroll bar?
            if (i >= 0 && labelsListBox.MeasureLabel(i).Width + 20 > labelsListBox.Width) {
                toolTip.SetToolTip(labelsListBox, labelsListBox.Items[i].ToString());
                toolTip.Active = true;
            }
            else
                toolTip.Active = false;
        }

        private void GoToAddressMenuItem_Click(object sender, EventArgs e) {
            var alert = new AlertDialog("Invalid selection.");
            if (!hexGrid.IsSelectionContiguous()) {
                alert.Show();
                return;
            }
            int address;
            try {
                address = HexUtils.BytesToInt(hexGrid.GetSelectedBytes());
            }
            catch {
                alert.Show();
                return;
            }
            GoTo(address, true);
        }

        private void AddLabelMenuItem_Click(object sender, EventArgs e) {
            var type = (LabelType)Enum.Parse(typeof(LabelType), sender.ToString());
            if (PromptAddLabel(type, out string name)) {
                int address = GetSelectionRange().X,
                    size = GetSelection().Length;
                var label = new HexLabel(address, size, type, name);
                ExecuteCommand(new AddLabelCommand(this, CurrentFile, label));
            }
        }

        private void RemoveLabelMenuItem_Click(object sender, EventArgs e) {
            var label = (HexLabel)labelsListBox.SelectedItem;
            ExecuteCommand(new RemoveLabelCommand(this, CurrentFile, label));
        }

        private void InsertRangeMenuItem_Click(object sender, EventArgs e) {
            var selectionRange = GetSelectionRange();
            if (!IsSelectionContiguous() || selectionRange.Y >= CurrentFile.Size) {
                new AlertDialog("Invalid selection.").ShowDialog();
                return;
            }
            int address = selectionRange.X,
                size = GetSelection().Length;
            ExecuteCommand(new InsertRangeCommand(this, CurrentFile, address, size));
        }

        private void DeleteRangeMenuItem_Click(object sender, EventArgs e) {
            var selectionRange = GetSelectionRange();
            if (!IsSelectionContiguous() || selectionRange.Y >= CurrentFile.Size) {
                new AlertDialog("Invalid selection.").ShowDialog();
                return;
            }
            int address = selectionRange.X,
                size = GetSelection().Length;
            ExecuteCommand(new DeleteRangeCommand(this, CurrentFile, address, size));
        }

        private void FillRangeMenuItem_Click(object sender, EventArgs e) {
            if (PromptFillRange(out byte[] bytes)) {
                int address = GetSelectionRange().X;
                ExecuteCommand(new SetRangeCommand(this, CurrentFile, address, bytes));
            }
        }

        private void HexGrid_CellEdited(object sender, CellEditEventArgs e) {
            if (e.Address > CurrentFile.Size - 1) {
                int size = e.Address - CurrentFile.Size + 1;
                ExecuteCommand(new InsertRangeCommand(this, CurrentFile, CurrentFile.Size, size));
            }
            ExecuteCommand(new SetRangeCommand(this, CurrentFile, e.Address, new byte[] { e.Value }));
        }

        private void GoToLabelMenuItem_Click(object sender, EventArgs e) {
            var label = (HexLabel)labelsListBox.SelectedItem;
            GoTo(label.Address, true);
        }

        private void LabelsListBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            var label = (HexLabel)labelsListBox.SelectedItem;
            if (e.Button == MouseButtons.Left)
                GoTo(label.Address, true);
        }

        private void GoToAddressMenuItem1_Click(object sender, EventArgs e) {
            var label = (HexLabel)labelsListBox.SelectedItem;
            int address = HexUtils.BytesToInt(CurrentFile.GetRange(label.Address, label.Size));
            GoTo(address, true);
        }

        private void RenameLabelMenuItem_Click(object sender, EventArgs e) {
            var label = (HexLabel)labelsListBox.SelectedItem;
            if (PromptRenameLabel(label, out string name))
                ExecuteCommand(new RenameLabelCommand(this, CurrentFile, label, name));
        }
    }
}