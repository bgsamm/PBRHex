
namespace PBRHex.StringEditor
{
    partial class StringEditorWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringEditorWindow));
            this.stringTableGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metadataPanel = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.offsetUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonRight = new System.Windows.Forms.RadioButton();
            this.radioButtonCenter = new System.Windows.Forms.RadioButton();
            this.radioButtonLeft = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spacingUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonLarge = new System.Windows.Forms.RadioButton();
            this.radioButtonMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonSmall = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backArrowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardArrowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.stringTableGridView)).BeginInit();
            this.metadataPanel.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spacingUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stringTableGridView
            // 
            this.stringTableGridView.AllowUserToResizeRows = false;
            this.stringTableGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.stringTableGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stringTableGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.stringTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stringTableGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.stringTableGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.stringTableGridView.Location = new System.Drawing.Point(27, 43);
            this.stringTableGridView.Name = "stringTableGridView";
            this.stringTableGridView.RowHeadersVisible = false;
            this.stringTableGridView.RowHeadersWidth = 51;
            this.stringTableGridView.RowTemplate.Height = 24;
            this.stringTableGridView.Size = new System.Drawing.Size(450, 410);
            this.stringTableGridView.TabIndex = 0;
            this.stringTableGridView.VirtualMode = true;
            this.stringTableGridView.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.StringTableGridView_CellParsing);
            this.stringTableGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.StringTableGridView_CellValueNeeded);
            this.stringTableGridView.CurrentCellChanged += new System.EventHandler(this.StringTableGridView_CurrentCellChanged);
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "  ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "String";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 270;
            // 
            // metadataPanel
            // 
            this.metadataPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.metadataPanel.Controls.Add(this.groupBox5);
            this.metadataPanel.Controls.Add(this.groupBox4);
            this.metadataPanel.Controls.Add(this.groupBox3);
            this.metadataPanel.Controls.Add(this.groupBox2);
            this.metadataPanel.Controls.Add(this.label1);
            this.metadataPanel.Controls.Add(this.groupBox1);
            this.metadataPanel.Location = new System.Drawing.Point(484, 43);
            this.metadataPanel.Name = "metadataPanel";
            this.metadataPanel.Size = new System.Drawing.Size(200, 410);
            this.metadataPanel.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.colorComboBox);
            this.groupBox5.Location = new System.Drawing.Point(20, 344);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(160, 55);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Color";
            // 
            // colorComboBox
            // 
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Items.AddRange(new object[] {
            "White",
            "Red",
            "Blue",
            "Yellow",
            "Green",
            "Gray"});
            this.colorComboBox.Location = new System.Drawing.Point(7, 22);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(121, 24);
            this.colorComboBox.TabIndex = 0;
            this.colorComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorComboBox_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.offsetUpDown);
            this.groupBox4.Location = new System.Drawing.Point(20, 283);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(160, 55);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Offset";
            // 
            // offsetUpDown
            // 
            this.offsetUpDown.Location = new System.Drawing.Point(7, 22);
            this.offsetUpDown.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.offsetUpDown.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.offsetUpDown.Name = "offsetUpDown";
            this.offsetUpDown.Size = new System.Drawing.Size(120, 22);
            this.offsetUpDown.TabIndex = 0;
            this.offsetUpDown.ValueChanged += new System.EventHandler(this.OffsetUpDown_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonRight);
            this.groupBox3.Controls.Add(this.radioButtonCenter);
            this.groupBox3.Controls.Add(this.radioButtonLeft);
            this.groupBox3.Location = new System.Drawing.Point(20, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(160, 90);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alignment";
            // 
            // radioButtonRight
            // 
            this.radioButtonRight.AutoSize = true;
            this.radioButtonRight.Location = new System.Drawing.Point(7, 60);
            this.radioButtonRight.Name = "radioButtonRight";
            this.radioButtonRight.Size = new System.Drawing.Size(62, 21);
            this.radioButtonRight.TabIndex = 2;
            this.radioButtonRight.TabStop = true;
            this.radioButtonRight.Text = "Right";
            this.radioButtonRight.UseVisualStyleBackColor = true;
            this.radioButtonRight.CheckedChanged += new System.EventHandler(this.RadioButtonAlignment_CheckedChanged);
            // 
            // radioButtonCenter
            // 
            this.radioButtonCenter.AutoSize = true;
            this.radioButtonCenter.Location = new System.Drawing.Point(7, 40);
            this.radioButtonCenter.Name = "radioButtonCenter";
            this.radioButtonCenter.Size = new System.Drawing.Size(71, 21);
            this.radioButtonCenter.TabIndex = 1;
            this.radioButtonCenter.TabStop = true;
            this.radioButtonCenter.Text = "Center";
            this.radioButtonCenter.UseVisualStyleBackColor = true;
            this.radioButtonCenter.CheckedChanged += new System.EventHandler(this.RadioButtonAlignment_CheckedChanged);
            // 
            // radioButtonLeft
            // 
            this.radioButtonLeft.AutoSize = true;
            this.radioButtonLeft.Location = new System.Drawing.Point(7, 20);
            this.radioButtonLeft.Name = "radioButtonLeft";
            this.radioButtonLeft.Size = new System.Drawing.Size(53, 21);
            this.radioButtonLeft.TabIndex = 0;
            this.radioButtonLeft.TabStop = true;
            this.radioButtonLeft.Text = "Left";
            this.radioButtonLeft.UseVisualStyleBackColor = true;
            this.radioButtonLeft.CheckedChanged += new System.EventHandler(this.RadioButtonAlignment_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.spacingUpDown);
            this.groupBox2.Location = new System.Drawing.Point(20, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 55);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Spacing";
            // 
            // spacingUpDown
            // 
            this.spacingUpDown.Location = new System.Drawing.Point(7, 22);
            this.spacingUpDown.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.spacingUpDown.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.spacingUpDown.Name = "spacingUpDown";
            this.spacingUpDown.Size = new System.Drawing.Size(120, 22);
            this.spacingUpDown.TabIndex = 0;
            this.spacingUpDown.ValueChanged += new System.EventHandler(this.SpacingUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Metadata";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonLarge);
            this.groupBox1.Controls.Add(this.radioButtonMedium);
            this.groupBox1.Controls.Add(this.radioButtonSmall);
            this.groupBox1.Location = new System.Drawing.Point(20, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Size";
            // 
            // radioButtonLarge
            // 
            this.radioButtonLarge.AutoSize = true;
            this.radioButtonLarge.Location = new System.Drawing.Point(7, 60);
            this.radioButtonLarge.Name = "radioButtonLarge";
            this.radioButtonLarge.Size = new System.Drawing.Size(66, 21);
            this.radioButtonLarge.TabIndex = 2;
            this.radioButtonLarge.TabStop = true;
            this.radioButtonLarge.Text = "Large";
            this.radioButtonLarge.UseVisualStyleBackColor = true;
            this.radioButtonLarge.CheckedChanged += new System.EventHandler(this.RadioButtonSize_CheckedChanged);
            // 
            // radioButtonMedium
            // 
            this.radioButtonMedium.AutoSize = true;
            this.radioButtonMedium.Location = new System.Drawing.Point(7, 40);
            this.radioButtonMedium.Name = "radioButtonMedium";
            this.radioButtonMedium.Size = new System.Drawing.Size(78, 21);
            this.radioButtonMedium.TabIndex = 1;
            this.radioButtonMedium.TabStop = true;
            this.radioButtonMedium.Text = "Medium";
            this.radioButtonMedium.UseVisualStyleBackColor = true;
            this.radioButtonMedium.CheckedChanged += new System.EventHandler(this.RadioButtonSize_CheckedChanged);
            // 
            // radioButtonSmall
            // 
            this.radioButtonSmall.AutoSize = true;
            this.radioButtonSmall.Location = new System.Drawing.Point(7, 20);
            this.radioButtonSmall.Name = "radioButtonSmall";
            this.radioButtonSmall.Size = new System.Drawing.Size(63, 21);
            this.radioButtonSmall.TabIndex = 0;
            this.radioButtonSmall.TabStop = true;
            this.radioButtonSmall.Text = "Small";
            this.radioButtonSmall.UseVisualStyleBackColor = true;
            this.radioButtonSmall.CheckedChanged += new System.EventHandler(this.RadioButtonSize_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backArrowMenuItem,
            this.forwardArrowMenuItem,
            this.undoMenuItem,
            this.redoMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(711, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backArrowMenuItem
            // 
            this.backArrowMenuItem.Enabled = false;
            this.backArrowMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("backArrowMenuItem.Image")));
            this.backArrowMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.backArrowMenuItem.Name = "backArrowMenuItem";
            this.backArrowMenuItem.Size = new System.Drawing.Size(28, 20);
            this.backArrowMenuItem.Visible = false;
            // 
            // forwardArrowMenuItem
            // 
            this.forwardArrowMenuItem.Enabled = false;
            this.forwardArrowMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("forwardArrowMenuItem.Image")));
            this.forwardArrowMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.forwardArrowMenuItem.Name = "forwardArrowMenuItem";
            this.forwardArrowMenuItem.Size = new System.Drawing.Size(28, 20);
            this.forwardArrowMenuItem.Visible = false;
            // 
            // undoMenuItem
            // 
            this.undoMenuItem.Enabled = false;
            this.undoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoMenuItem.Image")));
            this.undoMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.undoMenuItem.Name = "undoMenuItem";
            this.undoMenuItem.Size = new System.Drawing.Size(28, 20);
            this.undoMenuItem.Click += new System.EventHandler(this.UndoMenuItem_Click);
            // 
            // redoMenuItem
            // 
            this.redoMenuItem.Enabled = false;
            this.redoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoMenuItem.Image")));
            this.redoMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.redoMenuItem.Name = "redoMenuItem";
            this.redoMenuItem.Size = new System.Drawing.Size(28, 20);
            this.redoMenuItem.Click += new System.EventHandler(this.RedoMenuItem_Click);
            // 
            // StringEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(711, 478);
            this.Controls.Add(this.metadataPanel);
            this.Controls.Add(this.stringTableGridView);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StringEditorWindow";
            this.Text = "String Table";
            ((System.ComponentModel.ISupportInitialize)(this.stringTableGridView)).EndInit();
            this.metadataPanel.ResumeLayout(false);
            this.metadataPanel.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.offsetUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spacingUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView stringTableGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Panel metadataPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonLarge;
        private System.Windows.Forms.RadioButton radioButtonMedium;
        private System.Windows.Forms.RadioButton radioButtonSmall;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown spacingUpDown;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonRight;
        private System.Windows.Forms.RadioButton radioButtonCenter;
        private System.Windows.Forms.RadioButton radioButtonLeft;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown offsetUpDown;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backArrowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardArrowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoMenuItem;
    }
}