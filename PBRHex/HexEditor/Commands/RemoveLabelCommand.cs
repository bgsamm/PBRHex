using System;
using PBRHex.HexLabels;

namespace PBRHex.HexEditor.Commands
{
    public class RemoveLabelCommand : Command<HexEditorWindow>
    {
        private readonly int Address;
        private HexLabel Label;

        public RemoveLabelCommand(HexEditorWindow editor, int address) : base(editor) {
            Address = address;
        }

        public override bool Execute() {
            Label = Editor.RemoveLabel(Address);
            return true;
        }

        public override void Redo() {
            Editor.RemoveLabel(Address);
        }

        public override void Undo() {
            Editor.AddLabel(Address, Label.Size, Label.Type, Label.Name);
        }
    }
}
