using System;
using PBRHex.Tables;

namespace PBRHex.Commands.DexCommands
{
    public class SetAbilityCommand : Command
    {
        private readonly IDexEditor Editor;
        private readonly Pokemon Pokemon;
        private readonly int Slot;
        private readonly int NewAbility;
        private int OldAbility;

        public SetAbilityCommand(IDexEditor editor, Pokemon mon, int slot, int ability) {
            Editor = editor;
            Pokemon = mon;
            Slot = slot;
            NewAbility = ability;
        }

        public override bool Execute() {
            OldAbility = DexTable.GetAbility(Pokemon, Slot);
            DexTable.SetAbility(Pokemon, Slot, NewAbility);
            Editor.SetAbility(Pokemon, Slot, NewAbility);
            return true;
        }

        public override void Redo() {
            DexTable.SetAbility(Pokemon, Slot, NewAbility);
            Editor.SetAbility(Pokemon, Slot, NewAbility);
        }

        public override void Undo() {
            DexTable.SetAbility(Pokemon, Slot, OldAbility);
            Editor.SetAbility(Pokemon, Slot, OldAbility);
        }
    }
}
