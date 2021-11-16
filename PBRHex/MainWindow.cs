using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using PBRHex.Dialogs;
using PBRHex.Files;
using PBRHex.HexEditor;
using PBRHex.Tables;
using PBRHex.Utils;

/*
 * TODO:
 * -Support NTSC-J ISOs
 * -FileBuffers should automatically create workspaces for themselves
 * -Keep all changes to data tables in memory/temp files rather than writing directly to ISO
 * -'Add file', 'Remove file', 'Replace file', 'Restore all', etc.
 * -Add option to apply anti-cheat patch/apply automatically
 * -Prevent opening of same file in more than one editor at once (read-only mode?)
 * -Track modification of individual files WITHIN an fsys
 * -Handle failed file I/O without crashing the program
 * -Handle files that exceed Int32.MaxValue in size
 * -Add Model or SDR class
 * -Resizable windows (?)
 * -Document
 */

namespace PBRHex
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

        public static GameRegion ISORegion;

        private readonly TreeView FileTree;
        private string SelectedFilePath => (string)FileTree.SelectedNode.Tag;

        public MainWindow() {
            InitializeComponent();
            FileTree = fileTreeView;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);

            if(Directory.Exists(Program.ISODir)) {
                // provides backwards compatibility with old versions of PBRHex
                if(Directory.Exists($@"{Program.ISODir}\DATA"))
                    FlattenISODir();
                messageLabel.Visible = false;
                FSYSTable.Initialize();
                DOL.Initialize();
                int gameCodeSize = DOL.GetSectionSize(1);
                switch(gameCodeSize) {
                    case 0x3DEB20:
                        ISORegion = GameRegion.NTSCU;
                        break;
                    case 0x3C69E0:
                        ISORegion = GameRegion.NTSCJ;
                        break;
                    case 0x3DB4E0:
                        ISORegion = GameRegion.PAL;
                        break;
                    default:
                        // shouldn't ever get here but in case it does just don't load the ISO
                        return;
                }
                Console.WriteLine($"{gameCodeSize:X8}");
                BuildFileTree();
                EnableMenuItems();
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
            // expand first nodes
            fileTreeView.Nodes[0].Expand();
        }

        private void BuildFileTreeLoop(string dir, TreeNode parentNode = null) {
            TreeNode node;

            if(parentNode == null) {
                string rootName = ISORegion.ToString().Replace("NTSC", "NTSC-");
                node = new TreeNode(rootName)
                {
                    ImageIndex = 0,
                    SelectedImageIndex = 0,
                    Tag = dir,
                };
                //node.NodeFont = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
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
            HexEditorWindow hexEditor;
            
            foreach(Form form in Application.OpenForms) {
                if(form is HexEditorWindow editor) {
                    if((file is FSYS && editor.Name == $"{file.Name}_unpacked") ||
                       (!(file is FSYS) && editor.Name == file.Name)) {
                        form.BringToFront();
                        return;
                    } 
                    //else if((file is FSYS && editor.Name == file.Name) ||
                    //          (!(file is FSYS) && editor.Name == $"{file.Name}_unpacked")) {
                    //    new AlertDialog(
                    //        "This file is already open in another editor."
                    //    ).ShowDialog();
                    //    return;
                    //}
                }
            }

            if(file is FSYS fsys) {
                var files = new List<FileBuffer>();
                foreach(var f in fsys.Files) {
                    files.Add(f);
                }
                hexEditor = new HexEditorWindow(files.ToArray(), fsys)
                {
                    Name = $"{file.Name}_unpacked",
                    Text = $"{file.Name} (unpacked)"
                };
            }
            else {
                if(file.Extension == ".fsys") {
                    var confirm = new ConfirmDialog(
                        "Modifying .fsys files directly is not recommended.\n" +
                        "Are you sure you wish to continue?"
                    );
                    var result = confirm.ShowDialog();
                    if(result != DialogResult.Yes) 
                        return;
                }
                file.WorkingDir = FileUtils.CreateWorkspace(file.Path);
                hexEditor = new HexEditorWindow(new FileBuffer[] { file }) 
                {
                    Name = file.Name,
                    Text = file.Name 
                };
            }
            var node = FileTree.SelectedNode;
            hexEditor.FormClosed += (sender, e) => {
                if(FileUtils.HasBackup(node.Text)) {
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                }
            };
            hexEditor.Show();
        }

        private Form GetOpenForm(Type t) {
            foreach(Form form in Application.OpenForms) {
                if(form.GetType() == t) {
                    form.BringToFront();
                    return form;
                }
            }
            return null;
        }

        private void CloseForms() {
            for(int i = Application.OpenForms.Count - 1; i >= 0; i--) {
                var form = Application.OpenForms[i];
                if(!(form is MainWindow))
                    form.Close();
            }
        }

        private void EnableMenuItems() {
            // enable all menu items; assumes no sub-menus
            foreach(ToolStripMenuItem tab in headerMenuStrip.Items) {
                foreach(ToolStripMenuItem item in tab.DropDownItems) {
                    item.Enabled = true;
                }
            }
        }

        private string ReadGameCode(string path) {
            var iso = File.OpenRead(path);
            byte[] bytes = new byte[6];
            iso.Read(bytes, 0, 6);
            iso.Close();
            return HexUtils.BytesToAscii(bytes);
        }

        private void FlattenISODir() {
            FileUtils.MoveContents($@"{Program.ISODir}\DATA", Program.ISODir, true);
            FileUtils.DeleteDirectory($@"{Program.ISODir}\UPDATE");
        }

        private void UnpackISOButton_Click(object sender, EventArgs e) {
            if(openISODialog.ShowDialog() == DialogResult.OK) {
                string gameCode = ReadGameCode(openISODialog.FileName);
                // not as robust as I'd like but I'm not yet sure how else to detect an nkit
                if(openISODialog.FileName.Contains(".nkit")) {
                    new AlertDialog("PBRHex cannot open NKit files.\n" +
                        "Please convert it to an ISO and try again.").ShowDialog();
                    return;
                }
                if(gameCode != "RPBE01" && gameCode != "RPBP01") {
                    new AlertDialog("This ISO is not supported by PBRHex.").ShowDialog();
                    return;
                }

                if(gameCode == "RPBJ01")
                    ISORegion = GameRegion.NTSCJ;
                else if(gameCode == "RPBE01")
                    ISORegion = GameRegion.NTSCU;
                else if(gameCode == "RPBP01")
                    ISORegion = GameRegion.PAL;
                CloseForms();
                Program.Log("Unpacking ISO...");
                FileUtils.DeleteDirectory(Program.TempDir);
                FileUtils.CreateDirectory(Program.BackupsDir, true);
                FileTree.Nodes.Clear();
                FileTree.Refresh();
                messageLabel.Text = "Please wait. This will take some time.";
                messageLabel.Visible = true;
                messageLabel.Refresh();
                CommandUtils.UnpackISO(openISODialog.FileName);
                FSYSTable.Initialize();
                FSYSTable.RenameFile("pkx_600", "pkx_egg");
                FSYSTable.RenameFile("pkx_601", "pkx_sub");
                SpriteTable.DecodeSprites();
                DOL.Initialize();
                DexTable.PatchDex();
                // disable anti-modification function
                uint address = 0;
                switch(ISORegion) {
                    case GameRegion.NTSCJ:
                        address = 0x8021de60;
                        break;
                    case GameRegion.NTSCU:
                        address = 0x8022e1e4;
                        break;
                    case GameRegion.PAL:
                        address = 0x8022965c;
                        break;
                }
                DOL.WriteInstruction(address, 0x48000108);
                DOL.Write();
                BuildFileTree();
                FlashTaskbar();
                messageLabel.Visible = false;
                EnableMenuItems();
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

        private void DolphinButton_Click(object sender, EventArgs args) {
            try {
                CommandUtils.RunDolphin().Exited += (s, e) =>
                {
                    // must use Invoke to execute on the UI thread
                    Invoke(new Action(() =>
                    {
                        dolphinMenuItem.Enabled = true;
                    }));
                };
                dolphinMenuItem.Enabled = false;
            } catch {
                new AlertDialog( "Could not launch Dolphin. Please ensure that Dolphin is on the PATH." ).ShowDialog();
            }
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
            if(Path.GetExtension(SelectedFilePath) == ".fsys")
                FSYSTable.CloseFile(Path.GetFileName(SelectedFilePath));
            FileTree.SelectedNode.ImageIndex = 2;
            FileTree.SelectedNode.SelectedImageIndex = 2;
        }

        private void CodeEditorMenuItem_Click(object sender, EventArgs e) {
            var form = GetOpenForm(typeof(CodeEditor));
            if(form != null) {
                form.BringToFront();
                return;
            }
            var dialog = new ConfirmDialog(
                "Note: This feature is still under development\n" +
                "and may not always work as intended.\n" +
                "Do you still wish to continue?" 
            );
            if(dialog.ShowDialog() == DialogResult.Yes)
                new CodeEditor().Show();
        }

        private void StringEditorMenuItem_Click(object sender, EventArgs e) {
            var form = GetOpenForm(typeof(StringEditor));
            if(form != null)
                form.BringToFront();
            else
                new StringEditor().Show();
        }

        private void DexEditorMenuItem_Click(object sender, EventArgs e) {
            var form = GetOpenForm(typeof(DexEditor));
            if(form != null)
                form.BringToFront();
            else
                new DexEditor().Show();
        }

        private void RentalPassEditorMenuItem_Click(object sender, EventArgs e) {
            var form = GetOpenForm(typeof(PassEditor));
            if(form != null)
                form.BringToFront();
            else
                new PassEditor().Show();
        }
    }
}
