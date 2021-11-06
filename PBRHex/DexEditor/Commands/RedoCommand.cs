using System;

namespace PBRHex.DexEditor.Commands
{
    public class RedoCommand : Command<DexEditorWindow>
    {
        public RedoCommand(DexEditorWindow editor) : base(editor) { }

        public override bool Execute() {
            Editor.EditHistory.MoveForward().Redo();
            Editor.RefreshUndoRedoButtons();
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
