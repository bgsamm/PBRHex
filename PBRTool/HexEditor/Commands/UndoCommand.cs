namespace PBRTool.HexEditor.Commands
{
    public class UndoCommand : Command<HexEditorWindow>
    {
        public UndoCommand(HexEditorWindow editor) : base(editor) { }

        public override bool Execute() {
            Editor.EditHistory.GetCurrent().Undo();
            Editor.EditHistory.MoveBackward();
            Editor.RefreshUndoRedoButtons();
            return false;
        }

        public override void Redo() {
            throw new System.NotImplementedException();
        }

        public override void Undo() {
            throw new System.NotImplementedException();
        }
    }
}
