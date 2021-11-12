
namespace PBRHex
{
    partial class PassEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassEditor));
            this.trainerComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.speciesComboBox = new System.Windows.Forms.ComboBox();
            this.moveComboBox4 = new System.Windows.Forms.ComboBox();
            this.moveComboBox3 = new System.Windows.Forms.ComboBox();
            this.moveComboBox2 = new System.Windows.Forms.ComboBox();
            this.moveComboBox1 = new System.Windows.Forms.ComboBox();
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.abilityComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bodySpritePictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.spriteSlot6 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.spriteSlot5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.spriteSlot4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.spriteSlot3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.spriteSlot2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.spriteSlot1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bodySpritePictureBox)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot6)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot5)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot4)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot3)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot1)).BeginInit();
            this.SuspendLayout();
            // 
            // trainerComboBox
            // 
            this.trainerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainerComboBox.FormattingEnabled = true;
            this.trainerComboBox.Location = new System.Drawing.Point(29, 49);
            this.trainerComboBox.Name = "trainerComboBox";
            this.trainerComboBox.Size = new System.Drawing.Size(166, 24);
            this.trainerComboBox.TabIndex = 0;
            this.trainerComboBox.SelectedIndexChanged += new System.EventHandler(this.TrainerComboBox_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.undoMenuItem,
            this.redoMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(709, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(28, 26);
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.speciesComboBox);
            this.panel1.Controls.Add(this.moveComboBox4);
            this.panel1.Controls.Add(this.moveComboBox3);
            this.panel1.Controls.Add(this.moveComboBox2);
            this.panel1.Controls.Add(this.moveComboBox1);
            this.panel1.Controls.Add(this.itemComboBox);
            this.panel1.Controls.Add(this.abilityComboBox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.bodySpritePictureBox);
            this.panel1.Location = new System.Drawing.Point(441, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 322);
            this.panel1.TabIndex = 13;
            // 
            // speciesComboBox
            // 
            this.speciesComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.speciesComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.speciesComboBox.FormattingEnabled = true;
            this.speciesComboBox.Location = new System.Drawing.Point(92, 10);
            this.speciesComboBox.Name = "speciesComboBox";
            this.speciesComboBox.Size = new System.Drawing.Size(135, 24);
            this.speciesComboBox.TabIndex = 11;
            this.speciesComboBox.SelectedIndexChanged += new System.EventHandler(this.SpeciesComboBox_SelectedIndexChanged);
            // 
            // moveComboBox4
            // 
            this.moveComboBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.moveComboBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.moveComboBox4.FormattingEnabled = true;
            this.moveComboBox4.Location = new System.Drawing.Point(28, 273);
            this.moveComboBox4.Name = "moveComboBox4";
            this.moveComboBox4.Size = new System.Drawing.Size(150, 24);
            this.moveComboBox4.TabIndex = 9;
            this.moveComboBox4.SelectedIndexChanged += new System.EventHandler(this.MoveSlot_SelectedIndexChanged);
            // 
            // moveComboBox3
            // 
            this.moveComboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.moveComboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.moveComboBox3.FormattingEnabled = true;
            this.moveComboBox3.Location = new System.Drawing.Point(28, 243);
            this.moveComboBox3.Name = "moveComboBox3";
            this.moveComboBox3.Size = new System.Drawing.Size(150, 24);
            this.moveComboBox3.TabIndex = 8;
            this.moveComboBox3.SelectedIndexChanged += new System.EventHandler(this.MoveSlot_SelectedIndexChanged);
            // 
            // moveComboBox2
            // 
            this.moveComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.moveComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.moveComboBox2.FormattingEnabled = true;
            this.moveComboBox2.Location = new System.Drawing.Point(28, 213);
            this.moveComboBox2.Name = "moveComboBox2";
            this.moveComboBox2.Size = new System.Drawing.Size(150, 24);
            this.moveComboBox2.TabIndex = 7;
            this.moveComboBox2.SelectedIndexChanged += new System.EventHandler(this.MoveSlot_SelectedIndexChanged);
            // 
            // moveComboBox1
            // 
            this.moveComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.moveComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.moveComboBox1.FormattingEnabled = true;
            this.moveComboBox1.Location = new System.Drawing.Point(28, 183);
            this.moveComboBox1.Name = "moveComboBox1";
            this.moveComboBox1.Size = new System.Drawing.Size(150, 24);
            this.moveComboBox1.TabIndex = 6;
            this.moveComboBox1.SelectedIndexChanged += new System.EventHandler(this.MoveSlot_SelectedIndexChanged);
            // 
            // itemComboBox
            // 
            this.itemComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.itemComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(92, 121);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(135, 24);
            this.itemComboBox.TabIndex = 5;
            this.itemComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemComboBox_SelectedIndexChanged);
            // 
            // abilityComboBox
            // 
            this.abilityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.abilityComboBox.FormattingEnabled = true;
            this.abilityComboBox.Location = new System.Drawing.Point(92, 87);
            this.abilityComboBox.Name = "abilityComboBox";
            this.abilityComboBox.Size = new System.Drawing.Size(135, 24);
            this.abilityComboBox.TabIndex = 4;
            this.abilityComboBox.SelectedIndexChanged += new System.EventHandler(this.AbilityComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "Moves";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ability";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Held Item";
            // 
            // bodySpritePictureBox
            // 
            this.bodySpritePictureBox.Location = new System.Drawing.Point(12, 10);
            this.bodySpritePictureBox.Name = "bodySpritePictureBox";
            this.bodySpritePictureBox.Size = new System.Drawing.Size(72, 66);
            this.bodySpritePictureBox.TabIndex = 0;
            this.bodySpritePictureBox.TabStop = false;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel6, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(29, 87);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(396, 284);
            this.tableLayoutPanel.TabIndex = 17;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.spriteSlot6, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(266, 145);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(124, 133);
            this.tableLayoutPanel6.TabIndex = 25;
            this.tableLayoutPanel6.Click += new System.EventHandler(this.SpriteSlot_Click);
            // 
            // spriteSlot6
            // 
            this.spriteSlot6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.spriteSlot6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spriteSlot6.Location = new System.Drawing.Point(30, 17);
            this.spriteSlot6.Name = "spriteSlot6";
            this.spriteSlot6.Size = new System.Drawing.Size(64, 59);
            this.spriteSlot6.TabIndex = 0;
            this.spriteSlot6.TabStop = false;
            this.spriteSlot6.Click += new System.EventHandler(this.FaceSprite_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "label6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.spriteSlot5, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(136, 145);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(124, 133);
            this.tableLayoutPanel5.TabIndex = 24;
            this.tableLayoutPanel5.Click += new System.EventHandler(this.SpriteSlot_Click);
            // 
            // spriteSlot5
            // 
            this.spriteSlot5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.spriteSlot5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spriteSlot5.Location = new System.Drawing.Point(30, 17);
            this.spriteSlot5.Name = "spriteSlot5";
            this.spriteSlot5.Size = new System.Drawing.Size(64, 59);
            this.spriteSlot5.TabIndex = 0;
            this.spriteSlot5.TabStop = false;
            this.spriteSlot5.Click += new System.EventHandler(this.FaceSprite_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "label5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.spriteSlot4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 145);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(124, 133);
            this.tableLayoutPanel4.TabIndex = 23;
            this.tableLayoutPanel4.Click += new System.EventHandler(this.SpriteSlot_Click);
            // 
            // spriteSlot4
            // 
            this.spriteSlot4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.spriteSlot4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spriteSlot4.Location = new System.Drawing.Point(30, 17);
            this.spriteSlot4.Name = "spriteSlot4";
            this.spriteSlot4.Size = new System.Drawing.Size(64, 59);
            this.spriteSlot4.TabIndex = 0;
            this.spriteSlot4.TabStop = false;
            this.spriteSlot4.Click += new System.EventHandler(this.FaceSprite_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.spriteSlot3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(266, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(124, 133);
            this.tableLayoutPanel3.TabIndex = 22;
            this.tableLayoutPanel3.Click += new System.EventHandler(this.SpriteSlot_Click);
            // 
            // spriteSlot3
            // 
            this.spriteSlot3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.spriteSlot3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spriteSlot3.Location = new System.Drawing.Point(30, 31);
            this.spriteSlot3.Name = "spriteSlot3";
            this.spriteSlot3.Size = new System.Drawing.Size(64, 59);
            this.spriteSlot3.TabIndex = 0;
            this.spriteSlot3.TabStop = false;
            this.spriteSlot3.Click += new System.EventHandler(this.FaceSprite_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.spriteSlot2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(136, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(124, 133);
            this.tableLayoutPanel2.TabIndex = 21;
            this.tableLayoutPanel2.Click += new System.EventHandler(this.SpriteSlot_Click);
            // 
            // spriteSlot2
            // 
            this.spriteSlot2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.spriteSlot2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spriteSlot2.Location = new System.Drawing.Point(30, 31);
            this.spriteSlot2.Name = "spriteSlot2";
            this.spriteSlot2.Size = new System.Drawing.Size(64, 59);
            this.spriteSlot2.TabIndex = 0;
            this.spriteSlot2.TabStop = false;
            this.spriteSlot2.Click += new System.EventHandler(this.FaceSprite_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.spriteSlot1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(124, 133);
            this.tableLayoutPanel1.TabIndex = 20;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.SpriteSlot_Click);
            // 
            // spriteSlot1
            // 
            this.spriteSlot1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.spriteSlot1.BackColor = System.Drawing.Color.Transparent;
            this.spriteSlot1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spriteSlot1.Location = new System.Drawing.Point(30, 31);
            this.spriteSlot1.Name = "spriteSlot1";
            this.spriteSlot1.Size = new System.Drawing.Size(64, 59);
            this.spriteSlot1.TabIndex = 0;
            this.spriteSlot1.TabStop = false;
            this.spriteSlot1.Click += new System.EventHandler(this.FaceSprite_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // undoMenuItem
            // 
            this.undoMenuItem.Enabled = false;
            this.undoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoMenuItem.Image")));
            this.undoMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.undoMenuItem.Name = "undoMenuItem";
            this.undoMenuItem.Size = new System.Drawing.Size(28, 26);
            this.undoMenuItem.Click += new System.EventHandler(this.UndoMenuItem_Click);
            // 
            // redoMenuItem
            // 
            this.redoMenuItem.Enabled = false;
            this.redoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoMenuItem.Image")));
            this.redoMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.redoMenuItem.Name = "redoMenuItem";
            this.redoMenuItem.Size = new System.Drawing.Size(28, 26);
            this.redoMenuItem.Click += new System.EventHandler(this.RedoMenuItem_Click);
            // 
            // PassEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(709, 395);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trainerComboBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PassEditor";
            this.Text = "Rental Pass Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bodySpritePictureBox)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot6)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot5)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot4)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot3)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spriteSlot1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox trainerComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox bodySpritePictureBox;
        private System.Windows.Forms.ComboBox moveComboBox4;
        private System.Windows.Forms.ComboBox moveComboBox3;
        private System.Windows.Forms.ComboBox moveComboBox2;
        private System.Windows.Forms.ComboBox moveComboBox1;
        private System.Windows.Forms.ComboBox itemComboBox;
        private System.Windows.Forms.ComboBox abilityComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox spriteSlot1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.PictureBox spriteSlot6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox spriteSlot5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.PictureBox spriteSlot4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox spriteSlot3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox spriteSlot2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox speciesComboBox;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoMenuItem;
    }
}