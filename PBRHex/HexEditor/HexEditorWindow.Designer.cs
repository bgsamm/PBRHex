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
            this.backArrow = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardArrow = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.dataGridViewTextBoxColumn225 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn226 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn227 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn228 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn229 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn230 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn231 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn232 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn233 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn234 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn235 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn236 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn237 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn238 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn239 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn240 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn209 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn210 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn211 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn212 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn213 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn214 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn215 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn216 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn217 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn218 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn219 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn220 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn221 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn222 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn223 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn224 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn193 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn194 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn195 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn196 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn197 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn198 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn199 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn200 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn201 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn202 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn203 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn204 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn205 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn206 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn207 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn208 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn177 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn178 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn179 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn180 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn181 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn182 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn183 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn184 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn185 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn186 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn187 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn188 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn189 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn190 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn191 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn192 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn161 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn162 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn163 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn164 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn165 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn166 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn167 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn168 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn169 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn170 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn171 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn172 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn173 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn174 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn175 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn176 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn145 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn146 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn147 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn148 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn149 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn150 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn151 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn152 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn153 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn154 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn155 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn156 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn157 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn158 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn159 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn160 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn129 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn130 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn131 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn132 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn133 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn134 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn135 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn136 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn137 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn138 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn139 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn140 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn141 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn142 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn143 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn144 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn113 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn114 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn115 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn116 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn117 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn118 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn119 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn120 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn121 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn122 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn123 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn124 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn125 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn126 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn127 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn128 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn97 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn98 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn99 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn101 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn102 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn103 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn104 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn105 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn106 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn107 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn108 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn109 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn110 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn111 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn112 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn81 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn82 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn83 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn84 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn85 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn86 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn87 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn88 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn89 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn90 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn91 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn92 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn93 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn94 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn95 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn96 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn65 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn66 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn67 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn68 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn69 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn72 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn73 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn74 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn75 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn76 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn77 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn78 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn79 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn59 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn62 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn63 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.deleteLabelMenuItem.Click += new System.EventHandler(this.DeleteLabelMenuItem_Click);
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
            this.backArrow,
            this.forwardArrow,
            this.undoMenuItem,
            this.redoMenuItem,
            this.deleteFileMenuItem,
            this.newFileMenuItem,
            this.openFileMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(896, 30);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // backArrow
            // 
            this.backArrow.Enabled = false;
            this.backArrow.Image = ((System.Drawing.Image)(resources.GetObject("backArrow.Image")));
            this.backArrow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.backArrow.Name = "backArrow";
            this.backArrow.Size = new System.Drawing.Size(28, 26);
            this.backArrow.ToolTipText = "Previous Location";
            this.backArrow.Click += new System.EventHandler(this.BackArrowMenuItem_Click);
            // 
            // forwardArrow
            // 
            this.forwardArrow.Enabled = false;
            this.forwardArrow.Image = ((System.Drawing.Image)(resources.GetObject("forwardArrow.Image")));
            this.forwardArrow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.forwardArrow.Name = "forwardArrow";
            this.forwardArrow.Size = new System.Drawing.Size(28, 26);
            this.forwardArrow.ToolTipText = "Next Location";
            this.forwardArrow.Click += new System.EventHandler(this.ForwardArrowMenuItem_Click);
            // 
            // undoMenuItem
            // 
            this.undoMenuItem.Enabled = false;
            this.undoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoMenuItem.Image")));
            this.undoMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.undoMenuItem.Name = "undoMenuItem";
            this.undoMenuItem.Size = new System.Drawing.Size(28, 26);
            this.undoMenuItem.ToolTipText = "Undo";
            this.undoMenuItem.Click += new System.EventHandler(this.UndoMenuItem_Click);
            // 
            // redoMenuItem
            // 
            this.redoMenuItem.Enabled = false;
            this.redoMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoMenuItem.Image")));
            this.redoMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.redoMenuItem.Name = "redoMenuItem";
            this.redoMenuItem.Size = new System.Drawing.Size(28, 26);
            this.redoMenuItem.ToolTipText = "Redo";
            this.redoMenuItem.Click += new System.EventHandler(this.RedoMenuItem_Click);
            // 
            // deleteFileMenuItem
            // 
            this.deleteFileMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deleteFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteFileMenuItem.Image")));
            this.deleteFileMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteFileMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.deleteFileMenuItem.Name = "deleteFileMenuItem";
            this.deleteFileMenuItem.Size = new System.Drawing.Size(28, 26);
            this.deleteFileMenuItem.ToolTipText = "Delete File";
            this.deleteFileMenuItem.Click += new System.EventHandler(this.DeleteFileMenuItem_Click);
            // 
            // newFileMenuItem
            // 
            this.newFileMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.newFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newFileMenuItem.Image")));
            this.newFileMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newFileMenuItem.Name = "newFileMenuItem";
            this.newFileMenuItem.Size = new System.Drawing.Size(28, 26);
            this.newFileMenuItem.ToolTipText = "New File";
            this.newFileMenuItem.Click += new System.EventHandler(this.NewFileMenuItem_Click);
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.openFileMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileMenuItem.Image")));
            this.openFileMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.Size = new System.Drawing.Size(28, 26);
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
            this.dataGridViewTextBoxColumn225,
            this.dataGridViewTextBoxColumn226,
            this.dataGridViewTextBoxColumn227,
            this.dataGridViewTextBoxColumn228,
            this.dataGridViewTextBoxColumn229,
            this.dataGridViewTextBoxColumn230,
            this.dataGridViewTextBoxColumn231,
            this.dataGridViewTextBoxColumn232,
            this.dataGridViewTextBoxColumn233,
            this.dataGridViewTextBoxColumn234,
            this.dataGridViewTextBoxColumn235,
            this.dataGridViewTextBoxColumn236,
            this.dataGridViewTextBoxColumn237,
            this.dataGridViewTextBoxColumn238,
            this.dataGridViewTextBoxColumn239,
            this.dataGridViewTextBoxColumn240,
            this.dataGridViewTextBoxColumn209,
            this.dataGridViewTextBoxColumn210,
            this.dataGridViewTextBoxColumn211,
            this.dataGridViewTextBoxColumn212,
            this.dataGridViewTextBoxColumn213,
            this.dataGridViewTextBoxColumn214,
            this.dataGridViewTextBoxColumn215,
            this.dataGridViewTextBoxColumn216,
            this.dataGridViewTextBoxColumn217,
            this.dataGridViewTextBoxColumn218,
            this.dataGridViewTextBoxColumn219,
            this.dataGridViewTextBoxColumn220,
            this.dataGridViewTextBoxColumn221,
            this.dataGridViewTextBoxColumn222,
            this.dataGridViewTextBoxColumn223,
            this.dataGridViewTextBoxColumn224,
            this.dataGridViewTextBoxColumn193,
            this.dataGridViewTextBoxColumn194,
            this.dataGridViewTextBoxColumn195,
            this.dataGridViewTextBoxColumn196,
            this.dataGridViewTextBoxColumn197,
            this.dataGridViewTextBoxColumn198,
            this.dataGridViewTextBoxColumn199,
            this.dataGridViewTextBoxColumn200,
            this.dataGridViewTextBoxColumn201,
            this.dataGridViewTextBoxColumn202,
            this.dataGridViewTextBoxColumn203,
            this.dataGridViewTextBoxColumn204,
            this.dataGridViewTextBoxColumn205,
            this.dataGridViewTextBoxColumn206,
            this.dataGridViewTextBoxColumn207,
            this.dataGridViewTextBoxColumn208,
            this.dataGridViewTextBoxColumn177,
            this.dataGridViewTextBoxColumn178,
            this.dataGridViewTextBoxColumn179,
            this.dataGridViewTextBoxColumn180,
            this.dataGridViewTextBoxColumn181,
            this.dataGridViewTextBoxColumn182,
            this.dataGridViewTextBoxColumn183,
            this.dataGridViewTextBoxColumn184,
            this.dataGridViewTextBoxColumn185,
            this.dataGridViewTextBoxColumn186,
            this.dataGridViewTextBoxColumn187,
            this.dataGridViewTextBoxColumn188,
            this.dataGridViewTextBoxColumn189,
            this.dataGridViewTextBoxColumn190,
            this.dataGridViewTextBoxColumn191,
            this.dataGridViewTextBoxColumn192,
            this.dataGridViewTextBoxColumn161,
            this.dataGridViewTextBoxColumn162,
            this.dataGridViewTextBoxColumn163,
            this.dataGridViewTextBoxColumn164,
            this.dataGridViewTextBoxColumn165,
            this.dataGridViewTextBoxColumn166,
            this.dataGridViewTextBoxColumn167,
            this.dataGridViewTextBoxColumn168,
            this.dataGridViewTextBoxColumn169,
            this.dataGridViewTextBoxColumn170,
            this.dataGridViewTextBoxColumn171,
            this.dataGridViewTextBoxColumn172,
            this.dataGridViewTextBoxColumn173,
            this.dataGridViewTextBoxColumn174,
            this.dataGridViewTextBoxColumn175,
            this.dataGridViewTextBoxColumn176,
            this.dataGridViewTextBoxColumn145,
            this.dataGridViewTextBoxColumn146,
            this.dataGridViewTextBoxColumn147,
            this.dataGridViewTextBoxColumn148,
            this.dataGridViewTextBoxColumn149,
            this.dataGridViewTextBoxColumn150,
            this.dataGridViewTextBoxColumn151,
            this.dataGridViewTextBoxColumn152,
            this.dataGridViewTextBoxColumn153,
            this.dataGridViewTextBoxColumn154,
            this.dataGridViewTextBoxColumn155,
            this.dataGridViewTextBoxColumn156,
            this.dataGridViewTextBoxColumn157,
            this.dataGridViewTextBoxColumn158,
            this.dataGridViewTextBoxColumn159,
            this.dataGridViewTextBoxColumn160,
            this.dataGridViewTextBoxColumn129,
            this.dataGridViewTextBoxColumn130,
            this.dataGridViewTextBoxColumn131,
            this.dataGridViewTextBoxColumn132,
            this.dataGridViewTextBoxColumn133,
            this.dataGridViewTextBoxColumn134,
            this.dataGridViewTextBoxColumn135,
            this.dataGridViewTextBoxColumn136,
            this.dataGridViewTextBoxColumn137,
            this.dataGridViewTextBoxColumn138,
            this.dataGridViewTextBoxColumn139,
            this.dataGridViewTextBoxColumn140,
            this.dataGridViewTextBoxColumn141,
            this.dataGridViewTextBoxColumn142,
            this.dataGridViewTextBoxColumn143,
            this.dataGridViewTextBoxColumn144,
            this.dataGridViewTextBoxColumn113,
            this.dataGridViewTextBoxColumn114,
            this.dataGridViewTextBoxColumn115,
            this.dataGridViewTextBoxColumn116,
            this.dataGridViewTextBoxColumn117,
            this.dataGridViewTextBoxColumn118,
            this.dataGridViewTextBoxColumn119,
            this.dataGridViewTextBoxColumn120,
            this.dataGridViewTextBoxColumn121,
            this.dataGridViewTextBoxColumn122,
            this.dataGridViewTextBoxColumn123,
            this.dataGridViewTextBoxColumn124,
            this.dataGridViewTextBoxColumn125,
            this.dataGridViewTextBoxColumn126,
            this.dataGridViewTextBoxColumn127,
            this.dataGridViewTextBoxColumn128,
            this.dataGridViewTextBoxColumn97,
            this.dataGridViewTextBoxColumn98,
            this.dataGridViewTextBoxColumn99,
            this.dataGridViewTextBoxColumn100,
            this.dataGridViewTextBoxColumn101,
            this.dataGridViewTextBoxColumn102,
            this.dataGridViewTextBoxColumn103,
            this.dataGridViewTextBoxColumn104,
            this.dataGridViewTextBoxColumn105,
            this.dataGridViewTextBoxColumn106,
            this.dataGridViewTextBoxColumn107,
            this.dataGridViewTextBoxColumn108,
            this.dataGridViewTextBoxColumn109,
            this.dataGridViewTextBoxColumn110,
            this.dataGridViewTextBoxColumn111,
            this.dataGridViewTextBoxColumn112,
            this.dataGridViewTextBoxColumn81,
            this.dataGridViewTextBoxColumn82,
            this.dataGridViewTextBoxColumn83,
            this.dataGridViewTextBoxColumn84,
            this.dataGridViewTextBoxColumn85,
            this.dataGridViewTextBoxColumn86,
            this.dataGridViewTextBoxColumn87,
            this.dataGridViewTextBoxColumn88,
            this.dataGridViewTextBoxColumn89,
            this.dataGridViewTextBoxColumn90,
            this.dataGridViewTextBoxColumn91,
            this.dataGridViewTextBoxColumn92,
            this.dataGridViewTextBoxColumn93,
            this.dataGridViewTextBoxColumn94,
            this.dataGridViewTextBoxColumn95,
            this.dataGridViewTextBoxColumn96,
            this.dataGridViewTextBoxColumn65,
            this.dataGridViewTextBoxColumn66,
            this.dataGridViewTextBoxColumn67,
            this.dataGridViewTextBoxColumn68,
            this.dataGridViewTextBoxColumn69,
            this.dataGridViewTextBoxColumn70,
            this.dataGridViewTextBoxColumn71,
            this.dataGridViewTextBoxColumn72,
            this.dataGridViewTextBoxColumn73,
            this.dataGridViewTextBoxColumn74,
            this.dataGridViewTextBoxColumn75,
            this.dataGridViewTextBoxColumn76,
            this.dataGridViewTextBoxColumn77,
            this.dataGridViewTextBoxColumn78,
            this.dataGridViewTextBoxColumn79,
            this.dataGridViewTextBoxColumn80,
            this.dataGridViewTextBoxColumn49,
            this.dataGridViewTextBoxColumn50,
            this.dataGridViewTextBoxColumn51,
            this.dataGridViewTextBoxColumn52,
            this.dataGridViewTextBoxColumn53,
            this.dataGridViewTextBoxColumn54,
            this.dataGridViewTextBoxColumn55,
            this.dataGridViewTextBoxColumn56,
            this.dataGridViewTextBoxColumn57,
            this.dataGridViewTextBoxColumn58,
            this.dataGridViewTextBoxColumn59,
            this.dataGridViewTextBoxColumn60,
            this.dataGridViewTextBoxColumn61,
            this.dataGridViewTextBoxColumn62,
            this.dataGridViewTextBoxColumn63,
            this.dataGridViewTextBoxColumn64,
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
            // dataGridViewTextBoxColumn225
            // 
            this.dataGridViewTextBoxColumn225.HeaderText = "0";
            this.dataGridViewTextBoxColumn225.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn225.Name = "dataGridViewTextBoxColumn225";
            this.dataGridViewTextBoxColumn225.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn225.Width = 24;
            // 
            // dataGridViewTextBoxColumn226
            // 
            this.dataGridViewTextBoxColumn226.HeaderText = "1";
            this.dataGridViewTextBoxColumn226.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn226.Name = "dataGridViewTextBoxColumn226";
            this.dataGridViewTextBoxColumn226.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn226.Width = 24;
            // 
            // dataGridViewTextBoxColumn227
            // 
            this.dataGridViewTextBoxColumn227.HeaderText = "2";
            this.dataGridViewTextBoxColumn227.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn227.Name = "dataGridViewTextBoxColumn227";
            this.dataGridViewTextBoxColumn227.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn227.Width = 24;
            // 
            // dataGridViewTextBoxColumn228
            // 
            this.dataGridViewTextBoxColumn228.HeaderText = "3";
            this.dataGridViewTextBoxColumn228.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn228.Name = "dataGridViewTextBoxColumn228";
            this.dataGridViewTextBoxColumn228.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn228.Width = 24;
            // 
            // dataGridViewTextBoxColumn229
            // 
            this.dataGridViewTextBoxColumn229.HeaderText = "4";
            this.dataGridViewTextBoxColumn229.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn229.Name = "dataGridViewTextBoxColumn229";
            this.dataGridViewTextBoxColumn229.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn229.Width = 24;
            // 
            // dataGridViewTextBoxColumn230
            // 
            this.dataGridViewTextBoxColumn230.HeaderText = "5";
            this.dataGridViewTextBoxColumn230.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn230.Name = "dataGridViewTextBoxColumn230";
            this.dataGridViewTextBoxColumn230.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn230.Width = 24;
            // 
            // dataGridViewTextBoxColumn231
            // 
            this.dataGridViewTextBoxColumn231.HeaderText = "6";
            this.dataGridViewTextBoxColumn231.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn231.Name = "dataGridViewTextBoxColumn231";
            this.dataGridViewTextBoxColumn231.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn231.Width = 24;
            // 
            // dataGridViewTextBoxColumn232
            // 
            this.dataGridViewTextBoxColumn232.HeaderText = "7";
            this.dataGridViewTextBoxColumn232.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn232.Name = "dataGridViewTextBoxColumn232";
            this.dataGridViewTextBoxColumn232.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn232.Width = 24;
            // 
            // dataGridViewTextBoxColumn233
            // 
            this.dataGridViewTextBoxColumn233.HeaderText = "8";
            this.dataGridViewTextBoxColumn233.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn233.Name = "dataGridViewTextBoxColumn233";
            this.dataGridViewTextBoxColumn233.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn233.Width = 24;
            // 
            // dataGridViewTextBoxColumn234
            // 
            this.dataGridViewTextBoxColumn234.HeaderText = "9";
            this.dataGridViewTextBoxColumn234.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn234.Name = "dataGridViewTextBoxColumn234";
            this.dataGridViewTextBoxColumn234.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn234.Width = 24;
            // 
            // dataGridViewTextBoxColumn235
            // 
            this.dataGridViewTextBoxColumn235.HeaderText = "A";
            this.dataGridViewTextBoxColumn235.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn235.Name = "dataGridViewTextBoxColumn235";
            this.dataGridViewTextBoxColumn235.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn235.Width = 24;
            // 
            // dataGridViewTextBoxColumn236
            // 
            this.dataGridViewTextBoxColumn236.HeaderText = "B";
            this.dataGridViewTextBoxColumn236.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn236.Name = "dataGridViewTextBoxColumn236";
            this.dataGridViewTextBoxColumn236.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn236.Width = 24;
            // 
            // dataGridViewTextBoxColumn237
            // 
            this.dataGridViewTextBoxColumn237.HeaderText = "C";
            this.dataGridViewTextBoxColumn237.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn237.Name = "dataGridViewTextBoxColumn237";
            this.dataGridViewTextBoxColumn237.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn237.Width = 24;
            // 
            // dataGridViewTextBoxColumn238
            // 
            this.dataGridViewTextBoxColumn238.HeaderText = "D";
            this.dataGridViewTextBoxColumn238.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn238.Name = "dataGridViewTextBoxColumn238";
            this.dataGridViewTextBoxColumn238.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn238.Width = 24;
            // 
            // dataGridViewTextBoxColumn239
            // 
            this.dataGridViewTextBoxColumn239.HeaderText = "E";
            this.dataGridViewTextBoxColumn239.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn239.Name = "dataGridViewTextBoxColumn239";
            this.dataGridViewTextBoxColumn239.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn239.Width = 24;
            // 
            // dataGridViewTextBoxColumn240
            // 
            this.dataGridViewTextBoxColumn240.HeaderText = "F";
            this.dataGridViewTextBoxColumn240.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn240.Name = "dataGridViewTextBoxColumn240";
            this.dataGridViewTextBoxColumn240.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn240.Width = 24;
            // 
            // dataGridViewTextBoxColumn209
            // 
            this.dataGridViewTextBoxColumn209.HeaderText = "0";
            this.dataGridViewTextBoxColumn209.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn209.Name = "dataGridViewTextBoxColumn209";
            this.dataGridViewTextBoxColumn209.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn209.Width = 24;
            // 
            // dataGridViewTextBoxColumn210
            // 
            this.dataGridViewTextBoxColumn210.HeaderText = "1";
            this.dataGridViewTextBoxColumn210.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn210.Name = "dataGridViewTextBoxColumn210";
            this.dataGridViewTextBoxColumn210.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn210.Width = 24;
            // 
            // dataGridViewTextBoxColumn211
            // 
            this.dataGridViewTextBoxColumn211.HeaderText = "2";
            this.dataGridViewTextBoxColumn211.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn211.Name = "dataGridViewTextBoxColumn211";
            this.dataGridViewTextBoxColumn211.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn211.Width = 24;
            // 
            // dataGridViewTextBoxColumn212
            // 
            this.dataGridViewTextBoxColumn212.HeaderText = "3";
            this.dataGridViewTextBoxColumn212.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn212.Name = "dataGridViewTextBoxColumn212";
            this.dataGridViewTextBoxColumn212.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn212.Width = 24;
            // 
            // dataGridViewTextBoxColumn213
            // 
            this.dataGridViewTextBoxColumn213.HeaderText = "4";
            this.dataGridViewTextBoxColumn213.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn213.Name = "dataGridViewTextBoxColumn213";
            this.dataGridViewTextBoxColumn213.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn213.Width = 24;
            // 
            // dataGridViewTextBoxColumn214
            // 
            this.dataGridViewTextBoxColumn214.HeaderText = "5";
            this.dataGridViewTextBoxColumn214.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn214.Name = "dataGridViewTextBoxColumn214";
            this.dataGridViewTextBoxColumn214.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn214.Width = 24;
            // 
            // dataGridViewTextBoxColumn215
            // 
            this.dataGridViewTextBoxColumn215.HeaderText = "6";
            this.dataGridViewTextBoxColumn215.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn215.Name = "dataGridViewTextBoxColumn215";
            this.dataGridViewTextBoxColumn215.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn215.Width = 24;
            // 
            // dataGridViewTextBoxColumn216
            // 
            this.dataGridViewTextBoxColumn216.HeaderText = "7";
            this.dataGridViewTextBoxColumn216.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn216.Name = "dataGridViewTextBoxColumn216";
            this.dataGridViewTextBoxColumn216.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn216.Width = 24;
            // 
            // dataGridViewTextBoxColumn217
            // 
            this.dataGridViewTextBoxColumn217.HeaderText = "8";
            this.dataGridViewTextBoxColumn217.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn217.Name = "dataGridViewTextBoxColumn217";
            this.dataGridViewTextBoxColumn217.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn217.Width = 24;
            // 
            // dataGridViewTextBoxColumn218
            // 
            this.dataGridViewTextBoxColumn218.HeaderText = "9";
            this.dataGridViewTextBoxColumn218.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn218.Name = "dataGridViewTextBoxColumn218";
            this.dataGridViewTextBoxColumn218.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn218.Width = 24;
            // 
            // dataGridViewTextBoxColumn219
            // 
            this.dataGridViewTextBoxColumn219.HeaderText = "A";
            this.dataGridViewTextBoxColumn219.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn219.Name = "dataGridViewTextBoxColumn219";
            this.dataGridViewTextBoxColumn219.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn219.Width = 24;
            // 
            // dataGridViewTextBoxColumn220
            // 
            this.dataGridViewTextBoxColumn220.HeaderText = "B";
            this.dataGridViewTextBoxColumn220.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn220.Name = "dataGridViewTextBoxColumn220";
            this.dataGridViewTextBoxColumn220.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn220.Width = 24;
            // 
            // dataGridViewTextBoxColumn221
            // 
            this.dataGridViewTextBoxColumn221.HeaderText = "C";
            this.dataGridViewTextBoxColumn221.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn221.Name = "dataGridViewTextBoxColumn221";
            this.dataGridViewTextBoxColumn221.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn221.Width = 24;
            // 
            // dataGridViewTextBoxColumn222
            // 
            this.dataGridViewTextBoxColumn222.HeaderText = "D";
            this.dataGridViewTextBoxColumn222.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn222.Name = "dataGridViewTextBoxColumn222";
            this.dataGridViewTextBoxColumn222.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn222.Width = 24;
            // 
            // dataGridViewTextBoxColumn223
            // 
            this.dataGridViewTextBoxColumn223.HeaderText = "E";
            this.dataGridViewTextBoxColumn223.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn223.Name = "dataGridViewTextBoxColumn223";
            this.dataGridViewTextBoxColumn223.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn223.Width = 24;
            // 
            // dataGridViewTextBoxColumn224
            // 
            this.dataGridViewTextBoxColumn224.HeaderText = "F";
            this.dataGridViewTextBoxColumn224.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn224.Name = "dataGridViewTextBoxColumn224";
            this.dataGridViewTextBoxColumn224.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn224.Width = 24;
            // 
            // dataGridViewTextBoxColumn193
            // 
            this.dataGridViewTextBoxColumn193.HeaderText = "0";
            this.dataGridViewTextBoxColumn193.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn193.Name = "dataGridViewTextBoxColumn193";
            this.dataGridViewTextBoxColumn193.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn193.Width = 24;
            // 
            // dataGridViewTextBoxColumn194
            // 
            this.dataGridViewTextBoxColumn194.HeaderText = "1";
            this.dataGridViewTextBoxColumn194.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn194.Name = "dataGridViewTextBoxColumn194";
            this.dataGridViewTextBoxColumn194.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn194.Width = 24;
            // 
            // dataGridViewTextBoxColumn195
            // 
            this.dataGridViewTextBoxColumn195.HeaderText = "2";
            this.dataGridViewTextBoxColumn195.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn195.Name = "dataGridViewTextBoxColumn195";
            this.dataGridViewTextBoxColumn195.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn195.Width = 24;
            // 
            // dataGridViewTextBoxColumn196
            // 
            this.dataGridViewTextBoxColumn196.HeaderText = "3";
            this.dataGridViewTextBoxColumn196.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn196.Name = "dataGridViewTextBoxColumn196";
            this.dataGridViewTextBoxColumn196.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn196.Width = 24;
            // 
            // dataGridViewTextBoxColumn197
            // 
            this.dataGridViewTextBoxColumn197.HeaderText = "4";
            this.dataGridViewTextBoxColumn197.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn197.Name = "dataGridViewTextBoxColumn197";
            this.dataGridViewTextBoxColumn197.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn197.Width = 24;
            // 
            // dataGridViewTextBoxColumn198
            // 
            this.dataGridViewTextBoxColumn198.HeaderText = "5";
            this.dataGridViewTextBoxColumn198.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn198.Name = "dataGridViewTextBoxColumn198";
            this.dataGridViewTextBoxColumn198.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn198.Width = 24;
            // 
            // dataGridViewTextBoxColumn199
            // 
            this.dataGridViewTextBoxColumn199.HeaderText = "6";
            this.dataGridViewTextBoxColumn199.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn199.Name = "dataGridViewTextBoxColumn199";
            this.dataGridViewTextBoxColumn199.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn199.Width = 24;
            // 
            // dataGridViewTextBoxColumn200
            // 
            this.dataGridViewTextBoxColumn200.HeaderText = "7";
            this.dataGridViewTextBoxColumn200.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn200.Name = "dataGridViewTextBoxColumn200";
            this.dataGridViewTextBoxColumn200.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn200.Width = 24;
            // 
            // dataGridViewTextBoxColumn201
            // 
            this.dataGridViewTextBoxColumn201.HeaderText = "8";
            this.dataGridViewTextBoxColumn201.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn201.Name = "dataGridViewTextBoxColumn201";
            this.dataGridViewTextBoxColumn201.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn201.Width = 24;
            // 
            // dataGridViewTextBoxColumn202
            // 
            this.dataGridViewTextBoxColumn202.HeaderText = "9";
            this.dataGridViewTextBoxColumn202.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn202.Name = "dataGridViewTextBoxColumn202";
            this.dataGridViewTextBoxColumn202.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn202.Width = 24;
            // 
            // dataGridViewTextBoxColumn203
            // 
            this.dataGridViewTextBoxColumn203.HeaderText = "A";
            this.dataGridViewTextBoxColumn203.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn203.Name = "dataGridViewTextBoxColumn203";
            this.dataGridViewTextBoxColumn203.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn203.Width = 24;
            // 
            // dataGridViewTextBoxColumn204
            // 
            this.dataGridViewTextBoxColumn204.HeaderText = "B";
            this.dataGridViewTextBoxColumn204.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn204.Name = "dataGridViewTextBoxColumn204";
            this.dataGridViewTextBoxColumn204.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn204.Width = 24;
            // 
            // dataGridViewTextBoxColumn205
            // 
            this.dataGridViewTextBoxColumn205.HeaderText = "C";
            this.dataGridViewTextBoxColumn205.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn205.Name = "dataGridViewTextBoxColumn205";
            this.dataGridViewTextBoxColumn205.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn205.Width = 24;
            // 
            // dataGridViewTextBoxColumn206
            // 
            this.dataGridViewTextBoxColumn206.HeaderText = "D";
            this.dataGridViewTextBoxColumn206.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn206.Name = "dataGridViewTextBoxColumn206";
            this.dataGridViewTextBoxColumn206.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn206.Width = 24;
            // 
            // dataGridViewTextBoxColumn207
            // 
            this.dataGridViewTextBoxColumn207.HeaderText = "E";
            this.dataGridViewTextBoxColumn207.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn207.Name = "dataGridViewTextBoxColumn207";
            this.dataGridViewTextBoxColumn207.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn207.Width = 24;
            // 
            // dataGridViewTextBoxColumn208
            // 
            this.dataGridViewTextBoxColumn208.HeaderText = "F";
            this.dataGridViewTextBoxColumn208.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn208.Name = "dataGridViewTextBoxColumn208";
            this.dataGridViewTextBoxColumn208.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn208.Width = 24;
            // 
            // dataGridViewTextBoxColumn177
            // 
            this.dataGridViewTextBoxColumn177.HeaderText = "0";
            this.dataGridViewTextBoxColumn177.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn177.Name = "dataGridViewTextBoxColumn177";
            this.dataGridViewTextBoxColumn177.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn177.Width = 24;
            // 
            // dataGridViewTextBoxColumn178
            // 
            this.dataGridViewTextBoxColumn178.HeaderText = "1";
            this.dataGridViewTextBoxColumn178.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn178.Name = "dataGridViewTextBoxColumn178";
            this.dataGridViewTextBoxColumn178.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn178.Width = 24;
            // 
            // dataGridViewTextBoxColumn179
            // 
            this.dataGridViewTextBoxColumn179.HeaderText = "2";
            this.dataGridViewTextBoxColumn179.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn179.Name = "dataGridViewTextBoxColumn179";
            this.dataGridViewTextBoxColumn179.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn179.Width = 24;
            // 
            // dataGridViewTextBoxColumn180
            // 
            this.dataGridViewTextBoxColumn180.HeaderText = "3";
            this.dataGridViewTextBoxColumn180.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn180.Name = "dataGridViewTextBoxColumn180";
            this.dataGridViewTextBoxColumn180.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn180.Width = 24;
            // 
            // dataGridViewTextBoxColumn181
            // 
            this.dataGridViewTextBoxColumn181.HeaderText = "4";
            this.dataGridViewTextBoxColumn181.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn181.Name = "dataGridViewTextBoxColumn181";
            this.dataGridViewTextBoxColumn181.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn181.Width = 24;
            // 
            // dataGridViewTextBoxColumn182
            // 
            this.dataGridViewTextBoxColumn182.HeaderText = "5";
            this.dataGridViewTextBoxColumn182.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn182.Name = "dataGridViewTextBoxColumn182";
            this.dataGridViewTextBoxColumn182.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn182.Width = 24;
            // 
            // dataGridViewTextBoxColumn183
            // 
            this.dataGridViewTextBoxColumn183.HeaderText = "6";
            this.dataGridViewTextBoxColumn183.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn183.Name = "dataGridViewTextBoxColumn183";
            this.dataGridViewTextBoxColumn183.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn183.Width = 24;
            // 
            // dataGridViewTextBoxColumn184
            // 
            this.dataGridViewTextBoxColumn184.HeaderText = "7";
            this.dataGridViewTextBoxColumn184.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn184.Name = "dataGridViewTextBoxColumn184";
            this.dataGridViewTextBoxColumn184.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn184.Width = 24;
            // 
            // dataGridViewTextBoxColumn185
            // 
            this.dataGridViewTextBoxColumn185.HeaderText = "8";
            this.dataGridViewTextBoxColumn185.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn185.Name = "dataGridViewTextBoxColumn185";
            this.dataGridViewTextBoxColumn185.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn185.Width = 24;
            // 
            // dataGridViewTextBoxColumn186
            // 
            this.dataGridViewTextBoxColumn186.HeaderText = "9";
            this.dataGridViewTextBoxColumn186.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn186.Name = "dataGridViewTextBoxColumn186";
            this.dataGridViewTextBoxColumn186.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn186.Width = 24;
            // 
            // dataGridViewTextBoxColumn187
            // 
            this.dataGridViewTextBoxColumn187.HeaderText = "A";
            this.dataGridViewTextBoxColumn187.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn187.Name = "dataGridViewTextBoxColumn187";
            this.dataGridViewTextBoxColumn187.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn187.Width = 24;
            // 
            // dataGridViewTextBoxColumn188
            // 
            this.dataGridViewTextBoxColumn188.HeaderText = "B";
            this.dataGridViewTextBoxColumn188.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn188.Name = "dataGridViewTextBoxColumn188";
            this.dataGridViewTextBoxColumn188.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn188.Width = 24;
            // 
            // dataGridViewTextBoxColumn189
            // 
            this.dataGridViewTextBoxColumn189.HeaderText = "C";
            this.dataGridViewTextBoxColumn189.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn189.Name = "dataGridViewTextBoxColumn189";
            this.dataGridViewTextBoxColumn189.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn189.Width = 24;
            // 
            // dataGridViewTextBoxColumn190
            // 
            this.dataGridViewTextBoxColumn190.HeaderText = "D";
            this.dataGridViewTextBoxColumn190.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn190.Name = "dataGridViewTextBoxColumn190";
            this.dataGridViewTextBoxColumn190.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn190.Width = 24;
            // 
            // dataGridViewTextBoxColumn191
            // 
            this.dataGridViewTextBoxColumn191.HeaderText = "E";
            this.dataGridViewTextBoxColumn191.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn191.Name = "dataGridViewTextBoxColumn191";
            this.dataGridViewTextBoxColumn191.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn191.Width = 24;
            // 
            // dataGridViewTextBoxColumn192
            // 
            this.dataGridViewTextBoxColumn192.HeaderText = "F";
            this.dataGridViewTextBoxColumn192.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn192.Name = "dataGridViewTextBoxColumn192";
            this.dataGridViewTextBoxColumn192.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn192.Width = 24;
            // 
            // dataGridViewTextBoxColumn161
            // 
            this.dataGridViewTextBoxColumn161.HeaderText = "0";
            this.dataGridViewTextBoxColumn161.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn161.Name = "dataGridViewTextBoxColumn161";
            this.dataGridViewTextBoxColumn161.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn161.Width = 24;
            // 
            // dataGridViewTextBoxColumn162
            // 
            this.dataGridViewTextBoxColumn162.HeaderText = "1";
            this.dataGridViewTextBoxColumn162.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn162.Name = "dataGridViewTextBoxColumn162";
            this.dataGridViewTextBoxColumn162.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn162.Width = 24;
            // 
            // dataGridViewTextBoxColumn163
            // 
            this.dataGridViewTextBoxColumn163.HeaderText = "2";
            this.dataGridViewTextBoxColumn163.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn163.Name = "dataGridViewTextBoxColumn163";
            this.dataGridViewTextBoxColumn163.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn163.Width = 24;
            // 
            // dataGridViewTextBoxColumn164
            // 
            this.dataGridViewTextBoxColumn164.HeaderText = "3";
            this.dataGridViewTextBoxColumn164.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn164.Name = "dataGridViewTextBoxColumn164";
            this.dataGridViewTextBoxColumn164.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn164.Width = 24;
            // 
            // dataGridViewTextBoxColumn165
            // 
            this.dataGridViewTextBoxColumn165.HeaderText = "4";
            this.dataGridViewTextBoxColumn165.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn165.Name = "dataGridViewTextBoxColumn165";
            this.dataGridViewTextBoxColumn165.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn165.Width = 24;
            // 
            // dataGridViewTextBoxColumn166
            // 
            this.dataGridViewTextBoxColumn166.HeaderText = "5";
            this.dataGridViewTextBoxColumn166.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn166.Name = "dataGridViewTextBoxColumn166";
            this.dataGridViewTextBoxColumn166.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn166.Width = 24;
            // 
            // dataGridViewTextBoxColumn167
            // 
            this.dataGridViewTextBoxColumn167.HeaderText = "6";
            this.dataGridViewTextBoxColumn167.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn167.Name = "dataGridViewTextBoxColumn167";
            this.dataGridViewTextBoxColumn167.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn167.Width = 24;
            // 
            // dataGridViewTextBoxColumn168
            // 
            this.dataGridViewTextBoxColumn168.HeaderText = "7";
            this.dataGridViewTextBoxColumn168.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn168.Name = "dataGridViewTextBoxColumn168";
            this.dataGridViewTextBoxColumn168.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn168.Width = 24;
            // 
            // dataGridViewTextBoxColumn169
            // 
            this.dataGridViewTextBoxColumn169.HeaderText = "8";
            this.dataGridViewTextBoxColumn169.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn169.Name = "dataGridViewTextBoxColumn169";
            this.dataGridViewTextBoxColumn169.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn169.Width = 24;
            // 
            // dataGridViewTextBoxColumn170
            // 
            this.dataGridViewTextBoxColumn170.HeaderText = "9";
            this.dataGridViewTextBoxColumn170.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn170.Name = "dataGridViewTextBoxColumn170";
            this.dataGridViewTextBoxColumn170.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn170.Width = 24;
            // 
            // dataGridViewTextBoxColumn171
            // 
            this.dataGridViewTextBoxColumn171.HeaderText = "A";
            this.dataGridViewTextBoxColumn171.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn171.Name = "dataGridViewTextBoxColumn171";
            this.dataGridViewTextBoxColumn171.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn171.Width = 24;
            // 
            // dataGridViewTextBoxColumn172
            // 
            this.dataGridViewTextBoxColumn172.HeaderText = "B";
            this.dataGridViewTextBoxColumn172.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn172.Name = "dataGridViewTextBoxColumn172";
            this.dataGridViewTextBoxColumn172.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn172.Width = 24;
            // 
            // dataGridViewTextBoxColumn173
            // 
            this.dataGridViewTextBoxColumn173.HeaderText = "C";
            this.dataGridViewTextBoxColumn173.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn173.Name = "dataGridViewTextBoxColumn173";
            this.dataGridViewTextBoxColumn173.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn173.Width = 24;
            // 
            // dataGridViewTextBoxColumn174
            // 
            this.dataGridViewTextBoxColumn174.HeaderText = "D";
            this.dataGridViewTextBoxColumn174.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn174.Name = "dataGridViewTextBoxColumn174";
            this.dataGridViewTextBoxColumn174.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn174.Width = 24;
            // 
            // dataGridViewTextBoxColumn175
            // 
            this.dataGridViewTextBoxColumn175.HeaderText = "E";
            this.dataGridViewTextBoxColumn175.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn175.Name = "dataGridViewTextBoxColumn175";
            this.dataGridViewTextBoxColumn175.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn175.Width = 24;
            // 
            // dataGridViewTextBoxColumn176
            // 
            this.dataGridViewTextBoxColumn176.HeaderText = "F";
            this.dataGridViewTextBoxColumn176.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn176.Name = "dataGridViewTextBoxColumn176";
            this.dataGridViewTextBoxColumn176.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn176.Width = 24;
            // 
            // dataGridViewTextBoxColumn145
            // 
            this.dataGridViewTextBoxColumn145.HeaderText = "0";
            this.dataGridViewTextBoxColumn145.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn145.Name = "dataGridViewTextBoxColumn145";
            this.dataGridViewTextBoxColumn145.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn145.Width = 24;
            // 
            // dataGridViewTextBoxColumn146
            // 
            this.dataGridViewTextBoxColumn146.HeaderText = "1";
            this.dataGridViewTextBoxColumn146.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn146.Name = "dataGridViewTextBoxColumn146";
            this.dataGridViewTextBoxColumn146.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn146.Width = 24;
            // 
            // dataGridViewTextBoxColumn147
            // 
            this.dataGridViewTextBoxColumn147.HeaderText = "2";
            this.dataGridViewTextBoxColumn147.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn147.Name = "dataGridViewTextBoxColumn147";
            this.dataGridViewTextBoxColumn147.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn147.Width = 24;
            // 
            // dataGridViewTextBoxColumn148
            // 
            this.dataGridViewTextBoxColumn148.HeaderText = "3";
            this.dataGridViewTextBoxColumn148.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn148.Name = "dataGridViewTextBoxColumn148";
            this.dataGridViewTextBoxColumn148.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn148.Width = 24;
            // 
            // dataGridViewTextBoxColumn149
            // 
            this.dataGridViewTextBoxColumn149.HeaderText = "4";
            this.dataGridViewTextBoxColumn149.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn149.Name = "dataGridViewTextBoxColumn149";
            this.dataGridViewTextBoxColumn149.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn149.Width = 24;
            // 
            // dataGridViewTextBoxColumn150
            // 
            this.dataGridViewTextBoxColumn150.HeaderText = "5";
            this.dataGridViewTextBoxColumn150.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn150.Name = "dataGridViewTextBoxColumn150";
            this.dataGridViewTextBoxColumn150.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn150.Width = 24;
            // 
            // dataGridViewTextBoxColumn151
            // 
            this.dataGridViewTextBoxColumn151.HeaderText = "6";
            this.dataGridViewTextBoxColumn151.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn151.Name = "dataGridViewTextBoxColumn151";
            this.dataGridViewTextBoxColumn151.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn151.Width = 24;
            // 
            // dataGridViewTextBoxColumn152
            // 
            this.dataGridViewTextBoxColumn152.HeaderText = "7";
            this.dataGridViewTextBoxColumn152.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn152.Name = "dataGridViewTextBoxColumn152";
            this.dataGridViewTextBoxColumn152.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn152.Width = 24;
            // 
            // dataGridViewTextBoxColumn153
            // 
            this.dataGridViewTextBoxColumn153.HeaderText = "8";
            this.dataGridViewTextBoxColumn153.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn153.Name = "dataGridViewTextBoxColumn153";
            this.dataGridViewTextBoxColumn153.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn153.Width = 24;
            // 
            // dataGridViewTextBoxColumn154
            // 
            this.dataGridViewTextBoxColumn154.HeaderText = "9";
            this.dataGridViewTextBoxColumn154.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn154.Name = "dataGridViewTextBoxColumn154";
            this.dataGridViewTextBoxColumn154.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn154.Width = 24;
            // 
            // dataGridViewTextBoxColumn155
            // 
            this.dataGridViewTextBoxColumn155.HeaderText = "A";
            this.dataGridViewTextBoxColumn155.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn155.Name = "dataGridViewTextBoxColumn155";
            this.dataGridViewTextBoxColumn155.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn155.Width = 24;
            // 
            // dataGridViewTextBoxColumn156
            // 
            this.dataGridViewTextBoxColumn156.HeaderText = "B";
            this.dataGridViewTextBoxColumn156.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn156.Name = "dataGridViewTextBoxColumn156";
            this.dataGridViewTextBoxColumn156.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn156.Width = 24;
            // 
            // dataGridViewTextBoxColumn157
            // 
            this.dataGridViewTextBoxColumn157.HeaderText = "C";
            this.dataGridViewTextBoxColumn157.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn157.Name = "dataGridViewTextBoxColumn157";
            this.dataGridViewTextBoxColumn157.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn157.Width = 24;
            // 
            // dataGridViewTextBoxColumn158
            // 
            this.dataGridViewTextBoxColumn158.HeaderText = "D";
            this.dataGridViewTextBoxColumn158.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn158.Name = "dataGridViewTextBoxColumn158";
            this.dataGridViewTextBoxColumn158.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn158.Width = 24;
            // 
            // dataGridViewTextBoxColumn159
            // 
            this.dataGridViewTextBoxColumn159.HeaderText = "E";
            this.dataGridViewTextBoxColumn159.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn159.Name = "dataGridViewTextBoxColumn159";
            this.dataGridViewTextBoxColumn159.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn159.Width = 24;
            // 
            // dataGridViewTextBoxColumn160
            // 
            this.dataGridViewTextBoxColumn160.HeaderText = "F";
            this.dataGridViewTextBoxColumn160.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn160.Name = "dataGridViewTextBoxColumn160";
            this.dataGridViewTextBoxColumn160.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn160.Width = 24;
            // 
            // dataGridViewTextBoxColumn129
            // 
            this.dataGridViewTextBoxColumn129.HeaderText = "0";
            this.dataGridViewTextBoxColumn129.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn129.Name = "dataGridViewTextBoxColumn129";
            this.dataGridViewTextBoxColumn129.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn129.Width = 24;
            // 
            // dataGridViewTextBoxColumn130
            // 
            this.dataGridViewTextBoxColumn130.HeaderText = "1";
            this.dataGridViewTextBoxColumn130.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn130.Name = "dataGridViewTextBoxColumn130";
            this.dataGridViewTextBoxColumn130.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn130.Width = 24;
            // 
            // dataGridViewTextBoxColumn131
            // 
            this.dataGridViewTextBoxColumn131.HeaderText = "2";
            this.dataGridViewTextBoxColumn131.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn131.Name = "dataGridViewTextBoxColumn131";
            this.dataGridViewTextBoxColumn131.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn131.Width = 24;
            // 
            // dataGridViewTextBoxColumn132
            // 
            this.dataGridViewTextBoxColumn132.HeaderText = "3";
            this.dataGridViewTextBoxColumn132.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn132.Name = "dataGridViewTextBoxColumn132";
            this.dataGridViewTextBoxColumn132.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn132.Width = 24;
            // 
            // dataGridViewTextBoxColumn133
            // 
            this.dataGridViewTextBoxColumn133.HeaderText = "4";
            this.dataGridViewTextBoxColumn133.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn133.Name = "dataGridViewTextBoxColumn133";
            this.dataGridViewTextBoxColumn133.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn133.Width = 24;
            // 
            // dataGridViewTextBoxColumn134
            // 
            this.dataGridViewTextBoxColumn134.HeaderText = "5";
            this.dataGridViewTextBoxColumn134.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn134.Name = "dataGridViewTextBoxColumn134";
            this.dataGridViewTextBoxColumn134.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn134.Width = 24;
            // 
            // dataGridViewTextBoxColumn135
            // 
            this.dataGridViewTextBoxColumn135.HeaderText = "6";
            this.dataGridViewTextBoxColumn135.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn135.Name = "dataGridViewTextBoxColumn135";
            this.dataGridViewTextBoxColumn135.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn135.Width = 24;
            // 
            // dataGridViewTextBoxColumn136
            // 
            this.dataGridViewTextBoxColumn136.HeaderText = "7";
            this.dataGridViewTextBoxColumn136.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn136.Name = "dataGridViewTextBoxColumn136";
            this.dataGridViewTextBoxColumn136.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn136.Width = 24;
            // 
            // dataGridViewTextBoxColumn137
            // 
            this.dataGridViewTextBoxColumn137.HeaderText = "8";
            this.dataGridViewTextBoxColumn137.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn137.Name = "dataGridViewTextBoxColumn137";
            this.dataGridViewTextBoxColumn137.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn137.Width = 24;
            // 
            // dataGridViewTextBoxColumn138
            // 
            this.dataGridViewTextBoxColumn138.HeaderText = "9";
            this.dataGridViewTextBoxColumn138.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn138.Name = "dataGridViewTextBoxColumn138";
            this.dataGridViewTextBoxColumn138.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn138.Width = 24;
            // 
            // dataGridViewTextBoxColumn139
            // 
            this.dataGridViewTextBoxColumn139.HeaderText = "A";
            this.dataGridViewTextBoxColumn139.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn139.Name = "dataGridViewTextBoxColumn139";
            this.dataGridViewTextBoxColumn139.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn139.Width = 24;
            // 
            // dataGridViewTextBoxColumn140
            // 
            this.dataGridViewTextBoxColumn140.HeaderText = "B";
            this.dataGridViewTextBoxColumn140.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn140.Name = "dataGridViewTextBoxColumn140";
            this.dataGridViewTextBoxColumn140.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn140.Width = 24;
            // 
            // dataGridViewTextBoxColumn141
            // 
            this.dataGridViewTextBoxColumn141.HeaderText = "C";
            this.dataGridViewTextBoxColumn141.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn141.Name = "dataGridViewTextBoxColumn141";
            this.dataGridViewTextBoxColumn141.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn141.Width = 24;
            // 
            // dataGridViewTextBoxColumn142
            // 
            this.dataGridViewTextBoxColumn142.HeaderText = "D";
            this.dataGridViewTextBoxColumn142.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn142.Name = "dataGridViewTextBoxColumn142";
            this.dataGridViewTextBoxColumn142.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn142.Width = 24;
            // 
            // dataGridViewTextBoxColumn143
            // 
            this.dataGridViewTextBoxColumn143.HeaderText = "E";
            this.dataGridViewTextBoxColumn143.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn143.Name = "dataGridViewTextBoxColumn143";
            this.dataGridViewTextBoxColumn143.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn143.Width = 24;
            // 
            // dataGridViewTextBoxColumn144
            // 
            this.dataGridViewTextBoxColumn144.HeaderText = "F";
            this.dataGridViewTextBoxColumn144.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn144.Name = "dataGridViewTextBoxColumn144";
            this.dataGridViewTextBoxColumn144.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn144.Width = 24;
            // 
            // dataGridViewTextBoxColumn113
            // 
            this.dataGridViewTextBoxColumn113.HeaderText = "0";
            this.dataGridViewTextBoxColumn113.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn113.Name = "dataGridViewTextBoxColumn113";
            this.dataGridViewTextBoxColumn113.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn113.Width = 24;
            // 
            // dataGridViewTextBoxColumn114
            // 
            this.dataGridViewTextBoxColumn114.HeaderText = "1";
            this.dataGridViewTextBoxColumn114.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn114.Name = "dataGridViewTextBoxColumn114";
            this.dataGridViewTextBoxColumn114.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn114.Width = 24;
            // 
            // dataGridViewTextBoxColumn115
            // 
            this.dataGridViewTextBoxColumn115.HeaderText = "2";
            this.dataGridViewTextBoxColumn115.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn115.Name = "dataGridViewTextBoxColumn115";
            this.dataGridViewTextBoxColumn115.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn115.Width = 24;
            // 
            // dataGridViewTextBoxColumn116
            // 
            this.dataGridViewTextBoxColumn116.HeaderText = "3";
            this.dataGridViewTextBoxColumn116.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn116.Name = "dataGridViewTextBoxColumn116";
            this.dataGridViewTextBoxColumn116.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn116.Width = 24;
            // 
            // dataGridViewTextBoxColumn117
            // 
            this.dataGridViewTextBoxColumn117.HeaderText = "4";
            this.dataGridViewTextBoxColumn117.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn117.Name = "dataGridViewTextBoxColumn117";
            this.dataGridViewTextBoxColumn117.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn117.Width = 24;
            // 
            // dataGridViewTextBoxColumn118
            // 
            this.dataGridViewTextBoxColumn118.HeaderText = "5";
            this.dataGridViewTextBoxColumn118.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn118.Name = "dataGridViewTextBoxColumn118";
            this.dataGridViewTextBoxColumn118.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn118.Width = 24;
            // 
            // dataGridViewTextBoxColumn119
            // 
            this.dataGridViewTextBoxColumn119.HeaderText = "6";
            this.dataGridViewTextBoxColumn119.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn119.Name = "dataGridViewTextBoxColumn119";
            this.dataGridViewTextBoxColumn119.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn119.Width = 24;
            // 
            // dataGridViewTextBoxColumn120
            // 
            this.dataGridViewTextBoxColumn120.HeaderText = "7";
            this.dataGridViewTextBoxColumn120.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn120.Name = "dataGridViewTextBoxColumn120";
            this.dataGridViewTextBoxColumn120.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn120.Width = 24;
            // 
            // dataGridViewTextBoxColumn121
            // 
            this.dataGridViewTextBoxColumn121.HeaderText = "8";
            this.dataGridViewTextBoxColumn121.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn121.Name = "dataGridViewTextBoxColumn121";
            this.dataGridViewTextBoxColumn121.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn121.Width = 24;
            // 
            // dataGridViewTextBoxColumn122
            // 
            this.dataGridViewTextBoxColumn122.HeaderText = "9";
            this.dataGridViewTextBoxColumn122.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn122.Name = "dataGridViewTextBoxColumn122";
            this.dataGridViewTextBoxColumn122.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn122.Width = 24;
            // 
            // dataGridViewTextBoxColumn123
            // 
            this.dataGridViewTextBoxColumn123.HeaderText = "A";
            this.dataGridViewTextBoxColumn123.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn123.Name = "dataGridViewTextBoxColumn123";
            this.dataGridViewTextBoxColumn123.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn123.Width = 24;
            // 
            // dataGridViewTextBoxColumn124
            // 
            this.dataGridViewTextBoxColumn124.HeaderText = "B";
            this.dataGridViewTextBoxColumn124.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn124.Name = "dataGridViewTextBoxColumn124";
            this.dataGridViewTextBoxColumn124.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn124.Width = 24;
            // 
            // dataGridViewTextBoxColumn125
            // 
            this.dataGridViewTextBoxColumn125.HeaderText = "C";
            this.dataGridViewTextBoxColumn125.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn125.Name = "dataGridViewTextBoxColumn125";
            this.dataGridViewTextBoxColumn125.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn125.Width = 24;
            // 
            // dataGridViewTextBoxColumn126
            // 
            this.dataGridViewTextBoxColumn126.HeaderText = "D";
            this.dataGridViewTextBoxColumn126.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn126.Name = "dataGridViewTextBoxColumn126";
            this.dataGridViewTextBoxColumn126.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn126.Width = 24;
            // 
            // dataGridViewTextBoxColumn127
            // 
            this.dataGridViewTextBoxColumn127.HeaderText = "E";
            this.dataGridViewTextBoxColumn127.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn127.Name = "dataGridViewTextBoxColumn127";
            this.dataGridViewTextBoxColumn127.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn127.Width = 24;
            // 
            // dataGridViewTextBoxColumn128
            // 
            this.dataGridViewTextBoxColumn128.HeaderText = "F";
            this.dataGridViewTextBoxColumn128.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn128.Name = "dataGridViewTextBoxColumn128";
            this.dataGridViewTextBoxColumn128.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn128.Width = 24;
            // 
            // dataGridViewTextBoxColumn97
            // 
            this.dataGridViewTextBoxColumn97.HeaderText = "0";
            this.dataGridViewTextBoxColumn97.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn97.Name = "dataGridViewTextBoxColumn97";
            this.dataGridViewTextBoxColumn97.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn97.Width = 24;
            // 
            // dataGridViewTextBoxColumn98
            // 
            this.dataGridViewTextBoxColumn98.HeaderText = "1";
            this.dataGridViewTextBoxColumn98.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn98.Name = "dataGridViewTextBoxColumn98";
            this.dataGridViewTextBoxColumn98.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn98.Width = 24;
            // 
            // dataGridViewTextBoxColumn99
            // 
            this.dataGridViewTextBoxColumn99.HeaderText = "2";
            this.dataGridViewTextBoxColumn99.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn99.Name = "dataGridViewTextBoxColumn99";
            this.dataGridViewTextBoxColumn99.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn99.Width = 24;
            // 
            // dataGridViewTextBoxColumn100
            // 
            this.dataGridViewTextBoxColumn100.HeaderText = "3";
            this.dataGridViewTextBoxColumn100.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn100.Name = "dataGridViewTextBoxColumn100";
            this.dataGridViewTextBoxColumn100.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn100.Width = 24;
            // 
            // dataGridViewTextBoxColumn101
            // 
            this.dataGridViewTextBoxColumn101.HeaderText = "4";
            this.dataGridViewTextBoxColumn101.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn101.Name = "dataGridViewTextBoxColumn101";
            this.dataGridViewTextBoxColumn101.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn101.Width = 24;
            // 
            // dataGridViewTextBoxColumn102
            // 
            this.dataGridViewTextBoxColumn102.HeaderText = "5";
            this.dataGridViewTextBoxColumn102.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn102.Name = "dataGridViewTextBoxColumn102";
            this.dataGridViewTextBoxColumn102.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn102.Width = 24;
            // 
            // dataGridViewTextBoxColumn103
            // 
            this.dataGridViewTextBoxColumn103.HeaderText = "6";
            this.dataGridViewTextBoxColumn103.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn103.Name = "dataGridViewTextBoxColumn103";
            this.dataGridViewTextBoxColumn103.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn103.Width = 24;
            // 
            // dataGridViewTextBoxColumn104
            // 
            this.dataGridViewTextBoxColumn104.HeaderText = "7";
            this.dataGridViewTextBoxColumn104.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn104.Name = "dataGridViewTextBoxColumn104";
            this.dataGridViewTextBoxColumn104.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn104.Width = 24;
            // 
            // dataGridViewTextBoxColumn105
            // 
            this.dataGridViewTextBoxColumn105.HeaderText = "8";
            this.dataGridViewTextBoxColumn105.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn105.Name = "dataGridViewTextBoxColumn105";
            this.dataGridViewTextBoxColumn105.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn105.Width = 24;
            // 
            // dataGridViewTextBoxColumn106
            // 
            this.dataGridViewTextBoxColumn106.HeaderText = "9";
            this.dataGridViewTextBoxColumn106.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn106.Name = "dataGridViewTextBoxColumn106";
            this.dataGridViewTextBoxColumn106.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn106.Width = 24;
            // 
            // dataGridViewTextBoxColumn107
            // 
            this.dataGridViewTextBoxColumn107.HeaderText = "A";
            this.dataGridViewTextBoxColumn107.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn107.Name = "dataGridViewTextBoxColumn107";
            this.dataGridViewTextBoxColumn107.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn107.Width = 24;
            // 
            // dataGridViewTextBoxColumn108
            // 
            this.dataGridViewTextBoxColumn108.HeaderText = "B";
            this.dataGridViewTextBoxColumn108.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn108.Name = "dataGridViewTextBoxColumn108";
            this.dataGridViewTextBoxColumn108.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn108.Width = 24;
            // 
            // dataGridViewTextBoxColumn109
            // 
            this.dataGridViewTextBoxColumn109.HeaderText = "C";
            this.dataGridViewTextBoxColumn109.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn109.Name = "dataGridViewTextBoxColumn109";
            this.dataGridViewTextBoxColumn109.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn109.Width = 24;
            // 
            // dataGridViewTextBoxColumn110
            // 
            this.dataGridViewTextBoxColumn110.HeaderText = "D";
            this.dataGridViewTextBoxColumn110.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn110.Name = "dataGridViewTextBoxColumn110";
            this.dataGridViewTextBoxColumn110.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn110.Width = 24;
            // 
            // dataGridViewTextBoxColumn111
            // 
            this.dataGridViewTextBoxColumn111.HeaderText = "E";
            this.dataGridViewTextBoxColumn111.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn111.Name = "dataGridViewTextBoxColumn111";
            this.dataGridViewTextBoxColumn111.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn111.Width = 24;
            // 
            // dataGridViewTextBoxColumn112
            // 
            this.dataGridViewTextBoxColumn112.HeaderText = "F";
            this.dataGridViewTextBoxColumn112.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn112.Name = "dataGridViewTextBoxColumn112";
            this.dataGridViewTextBoxColumn112.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn112.Width = 24;
            // 
            // dataGridViewTextBoxColumn81
            // 
            this.dataGridViewTextBoxColumn81.HeaderText = "0";
            this.dataGridViewTextBoxColumn81.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn81.Name = "dataGridViewTextBoxColumn81";
            this.dataGridViewTextBoxColumn81.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn81.Width = 24;
            // 
            // dataGridViewTextBoxColumn82
            // 
            this.dataGridViewTextBoxColumn82.HeaderText = "1";
            this.dataGridViewTextBoxColumn82.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn82.Name = "dataGridViewTextBoxColumn82";
            this.dataGridViewTextBoxColumn82.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn82.Width = 24;
            // 
            // dataGridViewTextBoxColumn83
            // 
            this.dataGridViewTextBoxColumn83.HeaderText = "2";
            this.dataGridViewTextBoxColumn83.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn83.Name = "dataGridViewTextBoxColumn83";
            this.dataGridViewTextBoxColumn83.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn83.Width = 24;
            // 
            // dataGridViewTextBoxColumn84
            // 
            this.dataGridViewTextBoxColumn84.HeaderText = "3";
            this.dataGridViewTextBoxColumn84.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn84.Name = "dataGridViewTextBoxColumn84";
            this.dataGridViewTextBoxColumn84.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn84.Width = 24;
            // 
            // dataGridViewTextBoxColumn85
            // 
            this.dataGridViewTextBoxColumn85.HeaderText = "4";
            this.dataGridViewTextBoxColumn85.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn85.Name = "dataGridViewTextBoxColumn85";
            this.dataGridViewTextBoxColumn85.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn85.Width = 24;
            // 
            // dataGridViewTextBoxColumn86
            // 
            this.dataGridViewTextBoxColumn86.HeaderText = "5";
            this.dataGridViewTextBoxColumn86.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn86.Name = "dataGridViewTextBoxColumn86";
            this.dataGridViewTextBoxColumn86.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn86.Width = 24;
            // 
            // dataGridViewTextBoxColumn87
            // 
            this.dataGridViewTextBoxColumn87.HeaderText = "6";
            this.dataGridViewTextBoxColumn87.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn87.Name = "dataGridViewTextBoxColumn87";
            this.dataGridViewTextBoxColumn87.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn87.Width = 24;
            // 
            // dataGridViewTextBoxColumn88
            // 
            this.dataGridViewTextBoxColumn88.HeaderText = "7";
            this.dataGridViewTextBoxColumn88.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn88.Name = "dataGridViewTextBoxColumn88";
            this.dataGridViewTextBoxColumn88.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn88.Width = 24;
            // 
            // dataGridViewTextBoxColumn89
            // 
            this.dataGridViewTextBoxColumn89.HeaderText = "8";
            this.dataGridViewTextBoxColumn89.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn89.Name = "dataGridViewTextBoxColumn89";
            this.dataGridViewTextBoxColumn89.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn89.Width = 24;
            // 
            // dataGridViewTextBoxColumn90
            // 
            this.dataGridViewTextBoxColumn90.HeaderText = "9";
            this.dataGridViewTextBoxColumn90.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn90.Name = "dataGridViewTextBoxColumn90";
            this.dataGridViewTextBoxColumn90.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn90.Width = 24;
            // 
            // dataGridViewTextBoxColumn91
            // 
            this.dataGridViewTextBoxColumn91.HeaderText = "A";
            this.dataGridViewTextBoxColumn91.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn91.Name = "dataGridViewTextBoxColumn91";
            this.dataGridViewTextBoxColumn91.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn91.Width = 24;
            // 
            // dataGridViewTextBoxColumn92
            // 
            this.dataGridViewTextBoxColumn92.HeaderText = "B";
            this.dataGridViewTextBoxColumn92.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn92.Name = "dataGridViewTextBoxColumn92";
            this.dataGridViewTextBoxColumn92.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn92.Width = 24;
            // 
            // dataGridViewTextBoxColumn93
            // 
            this.dataGridViewTextBoxColumn93.HeaderText = "C";
            this.dataGridViewTextBoxColumn93.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn93.Name = "dataGridViewTextBoxColumn93";
            this.dataGridViewTextBoxColumn93.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn93.Width = 24;
            // 
            // dataGridViewTextBoxColumn94
            // 
            this.dataGridViewTextBoxColumn94.HeaderText = "D";
            this.dataGridViewTextBoxColumn94.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn94.Name = "dataGridViewTextBoxColumn94";
            this.dataGridViewTextBoxColumn94.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn94.Width = 24;
            // 
            // dataGridViewTextBoxColumn95
            // 
            this.dataGridViewTextBoxColumn95.HeaderText = "E";
            this.dataGridViewTextBoxColumn95.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn95.Name = "dataGridViewTextBoxColumn95";
            this.dataGridViewTextBoxColumn95.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn95.Width = 24;
            // 
            // dataGridViewTextBoxColumn96
            // 
            this.dataGridViewTextBoxColumn96.HeaderText = "F";
            this.dataGridViewTextBoxColumn96.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn96.Name = "dataGridViewTextBoxColumn96";
            this.dataGridViewTextBoxColumn96.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn96.Width = 24;
            // 
            // dataGridViewTextBoxColumn65
            // 
            this.dataGridViewTextBoxColumn65.HeaderText = "0";
            this.dataGridViewTextBoxColumn65.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn65.Name = "dataGridViewTextBoxColumn65";
            this.dataGridViewTextBoxColumn65.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn65.Width = 24;
            // 
            // dataGridViewTextBoxColumn66
            // 
            this.dataGridViewTextBoxColumn66.HeaderText = "1";
            this.dataGridViewTextBoxColumn66.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn66.Name = "dataGridViewTextBoxColumn66";
            this.dataGridViewTextBoxColumn66.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn66.Width = 24;
            // 
            // dataGridViewTextBoxColumn67
            // 
            this.dataGridViewTextBoxColumn67.HeaderText = "2";
            this.dataGridViewTextBoxColumn67.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn67.Name = "dataGridViewTextBoxColumn67";
            this.dataGridViewTextBoxColumn67.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn67.Width = 24;
            // 
            // dataGridViewTextBoxColumn68
            // 
            this.dataGridViewTextBoxColumn68.HeaderText = "3";
            this.dataGridViewTextBoxColumn68.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn68.Name = "dataGridViewTextBoxColumn68";
            this.dataGridViewTextBoxColumn68.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn68.Width = 24;
            // 
            // dataGridViewTextBoxColumn69
            // 
            this.dataGridViewTextBoxColumn69.HeaderText = "4";
            this.dataGridViewTextBoxColumn69.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn69.Name = "dataGridViewTextBoxColumn69";
            this.dataGridViewTextBoxColumn69.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn69.Width = 24;
            // 
            // dataGridViewTextBoxColumn70
            // 
            this.dataGridViewTextBoxColumn70.HeaderText = "5";
            this.dataGridViewTextBoxColumn70.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn70.Name = "dataGridViewTextBoxColumn70";
            this.dataGridViewTextBoxColumn70.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn70.Width = 24;
            // 
            // dataGridViewTextBoxColumn71
            // 
            this.dataGridViewTextBoxColumn71.HeaderText = "6";
            this.dataGridViewTextBoxColumn71.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn71.Name = "dataGridViewTextBoxColumn71";
            this.dataGridViewTextBoxColumn71.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn71.Width = 24;
            // 
            // dataGridViewTextBoxColumn72
            // 
            this.dataGridViewTextBoxColumn72.HeaderText = "7";
            this.dataGridViewTextBoxColumn72.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn72.Name = "dataGridViewTextBoxColumn72";
            this.dataGridViewTextBoxColumn72.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn72.Width = 24;
            // 
            // dataGridViewTextBoxColumn73
            // 
            this.dataGridViewTextBoxColumn73.HeaderText = "8";
            this.dataGridViewTextBoxColumn73.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn73.Name = "dataGridViewTextBoxColumn73";
            this.dataGridViewTextBoxColumn73.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn73.Width = 24;
            // 
            // dataGridViewTextBoxColumn74
            // 
            this.dataGridViewTextBoxColumn74.HeaderText = "9";
            this.dataGridViewTextBoxColumn74.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn74.Name = "dataGridViewTextBoxColumn74";
            this.dataGridViewTextBoxColumn74.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn74.Width = 24;
            // 
            // dataGridViewTextBoxColumn75
            // 
            this.dataGridViewTextBoxColumn75.HeaderText = "A";
            this.dataGridViewTextBoxColumn75.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn75.Name = "dataGridViewTextBoxColumn75";
            this.dataGridViewTextBoxColumn75.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn75.Width = 24;
            // 
            // dataGridViewTextBoxColumn76
            // 
            this.dataGridViewTextBoxColumn76.HeaderText = "B";
            this.dataGridViewTextBoxColumn76.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn76.Name = "dataGridViewTextBoxColumn76";
            this.dataGridViewTextBoxColumn76.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn76.Width = 24;
            // 
            // dataGridViewTextBoxColumn77
            // 
            this.dataGridViewTextBoxColumn77.HeaderText = "C";
            this.dataGridViewTextBoxColumn77.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn77.Name = "dataGridViewTextBoxColumn77";
            this.dataGridViewTextBoxColumn77.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn77.Width = 24;
            // 
            // dataGridViewTextBoxColumn78
            // 
            this.dataGridViewTextBoxColumn78.HeaderText = "D";
            this.dataGridViewTextBoxColumn78.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn78.Name = "dataGridViewTextBoxColumn78";
            this.dataGridViewTextBoxColumn78.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn78.Width = 24;
            // 
            // dataGridViewTextBoxColumn79
            // 
            this.dataGridViewTextBoxColumn79.HeaderText = "E";
            this.dataGridViewTextBoxColumn79.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn79.Name = "dataGridViewTextBoxColumn79";
            this.dataGridViewTextBoxColumn79.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn79.Width = 24;
            // 
            // dataGridViewTextBoxColumn80
            // 
            this.dataGridViewTextBoxColumn80.HeaderText = "F";
            this.dataGridViewTextBoxColumn80.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn80.Name = "dataGridViewTextBoxColumn80";
            this.dataGridViewTextBoxColumn80.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn80.Width = 24;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.HeaderText = "0";
            this.dataGridViewTextBoxColumn49.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            this.dataGridViewTextBoxColumn49.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn49.Width = 24;
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.HeaderText = "1";
            this.dataGridViewTextBoxColumn50.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn50.Width = 24;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.HeaderText = "2";
            this.dataGridViewTextBoxColumn51.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            this.dataGridViewTextBoxColumn51.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn51.Width = 24;
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.HeaderText = "3";
            this.dataGridViewTextBoxColumn52.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            this.dataGridViewTextBoxColumn52.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn52.Width = 24;
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.HeaderText = "4";
            this.dataGridViewTextBoxColumn53.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            this.dataGridViewTextBoxColumn53.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn53.Width = 24;
            // 
            // dataGridViewTextBoxColumn54
            // 
            this.dataGridViewTextBoxColumn54.HeaderText = "5";
            this.dataGridViewTextBoxColumn54.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
            this.dataGridViewTextBoxColumn54.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn54.Width = 24;
            // 
            // dataGridViewTextBoxColumn55
            // 
            this.dataGridViewTextBoxColumn55.HeaderText = "6";
            this.dataGridViewTextBoxColumn55.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
            this.dataGridViewTextBoxColumn55.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn55.Width = 24;
            // 
            // dataGridViewTextBoxColumn56
            // 
            this.dataGridViewTextBoxColumn56.HeaderText = "7";
            this.dataGridViewTextBoxColumn56.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn56.Name = "dataGridViewTextBoxColumn56";
            this.dataGridViewTextBoxColumn56.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn56.Width = 24;
            // 
            // dataGridViewTextBoxColumn57
            // 
            this.dataGridViewTextBoxColumn57.HeaderText = "8";
            this.dataGridViewTextBoxColumn57.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
            this.dataGridViewTextBoxColumn57.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn57.Width = 24;
            // 
            // dataGridViewTextBoxColumn58
            // 
            this.dataGridViewTextBoxColumn58.HeaderText = "9";
            this.dataGridViewTextBoxColumn58.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn58.Name = "dataGridViewTextBoxColumn58";
            this.dataGridViewTextBoxColumn58.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn58.Width = 24;
            // 
            // dataGridViewTextBoxColumn59
            // 
            this.dataGridViewTextBoxColumn59.HeaderText = "A";
            this.dataGridViewTextBoxColumn59.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn59.Name = "dataGridViewTextBoxColumn59";
            this.dataGridViewTextBoxColumn59.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn59.Width = 24;
            // 
            // dataGridViewTextBoxColumn60
            // 
            this.dataGridViewTextBoxColumn60.HeaderText = "B";
            this.dataGridViewTextBoxColumn60.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn60.Name = "dataGridViewTextBoxColumn60";
            this.dataGridViewTextBoxColumn60.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn60.Width = 24;
            // 
            // dataGridViewTextBoxColumn61
            // 
            this.dataGridViewTextBoxColumn61.HeaderText = "C";
            this.dataGridViewTextBoxColumn61.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn61.Name = "dataGridViewTextBoxColumn61";
            this.dataGridViewTextBoxColumn61.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn61.Width = 24;
            // 
            // dataGridViewTextBoxColumn62
            // 
            this.dataGridViewTextBoxColumn62.HeaderText = "D";
            this.dataGridViewTextBoxColumn62.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn62.Name = "dataGridViewTextBoxColumn62";
            this.dataGridViewTextBoxColumn62.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn62.Width = 24;
            // 
            // dataGridViewTextBoxColumn63
            // 
            this.dataGridViewTextBoxColumn63.HeaderText = "E";
            this.dataGridViewTextBoxColumn63.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn63.Name = "dataGridViewTextBoxColumn63";
            this.dataGridViewTextBoxColumn63.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn63.Width = 24;
            // 
            // dataGridViewTextBoxColumn64
            // 
            this.dataGridViewTextBoxColumn64.HeaderText = "F";
            this.dataGridViewTextBoxColumn64.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn64.Name = "dataGridViewTextBoxColumn64";
            this.dataGridViewTextBoxColumn64.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn64.Width = 24;
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
        private System.Windows.Forms.ToolStripMenuItem backArrow;
        private System.Windows.Forms.ToolStripMenuItem forwardArrow;
        private System.Windows.Forms.ToolStripMenuItem undoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoMenuItem;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn56;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn59;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn62;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn63;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn64;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn65;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn66;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn67;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn69;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn70;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn71;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn72;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn73;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn74;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn75;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn76;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn77;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn79;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn80;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn81;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn82;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn83;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn84;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn85;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn86;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn87;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn88;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn89;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn90;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn91;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn92;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn93;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn94;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn95;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn96;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn97;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn98;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn99;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn100;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn101;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn102;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn103;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn104;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn105;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn106;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn107;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn108;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn109;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn110;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn111;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn112;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn113;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn114;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn115;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn116;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn117;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn118;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn119;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn120;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn121;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn122;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn123;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn124;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn125;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn126;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn127;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn128;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn129;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn130;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn131;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn132;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn133;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn134;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn135;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn136;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn137;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn138;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn139;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn140;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn141;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn142;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn143;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn144;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn145;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn146;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn147;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn148;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn149;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn150;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn151;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn152;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn153;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn154;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn155;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn156;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn157;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn158;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn159;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn160;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn161;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn162;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn163;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn164;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn165;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn166;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn167;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn168;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn169;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn170;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn171;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn172;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn173;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn174;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn175;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn176;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn177;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn178;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn179;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn180;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn181;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn182;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn183;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn184;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn185;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn186;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn187;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn188;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn189;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn190;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn191;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn192;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn193;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn194;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn195;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn196;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn197;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn198;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn199;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn200;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn201;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn202;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn203;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn204;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn205;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn206;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn207;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn208;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn209;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn210;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn211;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn212;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn213;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn214;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn215;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn216;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn217;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn218;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn219;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn220;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn221;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn222;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn223;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn224;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn225;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn226;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn227;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn228;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn229;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn230;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn231;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn232;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn233;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn234;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn235;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn236;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn237;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn238;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn239;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn240;
    }
}