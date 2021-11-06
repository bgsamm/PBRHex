using System;

namespace PBRHex.HexEditor.Commands
{
    public class InsertRangeCommand : Command<HexEditorWindow>
    {
        private readonly int Address;
        private readonly int Size;

        public InsertRangeCommand(HexEditorWindow editor, int address, int size) : base(editor) {
            Address = address;
            Size = size;
        }

        public override bool Execute() {
            Editor.InsertRange(Address, new byte[Size]);
            return true;
        }

        public override void Redo() {
            Editor.InsertRange(Address, new byte[Size]);
        }

        public override void Undo() {
            Editor.DeleteRange(Address, Size);
        }
    }
}
