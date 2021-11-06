using System;
using PBRTool.Dialogs;

namespace PBRTool.HexEditor.Commands
{
    public class DeleteRangeCommand : Command<HexEditorWindow>
    {
        private int Address;
        private int Size;
        private byte[] Bytes;

        public DeleteRangeCommand(HexEditorWindow editor) : base(editor) { }

        public override bool Execute() {
            if(!Editor.IsSelectionContiguous()) {
                new AlertDialog() { Message = "Invalid selection." }.ShowDialog();
                return false;
            }
            Address = Editor.GetSelectionRange().X;
            Size = Editor.GetSelection().Length;
            Bytes = Editor.DeleteRange(Address, Size);
            return true;
        }

        public override void Redo() {
            Editor.DeleteRange(Address, Size);
        }

        public override void Undo() {
            Editor.InsertRange(Address, Bytes);
        }
    }
}
