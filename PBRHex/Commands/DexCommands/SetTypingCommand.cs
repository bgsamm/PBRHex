using System;
using PBRHex.Tables;

namespace PBRHex.Commands.DexCommands
{
    public class SetTypingCommand : Command
    {
        private readonly IDexEditor Editor;
        private readonly Pokemon Pokemon;
        private readonly int Slot;
        private readonly int NewType;
        private int OldType1, OldType2;

        public SetTypingCommand(IDexEditor editor, Pokemon mon, int slot, int type) {
            Editor = editor;
            Pokemon = mon;
            Slot = slot;
            NewType = type;
        }

        public override bool Execute() {
            OldType1 = DexTable.GetTyping(Pokemon, 0);
            OldType2 = DexTable.GetTyping(Pokemon, 1);
            DexTable.SetTyping(Pokemon, Slot, NewType);
            Editor.SetTyping(Pokemon, Slot, NewType);
            // "Mono-type" actually means type1 == type2
            if(Slot == 0 && OldType1 == OldType2) {
                DexTable.SetTyping(Pokemon, 1, NewType);
                Editor.SetTyping(Pokemon, 1, NewType);
            }
            return true;
        }

        public override void Redo() {
            DexTable.SetTyping(Pokemon, Slot, NewType);
            Editor.SetTyping(Pokemon, Slot, NewType);
            if(Slot == 0 && OldType1 == OldType2) {
                DexTable.SetTyping(Pokemon, 1, NewType);
                Editor.SetTyping(Pokemon, 1, NewType);
            }
        }

        public override void Undo() {
            DexTable.SetTyping(Pokemon, 0, OldType1);
            DexTable.SetTyping(Pokemon, 1, OldType2);
            Editor.SetTyping(Pokemon, 0, OldType1);
            Editor.SetTyping(Pokemon, 1, OldType2);
        }
    }
}
