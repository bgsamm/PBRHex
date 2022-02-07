using System;
using System.Windows.Forms;
using PBRHex.Commands.StringCommands;
using PBRHex.Dialogs;
using PBRHex.Tables;
using PBRHex.Utils;

/*
 * TODO:
 * -Enable undo/redo for Add String
 * -Add search functionality
 * -Allow discarding of unsaved changes when closing
 */

namespace PBRHex
{
    public partial class StringEditor : Form, IStringEditor
    {
        public readonly Tape<Command> EditHistory;
        public int LastSavePosition;

        private int CurrentIndex => stringTableGridView.CurrentCell.RowIndex + 1;

        private bool IgnoreEvent;

        public StringEditor() {
            InitializeComponent();

            EditHistory = new Tape<Command>();
            EditHistory.Insert(null);
            LastSavePosition = 0;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            stringTableGridView.RowCount = StringTable.Count + 1;
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);

            if(LastSavePosition != EditHistory.Position)
                Save();
        }

        private void ExecuteCommand(Command command) {
            if(command.Execute()) {
                EditHistory.Insert(command);
                RefreshUndoRedoButtons();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch(keyData) {
                case Keys.Control | Keys.G:
                    var input = new HexInputDialog("Enter string ID:");
                    if(input.ShowDialog() == DialogResult.OK && input.Response != null)
                        GoTo((int)input.Response);
                    return true;
                case Keys.Control | Keys.S:
                    Save();
                    return true;
                case Keys.Control | Keys.Z:
                    Undo();
                    return true;
                case Keys.Control | Keys.Y:
                case Keys.Control | Keys.Shift | Keys.Z:
                    Redo();
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void Save() {
            StringTable.Write();
            LastSavePosition = EditHistory.Position;
        }

        private void Undo() {
            if(EditHistory.HasPast()) {
                EditHistory.GetCurrent().Undo();
                EditHistory.MoveBackward();
                RefreshUndoRedoButtons();
            }
        }

        private void Redo() {
            if(EditHistory.HasFuture()) {
                EditHistory.MoveForward().Redo();
                RefreshUndoRedoButtons();
            }
        }

        public void RefreshUndoRedoButtons() {
            undoMenuItem.Enabled = EditHistory.HasPast();
            redoMenuItem.Enabled = EditHistory.HasFuture();
        }

        private bool IsIndexInbounds(int index) {
            return index > 0 && index <= stringTableGridView.Rows.Count;
        }

        private void GoTo(int index) {
            if(!IsIndexInbounds(index))
                new AlertDialog("ID out of bounds.").ShowDialog();
            else
                stringTableGridView.FirstDisplayedScrollingRowIndex = index - 1;
        }

        public void AddString(GameString gs) {
            stringTableGridView.RowCount = StringTable.Count + 1;
        }

        public void RemoveString(GameString gs) {
            stringTableGridView.RowCount = StringTable.Count;
        }

        public void SetText(int id, string s) {
            stringTableGridView.CurrentCell = stringTableGridView[1, id - 1];
            // cell text is automatically updated during CellValueNeeded
        }

        public void SetSize(int id, int size) {
            stringTableGridView.CurrentCell = stringTableGridView[1, id - 1];
            IgnoreEvent = true;
            if(size == 0)
                radioButtonLarge.Checked = true;
            else if(size == 1)
                radioButtonMedium.Checked = true;
            else if(size == 2)
                radioButtonSmall.Checked = true;
            IgnoreEvent = false;
        }

        public void SetSpacing(int id, int spacing) {
            stringTableGridView.CurrentCell = stringTableGridView[1, id - 1];
            IgnoreEvent = true;
            spacingUpDown.Value = spacing;
            IgnoreEvent = false;
        }

        public void SetAlignment(int id, int alignment) {
            stringTableGridView.CurrentCell = stringTableGridView[1, id - 1];
            IgnoreEvent = true;
            if(alignment == 0)
                radioButtonLeft.Checked = true;
            else if(alignment == 2)
                radioButtonCenter.Checked = true;
            else if(alignment == 3)
                radioButtonRight.Checked = true;
            IgnoreEvent = false;
        }

        public void SetVertOffset(int id, int offset) {
            stringTableGridView.CurrentCell = stringTableGridView[1, id - 1];
            IgnoreEvent = true;
            offsetUpDown.Value = offset;
            IgnoreEvent = false;
        }

        public void SetColor(int id, int color) {
            stringTableGridView.CurrentCell = stringTableGridView[1, id - 1];
            IgnoreEvent = true;
            if(color == 6)
                colorComboBox.SelectedIndex = 5;
            else
                colorComboBox.SelectedIndex = color;
            IgnoreEvent = false;
        }

        private void RadioButtonSize_CheckedChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            // ignore event for un-checked button
            if(((RadioButton)sender).Checked) {
                int size;
                if(sender == radioButtonLarge)
                    size = 0;
                else if(sender == radioButtonMedium)
                    size = 1;
                else
                    size = 2;
                ExecuteCommand(new SetStringSizeCommand(this, CurrentIndex, size));
            }
        }

        private void SpacingUpDown_ValueChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            ExecuteCommand(new SetStringSpacingCommand(this, CurrentIndex, 
                                                       (int)spacingUpDown.Value));
        }

        private void RadioButtonAlignment_CheckedChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            int alignment;
            if(((RadioButton)sender).Checked) {
                if(sender == radioButtonLeft)
                    alignment = 0;
                else if(sender == radioButtonCenter)
                    alignment = 2;
                else
                    alignment = 3;
                ExecuteCommand(new SetStringAlignmentCommand(this, CurrentIndex, alignment));
            }
        }

