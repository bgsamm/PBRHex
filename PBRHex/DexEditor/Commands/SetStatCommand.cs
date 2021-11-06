using PBRHex.Tables;
using System;

namespace PBRHex.DexEditor.Commands
{
    public class SetStatCommand : Command<DexEditorWindow>
    {
        private readonly int MonID, FormID;
        private readonly int StatIndex;
        private readonly int NewValue;
        private int OldValue;

        public SetStatCommand(DexEditorWindow dexEditor, int dex, int form, int index, int value) : base(dexEditor) {
            MonID = dex;
            FormID = form;
            StatIndex = index;
            NewValue = value;
        }
        public override bool Execute() {
            OldValue = DexTable.GetStat(MonID, FormID, StatIndex);
            DexTable.SetStat(MonID, FormID, StatIndex, NewValue);
            Editor.SetStat(MonID, StatIndex, NewValue);
            return true;
        }

        public override void Redo() {
            DexTable.SetStat(MonID, FormID, StatIndex, NewValue);
            Editor.SetStat(MonID, StatIndex, NewValue);
        }

        public override void Undo() {
            DexTable.SetStat(MonID, FormID, StatIndex, OldValue);
            Editor.SetStat(MonID, StatIndex, OldValue);
        }
    }
}
