using System;
using PBRHex.Tables;

namespace PBRHex.Commands.StringCommands
{
    public class SetStringAlignmentCommand : Command
    {
        private readonly IStringEditor Editor;
        private readonly int StringID;
        private readonly int NewAlignment;
        private int OldAlignment;

        public SetStringAlignmentCommand(IStringEditor editor, int id, int alignment) {
            Editor = editor;
            StringID = id;
            NewAlignment = alignment;
        }

        public override bool Execute() {
            OldAlignment = (int)StringTable.GetStringProperty(StringID, "Alignment");
            StringTable.SetStringProperty(StringID, "Alignment", NewAlignment);
            Editor.SetAlignment(StringID, NewAlignment);
            return true;
        }

        public override void Redo() {
            StringTable.SetStringProperty(StringID, "Alignment", NewAlignment);
            Editor.SetAlignment(StringID, NewAlignment);
        }

        public override void Undo() {
            StringTable.SetStringProperty(StringID, "Alignment", OldAlignment);
            Editor.SetAlignment(StringID, OldAlignment);
        }
    }
}
