
namespace PBRHex
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.openISODialog = new System.Windows.Forms.OpenFileDialog();
            this.fileTreeView = new System.Windows.Forms.TreeView();
            this.fileTreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.fileLocationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileTreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.folderLocationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompressFSYSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveISODialog = new System.Windows.Forms.SaveFileDialog();
            this.headerMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unpackISOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebuildISOMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFSYSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assemblyEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dexEditorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rentalPassEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dolphinMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.selectFilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileTreeContextMenu.SuspendLayout();
            this.headerMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openISODialog
            // 
            this.openISODialog.FileName = "Select ISO";
            this.openISODialog.Filter = "Disc Image Files|*.iso";
            this.openISODialog.Title = "Open ISO";
            // 
            // fileTreeView
            // 
            this.fileTreeView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fileTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileTreeView.ImageIndex = 0;
            this.fileTreeView.ImageList = this.fileTreeImageList;
            this.fileTreeView.Location = new System.Drawing.Point(11, 7);
            this.fileTreeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileTreeView.Name = "fileTreeView";
            this.fileTreeView.SelectedImageIndex = 0;
            this.fileTreeView.Size = new System.Drawing.Size(525, 366);
            this.fileTreeView.TabIndex = 1;
            this.fileTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FileTreeView_NodeMouseClick);
            this.fileTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FileTreeView_NodeMouseDoubleClick);
            // 
            // fileTreeImageList
            // 
            this.fileTreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileTreeImageList.ImageStream")));
            this.fileTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileTreeImageList.Images.SetKeyName(0, "TM_Normal_Sprite.png");
            this.fileTreeImageList.Images.SetKeyName(1, "Town_Map_Sprite.png");
            this.fileTreeImageList.Images.SetKeyName(2, "File_Unmodified_Sprite.png");
            this.fileTreeImageList.Images.SetKeyName(3, "Yellow_Shard_Sprite.png");
            // 
            // fileLocationMenuItem
            // 
            this.fileLocationMenuItem.Name = "fileLocationMenuItem";
            this.fileLocationMenuItem.Size = new System.Drawing.Size(216, 24);
            this.fileLocationMenuItem.Text = "Open file location";
            this.fileLocationMenuItem.Click += new System.EventHandler(this.OpenLocationMenuItem_Click);
            // 
            // hexEditorMenuItem
            // 
            this.hexEditorMenuItem.Name = "hexEditorMenuItem";
            this.hexEditorMenuItem.Size = new System.Drawing.Size(216, 24);
            this.hexEditorMenuItem.Text = "Edit";
            this.hexEditorMenuItem.Click += new System.EventHandler(this.HexEditorMenuItem_Click);
            // 
            // fileTreeContextMenu
            // 
            this.fileTreeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fileTreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hexEditorMenuItem,
            this.decompressFSYSMenuItem,
            this.restoreMenuItem,
            this.removeFileMenuItem,
            this.folderLocationMenuItem,
            this.fileLocationMenuItem});
            this.fileTreeContextMenu.Name = "fileTreeContextMenu";
            this.fileTreeContextMenu.Size = new System.Drawing.Size(217, 176);
            this.fileTreeContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.FileTreeContextMenu_Opening);
            // 
            // folderLocationMenuItem
            // 
            this.folderLocationMenuItem.Name = "folderLocationMenuItem";
            this.folderLocationMenuItem.Size = new System.Drawing.Size(216, 24);
            this.folderLocationMenuItem.Text = "Open folder location";
            this.folderLocationMenuItem.Click += new System.EventHandler(this.OpenLocationMenuItem_Click);
            // 
            // decompressFSYSMenuItem
            // 
            this.decompressFSYSMenuItem.Name = "decompressFSYSMenuItem";
            this.decompressFSYSMenuItem.Size = new System.Drawing.Size(216, 24);
            this.decompressFSYSMenuItem.Text = "Unpack";
            this.decompressFSYSMenuItem.Click += new System.EventHandler(this.DecompressFSYSMenuItem_Click);
            // 
            // restoreMenuItem
            // 
            this.restoreMenuItem.Name = "restoreMenuItem";
            this.restoreMenuItem.Size = new System.Drawing.Size(216, 24);
            this.restoreMenuItem.Text = "Restore";
            this.restoreMenuItem.Click += new System.EventHandler(this.RestoreMenuItem_Click);
            // 
            // removeFileMenuItem
            // 
            this.removeFileMenuItem.Name = "removeFileMenuItem";
            this.removeFileMenuItem.Size = new System.Drawing.Size(216, 24);
            this.removeFileMenuItem.Text = "Remove";
            this.removeFileMenuItem.Click += new System.EventHandler(this.RemoveFileMenuItem_Click);
            // 
            // saveISODialog
            // 
            this.saveISODialog.Filter = "Disc Image File|*.iso";
            this.saveISODialog.Title = "Select a Save Location";
            // 
            // headerMenuStrip
            // 
            this.headerMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.headerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.editorsToolStripMenuItem,
            this.dolphinMenuItem});
            this.headerMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.headerMenuStrip.Name = "headerMenuStrip";
            this.headerMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.headerMenuStrip.ShowItemToolTips = true;
            this.headerMenuStrip.Size = new System.Drawing.Size(595, 28);
            this.headerMenuStrip.TabIndex = 4;
            this.headerMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unpackISOToolStripMenuItem,
            this.rebuildISOMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // unpackISOToolStripMenuItem
            // 
            this.unpackISOToolStripMenuItem.Name = "unpackISOToolStripMenuItem";
            this.unpackISOToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.unpackISOToolStripMenuItem.Text = "Unpack ISO";
            this.unpackISOToolStripMenuItem.Click += new System.EventHandler(this.UnpackISOButton_Click);
            // 
            // rebuildISOMenuItem
            // 
            this.rebuildISOMenuItem.Enabled = false;
            this.rebuildISOMenuItem.Name = "rebuildISOMenuItem";
            this.rebuildISOMenuItem.Size = new System.Drawing.Size(170, 26);
            this.rebuildISOMenuItem.Text = "Rebuild ISO";
            this.rebuildISOMenuItem.Click += new System.EventHandler(this.RebuildISOButton_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFSYSMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // newFSYSMenuItem
            // 
            this.newFSYSMenuItem.Name = "newFSYSMenuItem";
            this.newFSYSMenuItem.Size = new System.Drawing.Size(157, 26);
            this.newFSYSMenuItem.Text = "New FSYS";
            this.newFSYSMenuItem.Click += new System.EventHandler(this.NewFSYSMenuItem_Click);
            // 
            // editorsToolStripMenuItem
            // 
            this.editorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stringEditorMenuItem,
            this.assemblyEditorMenuItem,
            this.dexEditorMenuItem,
            this.rentalPassEditorToolStripMenuItem});
            this.editorsToolStripMenuItem.Name = "editorsToolStripMenuItem";
            this.editorsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.editorsToolStripMenuItem.Text = "Tools";
            // 
            // stringEditorMenuItem
            // 
            this.stringEditorMenuItem.Enabled = false;
            this.stringEditorMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stringEditorMenuItem.Image")));
            this.stringEditorMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stringEditorMenuItem.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.stringEditorMenuItem.Name = "stringEditorMenuItem";
            this.stringEditorMenuItem.Size = new System.Drawing.Size(209, 26);
            this.stringEditorMenuItem.Text = "String Editor";
            this.stringEditorMenuItem.Click += new System.EventHandler(this.StringEditorMenuItem_Click);
            // 
            // assemblyEditorMenuItem
            // 
            this.assemblyEditorMenuItem.Enabled = false;
            this.assemblyEditorMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("assemblyEditorMenuItem.Image")));
            this.assemblyEditorMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.assemblyEditorMenuItem.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.assemblyEditorMenuItem.Name = "assemblyEditorMenuItem";
            this.assemblyEditorMenuItem.Size = new System.Drawing.Size(209, 26);
            this.assemblyEditorMenuItem.Text = "Assembly Editor";
            this.assemblyEditorMenuItem.Click += new System.EventHandler(this.CodeEditorMenuItem_Click);
            // 
            // dexEditorMenuItem
            // 
            this.dexEditorMenuItem.Enabled = false;
            this.dexEditorMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dexEditorMenuItem.Image")));
            this.dexEditorMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dexEditorMenuItem.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.dexEditorMenuItem.Name = "dexEditorMenuItem";
            this.dexEditorMenuItem.Size = new System.Drawing.Size(209, 26);
            this.dexEditorMenuItem.Text = "Dex Editor";
            this.dexEditorMenuItem.Click += new System.EventHandler(this.DexEditorMenuItem_Click);
            // 
            // rentalPassEditorToolStripMenuItem
            // 
            this.rentalPassEditorToolStripMenuItem.Enabled = false;
            this.rentalPassEditorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rentalPassEditorToolStripMenuItem.Image")));
            this.rentalPassEditorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.rentalPassEditorToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.rentalPassEditorToolStripMenuItem.Name = "rentalPassEditorToolStripMenuItem";
            this.rentalPassEditorToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.rentalPassEditorToolStripMenuItem.Text = "Rental Pass Editor";
            this.rentalPassEditorToolStripMenuItem.Click += new System.EventHandler(this.RentalPassEditorMenuItem_Click);
            // 
            // dolphinMenuItem
            // 
            this.dolphinMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.dolphinMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dolphinMenuItem.Image")));
            this.dolphinMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dolphinMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.dolphinMenuItem.Name = "dolphinMenuItem";
            this.dolphinMenuItem.Size = new System.Drawing.Size(28, 24);
            this.dolphinMenuItem.ToolTipText = "Play";
            this.dolphinMenuItem.Click += new System.EventHandler(this.DolphinButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.messageLabel);
            this.panel1.Controls.Add(this.fileTreeView);
            this.panel1.Location = new System.Drawing.Point(23, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 380);
            this.panel1.TabIndex = 5;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(135, 166);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(270, 18);
            this.messageLabel.TabIndex = 2;
            this.messageLabel.Text = "Go to \"File > Unpack ISO\" to get started";
            // 
            // selectFilesDialog
            // 
            this.selectFilesDialog.FileName = "Select file(s) to add to the archive";
            this.selectFilesDialog.Multiselect = true;
            this.selectFilesDialog.Title = "Select file(s)";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(595, 444);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.headerMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "PBRHex";
            this.fileTreeContextMenu.ResumeLayout(false);
            this.headerMenuStrip.ResumeLayout(false);
            this.headerMenuStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openISODialog;
        private System.Windows.Forms.TreeView fileTreeView;
        private System.Windows.Forms.ToolStripMenuItem fileLocationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexEditorMenuItem;
        private System.Windows.Forms.ContextMenuStrip fileTreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem folderLocationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompressFSYSMenuItem;
        private System.Windows.Forms.ImageList fileTreeImageList;
        private System.Windows.Forms.SaveFileDialog saveISODialog;
        private System.Windows.Forms.ToolStripMenuItem restoreMenuItem;
        private System.Windows.Forms.MenuStrip headerMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stringEditorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dexEditorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assemblyEditorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unpackISOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebuildISOMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dolphinMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.ToolStripMenuItem rentalPassEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFSYSMenuItem;
        private System.Windows.Forms.OpenFileDialog selectFilesDialog;
        private System.Windows.Forms.ToolStripMenuItem removeFileMenuItem;
    }
}

