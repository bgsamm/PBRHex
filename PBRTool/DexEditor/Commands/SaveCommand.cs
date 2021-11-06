using System;

namespace PBRTool.DexEditor.Commands
{
    public class SaveCommand : Command<DexEditorWindow>
    {
        public SaveCommand(DexEditorWindow editor) : base(editor) { }

        public override bool Execute() {
            Editor.Write();
            Editor.LastSavePosition = Editor.EditHistory.Position;
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
