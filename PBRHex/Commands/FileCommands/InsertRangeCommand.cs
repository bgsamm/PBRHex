using System;
using PBRHex.Files;

namespace PBRHex.Commands.FileCommands
{
    public class InsertRangeCommand : Command
    {
        private readonly IFileEditor Editor;
        private readonly FileBuffer File;
        private readonly int Address;
        private readonly int Size;

        public InsertRangeCommand(IFileEditor editor, FileBuffer file, int address, int size) {
            Editor = editor;
            File = file;
            Address = address;
            Size = size;
        }

        public override bool Execute() {
            File.InsertRange(Address, new byte[Size]);
            Editor.InsertRange(Address, new byte[Size]);
            return true;
        }

        public override void Redo() {
            File.InsertRange(Address, new byte[Size]);
            Editor.InsertRange(Address, new byte[Size]);
        }

        public override void Undo() {
            File.DeleteRange(Address, Size);
            Editor.DeleteRange(Address, Size);
        }
    }
}
