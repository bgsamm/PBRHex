using System;
using PBRHex.Tables;

namespace PBRHex.Commands.PassCommands
{
    public class SetPassSlotHeldItemCommand : Command
    {
        private readonly IPassEditor Editor;
        private readonly int PassIndex;
        private readonly int PassSlot;
        private readonly int NewItem;
        private int OldItem;

        public SetPassSlotHeldItemCommand(IPassEditor editor, int pass, int slot, int item) {
            Editor = editor;
            PassIndex = pass;
            PassSlot = slot;
            NewItem = item;
        }

        public override bool Execute() {
            OldItem = PassTable.GetPassMemberItem(PassIndex, PassSlot);
            PassTable.SetPassMemberItem(PassIndex, PassSlot, NewItem);
            Editor.SetSlotItem(PassIndex, PassSlot, NewItem);
            return true;
        }

        public override void Redo() {
            PassTable.SetPassMemberItem(PassIndex, PassSlot, NewItem);
            Editor.SetSlotItem(PassIndex, PassSlot, NewItem);
        }

        public override void Undo() {
            PassTable.SetPassMemberItem(PassIndex, PassSlot, OldItem);
            Editor.SetSlotItem(PassIndex, PassSlot, OldItem);
        }
    }
}
