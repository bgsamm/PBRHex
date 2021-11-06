using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PBRTool.Dialogs;
using PBRTool.Events;
using PBRTool.Utils;
using PBRTool.Files;
using PBRTool.HexLabels;
using PBRTool.HexEditor.Commands;

/*
 * TODO:
 * -Implement "Find All" search command
 * -Detect file type from extension when adding from disk
 * -Undo/redo deleting + adding files (just need to figure out interacting with the ContainingArchive's edit history)
 * -Renumber filenames on delete
 * -Highlight full match when searching
 * -Select entire labels in data view (double click? click on number?)
 * -Visually convey whether a file has unsaved changes
 * -Implement 'Add row'
 * -Implement byte search as command?
 * -Have files track their own location and edit histories?
 * -Make ASCII view linked to Hex Grid, instead of sending it a new array of bytes everytime something changes
 */

namespace PBRTool.HexEditor
{
    public partial class HexEditorWindow : Form {
        public Tape<int> LocationHistory => CurrentFile.LocationHistory;
        public Tape<Command<HexEditorWindow>> EditHistory => CurrentFile.EditHistory;

        /// <summary>
        /// An array containing the files open in the editor.
        /// </summary>
        private readonly List<FileBuffer> Files;
        /// <summary>
        /// The currently selected file in FileSelect
        /// </summary>
        private FileBuffer CurrentFile => Files[fileSelectDropdown.SelectedIndex];
        private readonly FSYS ContainingArchive;

