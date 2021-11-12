using System;
using PBRHex.Tables;

namespace PBRHex.Commands.PassCommands
{
    public class SetPassSlotSpeciesCommand : Command
    {
        private readonly IPassEditor Editor;
        private readonly int PassIndex;
        private readonly int PassSlot;
        private readonly Pokemon NewSpecies;
        private Pokemon OldSpecies;

        public SetPassSlotSpeciesCommand(IPassEditor editor, int pass, int slot, Pokemon mon) {
            Editor = editor;
            PassIndex = pass;
            PassSlot = slot;
            NewSpecies = mon;
        }

        public override bool Execute() {
            OldSpecies = PassTable.GetPassMemberSpecies(PassIndex, PassSlot);
            PassTable.SetPassMemberSpecies(PassIndex, PassSlot, NewSpecies);
            Editor.SetSlotSpecies(PassIndex, PassSlot, NewSpecies);
            return true;
        }

        public override void Redo() {
            PassTable.SetPassMemberSpecies(PassIndex, PassSlot, NewSpecies);
            Editor.SetSlotSpecies(PassIndex, PassSlot, NewSpecies);
        }

        public override void Undo() {
            PassTable.SetPassMemberSpecies(PassIndex, PassSlot, OldSpecies);
            Editor.SetSlotSpecies(PassIndex, PassSlot, OldSpecies);
        }
    }
}