        private void OffsetUpDown_ValueChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            ExecuteCommand(new SetStringVertOffsetCommand(this, CurrentIndex, 
                                                          (int)offsetUpDown.Value));
        }

        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            int colorIndex;
            if(colorComboBox.SelectedIndex == 5)
                colorIndex = 6;
            else
                colorIndex = colorComboBox.SelectedIndex;
            ExecuteCommand(new SetStringColorCommand(this, CurrentIndex, colorIndex));
        }

        private void StringTableGridView_CellValueNeeded(object sender, 
                                                         DataGridViewCellValueEventArgs e) {
            if(e.RowIndex > StringTable.Count - 1)
                return;
            if(e.ColumnIndex == 0)
                e.Value = HexUtils.IntToHex(e.RowIndex + 1, 4);
            else if(e.ColumnIndex == 1)
                e.Value = StringTable.GetString(e.RowIndex + 1).Text;
        }

        private void StringTableGridView_CurrentCellChanged(object sender, EventArgs e) {
            IgnoreEvent = true;
            GameString gameString;
            if(CurrentIndex <= StringTable.Count)
                gameString = StringTable.GetString(CurrentIndex);
            else
                // cheeky way to set to default values
                gameString = new GameString(0);

            if(gameString.Size == 0)
                radioButtonLarge.Checked = true;
            else if(gameString.Size == 1)
                radioButtonMedium.Checked = true;
            else if(gameString.Size == 2)
                radioButtonSmall.Checked = true;

            spacingUpDown.Value = gameString.Spacing;

            if(gameString.Alignment == 0 || gameString.Alignment == 1)
                radioButtonLeft.Checked = true;
            else if(gameString.Alignment == 2)
                radioButtonCenter.Checked = true;
            else if(gameString.Alignment == 3)
                radioButtonRight.Checked = true;

            offsetUpDown.Value = gameString.VertOffset;

            if(gameString.Color == 5)
                colorComboBox.SelectedIndex = 0;
            else if(gameString.Color == 6)
                colorComboBox.SelectedIndex = 5;
            else
                colorComboBox.SelectedIndex = gameString.Color;

            metadataPanel.Enabled = CurrentIndex <= StringTable.Count;
            IgnoreEvent = false;
        }

        private void StringTableGridView_CellParsing(object sender, 
                                                     DataGridViewCellParsingEventArgs e) {
            string text = e.Value.ToString().Replace(@"\n", " \n");
            if(e.RowIndex >= StringTable.Count)
                ExecuteCommand(new AddStringCommand(this, text));
            else
                ExecuteCommand(new SetStringTextCommand(this, e.RowIndex + 1, text));
            stringTableGridView.Invalidate();
        }

        private void SaveMenuItem_Click(object sender, EventArgs e) {
            Save();
        }

        private void UndoMenuItem_Click(object sender, EventArgs e) {
            Undo();
        }

        private void RedoMenuItem_Click(object sender, EventArgs e) {
            Redo();
        }
    }
}
