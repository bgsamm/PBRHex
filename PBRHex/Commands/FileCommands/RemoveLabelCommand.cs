using System;
using PBRHex.Files;
using PBRHex.HexLabels;

namespace PBRHex.Commands.FileCommands
{
    public class RemoveLabelCommand : Command
    {
        private readonly IFileEditor Editor;
        private readonly FileBuffer File;
        private readonly int Address;
        private HexLabel Label;

        public RemoveLabelCommand(IFileEditor editor, FileBuffer file, int address) {
            Editor = editor;
            File = file;
            Address = address;
        }

        public override bool Execute() {
            Label = File.RemoveLabel(Address);
            Editor.RemoveLabel(Label);
            return true;
        }

        public override void Redo() {
            File.RemoveLabel(Address);
            Editor.RemoveLabel(Label);
        }

        public override void Undo() {
            Label = File.AddLabel(Address, Label.Size, Label.Type, Label.Name);
            Editor.AddLabel(Label);
        }
    }
}
