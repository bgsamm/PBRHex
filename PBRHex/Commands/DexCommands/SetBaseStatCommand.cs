using System;
using PBRHex.Tables;

namespace PBRHex.Commands.DexCommands
{
    public class SetBaseStatCommand : Command
    {
        private readonly IDexEditor Editor;
        private readonly Pokemon Pokemon;
        private readonly int StatIndex;
        private readonly int NewValue;
        private int OldValue;

        public SetBaseStatCommand(IDexEditor editor, Pokemon mon, int index, int value) {
            Editor = editor;
            Pokemon = mon;
            StatIndex = index;
            NewValue = value;
        }

        public override bool Execute() {
            OldValue = DexTable.GetStat(Pokemon, StatIndex);
            DexTable.SetStat(Pokemon, StatIndex, NewValue);
            Editor.SetBaseStat(Pokemon, StatIndex, NewValue);
            return true;
        }

        public override void Redo() {
            DexTable.SetStat(Pokemon, StatIndex, NewValue);
            Editor.SetBaseStat(Pokemon, StatIndex, NewValue);
        }

        public override void Undo() {
            DexTable.SetStat(Pokemon, StatIndex, OldValue);
            Editor.SetBaseStat(Pokemon, StatIndex, OldValue);
        }
    }
}
