using PBRHex.Dialogs;

namespace PBRHex.HexEditor.Commands
{
    public class GoToCommand : Command<HexEditorWindow>
    {
        private readonly int toAddr;

        public GoToCommand(HexEditorWindow editor, int to) : base(editor) {
            toAddr = to;
        }

        public override bool Execute() {
            if(!Editor.IsAddressInbounds(toAddr)) {
                new AlertDialog() { Message = "Address out of bounds." }.ShowDialog();
            }
            else {
                Editor.LocationHistory.Insert(toAddr);
                Editor.GoToAddress(toAddr);
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
