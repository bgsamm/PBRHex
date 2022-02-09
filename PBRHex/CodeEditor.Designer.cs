
namespace PBRHex
{
    partial class CodeEditor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeEditor));
            this.codeView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newSectionButton = new System.Windows.Forms.Button();
            this.codeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertInstructionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteInstructionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionSelectDropdown = new PBRHex.HexEditor.Controls.FileSelectDropdown();
            this.loadButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.codeView)).BeginInit();
            this.codeViewContextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeView
            // 
            this.codeView.AllowUserToResizeColumns = false;
            this.codeView.AllowUserToResizeRows = false;
            this.codeView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.codeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.codeView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.codeView.DefaultCellStyle = dataGridViewCellStyle2;
            this.codeView.Location = new System.Drawing.Point(28, 58);
            this.codeView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.codeView.MultiSelect = false;
            this.codeView.Name = "codeView";
            this.codeView.RowHeadersWidth = 69;
            this.codeView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.codeView.RowTemplate.Height = 24;
            this.codeView.Size = new System.Drawing.Size(550, 309);
            this.codeView.TabIndex = 2;
            this.codeView.VirtualMode = true;
            this.codeView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CodeView_CellMouseClick);
            this.codeView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.CodeView_CellPainting);
            this.codeView.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.CodeView_CellParsing);
            this.codeView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.CodeView_CellValueNeeded);
            this.codeView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.CodeView_UserDeletedRow);
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Hex";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 69;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Instruction";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 235;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Comments";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 160;
            // 
            // newSectionButton
            // 
            this.newSectionButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.newSectionButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("newSectionButton.BackgroundImage")));
            this.newSectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.newSectionButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.newSectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newSectionButton.Location = new System.Drawing.Point(558, 31);
            this.newSectionButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newSectionButton.Name = "newSectionButton";
            this.newSectionButton.Size = new System.Drawing.Size(20, 21);
            this.newSectionButton.TabIndex = 4;
            this.newSectionButton.UseVisualStyleBackColor = false;
            this.newSectionButton.Click += new System.EventHandler(this.NewSectionButton_Click);
            // 
            // codeViewContextMenu
            // 
            this.codeViewContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.codeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertInstructionMenuItem,
            this.deleteInstructionMenuItem});
            this.codeViewContextMenu.Name = "codeViewContextMenu";
            this.codeViewContextMenu.Size = new System.Drawing.Size(168, 48);
            // 
            // insertInstructionMenuItem
            // 
            this.insertInstructionMenuItem.Name = "insertInstructionMenuItem";
            this.insertInstructionMenuItem.Size = new System.Drawing.Size(167, 22);
            this.insertInstructionMenuItem.Text = "Insert instruction";
            this.insertInstructionMenuItem.Click += new System.EventHandler(this.InsertInstructionMenuItem_Click);
            // 
            // deleteInstructionMenuItem
            // 
            this.deleteInstructionMenuItem.Name = "deleteInstructionMenuItem";
            this.deleteInstructionMenuItem.Size = new System.Drawing.Size(167, 22);
            this.deleteInstructionMenuItem.Text = "Delete instruction";
            this.deleteInstructionMenuItem.Click += new System.EventHandler(this.DeleteInstructionMenuItem_Click);
            // 
            // sectionSelectDropdown
            // 
            this.sectionSelectDropdown.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sectionSelectDropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sectionSelectDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sectionSelectDropdown.FormattingEnabled = true;
            this.sectionSelectDropdown.Location = new System.Drawing.Point(460, 31);
            this.sectionSelectDropdown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sectionSelectDropdown.Name = "sectionSelectDropdown";
            this.sectionSelectDropdown.Size = new System.Drawing.Size(96, 21);
            this.sectionSelectDropdown.TabIndex = 3;
            this.sectionSelectDropdown.SelectedIndexChanged += new System.EventHandler(this.SectionSelectDropdown_SelectedIndexChanged);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(28, 32);
            this.loadButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(94, 22);
            this.loadButton.TabIndex = 5;
            this.loadButton.Text = "Load from file";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Binary files|*.bin";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(608, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveMenuItem.Image")));
            this.saveMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(26, 20);
            this.saveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // CodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(608, 383);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.newSectionButton);
            this.Controls.Add(this.sectionSelectDropdown);
            this.Controls.Add(this.codeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "CodeEditor";
            this.Text = "CodeEditor";
            ((System.ComponentModel.ISupportInitialize)(this.codeView)).EndInit();
            this.codeViewContextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView codeView;
        private HexEditor.Controls.FileSelectDropdown sectionSelectDropdown;
        private System.Windows.Forms.Button newSectionButton;
        private System.Windows.Forms.ContextMenuStrip codeViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem insertInstructionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteInstructionMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
    }
}