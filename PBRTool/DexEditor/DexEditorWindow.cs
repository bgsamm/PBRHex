using System;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using PBRTool.DexEditor.Commands;
using PBRTool.Dialogs;
using PBRTool.Files;
using PBRTool.Tables;

/*
 * TODO:
 * -Ensure shiny models' bones/anims match base models'
 * -Implement "add slot" as a command
 * -Add gender toggle
 * -Allow discarding of unsaved changes when closing
 * -Speed up "replace model"
 */

namespace PBRTool.DexEditor
{
    public partial class DexEditorWindow : Form
    {
        private int CurrentSpecies => pokemonListBox.SelectedIndex + 1;
        private int CurrentForm => formesComboBox.SelectedIndex;

        public readonly Tape<Command<DexEditorWindow>> EditHistory;
        public int LastSavePosition;

        private NumericUpDown[] statUpDowns;
        private ComboBox[] boneComboBoxes, animComboBoxes;
        private bool IgnoreEvent;

        public DexEditorWindow() {
            InitializeComponent();

            EditHistory = new Tape<Command<DexEditorWindow>>();
            EditHistory.Insert(null);
            LastSavePosition = 0;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            attributesPage.Enabled = false;
            modelPage.Enabled = false;

            for(int i = 1; i <= DexTable.GetRange(); i++) {
                pokemonListBox.Items.Add(DexTable.GetName(i));
            }

            statUpDowns = new NumericUpDown[]
            {
                hpUpDown, attUpDown, defUpDown, speUpDown, spaUpDown, spdUpDown
            };

            boneComboBoxes = new ComboBox[boneSlotsTable.RowCount];
            for(int i = 0; i < boneComboBoxes.Length; i++) {
                boneComboBoxes[i] = (ComboBox)boneSlotsTable.GetControlFromPosition(1, i);
            };

            animComboBoxes = new ComboBox[animSlotsTable.RowCount];
            for(int i = 0; i < animComboBoxes.Length; i++) {
                animComboBoxes[i] = (ComboBox)animSlotsTable.GetControlFromPosition(1, i);
            };
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);

            if(LastSavePosition != EditHistory.Position)
                ExecuteCommand(new SaveCommand(this));
        }

        public void Write() {
            DexTable.Write();
            StringTable.Write();
        }

        private void ExecuteCommand(Command<DexEditorWindow> cmd) {
            if(cmd.Execute()) {
                EditHistory.Insert(cmd);
                RefreshUndoRedoButtons();
            }
        }

        public void SetFaceSprite(Image newImage) {
            faceSpritePictureBox.Image = newImage;
            faceSpritePictureBox.Invalidate();
            faceShinySpritePictureBox.Image = newImage;
            faceShinySpritePictureBox.Invalidate();
        }

        public void SetBodySprite(Image newImage) {
            bodySpritePictureBox.Image = newImage;
            bodySpritePictureBox.Invalidate();
            bodyShinySpritePictureBox.Image = newImage;
            bodyShinySpritePictureBox.Invalidate();
        }

        public void SetName(int dex, string name) {
            pokemonListBox.SelectedIndex = dex - 1;
            IgnoreEvent = true;
            nameTextBox.Text = name;
            pokemonListBox.Items[CurrentSpecies - 1] = name;
            IgnoreEvent = false;
        }

        public void SetTyping(int dex, int slot, int type) {
            pokemonListBox.SelectedIndex = dex - 1;
            IgnoreEvent = true;
            if(slot == 0)
                primaryTypeComboBox.SelectedIndex = type < 9 ? type : type - 1;
            else
                secondaryTypeComboBox.SelectedIndex = type < 9 ? type + 1 : type;
            if(primaryTypeComboBox.SelectedIndex == secondaryTypeComboBox.SelectedIndex - 1)
                secondaryTypeComboBox.SelectedIndex = 0;
            IgnoreEvent = false;
        }

        public void SetStat(int dex, int stat, int value) {
            pokemonListBox.SelectedIndex = dex - 1;
            IgnoreEvent = true;
            statUpDowns[stat].Value = value;
            IgnoreEvent = false;
        }

        public void SetBoneSlot(int dex, int slot, int bone) {
            pokemonListBox.SelectedIndex = dex - 1;
            IgnoreEvent = true;
            pokemonTabControl.SelectedIndex = 1;
            boneComboBoxes[slot].SelectedIndex = bone;
            boneComboBoxes[slot].Focus();
            IgnoreEvent = false;
        }

