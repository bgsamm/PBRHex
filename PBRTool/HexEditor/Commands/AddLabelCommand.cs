using System;
using System.Windows.Forms;
using PBRTool.Dialogs;
using PBRTool.HexLabels;
using PBRTool.Utils;

namespace PBRTool.HexEditor.Commands
{
    public class AddLabelCommand : Command<HexEditorWindow>
    {
        private readonly LabelType Type;
        private int Address;
        private int Size;
        private string Name;

        public AddLabelCommand(HexEditorWindow editor, LabelType type) : base(editor) {
            Type = type;
        }

        public override bool Execute() {
            if(!Editor.IsSelectionContiguous()) {
                new AlertDialog() { Message = "Invalid selection." }.ShowDialog();
                return false;
            }
            Address = Editor.GetSelectionRange().X;
            if(Editor.IsAddressLabeled(Address)) {
                new AlertDialog() { Message = "A label already exists at this address." }.ShowDialog();
                return false;
            }
            var input = new InputDialog() { Prompt = "Label name:", };
            var bytes = Editor.GetSelection();
            if(Type == LabelType.Float)
                input.Default = HexUtils.BytesToFloat(bytes).ToString();
            else
                input.Default = $"0x{Address:X8}";

            if(input.ShowDialog() == DialogResult.OK) {
                Size = bytes.Length;
                Name = input.Response;
                Editor.AddLabel(Address, Size, Type, Name);
                return true;
            }
            return false;
        }

        public override void Redo() {
            Editor.AddLabel(Address, Size, Type, Name);
        }

        public override void Undo() {
            Editor.RemoveLabel(Address);
        }
    }
}
