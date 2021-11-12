using System;
using PBRHex.Tables;

namespace PBRHex.Commands.PassCommands
{
    public class SetPassSlotAbilityCommand : Command
    {
        private readonly IPassEditor Editor;
        private readonly int PassIndex;
        private readonly int PassSlot;
        private readonly int NewAbilitySlot;
        private int OldAbilitySlot;

        public SetPassSlotAbilityCommand(IPassEditor editor, int pass, int slot, int abSlot) {
            Editor = editor;
            PassIndex = pass;
            PassSlot = slot;
            NewAbilitySlot = abSlot;
        }

        public override bool Execute() {
            OldAbilitySlot = PassTable.GetPassMemberAbilitySlot(PassIndex, PassSlot);
            PassTable.SetPassMemberAbilitySlot(PassIndex, PassSlot, NewAbilitySlot);
            Editor.SetSlotAbility(PassIndex, PassSlot, NewAbilitySlot);
            return true;
        }

        public override void Redo() {
            PassTable.SetPassMemberAbilitySlot(PassIndex, PassSlot, NewAbilitySlot);
            Editor.SetSlotAbility(PassIndex, PassSlot, NewAbilitySlot);
        }

        public override void Undo() {
            PassTable.SetPassMemberAbilitySlot(PassIndex, PassSlot, OldAbilitySlot);
            Editor.SetSlotAbility(PassIndex, PassSlot, OldAbilitySlot);
        }
    }
}
