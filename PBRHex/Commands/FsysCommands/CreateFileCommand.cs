using System;
using PBRHex.Files;
using PBRHex.Utils;

namespace PBRHex.Commands.FsysCommands
{
    public class CreateFileCommand : Command
    {
        private readonly IFsysEditor Editor;
        private readonly FSYS FSYS;
        private FileBuffer File;

        public CreateFileCommand(IFsysEditor editor, FSYS fsys) {
            Editor = editor;
            FSYS = fsys;
        }

        public override bool Execute() {
            string path = $@"{Program.TempDir}\temp";
            FileUtils.CreateFile(path, 0x10);
            File = FSYS.AddFile(path);
            Editor.AddFile(File);
            return false;
        }

        public override void Redo() {
            File = FSYS.AddFile(File);
            Editor.AddFile(File);
        }

        public override void Undo() {
            FSYS.RemoveFile(File.ID);
            Editor.RemoveFile(File);
        }
    }
}
