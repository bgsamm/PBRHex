using System;
using System.Windows.Forms;
using PBRTool.Dialogs;
using PBRTool.HexLabels;

namespace PBRTool.HexEditor.Commands
{
    public class RenameLabelCommand : Command<HexEditorWindow>
    {
        private readonly HexLabel Label;
        private string OldName, NewName;

        public RenameLabelCommand(HexEditorWindow editor, HexLabel label) : base(editor) {
            Label = label;
        }

        public override bool Execute() {
            OldName = Label.Name;
            var input = new InputDialog()
            {
                Prompt = "Enter label name",
                Default = OldName
            };
            if(input.ShowDialog() == DialogResult.OK) {
                NewName = input.Response;
                Editor.RenameLabel(Label, NewName);
                return true;
            }
            return false;
        }

        public override void Redo() {
            Editor.RenameLabel(Label, NewName);
        }

        public override void Undo() {
            Editor.RenameLabel(Label, OldName);
        }
    }
}
