using PBRHex.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBRHex.DexEditor.Commands
{
    public class SetTypeCommand : Command<DexEditorWindow>
    {
        private readonly int MonID, FormID;
        private readonly int Slot;
        private readonly int NewType;
        private int OldType1, OldType2;

        public SetTypeCommand(DexEditorWindow editor, int dex, int form, int slot, int type) : base(editor) {
            MonID = dex;
            FormID = form;
            Slot = slot;
            NewType = type;
        }

        public override bool Execute() {
            OldType1 = DexTable.GetTyping(MonID, FormID, 0);
            OldType2 = DexTable.GetTyping(MonID, FormID, 1);
            DexTable.SetTyping(MonID, FormID, Slot, NewType);
            Editor.SetTyping(MonID, Slot, NewType);
            // "Mono-type" actually means type1 == type2
            if(Slot == 0 && OldType1 == OldType2) {
                DexTable.SetTyping(MonID, FormID, 1, NewType);
                Editor.SetTyping(MonID, 1, NewType);
            }
            return true;
        }

        public override void Redo() {
            DexTable.SetTyping(MonID, FormID, Slot, NewType);
            Editor.SetTyping(MonID, Slot, NewType);
            if(Slot == 0 && OldType1 == OldType2) {
                DexTable.SetTyping(MonID, FormID, 1, NewType);
                Editor.SetTyping(MonID, 1, NewType);
            }
        }

        public override void Undo() {
            DexTable.SetTyping(MonID, FormID, 0, OldType1);
            DexTable.SetTyping(MonID, FormID, 1, OldType2);
            Editor.SetTyping(MonID, 0, OldType1);
            Editor.SetTyping(MonID, 1, OldType2);
        }
    }
}
