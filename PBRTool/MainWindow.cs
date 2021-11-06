using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using PBRTool.CodeEditor;
using PBRTool.DexEditor;
using PBRTool.Dialogs;
using PBRTool.Files;
using PBRTool.HexEditor;
using PBRTool.StringEditor;
using PBRTool.Tables;
using PBRTool.Utils;

/*
 * TODO:
 * -FileBuffers should automatically create workspaces for themselves
 * -Keep all changes to data tables in memory/temp files rather than writing directly to ISO
 * -'Add file', 'Remove file', 'Replace file', 'Restore all', etc.
 * -Add option to apply anti-cheat patch/apply automatically
 * -Prevent opening of same file in more than one editor at once (read-only mode?)
 * -Track modification of individual files WITHIN an fsys
 * -Handle failed file I/O without crashing the program
 * -Handle files that exceed Int32.MaxValue in size
 * -Resizable windows (?)
 * -Document
 */

namespace PBRTool
{
    public partial class MainWindow : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public Int32 dwFlags;
            public UInt32 uCount;
            public Int32 dwTimeout;
        }

        [DllImport("user32.dll")]
        static extern Int32 FlashWindowEx(ref FLASHWINFO pwfi);

        private readonly TreeView FileTree;
        private string SelectedFilePath => (string)FileTree.SelectedNode.Tag;

        public MainWindow() {
            InitializeComponent();
            FileTree = fileTreeView;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            if(Directory.Exists(Program.ISODir)) {
                FSYSTable.Initialize();
                DOL.Initialize();
                BuildFileTree();
            }
        }

        private void FlashTaskbar() {
            var fw = new FLASHWINFO
            {
                cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO))),
                hwnd = Handle,
                dwFlags = 2,
                uCount = 1
            };
            FlashWindowEx(ref fw);
        }

        private void BuildFileTree() {
            BuildFileTreeLoop(Program.ISODir);
            // expand first two nodes
            fileTreeView.Nodes[0].Expand();
            fileTreeView.Nodes[0].Nodes[0].Expand();
        }

        private void BuildFileTreeLoop(string dir, TreeNode parentNode = null) {
            TreeNode node;

            if(parentNode == null) {
                node = new TreeNode("root") 
                {
                    ImageIndex = 0,
                    SelectedImageIndex = 0,
                    Tag = dir,
                };
                fileTreeView.Nodes.Add(node);
            }
            else {
                node = new TreeNode(Path.GetFileName(dir)) 
                {
                    ImageIndex = 1,
                    SelectedImageIndex = 1,
                    Tag = dir,
                };
                parentNode.Nodes.Add(node);
            }
            node.ContextMenuStrip = fileTreeContextMenu;

            foreach(var subdir in Directory.GetDirectories(dir)) {
                BuildFileTreeLoop(subdir, node);
            }
            foreach(var fpath in Directory.GetFiles(dir)) {
                string name = Path.GetFileName(fpath);
                int idx = FileUtils.HasBackup(name) ? 3 : 2;
                var child = new TreeNode(name) 
                { 
                    ImageIndex = idx,
                    SelectedImageIndex = idx,
                    Tag = fpath,
                };
                node.Nodes.Add(child);
                child.ContextMenuStrip = fileTreeContextMenu;
            }
        }

        private void OpenHexEditor(FileBuffer file) {
            HexEditorWindow editor;
            if(file as FSYS != null) {
                var files = new List<FileBuffer>();
                var fsys = (FSYS)file;
                foreach(var f in fsys.Files) {
                    files.Add(f);
                }
                editor = new HexEditorWindow(files.ToArray(), fsys)
                {
                    Text = $"{file.Name} (unpacked)"
                };
            }
            else {
                if(file.Extension == ".fsys") {
                    var confirm = new ConfirmDialog()
                    {
                        Message = "Modifying .fsys files directly is not recommended.\n" +
                        "Are you sure you wish to continue?"
                    };
                    var result = confirm.ShowDialog();
                    if(result != DialogResult.Yes) 
                        return;
                }
                file.WorkingDir = FileUtils.CreateWorkspace(file.Path);
                editor = new HexEditorWindow(new FileBuffer[] { file }) 
                { 
                    Text = file.Name 
                };
            }
            var node = FileTree.SelectedNode;
            editor.FormClosed += (sender, e) => {
                if(FileUtils.HasBackup(node.Text)) {
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                }
            };
            editor.Show();
        }

        private void CloseForms() {
            for(int i = Application.OpenForms.Count - 1; i >= 0; i--) {
                var form = Application.OpenForms[i];
                if(form.GetType() != typeof(MainWindow))
                    form.Close();
            }
        }

        private void UnpackISOButton_Click(object sender, EventArgs e) {
            if(openISODialog.ShowDialog() == DialogResult.OK) {
                CloseForms();
                try {
                    pleaseWaitLabel.Visible = true;
                    FileUtils.DeleteDirectory(Program.TempDir);
                    FileUtils.CreateDirectory(Program.BackupsDir, true);
                    FileTree.Nodes.Clear();
                    FileTree.Refresh();
                    pleaseWaitLabel.Refresh();
                    CommandUtils.UnpackISO(openISODialog.FileName);
                    FSYSTable.Initialize();
                    FSYSTable.RenameFile("pkx_600", "pkx_egg");
                    FSYSTable.RenameFile("pkx_601", "pkx_sub");
                    SpriteTable.DecodeSprites();
                    DexTable.PatchDex();
                    DOL.Initialize();
                    DOL.WriteInstruction(0x8022e1e4, 0x48000108);
                    DOL.Write();
                    BuildFileTree();
                    FlashTaskbar();
                    pleaseWaitLabel.Visible = false;
                }
                catch(SecurityException ex) {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
                //catch(IOException) {
                //    new AlertDialog() {
                //        Message = "One or more files are in use by another program.\nPlease close the files and try again."
                //    }.ShowDialog();
                //}
            }
        }

        private void RebuildISOButton_Click(object sender, EventArgs e) {
            if(saveISODialog.ShowDialog() == DialogResult.OK) {
                try {
                    CommandUtils.BuildISO(saveISODialog.FileName);
                }
                catch(SecurityException ex) {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void DolphinButton_Click(object sender, EventArgs e) {
            CommandUtils.PlayTest();
        }

        private void FileTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            FileTree.SelectedNode = e.Node;
            if(e.Button == MouseButtons.Right) {
                fileTreeContextMenu.Show(e.Location);
            }
        }

        private void FileTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            string path = (string)FileTree.SelectedNode.Tag;
            if(e.Button == MouseButtons.Left && !File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                OpenHexEditor(new FileBuffer(path));
        }

        private void FileTreeContextMenu_Opening(object sender, CancelEventArgs e) {
            folderLocationMenuItem.Visible = false;
            fileLocationMenuItem.Visible = false;
            hexEditorMenuItem.Visible = false;
            decompressFSYSMenuItem.Visible = false;
            restoreMenuItem.Visible = false;

            if(File.GetAttributes(SelectedFilePath).HasFlag(FileAttributes.Directory)) {
                folderLocationMenuItem.Visible = true;
            }
            else {
                fileLocationMenuItem.Visible = true;
                hexEditorMenuItem.Visible = true;
                if(Path.GetExtension(SelectedFilePath) == ".fsys")
                    decompressFSYSMenuItem.Visible = true;
                if(FileUtils.HasBackup(Path.GetFileName(SelectedFilePath)))
                    restoreMenuItem.Visible = true;
            }
        }

        private void FolderLocationMenuItem_Click(object sender, EventArgs e) {
            // open in file explorer
            Process.Start(SelectedFilePath);
        }

        private void FileLocationMenuItem_Click(object sender, EventArgs e) {
            // open in file explorer
            Process.Start(SelectedFilePath);
        }

        private void HexEditorMenuItem_Click(object sender, EventArgs e) {
            OpenHexEditor(new FileBuffer(SelectedFilePath));
        }

        private void DecompressFSYSMenuItem_Click(object sender, EventArgs e) {
            string name = Path.GetFileNameWithoutExtension(SelectedFilePath);
            OpenHexEditor(FSYSTable.GetFile(name));
        }

        private void RestoreMenuItem_Click(object sender, EventArgs e) {
            FileUtils.RestoreFile(SelectedFilePath);
            FileTree.SelectedNode.ImageIndex = 2;
            FileTree.SelectedNode.SelectedImageIndex = 2;
        }

        private void DisassembleDOLMenuItem_Click(object sender, EventArgs e) {
            foreach(Form form in Application.OpenForms) {
                if(form.GetType() == typeof(CodeEditorWindow)) {
                    form.BringToFront();
                    return;
                }
            }
            new CodeEditorWindow().Show();
        }

        private void EditStringsMenuItem_Click(object sender, EventArgs e) {
            foreach(Form form in Application.OpenForms) {
                if(form.GetType() == typeof(StringEditorWindow)) {
                    form.BringToFront();
                    return;
                }
            }
            new StringEditorWindow().Show();
        }

        private void DexEditorMenuItem_Click(object sender, EventArgs e) {
            foreach(Form form in Application.OpenForms) {
                if(form.GetType() == typeof(DexEditorWindow)) {
                    form.BringToFront();
                    return;
                }
            }
            new DexEditorWindow().Show();
        }
    }
}
