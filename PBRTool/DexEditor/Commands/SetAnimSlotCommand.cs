using System;
using PBRTool.Tables;

namespace PBRTool.DexEditor.Commands
{
    public class SetAnimSlotCommand : Command<DexEditorWindow>
    {
        private readonly int MonID, FormID;
        private readonly int Gender;
        private readonly int AnimSlot;
        private readonly int NewIndex;
        private int OldIndex;

        public SetAnimSlotCommand(DexEditorWindow editor, int dex, int form, int gender, int slot, int anim) : base(editor) {
            MonID = dex;
            FormID = form;
            Gender = gender;
            AnimSlot = slot;
            NewIndex = anim;
        }

        public override bool Execute() {
            OldIndex = ModelTable.GetAnimSlot(MonID, FormID, Gender, AnimSlot);
            ModelTable.SetAnimSlot(MonID, FormID, Gender, AnimSlot, NewIndex);
            Editor.SetAnimSlot(MonID, AnimSlot, NewIndex);
            return true;
        }

        public override void Redo() {
            ModelTable.SetAnimSlot(MonID, FormID, Gender, AnimSlot, NewIndex);
            Editor.SetAnimSlot(MonID, AnimSlot, NewIndex);
        }

        public override void Undo() {
            ModelTable.SetAnimSlot(MonID, FormID, Gender, AnimSlot, OldIndex);
            Editor.SetAnimSlot(MonID, AnimSlot, OldIndex);
        }
    }
}