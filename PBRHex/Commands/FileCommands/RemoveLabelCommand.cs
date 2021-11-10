using System;
using PBRHex.Files;
using PBRHex.HexLabels;

namespace PBRHex.Commands.FileCommands
{
    public class RemoveLabelCommand : Command
    {
        private readonly IFileEditor Editor;
        private readonly FileBuffer File;
        private readonly HexLabel Label;

        public RemoveLabelCommand(IFileEditor editor, FileBuffer file, HexLabel label) {
            Editor = editor;
            File = file;
            Label = label;
        }

        public override bool Execute() {
            File.RemoveLabel(Label);
            Editor.RemoveLabel(Label);
            return true;
        }

        public override void Redo() {
            File.RemoveLabel(Label);
            Editor.RemoveLabel(Label);
        }

        public override void Undo() {
            File.AddLabel(Label);
            Editor.AddLabel(Label);
        }
    }
}
