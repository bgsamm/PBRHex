using System;
using PBRHex.Files;

namespace PBRHex.Commands.FileCommands
{
    public class DeleteRangeCommand : Command
    {
        private readonly IFileEditor Editor;
        private readonly FileBuffer File;
        private readonly int Address;
        private readonly int Size;
        private byte[] Bytes;

        public DeleteRangeCommand(IFileEditor editor, FileBuffer file, int address, int size) {
            Editor = editor;
            File = file;
            Address = address;
            Size = size;
        }

        public override bool Execute() {
            Bytes = File.DeleteRange(Address, Size);
            Editor.DeleteRange(Address, Size);
            return true;
        }

        public override void Redo() {
            File.DeleteRange(Address, Size);
            Editor.DeleteRange(Address, Size);
        }

        public override void Undo() {
            File.InsertRange(Address, Bytes);
            Editor.InsertRange(Address, new byte[Size]);
        }
    }
}
