
namespace PBRTool
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
            this.saveISODialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unpackISOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebuildISOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assemblyEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dexEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pleaseWaitLabel = new System.Windows.Forms.Label();
            this.fileTreeContextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.fileTreeImageList.Images.SetKeyName(3, "File_Modified_Sprite.png");
            // 
            // fileLocationMenuItem
            // 
            this.fileLocationMenuItem.Name = "fileLocationMenuItem";
            this.fileLocationMenuItem.Size = new System.Drawing.Size(216, 24);
            this.fileLocationMenuItem.Text = "Open file location";
            this.fileLocationMenuItem.Click += new System.EventHandler(this.FileLocationMenuItem_Click);
            // 
            // hexEditorMenuItem
            // 
            this.hexEditorMenuItem.Name = "hexEditorMenuItem";
            this.hexEditorMenuItem.Size = new System.Drawing.Size(216, 24);
            this.hexEditorMenuItem.Text = "Open in hex editor";
            this.hexEditorMenuItem.Click += new System.EventHandler(this.HexEditorMenuItem_Click);
            // 
            // fileTreeContextMenu
            // 
            this.fileTreeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fileTreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderLocationMenuItem,
            this.fileLocationMenuItem,
            this.hexEditorMenuItem,
            this.decompressFSYSMenuItem,
            this.restoreMenuItem});
            this.fileTreeContextMenu.Name = "fileTreeContextMenu";
            this.fileTreeContextMenu.Size = new System.Drawing.Size(217, 124);
            this.fileTreeContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.FileTreeContextMenu_Opening);
            // 
            // folderLocationMenuItem
            // 
            this.folderLocationMenuItem.Name = "folderLocationMenuItem";
            this.folderLocationMenuItem.Size = new System.Drawing.Size(216, 24);
            this.folderLocationMenuItem.Text = "Open folder location";
            this.folderLocationMenuItem.Click += new System.EventHandler(this.FolderLocationMenuItem_Click);
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
            // saveISODialog
            // 
            this.saveISODialog.Filter = "Disc Image File|*.iso";
            this.saveISODialog.Title = "Select a Save Location";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editorsToolStripMenuItem,
            this.playToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(595, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unpackISOToolStripMenuItem,
            this.rebuildISOToolStripMenuItem});
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
            // rebuildISOToolStripMenuItem
            // 
            this.rebuildISOToolStripMenuItem.Name = "rebuildISOToolStripMenuItem";
            this.rebuildISOToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.rebuildISOToolStripMenuItem.Text = "Rebuild ISO";
            this.rebuildISOToolStripMenuItem.Click += new System.EventHandler(this.RebuildISOButton_Click);
            // 
            // editorsToolStripMenuItem
            // 
            this.editorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stringEditorToolStripMenuItem,
            this.assemblyEditorToolStripMenuItem,
            this.dexEditorToolStripMenuItem});
            this.editorsToolStripMenuItem.Name = "editorsToolStripMenuItem";
            this.editorsToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.editorsToolStripMenuItem.Text = "Editors";
            // 
            // stringEditorToolStripMenuItem
            // 
            this.stringEditorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stringEditorToolStripMenuItem.Image")));
            this.stringEditorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stringEditorToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.stringEditorToolStripMenuItem.Name = "stringEditorToolStripMenuItem";
            this.stringEditorToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.stringEditorToolStripMenuItem.Text = "String Editor";
            this.stringEditorToolStripMenuItem.Click += new System.EventHandler(this.EditStringsMenuItem_Click);
            // 
            // assemblyEditorToolStripMenuItem
            // 
            this.assemblyEditorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("assemblyEditorToolStripMenuItem.Image")));
            this.assemblyEditorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.assemblyEditorToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.assemblyEditorToolStripMenuItem.Name = "assemblyEditorToolStripMenuItem";
            this.assemblyEditorToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.assemblyEditorToolStripMenuItem.Text = "Code Editor";
            // 
            // dexEditorToolStripMenuItem
            // 
            this.dexEditorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dexEditorToolStripMenuItem.Image")));
            this.dexEditorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dexEditorToolStripMenuItem.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.dexEditorToolStripMenuItem.Name = "dexEditorToolStripMenuItem";
            this.dexEditorToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.dexEditorToolStripMenuItem.Text = "Dex Editor";
            this.dexEditorToolStripMenuItem.Click += new System.EventHandler(this.DexEditorMenuItem_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.playToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("playToolStripMenuItem.Image")));
            this.playToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.playToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(28, 24);
            this.playToolStripMenuItem.ToolTipText = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.DolphinButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pleaseWaitLabel);
            this.panel1.Controls.Add(this.fileTreeView);
            this.panel1.Location = new System.Drawing.Point(23, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 380);
            this.panel1.TabIndex = 5;
            // 
            // pleaseWaitLabel
            // 
            this.pleaseWaitLabel.AutoSize = true;
            this.pleaseWaitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pleaseWaitLabel.Location = new System.Drawing.Point(136, 166);
            this.pleaseWaitLabel.Name = "pleaseWaitLabel";
            this.pleaseWaitLabel.Size = new System.Drawing.Size(253, 18);
            this.pleaseWaitLabel.TabIndex = 2;
            this.pleaseWaitLabel.Text = "Please wait. This will take some time.";
            this.pleaseWaitLabel.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(595, 444);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "PBRHex";
            this.fileTreeContextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stringEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dexEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assemblyEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unpackISOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebuildISOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label pleaseWaitLabel;
    }
}

