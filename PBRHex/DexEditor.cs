using System;
using System.Drawing;
using System.Security;
using System.Windows.Forms;
using PBRHex.Commands.DexCommands;
using PBRHex.Commands.ModelCommands;
using PBRHex.Commands.SpriteCommands;
using PBRHex.Dialogs;
using PBRHex.Files;
using PBRHex.Tables;

/*
 * TODO:
 * -Ensure shiny models' bones/anims match base models'
 * -Implement "add slot" as a command
 * -Add gender toggle
 * -Allow discarding of unsaved changes when closing
 * -Speed up "replace model"
 */

namespace PBRHex
{
    public partial class DexEditor : Form, IDexEditor, ISpriteEditor, IModelEditor
    {
        private Pokemon CurrentPokemon => new Pokemon(CurrentSpecies, CurrentForm);
        private int CurrentSpecies => pokemonListBox.SelectedIndex + 1;
        private int CurrentForm => formsComboBox.SelectedIndex;

        public readonly Tape<Command> EditHistory;
        public int LastSavePosition;

        private NumericUpDown[] statUpDowns;
        private ComboBox[] boneComboBoxes, animComboBoxes;
        private bool IgnoreEvent;

        public DexEditor() {
            InitializeComponent();

            EditHistory = new Tape<Command>();
            EditHistory.Insert(null);
            LastSavePosition = 0;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            attributesPage.Enabled = false;
            modelPage.Enabled = false;

            for(int i = 1; i <= DexTable.GetMaxDexNum(); i++) {
                pokemonListBox.Items.Add(DexTable.GetSpeciesName(i));
            }

            string[] abilities = new string[AbilityTable.Count - 1];
            for(int i = 1; i < AbilityTable.Count; i++) {
                abilities[i - 1] = AbilityTable.GetName(i);
            }
            primaryAbilityComboBox.Items.AddRange(abilities);
            secondaryAbilityComboBox.Items.Add("(None)");
            secondaryAbilityComboBox.Items.AddRange(abilities);

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
            DexTable.Write();
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

        private void GoTo(Pokemon mon, bool modelTab = false) {
            pokemonListBox.SelectedIndex = mon.DexNum - 1;
            formsComboBox.SelectedIndex = mon.FormIndex;
            pokemonTabControl.SelectedIndex = modelTab ? 1 : 0;
        }

        public void SetFaceSprites(Pokemon mon, Image newImage) {
            GoTo(mon);
            faceSpritePictureBox.Image = newImage;
            faceSpritePictureBox.Invalidate();
            faceShinySpritePictureBox.Image = newImage;
            faceShinySpritePictureBox.Invalidate();
        }

        public void SetBodySprites(Pokemon mon, Image newImage) {
            GoTo(mon);
            bodySpritePictureBox.Image = newImage;
            bodySpritePictureBox.Invalidate();
            bodyShinySpritePictureBox.Image = newImage;
            bodyShinySpritePictureBox.Invalidate();
        }

        public void SetSpeciesName(Pokemon mon, string name) {
            GoTo(mon);
            IgnoreEvent = true;
            nameTextBox.Text = name;
            pokemonListBox.Items[CurrentSpecies - 1] = name;
            IgnoreEvent = false;
        }

        public void SetTyping(Pokemon mon, int slot, PokeType type) {
            GoTo(mon);
            IgnoreEvent = true;
            var comboBox = slot == 0 ? primaryTypeComboBox : secondaryTypeComboBox;
            comboBox.SelectedItem = type.ToString();
            if(primaryTypeComboBox.SelectedIndex == secondaryTypeComboBox.SelectedIndex - 1)
                secondaryTypeComboBox.SelectedIndex = 0;
            IgnoreEvent = false;
        }

        public void SetAbility(Pokemon mon, int slot, int ability) {
            GoTo(mon);
            IgnoreEvent = true;
            if(slot == 0)
                primaryAbilityComboBox.SelectedIndex = ability - 1;
            else
                secondaryAbilityComboBox.SelectedIndex = ability;
            IgnoreEvent = false;
        }

        public void SetBaseStat(Pokemon mon, int stat, int value) {
            GoTo(mon);
            IgnoreEvent = true;
            statUpDowns[stat].Value = value;
            IgnoreEvent = false;
        }

        public void SetTier(Pokemon mon, SmogonTier tier) {
            GoTo(mon);
            IgnoreEvent = true;
            int index = tierComboBox.Items.IndexOf(tier.ToString());
            tierComboBox.SelectedIndex = index;
            IgnoreEvent = false;
        }

        public void SetModel(Pokemon mon, FileBuffer model) {
            GoTo(mon, true);
            UpdateModelPageComboBoxes();
        }

        public void SetBoneSlot(Pokemon mon, int slot, int bone) {
            GoTo(mon, true);
            IgnoreEvent = true;
            pokemonTabControl.SelectedIndex = 1;
            boneComboBoxes[slot].SelectedIndex = bone;
            boneComboBoxes[slot].Focus();
            IgnoreEvent = false;
        }

        public void SetAnimSlot(Pokemon mon, int slot, int anim) {
            GoTo(mon, true);
            IgnoreEvent = true;
            modelPage.Select();
            if(anim == 0xff)
                animComboBoxes[slot].SelectedIndex = animComboBoxes[slot].Items.Count - 1;
            else
                animComboBoxes[slot].SelectedIndex = anim;
            IgnoreEvent = false;
        }

        private void UpdateModelPageComboBoxes() {
            IgnoreEvent = true;
            var boneNames = ModelTable.GetBoneNames(CurrentPokemon);
            for(int i = 0; i < boneComboBoxes.Length; i++) {
                var comboBox = boneComboBoxes[i];
                comboBox.Items.Clear();
                comboBox.Items.AddRange(boneNames);
                comboBox.SelectedIndex = ModelTable.GetBoneSlot(CurrentPokemon, i);
            }

            int numAnims = ModelTable.GetAnimCount(CurrentPokemon);
            var animNames = ModelTable.GetAnimNames(CurrentPokemon);
            for(int i = 0; i < animComboBoxes.Length; i++) {
                var comboBox = animComboBoxes[i];
                comboBox.Items.Clear();
                if(numAnims > 0) {
                    comboBox.Items.AddRange(animNames);
                    if(i >= 19)
                        comboBox.Items.Add("-----");
                    int index = ModelTable.GetAnimSlot(CurrentPokemon, i);
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

        private void PokemonListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(CurrentSpecies <= 0)
                return;
            IgnoreEvent = true;
            attributesPage.Enabled = true;
            modelPage.Enabled = true;
            // dex & name
            dexNumLabel.Text = $"#{CurrentSpecies:D3}";
            nameTextBox.Text = DexTable.GetSpeciesName(CurrentSpecies);
            // formes
            formsComboBox.Items.Clear();
            int numForms = DexTable.GetFormCount(CurrentSpecies);
            for(int i = 0; i < numForms; i++) {
                string formName = DexTable.GetFormName(new Pokemon(CurrentSpecies, i));
                formsComboBox.Items.Add(formName);
            }
            // FormesComboBox_SelectedIndexChanged() will handle the rest of the attributes
            formsComboBox.SelectedIndex = 0;
            formsComboBox.Enabled = formsComboBox.Items.Count > 1;
            IgnoreEvent = false;
        }

        private void FormesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            IgnoreEvent = true;
            // stats
            for(int i = 0; i < 6; i++) {
                int stat = DexTable.GetStat(CurrentPokemon, i);
                SetBaseStat(CurrentPokemon, i, stat);
            }
            // types
            PokeType type1 = DexTable.GetTyping(CurrentPokemon, 0),
                type2 = DexTable.GetTyping(CurrentPokemon, 1);
            SetTyping(CurrentPokemon, 0, type1);
            SetTyping(CurrentPokemon, 1, type2);
            // abilities
            int ability1 = DexTable.GetAbility(CurrentPokemon, 0),
                ability2 = DexTable.GetAbility(CurrentPokemon, 1);
            SetAbility(CurrentPokemon, 0, ability1);
            SetAbility(CurrentPokemon, 1, ability2);
            // tier
            var tier = DexTable.GetTier(CurrentPokemon);
            SetTier(CurrentPokemon, tier);
            // sprites
            SetFaceSprites(CurrentPokemon, SpriteTable.GetFaceSprites(CurrentPokemon));
            SetBodySprites(CurrentPokemon, SpriteTable.GetBodySprites(CurrentPokemon));
            // model
            UpdateModelPageComboBoxes();
            IgnoreEvent = false;
        }

        private void UndoMenuItem_Click(object sender, EventArgs e) {
            Undo();
        }

        private void RedoMenuItem_Click(object sender, EventArgs e) {
            Redo();
        }

        private void NameTextBox_Leave(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            string name = nameTextBox.Text;
            if(name != DexTable.GetSpeciesName(CurrentSpecies))
                ExecuteCommand(new SetSpeciesNameCommand(this, CurrentPokemon, name));
        }

        private void StatUpDown_ValueChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            int idx = Array.IndexOf(statUpDowns, sender);
            ExecuteCommand(new SetBaseStatCommand(this, CurrentPokemon, idx, (int)statUpDowns[idx].Value));
        }

        private void PrimaryTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            string typeName = primaryTypeComboBox.SelectedItem.ToString();
            var type = (PokeType)Enum.Parse(typeof(PokeType), typeName);
            ExecuteCommand(new SetTypingCommand(this, CurrentPokemon, 0, type));
        }

