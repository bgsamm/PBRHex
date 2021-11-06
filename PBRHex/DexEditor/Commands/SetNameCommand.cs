using System;
using PBRHex.Tables;

namespace PBRHex.DexEditor.Commands
{
    public class SetNameCommand : Command<DexEditorWindow>
    {
        private readonly string NewName;
        private readonly int MonID;
        private string OldName;

        public SetNameCommand(DexEditorWindow editor, int dex, string name) : base(editor) {
            MonID = dex;
            NewName = name;
        }

        public override bool Execute() {
            OldName = DexTable.GetName(MonID);
            DexTable.SetName(MonID, NewName);
            Editor.SetName(MonID, NewName);
            return true;
        }

        public override void Redo() {
            DexTable.SetName(MonID, NewName);
            Editor.SetName(MonID, NewName);
        }

        public override void Undo() {
            DexTable.SetName(MonID, OldName);
            Editor.SetName(MonID, OldName);
        }
    }
}
