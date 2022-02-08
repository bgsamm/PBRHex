using System;
using PBRHex.Tables;

namespace PBRHex.Commands.DexCommands
{
    public class SetTierCommand : Command
    {
        private readonly IDexEditor Editor;
        private readonly Pokemon Pokemon;
        private readonly SmogonTier NewTier;
        private SmogonTier OldTier;

        public SetTierCommand(IDexEditor editor, Pokemon mon, SmogonTier tier) {
            Editor = editor;
            Pokemon = mon;
            NewTier = tier;
        }

        public override bool Execute() {
            OldTier = DexTable.GetTier(Pokemon);
            DexTable.SetTier(Pokemon, NewTier);
            Editor.SetTier(Pokemon, NewTier);
            return true;
        }

        public override void Redo() {
            DexTable.SetTier(Pokemon, NewTier);
            Editor.SetTier(Pokemon, NewTier);
        }

        public override void Undo() {
            DexTable.SetTier(Pokemon, OldTier);
            Editor.SetTier(Pokemon, OldTier);
        }
    }
}
