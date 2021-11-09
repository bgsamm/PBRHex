using System;
using PBRHex.Files;

namespace PBRHex.Commands.FsysCommands
{
    public class RemoveFileCommand : Command
    {
        private readonly IFsysEditor Editor;
        private readonly FSYS FSYS;
        private FileBuffer File;

        public RemoveFileCommand(IFsysEditor editor, FSYS fsys, FileBuffer file) {
            Editor = editor;
            FSYS = fsys;
            File = file;
        }

        public override bool Execute() {
            FSYS.RemoveFile(File.ID);
            Editor.RemoveFile(File);
            return false;
        }

        public override void Redo() {
            FSYS.RemoveFile(File.ID);
            Editor.RemoveFile(File);
        }

        public override void Undo() {
            File = FSYS.AddFile(File);
            Editor.AddFile(File);
        }
    }
}
