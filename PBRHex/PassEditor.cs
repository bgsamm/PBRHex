using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PBRHex.Commands.PassCommands;
using PBRHex.Tables;

namespace PBRHex
{
    public partial class PassEditor : Form, IPassEditor
    {
        private readonly Tape<Command> EditHistory;
        private int LastSavePosition;

        private int CurrentPass => trainerComboBox.SelectedIndex;
        private int CurrentSlot;

        private readonly PictureBox[] FaceSpritePictureBoxes;
        private readonly ComboBox[] MoveComboBoxes;

        private bool IgnoreEvent;

        public PassEditor() {
            InitializeComponent();

            FaceSpritePictureBoxes = new PictureBox[]
            {
                spriteSlot1, spriteSlot2, spriteSlot3, spriteSlot4, spriteSlot5, spriteSlot6
            };

            MoveComboBoxes = new ComboBox[]
            {
                moveComboBox1, moveComboBox2, moveComboBox3, moveComboBox4
            };

            EditHistory = new Tape<Command>();
            EditHistory.Insert(null);
            LastSavePosition = 0;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            for(int i = 1; i <= DexTable.GetRange(); i++) {
                speciesComboBox.Items.Add(DexTable.GetSpeciesName(i));
            }

            for(int i = 0; i < ItemTable.Count; i++) {
                itemComboBox.Items.Add(ItemTable.GetName(i));
            }

            string[] moves = new string[MoveTable.Count];
            for(int i = 0; i < moves.Length; i++) {
                moves[i] = MoveTable.GetName(i);
            }
            foreach(var slot in MoveComboBoxes) {
                slot.Items.AddRange(moves);
            }

            CurrentSlot = 0;
            for(int i = 0; i < 6; i++) {
                trainerComboBox.Items.Add(PassTable.GetTrainerName(i));
            }
            trainerComboBox.SelectedIndex = 0;
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);

            if(LastSavePosition != EditHistory.Position)
                Save();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch(keyData) {
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

        private void ExecuteCommand(Command command) {
            if(command.Execute()) {
                EditHistory.Insert(command);
                RefreshUndoRedoButtons();
            }
        }

        private void Save() {
            FSYSTable.WriteFile("deck");
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

        private void GoTo(int pass, int slot) {
            trainerComboBox.SelectedIndex = pass;
            SelectSlot(slot);
        }

        public void RefreshUndoRedoButtons() {
            undoMenuItem.Enabled = EditHistory.HasPast();
            redoMenuItem.Enabled = EditHistory.HasFuture();
        }

        public void SetSlotSpecies(int pass, int slot, Pokemon mon) {
            SetSlot(slot, mon);
            GoTo(pass, slot);
        }

        public void SetSlotAbility(int pass, int slot, int ability) {
            GoTo(pass, slot);
            IgnoreEvent = true;
            abilityComboBox.SelectedIndex = ability;
            IgnoreEvent = false;
        }

        public void SetSlotItem(int pass, int slot, int item) {
            GoTo(pass, slot);
            IgnoreEvent = true;
            itemComboBox.SelectedIndex = item;
            IgnoreEvent = false;
        }

        public void SetSlotMove(int pass, int slot, int moveSlot, int move) {
            GoTo(pass, slot);
            IgnoreEvent = true;
            MoveComboBoxes[moveSlot].SelectedIndex = move;
            IgnoreEvent = false;
        }

        private void SelectSlot(int index) {
            for(int i = 0; i < FaceSpritePictureBoxes.Length; i++) {
                FaceSpritePictureBoxes[i].Parent.BackColor = i == index ?
                    SystemColors.GradientActiveCaption : Color.Transparent;
            }
            UpdateMonDetails(index);
        }

        private void UpdateMonDetails(int index) {
            IgnoreEvent = true;

            var mon = PassTable.GetPassMember(CurrentPass, index);
            abilityComboBox.Items.Clear();
            int ab1 = DexTable.GetAbility(mon, 0),
                ab2 = DexTable.GetAbility(mon, 1);
            abilityComboBox.Items.Add(AbilityTable.GetName(ab1));
            if(ab2 != 0)
                abilityComboBox.Items.Add(AbilityTable.GetName(ab2));

            bodySpritePictureBox.Image = SpriteTable.GetBodySprites(mon);
            speciesComboBox.SelectedIndex = mon.DexNo - 1;
            abilityComboBox.SelectedIndex = mon.Ability == ab1 ? 0 : 1;
            itemComboBox.SelectedIndex = mon.HeldItem;
            for(int i = 0; i < 4; i++) {
                MoveComboBoxes[i].SelectedIndex = mon.Moves[i];
            }
            CurrentSlot = index;

            IgnoreEvent = false;
        }

        private void SetSlot(int index, Pokemon mon) {
            var controls = tableLayoutPanel.GetControlFromPosition(index % 3, index / 3).Controls;
            var pictureBox = controls.OfType<PictureBox>().First();
            var label = controls.OfType<Label>().First();
            pictureBox.Image = SpriteTable.GetFaceSprites(mon);
            label.Text = DexTable.GetSpeciesName(mon.DexNo);
        }

        private void TrainerComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            for(int i = 0; i < 6; i++) {
                SetSlot(i, PassTable.GetPassMember(CurrentPass, i));
            }
            SelectSlot(CurrentSlot);
        }

        private void SpriteSlot_Click(object sender, EventArgs e) {
            var pos = tableLayoutPanel.GetPositionFromControl((Control)sender);
            SelectSlot(pos.Row * 3 + pos.Column);
        }

        private void FaceSprite_Click(object sender, EventArgs e) {
            SelectSlot(Array.IndexOf(FaceSpritePictureBoxes, sender));
        }

        private void SpeciesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            var mon = new Pokemon(speciesComboBox.SelectedIndex + 1, 0);
            ExecuteCommand(new SetPassSlotSpeciesCommand(this, CurrentPass, CurrentSlot, mon));
        }

        private void AbilityComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            ExecuteCommand(new SetPassSlotAbilityCommand(this, CurrentPass, CurrentSlot, abilityComboBox.SelectedIndex));
        }

        private void ItemComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            ExecuteCommand(new SetPassSlotHeldItemCommand(this, CurrentPass, CurrentSlot, itemComboBox.SelectedIndex));
        }

        private void MoveSlot_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            var comboBox = (ComboBox)sender;
            int slot = Array.IndexOf(MoveComboBoxes, sender);
            ExecuteCommand(new SetPassSlotMoveCommand(this, CurrentPass, CurrentSlot, slot, comboBox.SelectedIndex));
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
