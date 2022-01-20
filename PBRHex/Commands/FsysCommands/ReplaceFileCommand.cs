using System;
using PBRHex.Files;

namespace PBRHex.Commands.FsysCommands
{
    public class ReplaceFileCommand : Command
    {
        private readonly IFsysEditor Editor;
        private readonly FSYS FSYS;
        private readonly FileBuffer OldFile;
        private readonly string Path;
        private FileBuffer NewFile;

        public ReplaceFileCommand(IFsysEditor editor, FSYS fsys, FileBuffer oldFile, string path) {
            Editor = editor;
            FSYS = fsys;
            OldFile = oldFile;
            Path = path;
        }

        public override bool Execute() {
            NewFile = FSYS.ReplaceFile(OldFile.ID, Path);
            Editor.ReplaceFile(OldFile, NewFile);
            return false;
        }

        public override void Redo() {
            throw new NotImplementedException();
        }

        public override void Undo() {
            throw new NotImplementedException();
        }
    }
}
