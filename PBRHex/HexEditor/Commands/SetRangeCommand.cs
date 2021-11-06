using System;

namespace PBRHex.HexEditor.Commands
{
    public class SetRangeCommand : Command<HexEditorWindow>
    {
        private readonly int Address;
        private readonly byte[] NewBytes;
        private byte[] OldBytes;

        public SetRangeCommand(HexEditorWindow editor, int address, byte[] bytes) : base(editor) {
            Address = address;
            NewBytes = bytes;
        }

        public override bool Execute() {
            OldBytes = Editor.GetRange(Address, NewBytes.Length);
            Editor.SetRange(Address, NewBytes);
            return true;
        }

        public override void Redo() {
            Editor.SetRange(Address, NewBytes);
        }

        public override void Undo() {
            Editor.SetRange(Address, OldBytes);
        }
    }
}
