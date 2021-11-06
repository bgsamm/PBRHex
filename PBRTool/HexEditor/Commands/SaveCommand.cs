using System;

namespace PBRTool.HexEditor.Commands
{
    public class SaveCommand : Command<HexEditorWindow>
    {
        public SaveCommand(HexEditorWindow editor) : base(editor) { }

        public override bool Execute() {
            Editor.Write();
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
