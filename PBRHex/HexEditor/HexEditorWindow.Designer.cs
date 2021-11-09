namespace PBRHex.HexEditor
{
    partial class HexEditorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HexEditorWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backArrowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardArrowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileButton = new System.Windows.Forms.Button();
            this.widgetsTabControl = new System.Windows.Forms.TabControl();
            this.asciiViewTabPage = new System.Windows.Forms.TabPage();
            this.asciiView = new PBRHex.HexEditor.Controls.AsciiViewer();
            this.labelsTabPage = new System.Windows.Forms.TabPage();
            this.labelsListBox = new PBRHex.HexEditor.Controls.LabelsListBox();
            this.labelsListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToAddressMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.renameLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.hexGridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToAddressMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEmptyLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPointerLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addIntLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFloatLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStringLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addColorLabelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillRangeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertRangeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRangeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.deleteFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.nextMatchButton = new System.Windows.Forms.Button();
            this.searchAllButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.deleteLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.previousMatchButton = new System.Windows.Forms.Button();
            this.fileSelectDropdown = new PBRHex.HexEditor.Controls.FileSelectDropdown();
            this.hexGrid = new PBRHex.HexEditor.Controls.HexGridView();
            this.widgetsTabControl.SuspendLayout();
            this.asciiViewTabPage.SuspendLayout();
            this.labelsTabPage.SuspendLayout();
            this.labelsListContextMenu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.hexGridContextMenu.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hexGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // backArrowMenuItem
            // 
            this.backArrowMenuItem.Enabled = false;
            this.backArrowMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("backArrowMenuItem.Image")));
            this.backArrowMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.backArrowMenuItem.Name = "backArrowMenuItem";
            this.backArrowMenuItem.Size = new System.Drawing.Size(28, 20);
            this.backArrowMenuItem.ToolTipText = "Previous Location";
            // 
            // forwardArrowMenuItem
            // 
            this.forwardArrowMenuItem.Enabled = false;
            this.forwardArrowMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("forwardArrowMenuItem.Image")));
            this.forwardArrowMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.forwardArrowMenuItem.Name = "forwardArrowMenuItem";
            this.forwardArrowMenuItem.Size = new System.Drawing.Size(28, 20);
            this.forwardArrowMenuItem.ToolTipText = "Next Location";
            // 
            // undoMenuItem
            // 
            this.undoMenuItem.Enabled = false;
            this.undoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoMenuItem.Image")));
            this.undoMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.undoMenuItem.Name = "undoMenuItem";
            this.undoMenuItem.Size = new System.Drawing.Size(28, 20);
            this.undoMenuItem.ToolTipText = "Undo";
            this.undoMenuItem.Click += new System.EventHandler(this.UndoMenuItem_Click);
            // 
            // redoMenuItem
            // 
            this.redoMenuItem.Enabled = false;
            this.redoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoMenuItem.Image")));
            this.redoMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.redoMenuItem.Name = "redoMenuItem";
            this.redoMenuItem.Size = new System.Drawing.Size(28, 20);
            this.redoMenuItem.ToolTipText = "Redo";
            this.redoMenuItem.Click += new System.EventHandler(this.RedoMenuItem_Click);
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Location = new System.Drawing.Point(37, 42);
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(104, 24);
            this.saveToFileButton.TabIndex = 3;
            this.saveToFileButton.Text = "Save to file";
            this.saveToFileButton.UseVisualStyleBackColor = true;
            this.saveToFileButton.Click += new System.EventHandler(this.SaveToFileButton_Click);
            // 
            // widgetsTabControl
            // 
            this.widgetsTabControl.Controls.Add(this.asciiViewTabPage);
            this.widgetsTabControl.Controls.Add(this.labelsTabPage);
            this.widgetsTabControl.Controls.Add(this.tabPage1);
            this.widgetsTabControl.Location = new System.Drawing.Point(685, 72);
            this.widgetsTabControl.Name = "widgetsTabControl";
            this.widgetsTabControl.SelectedIndex = 0;
            this.widgetsTabControl.Size = new System.Drawing.Size(181, 381);
            this.widgetsTabControl.TabIndex = 4;
            // 
            // asciiViewTabPage
            // 
            this.asciiViewTabPage.Controls.Add(this.asciiView);
            this.asciiViewTabPage.Location = new System.Drawing.Point(4, 25);
            this.asciiViewTabPage.Name = "asciiViewTabPage";
            this.asciiViewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.asciiViewTabPage.Size = new System.Drawing.Size(173, 352);
            this.asciiViewTabPage.TabIndex = 0;
            this.asciiViewTabPage.Text = "ASCII";
            this.asciiViewTabPage.UseVisualStyleBackColor = true;
            // 
            // asciiView
            // 
            this.asciiView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.asciiView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.asciiView.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.asciiView.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asciiView.FormattingEnabled = true;
            this.asciiView.ItemHeight = 24;
            this.asciiView.Location = new System.Drawing.Point(-4, 0);
            this.asciiView.Name = "asciiView";
            this.asciiView.Size = new System.Drawing.Size(181, 360);
            this.asciiView.TabIndex = 0;
            // 
            // labelsTabPage
            // 
            this.labelsTabPage.Controls.Add(this.labelsListBox);
            this.labelsTabPage.Location = new System.Drawing.Point(4, 25);
            this.labelsTabPage.Name = "labelsTabPage";
            this.labelsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.labelsTabPage.Size = new System.Drawing.Size(173, 352);
            this.labelsTabPage.TabIndex = 1;
            this.labelsTabPage.Text = "Labels";
            this.labelsTabPage.UseVisualStyleBackColor = true;
            // 
            // labelsListBox
            // 
            this.labelsListBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelsListBox.ContextMenuStrip = this.labelsListContextMenu;
            this.labelsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.labelsListBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsListBox.FormattingEnabled = true;
            this.labelsListBox.ItemHeight = 22;
            this.labelsListBox.Location = new System.Drawing.Point(0, 0);
            this.labelsListBox.Name = "labelsListBox";
            this.labelsListBox.Size = new System.Drawing.Size(177, 352);
            this.labelsListBox.TabIndex = 0;
            this.labelsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LabelsListBox_MouseDoubleClick);
            this.labelsListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelsListBox_MouseMove);
            this.labelsListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LabelsListBox_MouseUp);
            // 
            // labelsListContextMenu
            // 
            this.labelsListContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.labelsListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToLabelMenuItem,
            this.goToAddressMenuItem1,
            this.renameLabelMenuItem,
            this.deleteLabelMenuItem});
            this.labelsListContextMenu.Name = "labelsListContextMenu";
            this.labelsListContextMenu.Size = new System.Drawing.Size(171, 100);
            // 
            // goToLabelMenuItem
            // 
            this.goToLabelMenuItem.Name = "goToLabelMenuItem";
            this.goToLabelMenuItem.Size = new System.Drawing.Size(170, 24);
            this.goToLabelMenuItem.Text = "Go to label";
            this.goToLabelMenuItem.Click += new System.EventHandler(this.GoToLabelMenuItem_Click);
            // 
            // goToAddressMenuItem1
            // 
            this.goToAddressMenuItem1.Name = "goToAddressMenuItem1";
            this.goToAddressMenuItem1.Size = new System.Drawing.Size(170, 24);
            this.goToAddressMenuItem1.Text = "Go to address";
            this.goToAddressMenuItem1.Click += new System.EventHandler(this.GoToAddressMenuItem1_Click);
            // 
            // renameLabelMenuItem
            // 
            this.renameLabelMenuItem.Name = "renameLabelMenuItem";
            this.renameLabelMenuItem.Size = new System.Drawing.Size(170, 24);
            this.renameLabelMenuItem.Text = "Rename label";
            this.renameLabelMenuItem.Click += new System.EventHandler(this.RenameLabelMenuItem_Click);
            // 
            // deleteLabelMenuItem
            // 
            this.deleteLabelMenuItem.Name = "deleteLabelMenuItem";
            this.deleteLabelMenuItem.Size = new System.Drawing.Size(170, 24);
            this.deleteLabelMenuItem.Text = "Delete label";
            this.deleteLabelMenuItem.Click += new System.EventHandler(this.RemoveLabelMenuItem_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.notesTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(173, 352);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Notes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // notesTextBox
            // 
            this.notesTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notesTextBox.Location = new System.Drawing.Point(-4, 0);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.notesTextBox.Size = new System.Drawing.Size(181, 356);
            this.notesTextBox.TabIndex = 0;
            this.notesTextBox.TextChanged += new System.EventHandler(this.NotesBox_TextChanged);
            // 
            // hexGridContextMenu
            // 
            this.hexGridContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.hexGridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToAddressMenuItem,
            this.addLabelMenuItem,
            this.fillRangeMenuItem,
            this.insertRangeMenuItem,
            this.deleteRangeMenuItem});
            this.hexGridContextMenu.Name = "hexViewContextMenu";
            this.hexGridContextMenu.Size = new System.Drawing.Size(171, 124);
            // 
            // goToAddressMenuItem
            // 
            this.goToAddressMenuItem.Name = "goToAddressMenuItem";
            this.goToAddressMenuItem.Size = new System.Drawing.Size(170, 24);
            this.goToAddressMenuItem.Text = "Go to address";
            this.goToAddressMenuItem.Click += new System.EventHandler(this.GoToAddressMenuItem_Click);
            // 
            // addLabelMenuItem
            // 
            this.addLabelMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEmptyLabelMenuItem,
            this.addPointerLabelMenuItem,
            this.addIntLabelMenuItem,
            this.addFloatLabelMenuItem,
            this.addStringLabelMenuItem,
            this.addColorLabelMenuItem});
            this.addLabelMenuItem.Name = "addLabelMenuItem";
            this.addLabelMenuItem.Size = new System.Drawing.Size(170, 24);
            this.addLabelMenuItem.Text = "Add label";
            // 
            // addEmptyLabelMenuItem
            // 
            this.addEmptyLabelMenuItem.Name = "addEmptyLabelMenuItem";
            this.addEmptyLabelMenuItem.Size = new System.Drawing.Size(138, 26);
            this.addEmptyLabelMenuItem.Text = "Empty";
            this.addEmptyLabelMenuItem.Click += new System.EventHandler(this.AddLabelMenuItem_Click);
            // 
            // addPointerLabelMenuItem
            // 
            this.addPointerLabelMenuItem.Name = "addPointerLabelMenuItem";
            this.addPointerLabelMenuItem.Size = new System.Drawing.Size(138, 26);
            this.addPointerLabelMenuItem.Text = "Pointer";
            this.addPointerLabelMenuItem.Click += new System.EventHandler(this.AddLabelMenuItem_Click);
            // 
            // addIntLabelMenuItem
            // 
            this.addIntLabelMenuItem.Name = "addIntLabelMenuItem";
            this.addIntLabelMenuItem.Size = new System.Drawing.Size(138, 26);
            this.addIntLabelMenuItem.Text = "Int";
            this.addIntLabelMenuItem.Click += new System.EventHandler(this.AddLabelMenuItem_Click);
            // 
            // addFloatLabelMenuItem
            // 
            this.addFloatLabelMenuItem.Name = "addFloatLabelMenuItem";
            this.addFloatLabelMenuItem.Size = new System.Drawing.Size(138, 26);
            this.addFloatLabelMenuItem.Text = "Float";
            this.addFloatLabelMenuItem.Click += new System.EventHandler(this.AddLabelMenuItem_Click);
            // 
            // addStringLabelMenuItem
            // 
            this.addStringLabelMenuItem.Name = "addStringLabelMenuItem";
            this.addStringLabelMenuItem.Size = new System.Drawing.Size(138, 26);
            this.addStringLabelMenuItem.Text = "String";
            this.addStringLabelMenuItem.Click += new System.EventHandler(this.AddLabelMenuItem_Click);
            // 
            // addColorLabelMenuItem
            // 
            this.addColorLabelMenuItem.Name = "addColorLabelMenuItem";
            this.addColorLabelMenuItem.Size = new System.Drawing.Size(138, 26);
            this.addColorLabelMenuItem.Text = "Color";
            this.addColorLabelMenuItem.Click += new System.EventHandler(this.AddLabelMenuItem_Click);
            // 
            // fillRangeMenuItem
            // 
            this.fillRangeMenuItem.Name = "fillRangeMenuItem";
            this.fillRangeMenuItem.Size = new System.Drawing.Size(170, 24);
            this.fillRangeMenuItem.Text = "Fill Range";
            this.fillRangeMenuItem.Click += new System.EventHandler(this.FillRangeMenuItem_Click);
            // 
            // insertRangeMenuItem
            // 
            this.insertRangeMenuItem.Name = "insertRangeMenuItem";
            this.insertRangeMenuItem.Size = new System.Drawing.Size(170, 24);
            this.insertRangeMenuItem.Text = "Insert Range";
            this.insertRangeMenuItem.Click += new System.EventHandler(this.InsertRangeMenuItem_Click);
            // 
            // deleteRangeMenuItem
            // 
            this.deleteRangeMenuItem.Name = "deleteRangeMenuItem";
            this.deleteRangeMenuItem.Size = new System.Drawing.Size(170, 24);
            this.deleteRangeMenuItem.Text = "Delete Range";
            this.deleteRangeMenuItem.Click += new System.EventHandler(this.DeleteRangeMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backArrowMenuItem,
            this.forwardArrowMenuItem,
            this.undoMenuItem,
            this.redoMenuItem,
            this.deleteFileMenuItem,
            this.newFileMenuItem,
            this.openFileMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(896, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // deleteFileMenuItem
            // 
            this.deleteFileMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deleteFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteFileMenuItem.Image")));
            this.deleteFileMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteFileMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.deleteFileMenuItem.Name = "deleteFileMenuItem";
            this.deleteFileMenuItem.Size = new System.Drawing.Size(28, 20);
            this.deleteFileMenuItem.ToolTipText = "Delete File";
            this.deleteFileMenuItem.Click += new System.EventHandler(this.DeleteFileMenuItem_Click);
            // 
            // newFileMenuItem
            // 
            this.newFileMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.newFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newFileMenuItem.Image")));
            this.newFileMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newFileMenuItem.Name = "newFileMenuItem";
            this.newFileMenuItem.Size = new System.Drawing.Size(28, 20);
            this.newFileMenuItem.ToolTipText = "New File";
            this.newFileMenuItem.Click += new System.EventHandler(this.NewFileMenuItem_Click);
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.openFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileMenuItem.Image")));
            this.openFileMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.Size = new System.Drawing.Size(28, 20);
            this.openFileMenuItem.ToolTipText = "Open File";
            this.openFileMenuItem.Click += new System.EventHandler(this.AddFileMenuItem_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(356, 42);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.searchTextBox.Size = new System.Drawing.Size(228, 24);
            this.searchTextBox.TabIndex = 8;
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // nextMatchButton
            // 
            this.nextMatchButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.nextMatchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.nextMatchButton.Enabled = false;
            this.nextMatchButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.nextMatchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextMatchButton.Image = ((System.Drawing.Image)(resources.GetObject("nextMatchButton.Image")));
            this.nextMatchButton.Location = new System.Drawing.Point(609, 42);
            this.nextMatchButton.Name = "nextMatchButton";
            this.nextMatchButton.Size = new System.Drawing.Size(26, 26);
            this.nextMatchButton.TabIndex = 9;
            this.nextMatchButton.UseVisualStyleBackColor = false;
            this.nextMatchButton.Click += new System.EventHandler(this.NextMatchButton_Click);
            // 
            // searchAllButton
            // 
            this.searchAllButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.searchAllButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchAllButton.Enabled = false;
            this.searchAllButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.searchAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchAllButton.Image = ((System.Drawing.Image)(resources.GetObject("searchAllButton.Image")));
            this.searchAllButton.Location = new System.Drawing.Point(637, 42);
            this.searchAllButton.Name = "searchAllButton";
            this.searchAllButton.Size = new System.Drawing.Size(26, 26);
            this.searchAllButton.TabIndex = 11;
            this.searchAllButton.UseVisualStyleBackColor = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Data File|*.*";
            // 
            // deleteLabelToolStripMenuItem
            // 
            this.deleteLabelToolStripMenuItem.Name = "deleteLabelToolStripMenuItem";
            this.deleteLabelToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.deleteLabelToolStripMenuItem.Text = "Delete Label";
            // 
            // previousMatchButton
            // 
            this.previousMatchButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.previousMatchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.previousMatchButton.Enabled = false;
            this.previousMatchButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.previousMatchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousMatchButton.Image = ((System.Drawing.Image)(resources.GetObject("previousMatchButton.Image")));
            this.previousMatchButton.Location = new System.Drawing.Point(584, 42);
            this.previousMatchButton.Name = "previousMatchButton";
            this.previousMatchButton.Size = new System.Drawing.Size(26, 26);
            this.previousMatchButton.TabIndex = 10;
            this.previousMatchButton.UseVisualStyleBackColor = false;
            this.previousMatchButton.Click += new System.EventHandler(this.PreviousMatchButton_Click);
            // 
            // fileSelectDropdown
            // 
            this.fileSelectDropdown.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.fileSelectDropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.fileSelectDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileSelectDropdown.FormattingEnabled = true;
            this.fileSelectDropdown.Location = new System.Drawing.Point(685, 42);
            this.fileSelectDropdown.Name = "fileSelectDropdown";
            this.fileSelectDropdown.Size = new System.Drawing.Size(181, 23);
            this.fileSelectDropdown.TabIndex = 6;
            this.fileSelectDropdown.SelectedIndexChanged += new System.EventHandler(this.FileSelectDropdown_SelectedIndexChanged);
            // 
            // hexGrid
            // 
            this.hexGrid.AllowUserToAddRows = false;
            this.hexGrid.AllowUserToDeleteRows = false;
            this.hexGrid.AllowUserToResizeColumns = false;
            this.hexGrid.AllowUserToResizeRows = false;
            this.hexGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.hexGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hexGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.hexGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hexGrid.ContextMenuStrip = this.hexGridContextMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.hexGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.hexGrid.Location = new System.Drawing.Point(37, 72);
            this.hexGrid.Name = "hexGrid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.hexGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.hexGrid.RowHeadersWidth = 69;
            this.hexGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.hexGrid.RowTemplate.Height = 24;
            this.hexGrid.Size = new System.Drawing.Size(626, 381);
            this.hexGrid.TabIndex = 5;
            this.hexGrid.VirtualMode = true;
            this.hexGrid.CellEdited += new System.EventHandler<PBRHex.Events.CellEditEventArgs>(this.HexGrid_CellEdited);
            this.hexGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HexView_Scroll);
            // 
            // HexEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(896, 472);
            this.Controls.Add(this.searchAllButton);
            this.Controls.Add(this.previousMatchButton);
            this.Controls.Add(this.nextMatchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.fileSelectDropdown);
            this.Controls.Add(this.hexGrid);
            this.Controls.Add(this.widgetsTabControl);
            this.Controls.Add(this.saveToFileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "HexEditorWindow";
            this.Text = "HexEditor";
            this.widgetsTabControl.ResumeLayout(false);
            this.asciiViewTabPage.ResumeLayout(false);
            this.labelsTabPage.ResumeLayout(false);
            this.labelsListContextMenu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.hexGridContextMenu.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hexGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveToFileButton;
        private System.Windows.Forms.TabControl widgetsTabControl;
        private System.Windows.Forms.TabPage asciiViewTabPage;
        private System.Windows.Forms.TabPage labelsTabPage;
        private System.Windows.Forms.ToolStripMenuItem backArrowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardArrowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoMenuItem;
        private Controls.FileSelectDropdown fileSelectDropdown;
        private Controls.LabelsListBox labelsListBox;
        private Controls.AsciiViewer asciiView;
        private Controls.HexGridView hexGrid;
        private System.Windows.Forms.ContextMenuStrip hexGridContextMenu;
        private System.Windows.Forms.ToolStripMenuItem goToAddressMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLabelMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button nextMatchButton;
        private System.Windows.Forms.Button previousMatchButton;
        private System.Windows.Forms.Button searchAllButton;
        private System.Windows.Forms.ToolStripMenuItem newFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem addIntLabelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStringLabelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addColorLabelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLabelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEmptyLabelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFloatLabelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPointerLabelMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem fillRangeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertRangeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRangeMenuItem;
        private System.Windows.Forms.ContextMenuStrip labelsListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem goToLabelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToAddressMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameLabelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLabelMenuItem;
    }
}