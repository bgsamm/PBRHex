using System;
using PBRHex.Files;

namespace PBRHex.Commands.FsysCommands
{
    public class AddFileCommand : Command
    {
        private readonly IFsysEditor Editor;
        private readonly FSYS FSYS;
        private FileBuffer File;

        public AddFileCommand(IFsysEditor editor, FSYS fsys, FileBuffer file) {
            Editor = editor;
            FSYS = fsys;
            File = file;
        }

        public override bool Execute() {
            File = FSYS.AddFile(File);
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
