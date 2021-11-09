using System;
using PBRHex.Tables;

namespace PBRHex.Commands.StringCommands
{
    public class SetStringSpacingCommand : Command
    {
        private readonly IStringEditor Editor;
        private readonly int StringID;
        private readonly int NewSpacing;
        private int OldSpacing;

        public SetStringSpacingCommand(IStringEditor editor, int id, int spacing) {
            Editor = editor;
            StringID = id;
            NewSpacing = spacing;
        }

        public override bool Execute() {
            OldSpacing = (int)StringTable.GetStringProperty(StringID, "Spacing");
            StringTable.SetStringProperty(StringID, "Spacing", NewSpacing);
            Editor.SetSpacing(StringID, NewSpacing);
            return true;
        }

        public override void Redo() {
            StringTable.SetStringProperty(StringID, "Spacing", NewSpacing);
            Editor.SetSpacing(StringID, NewSpacing);
        }

        public override void Undo() {
            StringTable.SetStringProperty(StringID, "Spacing", OldSpacing);
            Editor.SetSpacing(StringID, OldSpacing);
        }
    }
}
