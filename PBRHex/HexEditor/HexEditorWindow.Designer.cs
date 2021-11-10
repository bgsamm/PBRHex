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
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.backArrowMenuItem.Click += new System.EventHandler(this.BackArrowMenuItem_Click);
            // 
            // forwardArrowMenuItem
            // 
            this.forwardArrowMenuItem.Enabled = false;
            this.forwardArrowMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("forwardArrowMenuItem.Image")));
            this.forwardArrowMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.forwardArrowMenuItem.Name = "forwardArrowMenuItem";
            this.forwardArrowMenuItem.Size = new System.Drawing.Size(28, 20);
            this.forwardArrowMenuItem.ToolTipText = "Next Location";
            this.forwardArrowMenuItem.Click += new System.EventHandler(this.ForwardArrowMenuItem_Click);
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
            this.hexGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn34,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn36,
            this.dataGridViewTextBoxColumn37,
            this.dataGridViewTextBoxColumn38,
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn40,
            this.dataGridViewTextBoxColumn41,
            this.dataGridViewTextBoxColumn42,
            this.dataGridViewTextBoxColumn43,
            this.dataGridViewTextBoxColumn44,
            this.dataGridViewTextBoxColumn45,
            this.dataGridViewTextBoxColumn46,
            this.dataGridViewTextBoxColumn47,
            this.dataGridViewTextBoxColumn48,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16});
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
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.HeaderText = "0";
            this.dataGridViewTextBoxColumn33.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn33.Width = 24;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.HeaderText = "1";
            this.dataGridViewTextBoxColumn34.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn34.Width = 24;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.HeaderText = "2";
            this.dataGridViewTextBoxColumn35.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn35.Width = 24;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.HeaderText = "3";
            this.dataGridViewTextBoxColumn36.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn36.Width = 24;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.HeaderText = "4";
            this.dataGridViewTextBoxColumn37.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn37.Width = 24;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.HeaderText = "5";
            this.dataGridViewTextBoxColumn38.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn38.Width = 24;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.HeaderText = "6";
            this.dataGridViewTextBoxColumn39.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn39.Width = 24;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.HeaderText = "7";
            this.dataGridViewTextBoxColumn40.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn40.Width = 24;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.HeaderText = "8";
            this.dataGridViewTextBoxColumn41.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn41.Width = 24;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.HeaderText = "9";
            this.dataGridViewTextBoxColumn42.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn42.Width = 24;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.HeaderText = "A";
            this.dataGridViewTextBoxColumn43.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn43.Width = 24;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.HeaderText = "B";
            this.dataGridViewTextBoxColumn44.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn44.Width = 24;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.HeaderText = "C";
            this.dataGridViewTextBoxColumn45.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn45.Width = 24;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.HeaderText = "D";
            this.dataGridViewTextBoxColumn46.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn46.Width = 24;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.HeaderText = "E";
            this.dataGridViewTextBoxColumn47.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn47.Width = 24;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.HeaderText = "F";
            this.dataGridViewTextBoxColumn48.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn48.Width = 24;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "0";
            this.dataGridViewTextBoxColumn17.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn17.Width = 24;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "1";
            this.dataGridViewTextBoxColumn18.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn18.Width = 24;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "2";
            this.dataGridViewTextBoxColumn19.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn19.Width = 24;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "3";
            this.dataGridViewTextBoxColumn20.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn20.Width = 24;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.HeaderText = "4";
            this.dataGridViewTextBoxColumn21.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn21.Width = 24;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.HeaderText = "5";
            this.dataGridViewTextBoxColumn22.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn22.Width = 24;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.HeaderText = "6";
            this.dataGridViewTextBoxColumn23.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn23.Width = 24;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "7";
            this.dataGridViewTextBoxColumn24.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn24.Width = 24;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.HeaderText = "8";
            this.dataGridViewTextBoxColumn25.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn25.Width = 24;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.HeaderText = "9";
            this.dataGridViewTextBoxColumn26.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn26.Width = 24;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.HeaderText = "A";
            this.dataGridViewTextBoxColumn27.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn27.Width = 24;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.HeaderText = "B";
            this.dataGridViewTextBoxColumn28.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn28.Width = 24;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.HeaderText = "C";
            this.dataGridViewTextBoxColumn29.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn29.Width = 24;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.HeaderText = "D";
            this.dataGridViewTextBoxColumn30.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn30.Width = 24;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.HeaderText = "E";
            this.dataGridViewTextBoxColumn31.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn31.Width = 24;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.HeaderText = "F";
            this.dataGridViewTextBoxColumn32.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn32.Width = 24;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "0";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 24;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "1";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 24;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "2";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 24;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "3";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 24;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "4";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 24;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "5";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Width = 24;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "6";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.Width = 24;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "7";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.Width = 24;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "8";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.Width = 24;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "9";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn10.Width = 24;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "A";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn11.Width = 24;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "B";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn12.Width = 24;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "C";
            this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn13.Width = 24;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "D";
            this.dataGridViewTextBoxColumn14.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn14.Width = 24;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "E";
            this.dataGridViewTextBoxColumn15.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn15.Width = 24;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "F";
            this.dataGridViewTextBoxColumn16.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn16.Width = 24;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
    }
}