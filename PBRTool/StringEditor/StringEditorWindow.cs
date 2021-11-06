using System;
using System.Windows.Forms;
using PBRTool.Dialogs;
using PBRTool.StringEditor.Commands;
using PBRTool.Tables;
using PBRTool.Utils;

/*
 * TODO:
 * -Implement undo/redo and modified tracking
 * -Add search functionality
 */

namespace PBRTool.StringEditor
{
    public partial class StringEditorWindow : Form
    {
        public Tape<int> LocationHistory { get; private set; }

        private bool IgnoreEvent;

        public StringEditorWindow() {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            stringTableGridView.RowCount = StringTable.Count + 1;
            LocationHistory = new Tape<int>();
            LocationHistory.Insert(1);
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            StringTable.Write();
        }

        public void GoToString(int id) {
            stringTableGridView.FirstDisplayedScrollingRowIndex = id - 1;
        }

        public void RefreshHistoryButtons() {
            backArrowMenuItem.Enabled = LocationHistory.HasPast();
            forwardArrowMenuItem.Enabled = LocationHistory.HasFuture();
        }

        public void ExecuteCommand(Command<StringEditorWindow> command) {
            if(command.Execute()) {
                //EditHistory.Insert(command);
                //RefreshUndoRedoButtons();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch(keyData) {
                case Keys.Control | Keys.G:
                    var input = new HexInputDialog() { Prompt = "Enter string ID:" };
                    if(input.ShowDialog() == DialogResult.OK)
                        try {
                            ExecuteCommand(new GoToCommand(this, input.Response));
                        }
                        catch {
                            new AlertDialog() { Message = "Invalid input." }.Show();
                        }
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void RadioButtonSize_CheckedChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            int row = stringTableGridView.CurrentCell.RowIndex;
            // ignore event for un-checked button
            if(((RadioButton)sender).Checked) {
                int size;
                if(sender == radioButtonLarge)
                    size = 0;
                else if(sender == radioButtonMedium)
                    size = 1;
                else
                    size = 2;
                StringTable.SetStringProperty(row + 1, "Size", size);
            }
        }

        private void SpacingUpDown_ValueChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            int row = stringTableGridView.CurrentCell.RowIndex;
            StringTable.SetStringProperty(row + 1, "Spacing", (int)spacingUpDown.Value);
        }

        private void RadioButtonAlignment_CheckedChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            int row = stringTableGridView.CurrentCell.RowIndex;
            int alignment;
            if(sender == radioButtonLeft)
                alignment = 0;
            else if(sender == radioButtonCenter)
                alignment = 2;
            else
                alignment = 3;
            StringTable.SetStringProperty(row + 1, "Alignment", alignment);
        }

        private void OffsetUpDown_ValueChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            int row = stringTableGridView.CurrentCell.RowIndex;
            StringTable.SetStringProperty(row + 1, "VertOffset", (int)offsetUpDown.Value);
        }

        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            int row = stringTableGridView.CurrentCell.RowIndex;
            int colorIndex;
            if(colorComboBox.SelectedIndex == 5)
                colorIndex = 6;
            else
                colorIndex = colorComboBox.SelectedIndex;
            StringTable.SetStringProperty(row + 1, "Color", colorIndex);
        }

        private void StringTableGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            if(e.RowIndex > StringTable.Count - 1)
                return;
            if(e.ColumnIndex == 0)
                e.Value = HexUtils.IntToHex(e.RowIndex + 1, 4);
            else if(e.ColumnIndex == 1)
                e.Value = StringTable.GetString(e.RowIndex + 1).Text;
        }

        private void StringTableGridView_CurrentCellChanged(object sender, EventArgs e) {
            IgnoreEvent = true;
            int row = stringTableGridView.CurrentCell.RowIndex;
            GameString gameString;
            if(row < StringTable.Count)
                gameString = StringTable.GetString(row + 1);
            else
                // cheeky way to set to default values
                gameString = new GameString();

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

            metadataPanel.Enabled = row < StringTable.Count;
            IgnoreEvent = false;
        }

        private void StringTableGridView_CellParsing(object sender, DataGridViewCellParsingEventArgs e) {
            if(e.RowIndex >= StringTable.Count)
                StringTable.AddString(e.Value.ToString().Replace(@"\n", " \n"));
            else
                StringTable.SetStringProperty(e.RowIndex + 1, "Text", e.Value.ToString());
            stringTableGridView.Invalidate();
        }

        private void BackArrowMenuItem_Click(object sender, EventArgs e) {
            GoToString(LocationHistory.MoveBackward());
            RefreshHistoryButtons();
        }

        private void ForwardArrowMenuItem_Click(object sender, EventArgs e) {
            GoToString(LocationHistory.MoveForward());
            RefreshHistoryButtons();
        }
    }
}
