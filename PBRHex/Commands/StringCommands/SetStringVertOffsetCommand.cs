using System;
using PBRHex.Tables;

namespace PBRHex.Commands.StringCommands
{
    public class SetStringVertOffsetCommand : Command
    {
        private readonly IStringEditor Editor;
        private readonly int StringID;
        private readonly int NewOffset;
        private int OldOffset;

        public SetStringVertOffsetCommand(IStringEditor editor, int id, int offset) {
            Editor = editor;
            StringID = id;
            NewOffset = offset;
        }

        public override bool Execute() {
            OldOffset = (int)StringTable.GetStringProperty(StringID, "Offset");
            StringTable.SetStringProperty(StringID, "Offset", NewOffset);
            Editor.SetVertOffset(StringID, NewOffset);
            return true;
        }

        public override void Redo() {
            StringTable.SetStringProperty(StringID, "Offset", NewOffset);
            Editor.SetVertOffset(StringID, NewOffset);
        }

        public override void Undo() {
            StringTable.SetStringProperty(StringID, "Offset", OldOffset);
            Editor.SetVertOffset(StringID, OldOffset);
        }
    }
}
