using System;
using PBRHex.Files;

namespace PBRHex.HexEditor.Commands
{
    public class AddFileCommand : Command<HexEditorWindow>
    {
        private readonly string Path;
        private FileBuffer File;

        public AddFileCommand(HexEditorWindow editor, string path) : base(editor) {
            Path = path;
        }

        public override bool Execute() {
            File = Editor.AddFile(Path);
            return false;
        }

        public override void Redo() {
            File = Editor.AddFile(Path);
        }

        public override void Undo() {
            Editor.RemoveFile(File);
        }
    }
}