        public void SetAnimSlot(int dex, int slot, int anim) {
            pokemonListBox.SelectedIndex = dex - 1;
            IgnoreEvent = true;
            modelPage.Select();
            if(anim == 0xff)
                animComboBoxes[slot].SelectedIndex = animComboBoxes[slot].Items.Count - 1;
            else
                animComboBoxes[slot].SelectedIndex = anim;
            IgnoreEvent = false;
        }

        public void UpdateModelPageComboBoxes() {
            IgnoreEvent = true;
            var boneNames = ModelTable.GetBoneNames(CurrentSpecies, CurrentForm, 0);
            for(int i = 0; i < boneComboBoxes.Length; i++) {
                var comboBox = boneComboBoxes[i];
                comboBox.Items.Clear();
                comboBox.Items.AddRange(boneNames);
                comboBox.SelectedIndex = ModelTable.GetBoneSlot(CurrentSpecies, CurrentForm, 0, i);
            }

            int numAnims = ModelTable.GetAnimCount(CurrentSpecies, CurrentForm, 0);
            var animNames = ModelTable.GetAnimNames(CurrentSpecies, CurrentForm, 0);
            for(int i = 0; i < animComboBoxes.Length; i++) {
                var comboBox = animComboBoxes[i];
                comboBox.Items.Clear();
                if(numAnims > 0) {
                    comboBox.Items.AddRange(animNames);
                    if(i >= 19)
                        comboBox.Items.Add("-----");
                    int index = ModelTable.GetAnimSlot(CurrentSpecies, CurrentForm, 0, i);
                    comboBox.SelectedIndex = index == 0xff ? numAnims : index;
                    comboBox.Enabled = true;
                } else {
                    comboBox.Items.Add("-----");
                    comboBox.SelectedIndex = 0;
                    comboBox.Enabled = false;
                }
            }
            IgnoreEvent = false;
        }

        public void RefreshUndoRedoButtons() {
            undoMenuItem.Enabled = EditHistory.HasPast();
            redoMenuItem.Enabled = EditHistory.HasFuture();
        }

