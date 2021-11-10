using System;
using PBRHex.Files;
using PBRHex.HexLabels;

namespace PBRHex.Commands.FileCommands
{
    public class AddLabelCommand : Command
    {
        private readonly IFileEditor Editor;
        private readonly FileBuffer File;
        private readonly HexLabel Label;

        public AddLabelCommand(IFileEditor editor, FileBuffer file, HexLabel label) {
            Editor = editor;
            File = file;
            Label = label;
        }

        public override bool Execute() {
            File.AddLabel(Label);
            Editor.AddLabel(Label);
            return true;
        }

        public override void Redo() {
            File.AddLabel(Label);
            Editor.AddLabel(Label);
        }

        public override void Undo() {
            File.RemoveLabel(Label);
            Editor.RemoveLabel(Label);
        }
    }
}
