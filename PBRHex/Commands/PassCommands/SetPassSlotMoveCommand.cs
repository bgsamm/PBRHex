using System;
using PBRHex.Tables;

namespace PBRHex.Commands.PassCommands
{
    public class SetPassSlotMoveCommand : Command
    {
        private readonly IPassEditor Editor;
        private readonly int PassIndex;
        private readonly int PassSlot;
        private readonly int MoveSlot;
        private readonly int NewMove;
        private int OldMove;

        public SetPassSlotMoveCommand(IPassEditor editor, int pass, int slot, int moveSlot, int move) {
            Editor = editor;
            PassIndex = pass;
            PassSlot = slot;
            MoveSlot = moveSlot;
            NewMove = move;
        }

        public override bool Execute() {
            OldMove = PassTable.GetPassMemberMove(PassIndex, PassSlot, MoveSlot);
            PassTable.SetPassMemberMove(PassIndex, PassSlot, MoveSlot, NewMove);
            Editor.SetSlotMove(PassIndex, PassSlot, MoveSlot, NewMove);
            return true;
        }

        public override void Redo() {
            PassTable.SetPassMemberMove(PassIndex, PassSlot, MoveSlot, NewMove);
            Editor.SetSlotMove(PassIndex, PassSlot, MoveSlot, NewMove);
        }

        public override void Undo() {
            PassTable.SetPassMemberMove(PassIndex, PassSlot, MoveSlot, OldMove);
            Editor.SetSlotMove(PassIndex, PassSlot, MoveSlot, OldMove);
        }
    }
}
