using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBRTool.DexEditor.Commands
{
    public class UndoCommand : Command<DexEditorWindow>
    {
        public UndoCommand(DexEditorWindow editor) : base(editor) { }

        public override bool Execute() {
            Editor.EditHistory.GetCurrent().Undo();
            Editor.EditHistory.MoveBackward();
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
