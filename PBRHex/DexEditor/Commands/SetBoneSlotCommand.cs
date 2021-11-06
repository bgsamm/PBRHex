using System;
using PBRHex.Tables;

namespace PBRHex.DexEditor.Commands
{
    public class SetBoneSlotCommand : Command<DexEditorWindow>
    {
        private readonly int MonID, FormID;
        private readonly int Gender;
        private readonly int BoneSlot;
        private readonly int NewIndex;
        private int OldIndex;

        public SetBoneSlotCommand(DexEditorWindow editor, int dex, int form, int gender, int slot, int bone) : base(editor) {
            MonID = dex;
            FormID = form;
            Gender = gender;
            BoneSlot = slot;
            NewIndex = bone;
        }

        public override bool Execute() {
            OldIndex = ModelTable.GetBoneSlot(MonID, FormID, Gender, BoneSlot);
            ModelTable.SetBoneSlot(MonID, FormID, Gender, BoneSlot, NewIndex);
            Editor.SetBoneSlot(MonID, BoneSlot, NewIndex);
            return true;
        }

        public override void Redo() {
            ModelTable.SetBoneSlot(MonID, FormID, Gender, BoneSlot, NewIndex);
            Editor.SetBoneSlot(MonID, BoneSlot, NewIndex);
        }

        public override void Undo() {
            ModelTable.SetBoneSlot(MonID, FormID, Gender, BoneSlot, OldIndex);
            Editor.SetBoneSlot(MonID, BoneSlot, OldIndex);
        }
    }
}