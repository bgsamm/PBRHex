using System;

namespace PBRHex.HexEditor.Commands
{
    public class RedoCommand : Command<HexEditorWindow>
    {
        public RedoCommand(HexEditorWindow editor) : base(editor) { }

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