        public HexEditorWindow(FileBuffer[] files, FSYS archive = null) {
            InitializeComponent();
            Files = new List<FileBuffer>(files);
            ContainingArchive = archive;
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

            foreach(var file in Files) {
                if(file.SaveHead != file.EditHistory.Position) {
                    var confirm = new ConfirmDialog()
                    {
                        Message = "You have unsaved changes.\n" +
                        "Would you like to save before closing?"
                    };
                    var result = confirm.ShowDialog();
                    if(result == DialogResult.Yes)
                        ExecuteCommand(new SaveCommand(this));
                    else if(result != DialogResult.No)
                        e.Cancel = true;
                    return;
                }
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
            foreach(var label in CurrentFile.Labels) {
                labelsListBox.AddItem(label);
            }

            // load notes
            notesTextBox.Text = CurrentFile.Notes;

            RefreshHistoryButtons();
            RefreshUndoRedoButtons();
        }

        public void Write() {
            foreach(var file in Files) {
                file.Save();
            }

            if(ContainingArchive != null) {
                string path = FileUtils.CompressFSYS(ContainingArchive);
                FileUtils.MoveFile(path, ContainingArchive.Path);
            } else {
                FileUtils.WriteToISO(CurrentFile);
            }

            Console.WriteLine("Changes saved");
        }

        public void GoToAddress(int address) {
            hexGrid.GoTo(address);
        }

        public bool SearchHex(string hex, out int address, int start = 0, bool reverse = false) {
            Program.NotifyWaiting();
            var result = CurrentFile.Search(HexUtils.HexToBytes(hex), out address, start, reverse);
            Program.NotifyDone();
            return result;
        }

        public FileBuffer AddFile(string path) {
            var file = ContainingArchive.AddFile(path);
            Files.Add(file);
            fileSelectDropdown.Items.Add(file);
            fileSelectDropdown.SelectedIndex = fileSelectDropdown.Items.Count - 1;
            return file;
        }

        public void RemoveFile(FileBuffer file) {
            ContainingArchive.DeleteFile(file);
            int i = fileSelectDropdown.SelectedIndex;
            Files.RemoveAt(i);
            fileSelectDropdown.Items.RemoveAt(i);
            fileSelectDropdown.SelectedIndex = i < fileSelectDropdown.Items.Count ? i : i - 1;
        }

        public FileBuffer CreateFile() {
            var file = ContainingArchive.AddFile();
            Files.Add(file);
            fileSelectDropdown.Items.Add(file);
            fileSelectDropdown.SelectedIndex = fileSelectDropdown.Items.Count - 1;
            return file;
        }

        public HexLabel AddLabel(int address, int size, LabelType type, string name) {
            var label = CurrentFile.AddLabel(address, size, type, name);
            labelsListBox.AddItem(label);
            return label;
        }

        public HexLabel RemoveLabel(int address) {
            var label = CurrentFile.DeleteLabel(address);
            labelsListBox.RemoveItem(label);
            return label;
        }

        public void RenameLabel(HexLabel label, string name) {
            CurrentFile.RenameLabel(label.Address, name);
            labelsListBox.Invalidate();
        }

        public void InsertRange(int address, byte[] bytes) {
            CurrentFile.InsertRange(address, bytes);
            UpdateHexGrid();
            GoToAddress(address);
        }

        public byte[] DeleteRange(int address, int size) {
            var bytes = CurrentFile.DeleteRange(address, size);
            UpdateHexGrid();
            // handle deleting at EOF
            if(address / 16 == hexGrid.RowCount)
                address -= 16;
            GoToAddress(address);
            return bytes;
        }

        public void SetRange(int address, byte[] bytes) {
            CurrentFile.SetRange(address, bytes);
            hexGrid.Invalidate();
            asciiView.UpdateView(hexGrid.GetDisplayedBytes());
        }

        public byte[] GetRange(int address, int size) {
            return CurrentFile.GetRange(address, size);
        }

        public void RefreshHistoryButtons() {
            backArrow.Enabled = LocationHistory.HasPast();
            forwardArrow.Enabled = LocationHistory.HasFuture();
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

        public void ExecuteCommand(Command<HexEditorWindow> command) {
            if(command.Execute()) {
                EditHistory.Insert(command);
                RefreshUndoRedoButtons();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch(keyData) {
                case Keys.Control | Keys.F:
                    searchTextBox.Focus();
                    return true;
                case Keys.Control | Keys.G:
                    var input = new HexInputDialog() { Prompt = "Enter address:" };
                    if(input.ShowDialog() == DialogResult.OK)
                        try {
                            ExecuteCommand(new GoToCommand(this, input.Response));
                        } catch {
                            new AlertDialog() { Message = "Invalid input." }.Show();
                        }
                    return true;
                case Keys.Control | Keys.S:
                    ExecuteCommand(new SaveCommand(this));
                    return true;
                case Keys.Control | Keys.V:
                    if(hexGrid.Focused) {
                        ExecuteCommand(new PasteCommand(this));
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                case Keys.Control | Keys.Z:
                    if(hexGrid.Focused) {
                        ExecuteCommand(new UndoCommand(this));
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                case Keys.Control | Keys.Y:
                case Keys.Control | Keys.Shift | Keys.Z:
                    ExecuteCommand(new RedoCommand(this));
                    return true;

                // labels
                case Keys.Control | Keys.Alt | Keys.E:
                    ExecuteCommand(new AddLabelCommand(this, LabelType.Empty));
                    return true;
                case Keys.Control | Keys.Alt | Keys.P:
                    ExecuteCommand(new AddLabelCommand(this, LabelType.Pointer));
                    return true;
                case Keys.Control | Keys.Alt | Keys.I:
                    ExecuteCommand(new AddLabelCommand(this, LabelType.Int));
                    return true;
                case Keys.Control | Keys.Alt | Keys.F:
                    ExecuteCommand(new AddLabelCommand(this, LabelType.Float));
                    return true;
                case Keys.Control | Keys.Alt | Keys.S:
                    ExecuteCommand(new AddLabelCommand(this, LabelType.String));
                    return true;
                case Keys.Control | Keys.Alt | Keys.C:
                    ExecuteCommand(new AddLabelCommand(this, LabelType.Color));
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void SaveToFileButton_Click(object sender, EventArgs e) {
            ExecuteCommand(new SaveCommand(this));
        }

        private void FileSelectDropdown_SelectedIndexChanged(object sender, EventArgs e) {
            LoadSelectedFile();
        }

        private void HexView_Scroll(object sender, ScrollEventArgs e) {
            asciiView.UpdateView(hexGrid.GetDisplayedBytes());
        }

        private void BackArrowMenuItem_Click(object sender, EventArgs e) {
            GoToAddress(LocationHistory.MoveBackward());
            RefreshHistoryButtons();
        }

        private void ForwardArrowMenuItem_Click(object sender, EventArgs e) {
            GoToAddress(LocationHistory.MoveForward());
            RefreshHistoryButtons();
        }

        private void UndoMenuItem_Click(object sender, EventArgs e) {
            ExecuteCommand(new UndoCommand(this));
        }

        private void RedoMenuItem_Click(object sender, EventArgs e) {
            ExecuteCommand(new RedoCommand(this));
        }

        private void PreviousMatchButton_Click(object sender, EventArgs e) {
            int start = GetSelectionRange().X - 1;
            if(SearchHex(searchTextBox.Text, out int address, start, true))
                GoToAddress(address);
        }

        private void NextMatchButton_Click(object sender, EventArgs e) {
            int start = GetSelectionRange().X + 1;
            if(SearchHex(searchTextBox.Text, out int address, start))
                GoToAddress(address);
        }

        private void AddFileMenuItem_Click(object sender, EventArgs e) {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
                ExecuteCommand(new AddFileCommand(this, openFileDialog.FileName));
        }

        private void NewFileMenuItem_Click(object sender, EventArgs e) {
            var confirm = new ConfirmDialog() { Message = "Add a new file to the archive?" };
            if(confirm.ShowDialog() == DialogResult.Yes)
                ExecuteCommand(new CreateFileCommand(this));
        }

        private void DeleteFileMenuItem_Click(object sender, EventArgs e) {
            if(ContainingArchive.Files.Count == 1) {
                new AlertDialog() { Message = "Cannot delete only file in the archive." }.ShowDialog();
                return;
            }
            var confirm = new ConfirmDialog() { Message = "Delete the current file from the archive?" };
            if(confirm.ShowDialog() == DialogResult.Yes)
                ExecuteCommand(new RemoveFileCommand(this, CurrentFile));
        }

        private void NotesBox_TextChanged(object sender, EventArgs e) {
            CurrentFile.Notes = notesTextBox.Text;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e) {
            searchTextBox.TextChanged -= SearchBox_TextChanged;
            searchTextBox.Text = searchTextBox.Text.ToUpper();
            searchTextBox.Text = Regex.Replace(searchTextBox.Text, @"[^A-F\d]", "");
            searchTextBox.TextChanged += SearchBox_TextChanged;

            if(searchTextBox.Text.Length > 0 && SearchHex(searchTextBox.Text, out int address)) {
                searchTextBox.ForeColor = Color.Black;
                GoToAddress(address);
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

        //private void HexGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
        //    if(e.ColumnIndex >= 0 && e.RowIndex >= 0 && !hexGrid[e.ColumnIndex, e.RowIndex].Selected)
        //        hexGrid.SelectCell(e.ColumnIndex, e.RowIndex);
        //    if(e.Button == MouseButtons.Right)
        //        hexGridContextMenu.Show(MousePosition);
        //}

        // Right clicking does not fire MouseClick, so use MouseUp
        //private void LabelsListBox_MouseUp(object sender, MouseEventArgs e) {
        //    int index = labelsListBox.IndexFromPoint(e.Location);
        //    if(e.Button == MouseButtons.Right && index >= 0) {
        //        // right-clicks do not select so need to do it manually
        //        labelsListBox.SelectedIndex = index;
        //        var label = (HexLabel)labelsListBox.Items[index];
        //        goToAddressMenuItem.Visible = label.Type == LabelType.Pointer;
        //        labelsListContextMenu.Show(MousePosition);
        //    }
        //}

        private void LabelsListBox_MouseMove(object sender, MouseEventArgs e) {
            int i = labelsListBox.IndexFromPoint(e.Location);
            // the '+ 20' is totally hard-coded, not sure where it comes from, margins maybe? Scroll bar?
            if(i >= 0 && labelsListBox.MeasureLabel(i).Width + 20 > labelsListBox.Width) {
                toolTip.SetToolTip(labelsListBox, labelsListBox.Items[i].ToString());
                toolTip.Active = true;
            }
            else
                toolTip.Active = false;
        }

        private void GoToAddressMenuItem_Click(object sender, EventArgs e) {
            var alert = new AlertDialog() { Message = "Invalid selection." };
            if(!hexGrid.IsSelectionContiguous()) {
                alert.Show();
                return;
            }
            int address;
            try {
                address = HexUtils.BytesToInt(hexGrid.GetSelectedBytes());
            } catch {
                alert.Show();
                return;
            }
            ExecuteCommand(new GoToCommand(this, address));
        }

        private void AddLabelMenuItem_Click(object sender, EventArgs e) {
            var type = (LabelType)Enum.Parse(typeof(LabelType), sender.ToString());
            ExecuteCommand(new AddLabelCommand(this, type));
        }

        private void DeleteLabelMenuItem_Click(object sender, EventArgs e) {
            int address = ((HexLabel)labelsListBox.SelectedItem).Address;
            ExecuteCommand(new RemoveLabelCommand(this, address));
        }

        private void InsertRangeMenuItem_Click(object sender, EventArgs e) {
            if(!IsSelectionContiguous()) {
                new AlertDialog() { Message = "Invalid selection." }.ShowDialog();
                return;
            }
            int address = GetSelectionRange().X,
                size = GetSelection().Length;
            ExecuteCommand(new InsertRangeCommand(this, address, size));
        }

        private void DeleteRangeMenuItem_Click(object sender, EventArgs e) {
            ExecuteCommand(new DeleteRangeCommand(this));
        }

        private void FillRangeMenuItem_Click(object sender, EventArgs e) {
            ExecuteCommand(new FillRangeCommand(this));
        }

        private void HexGrid_CellEdited(object sender, CellEditEventArgs e) {
            if(e.Address > CurrentFile.Size - 1) {
                int size = e.Address - CurrentFile.Size + 1;
                ExecuteCommand(new InsertRangeCommand(this, CurrentFile.Size, size));
            }
            ExecuteCommand(new SetRangeCommand(this, e.Address, new byte[] { e.Value }));
        }

        private void GoToLabelMenuItem_Click(object sender, EventArgs e) {
            var label = (HexLabel)labelsListBox.SelectedItem;
            ExecuteCommand(new GoToCommand(this, label.Address));
        }

        private void LabelsListBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Left)
                ExecuteCommand(new GoToCommand(this, ((HexLabel)labelsListBox.SelectedItem).Address));
        }

        private void GoToAddressMenuItem1_Click(object sender, EventArgs e) {
            var label = (HexLabel)labelsListBox.SelectedItem;
            int address = HexUtils.BytesToInt(CurrentFile.GetRange(label.Address, label.Size));
            ExecuteCommand(new GoToCommand(this, address));
        }

        private void RenameLabelMenuItem_Click(object sender, EventArgs e) {
            var label = (HexLabel)labelsListBox.SelectedItem;
            ExecuteCommand(new RenameLabelCommand(this, label));
        }
    }
}