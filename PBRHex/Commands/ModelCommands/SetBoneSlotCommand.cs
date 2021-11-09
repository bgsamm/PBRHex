using System;
using PBRHex.Tables;

namespace PBRHex.Commands.ModelCommands
{
    public class SetBoneSlotCommand : Command
    {
        private readonly IModelEditor Editor;
        private readonly Pokemon Pokemon;
        private readonly int BoneSlot;
        private readonly int NewIndex;
        private int OldIndex;

        public SetBoneSlotCommand(IModelEditor editor, Pokemon mon, int slot, int bone) {
            Editor = editor;
            Pokemon = mon;
            BoneSlot = slot;
            NewIndex = bone;
        }

        public override bool Execute() {
            OldIndex = ModelTable.GetBoneSlot(Pokemon, BoneSlot);
            ModelTable.SetBoneSlot(Pokemon, BoneSlot, NewIndex);
            Editor.SetBoneSlot(Pokemon, BoneSlot, NewIndex);
            return true;
        }

        public override void Redo() {
            ModelTable.SetBoneSlot(Pokemon, BoneSlot, NewIndex);
            Editor.SetBoneSlot(Pokemon, BoneSlot, NewIndex);
        }

        public override void Undo() {
            ModelTable.SetBoneSlot(Pokemon, BoneSlot, OldIndex);
            Editor.SetBoneSlot(Pokemon, BoneSlot, OldIndex);
        }
    }
}