        private void SecondaryTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            PokeType type;
            if (secondaryTypeComboBox.SelectedIndex == 0)
                type = DexTable.GetTyping(CurrentPokemon, 0);
            else {
                string typeName = secondaryTypeComboBox.SelectedItem.ToString();
                type = (PokeType)Enum.Parse(typeof(PokeType), typeName);
            }
            ExecuteCommand(new SetTypingCommand(this, CurrentPokemon, 1, type));
        }

        private void PrimaryAbilityComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            ExecuteCommand(new SetAbilityCommand(this, CurrentPokemon, 0, primaryAbilityComboBox.SelectedIndex + 1));
        }

        private void SecondaryAbilityComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            ExecuteCommand(new SetAbilityCommand(this, CurrentPokemon, 1, secondaryAbilityComboBox.SelectedIndex));
        }

        private void BoneComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            var comboBox = (ComboBox)sender;
            int slot = Array.IndexOf(boneComboBoxes, comboBox);
            ExecuteCommand(new SetBoneSlotCommand(this, CurrentPokemon, slot, comboBox.SelectedIndex));
        }

        private void AnimComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(IgnoreEvent)
                return;
            var comboBox = (ComboBox)sender;
            int slot = Array.IndexOf(animComboBoxes, comboBox),
                index = comboBox.SelectedIndex;
            if(slot >= 19 && index == comboBox.Items.Count - 1)
                index = 0xff;
            ExecuteCommand(new SetAnimSlotCommand(this, CurrentPokemon, slot, index));
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
                        new AlertDialog( "Invalid sprite; dimensions must be 48 x 48." ).ShowDialog();
                        return;
                    }
                    var mon = new Pokemon(CurrentSpecies, CurrentForm, 0, sender == replaceFaceShinySpriteButton);
                    ExecuteCommand(new SetFaceSpriteCommand(this, newSprite, mon));
                } catch(SecurityException ex) {
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
                        new AlertDialog( "Invalid sprite; dimensions must be 54 x 54." ).ShowDialog();
                        return;
                    }
                    var mon = new Pokemon(CurrentSpecies, CurrentForm, 0, sender == replaceBodyShinySpriteButton);
                    ExecuteCommand(new SetBodySpriteCommand(this, newSprite, mon));
                } catch(SecurityException ex) {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void ReplaceModelButton_Click(object sender, EventArgs e) {
            if(openModelDialog.ShowDialog() == DialogResult.OK) {
                try {
                    var file = new FileBuffer(openModelDialog.FileName);
                    var mon = new Pokemon(CurrentSpecies, CurrentForm, 0, sender == replaceModelShinyButton);
                    ExecuteCommand(new SetModelCommand(this, file, mon));
                } catch(SecurityException ex) {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e) {
            Save();
        }

        private void AddMonMenuItem_Click(object sender, EventArgs e) {
            int dex = DexTable.AddSlot();
            Save();
            pokemonListBox.Items.Add(DexTable.GetSpeciesName(dex));
            pokemonListBox.SelectedIndex = pokemonListBox.Items.Count - 1;
        }
    }
}