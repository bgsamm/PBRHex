using System;
using PBRHex.Tables;

namespace PBRHex.Commands.DexCommands
{
    public class SetFormNameCommand : Command
    {
        private readonly IDexEditor Editor;
        private readonly Pokemon Pokemon;
        private readonly string NewName;
        private string OldName;

        public SetFormNameCommand(IDexEditor editor, Pokemon mon, string name) {
            Editor = editor;
            Pokemon = mon;
            NewName = name;
        }

        public override bool Execute() {
            OldName = DexTable.GetFormName(Pokemon);
            DexTable.SetFormName(Pokemon, NewName);
            Editor.SetFormName(Pokemon, NewName);
            return true;
        }

        public override void Redo() {
            DexTable.SetFormName(Pokemon, NewName);
            Editor.SetFormName(Pokemon, NewName);
        }

        // when reverting to default, sets new string slot to "-----"
        // rather than removing it and resetting the form name ID
        public override void Undo() {
            DexTable.SetFormName(Pokemon, OldName);
            Editor.SetFormName(Pokemon, OldName);
        }
    }
}
