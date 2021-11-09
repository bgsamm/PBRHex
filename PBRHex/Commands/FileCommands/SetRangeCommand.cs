using System;
using PBRHex.Files;

namespace PBRHex.Commands.FileCommands
{
    public class SetRangeCommand : Command
    {
        private readonly IFileEditor Editor;
        private readonly FileBuffer File;
        private readonly int Address;
        private readonly byte[] NewBytes;
        private byte[] OldBytes;

        public SetRangeCommand(IFileEditor editor, FileBuffer file, int address, byte[] bytes) {
            Editor = editor;
            File = file;
            Address = address;
            NewBytes = bytes;
        }

        public override bool Execute() {
            OldBytes = File.GetRange(Address, NewBytes.Length);
            File.SetRange(Address, NewBytes);
            Editor.SetRange(Address, NewBytes);
            return true;
        }

        public override void Redo() {
            File.SetRange(Address, NewBytes);
            Editor.SetRange(Address, NewBytes);
        }

        public override void Undo() {
            File.SetRange(Address, OldBytes);
            Editor.SetRange(Address, OldBytes);
        }
    }
}
