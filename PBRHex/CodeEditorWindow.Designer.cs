
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
            ((System.ComponentModel.ISupportInitialize)(this.codeView)).BeginInit();
            this.codeViewContextMenu.SuspendLayout();
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
            this.codeView.Location = new System.Drawing.Point(38, 62);
            this.codeView.MultiSelect = false;
            this.codeView.Name = "codeView";
            this.codeView.RowHeadersWidth = 69;
            this.codeView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.codeView.RowTemplate.Height = 24;
            this.codeView.Size = new System.Drawing.Size(733, 380);
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
            this.newSectionButton.Location = new System.Drawing.Point(746, 29);
            this.newSectionButton.Name = "newSectionButton";
            this.newSectionButton.Size = new System.Drawing.Size(26, 26);
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
            this.codeViewContextMenu.Size = new System.Drawing.Size(196, 52);
            // 
            // insertInstructionMenuItem
            // 
            this.insertInstructionMenuItem.Name = "insertInstructionMenuItem";
            this.insertInstructionMenuItem.Size = new System.Drawing.Size(195, 24);
            this.insertInstructionMenuItem.Text = "Insert instruction";
            this.insertInstructionMenuItem.Click += new System.EventHandler(this.InsertInstructionMenuItem_Click);
            // 
            // deleteInstructionMenuItem
            // 
            this.deleteInstructionMenuItem.Name = "deleteInstructionMenuItem";
            this.deleteInstructionMenuItem.Size = new System.Drawing.Size(195, 24);
            this.deleteInstructionMenuItem.Text = "Delete instruction";
            this.deleteInstructionMenuItem.Click += new System.EventHandler(this.DeleteInstructionMenuItem_Click);
            // 
            // sectionSelectDropdown
            // 
            this.sectionSelectDropdown.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sectionSelectDropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.sectionSelectDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sectionSelectDropdown.FormattingEnabled = true;
            this.sectionSelectDropdown.Location = new System.Drawing.Point(619, 29);
            this.sectionSelectDropdown.Name = "sectionSelectDropdown";
            this.sectionSelectDropdown.Size = new System.Drawing.Size(127, 23);
            this.sectionSelectDropdown.TabIndex = 3;
            this.sectionSelectDropdown.SelectedIndexChanged += new System.EventHandler(this.SectionSelectDropdown_SelectedIndexChanged);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(38, 29);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(125, 27);
            this.loadButton.TabIndex = 5;
            this.loadButton.Text = "Load from file";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Binary files|*.bin";
            // 
            // CodeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(811, 471);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.newSectionButton);
            this.Controls.Add(this.sectionSelectDropdown);
            this.Controls.Add(this.codeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CodeEditor";
            this.Text = "CodeEditor";
            ((System.ComponentModel.ISupportInitialize)(this.codeView)).EndInit();
            this.codeViewContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}