        private void PokemonListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(CurrentSpecies <= 0)
                return;
            IgnoreEvent = true;
            attributesPage.Enabled = true;
            modelPage.Enabled = true;
            // dex & name
            dexNumLabel.Text = $"#{CurrentSpecies:D3}";
            nameTextBox.Text = DexTable.GetName(CurrentSpecies);
            // formes
            formesComboBox.Items.Clear();
            int numForms = DexTable.GetFormCount(CurrentSpecies);
            for(int i = 0; i < numForms; i++) {
                string formName = DexTable.GetFormName(CurrentSpecies, i);
                formesComboBox.Items.Add(formName);
            }
            // FormesComboBox_SelectedIndexChanged() will handle the rest of the attributes
            formesComboBox.SelectedIndex = 0;
            formesComboBox.Enabled = formesComboBox.Items.Count > 1;
            IgnoreEvent = false;
        }

        private void FormesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            IgnoreEvent = true;
            int form = formesComboBox.SelectedIndex;
            // stats
            for(int i = 0; i < 6; i++) {
                statUpDowns[i].Value = DexTable.GetStat(CurrentSpecies, form, i);
            }
            // types
            int type1 = DexTable.GetTyping(CurrentSpecies, form, 0),
                type2 = DexTable.GetTyping(CurrentSpecies, form, 1);
            primaryTypeComboBox.SelectedIndex = type1 < 9 ? type1 : type1 - 1;
            secondaryTypeComboBox.SelectedIndex = type2 == type1 ? 0 : (type2 < 9 ? type2 + 1 : type2);
            // sprites
            SetFaceSprite(SpriteTable.GetFaceSprite(CurrentSpecies, CurrentForm, 0));
            SetBodySprite(SpriteTable.GetBodySprite(CurrentSpecies, CurrentForm, 0));
            // model
            UpdateModelPageComboBoxes();
            IgnoreEvent = false;
        }

        private void UndoMenuItem_Click(object sender, EventArgs e) {
            ExecuteCommand(new UndoCommand(this));
        }

        private void RedoMenuItem_Click(object sender, EventArgs e) {
            ExecuteCommand(new RedoCommand(this));
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            ExecuteCommand(new SetNameCommand(this, CurrentSpecies, nameTextBox.Text));
        }

        private void StatUpDown_ValueChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            int idx = Array.IndexOf(statUpDowns, sender);
            ExecuteCommand(new SetStatCommand(this, CurrentSpecies, 0, idx, (int)statUpDowns[idx].Value));
        }

        private void PrimaryTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            int type = primaryTypeComboBox.SelectedIndex;
            if(type >= 9)
                type++;
            ExecuteCommand(new SetTypeCommand(this, CurrentSpecies, 0, 0, type));
        }

        private void SecondaryTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            int type = secondaryTypeComboBox.SelectedIndex;
            if(type == 0)
                type = DexTable.GetTyping(CurrentSpecies, 0, 0);
            else if(type <= 9)
                type--;
            ExecuteCommand(new SetTypeCommand(this, CurrentSpecies, 0, 1, type));
        }

        private void BoneComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            var comboBox = (ComboBox)sender;
            int slot = Array.IndexOf(boneComboBoxes, comboBox);
            ExecuteCommand(new SetBoneSlotCommand(this, CurrentSpecies, CurrentForm, 0, slot, comboBox.SelectedIndex));
        }

        private void AnimComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            var comboBox = (ComboBox)sender;
            int slot = Array.IndexOf(animComboBoxes, comboBox),
                index = comboBox.SelectedIndex;
            if(slot >= 19 && index == comboBox.Items.Count - 1)
                index = 0xff;
            ExecuteCommand(new SetAnimSlotCommand(this, CurrentSpecies, CurrentForm, 0, slot, index));
        }

        private void FaceShinySpritePictureBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(SystemColors.Window);
            if(faceShinySpritePictureBox.Image != null)
                e.Graphics.DrawImage(faceShinySpritePictureBox.Image, 0, -48);
        }

        private void BodyShinySpritePictureBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(SystemColors.Window);
            if(bodyShinySpritePictureBox.Image != null)
                e.Graphics.DrawImage(bodyShinySpritePictureBox.Image, 0, -54);
        }

        private void ReplaceFaceSpriteButton_Click(object sender, EventArgs e) {
            if(openImageDialog.ShowDialog() == DialogResult.OK) {
                try {
                    var newSprite = Image.FromFile(openImageDialog.FileName);
                    if(newSprite.Width != 48 || newSprite.Height != 48) {
                        new AlertDialog() { Message = "Invalid sprite; dimensions must be 48 x 48." }.ShowDialog();
                        return;
                    }
                    ExecuteCommand(new SetFaceSpriteCommand(this, newSprite, CurrentSpecies, CurrentForm, 0, 
                                    sender == replaceFaceShinySpriteButton));
                }
                catch(SecurityException ex) {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void ReplaceBodySpriteButton_Click(object sender, EventArgs e) {
            if(openImageDialog.ShowDialog() == DialogResult.OK) {
                try {
                    var newSprite = Image.FromFile(openImageDialog.FileName);
                    if(newSprite.Width != 54 || newSprite.Height != 54) {
                        new AlertDialog() { Message = "Invalid sprite; dimensions must be 54 x 54." }.ShowDialog();
                        return;
                    }
                    ExecuteCommand(new SetBodySpriteCommand(this, newSprite, CurrentSpecies, CurrentForm, 0, 
                                    sender == replaceBodyShinySpriteButton));
                }
                catch(SecurityException ex) {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void ReplaceModelButton_Click(object sender, EventArgs e) {
            if(openModelDialog.ShowDialog() == DialogResult.OK) {
                try {
                    var file = new FileBuffer(openModelDialog.FileName);
                    ExecuteCommand(new SetModelCommand(this, file, CurrentSpecies, CurrentForm, 0,
                                    sender == replaceModelShinyButton));
                }
                catch(SecurityException ex) {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e) {
            ExecuteCommand(new SaveCommand(this));
        }

        private void AddMonMenuItem_Click(object sender, EventArgs e) {
            int dex = DexTable.AddSlot();
            pokemonListBox.Items.Add(DexTable.GetName(dex));
            //var input = new InputDialog() { Prompt = "Enter species name:" };
            //if(input.ShowDialog() == DialogResult.OK) {
            //    int index = DexTable.AddSlot();
            //    string name = input.Response;
            //    DexTable.SetName(index, name);
            //    pokemonListBox.Items.Add(name);
            //}
        }
    }
}
