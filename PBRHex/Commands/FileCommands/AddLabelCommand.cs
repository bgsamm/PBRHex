using System;
using PBRHex.Files;
using PBRHex.HexLabels;

namespace PBRHex.Commands.FileCommands
{
    public class AddLabelCommand : Command
    {
        private readonly IFileEditor Editor;
        private readonly FileBuffer File;
        private readonly LabelType Type;
        private readonly int Address;
        private readonly int Size;
        private readonly string Name;
        private HexLabel Label;

        public AddLabelCommand(IFileEditor editor, FileBuffer file, LabelType type, int address, 
                               int size, string name) {
            Editor = editor;
            File = file;
            Type = type;
            Address = address;
            Size = size;
            Name = name;
        }

        public override bool Execute() {
            Label = File.AddLabel(Address, Size, Type, Name);
            Editor.AddLabel(Label);
            return true;
        }

        public override void Redo() {
            File.AddLabel(Address, Size, Type, Name);
            Editor.AddLabel(Label);
        }

        public override void Undo() {
            File.RemoveLabel(Address);
            Editor.RemoveLabel(Label);
        }
    }
}
