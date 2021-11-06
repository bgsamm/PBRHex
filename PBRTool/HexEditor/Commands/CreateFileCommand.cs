using System;
using PBRTool.Files;

namespace PBRTool.HexEditor.Commands
{
    public class CreateFileCommand : Command<HexEditorWindow>
    {
        private FileBuffer File;

        public CreateFileCommand(HexEditorWindow editor) : base(editor) { }

        public override bool Execute() {
            File = Editor.CreateFile();
            return false;
        }

        public override void Redo() {
            File = Editor.AddFile(File.Path);
        }

        public override void Undo() {
            Editor.RemoveFile(File);
        }
    }
}
