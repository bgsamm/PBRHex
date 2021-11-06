using System;
using PBRHex.Files;

namespace PBRHex.HexEditor.Commands
{
    public class RemoveFileCommand : Command<HexEditorWindow>
    {
        private FileBuffer File;

        public RemoveFileCommand(HexEditorWindow editor, FileBuffer file) : base(editor) {
            File = file;
        }

        public override bool Execute() {
            Editor.RemoveFile(File);
            return false;
        }

        public override void Redo() {
            Editor.RemoveFile(File);
        }

        public override void Undo() {
            File = Editor.AddFile(File.Path);
        }
    }
}
