using PBRHex.Dialogs;
using PBRHex.Tables;

namespace PBRHex.StringEditor.Commands
{
    public class GoToCommand : Command<StringEditorWindow>
    {
        private readonly int StringID;

        public GoToCommand(StringEditorWindow editor, int id) : base(editor) {
            StringID = id;
        }

        public override bool Execute() {
            if(StringID > StringTable.Count) {
                new AlertDialog() { Message = "Invalid string ID." }.ShowDialog();
            }
            else {
                Editor.LocationHistory.Insert(StringID);
                Editor.GoToString(StringID);
                Editor.RefreshHistoryButtons();
            }
            return false;
        }

        public override void Redo() {
            throw new System.NotImplementedException();
        }

        public override void Undo() {
            throw new System.NotImplementedException();
        }
    }
}
