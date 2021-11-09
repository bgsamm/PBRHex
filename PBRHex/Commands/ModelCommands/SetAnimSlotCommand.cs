using System;
using PBRHex.Tables;

namespace PBRHex.Commands.ModelCommands
{
    public class SetAnimSlotCommand : Command
    {
        private readonly IModelEditor Editor;
        private readonly Pokemon Pokemon;
        private readonly int AnimSlot;
        private readonly int NewIndex;
        private int OldIndex;

        public SetAnimSlotCommand(IModelEditor editor, Pokemon mon, int slot, int anim) {
            Editor = editor;
            Pokemon = mon;
            AnimSlot = slot;
            NewIndex = anim;
        }

        public override bool Execute() {
            OldIndex = ModelTable.GetAnimSlot(Pokemon, AnimSlot);
            ModelTable.SetAnimSlot(Pokemon, AnimSlot, NewIndex);
            Editor.SetAnimSlot(Pokemon, AnimSlot, NewIndex);
            return true;
        }

        public override void Redo() {
            ModelTable.SetAnimSlot(Pokemon, AnimSlot, NewIndex);
            Editor.SetAnimSlot(Pokemon, AnimSlot, NewIndex);
        }

        public override void Undo() {
            ModelTable.SetAnimSlot(Pokemon, AnimSlot, OldIndex);
            Editor.SetAnimSlot(Pokemon, AnimSlot, OldIndex);
        }
    }
}