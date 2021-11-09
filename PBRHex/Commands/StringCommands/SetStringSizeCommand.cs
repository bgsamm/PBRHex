using System;
using PBRHex.Tables;

namespace PBRHex.Commands.StringCommands
{
    public class SetStringSizeCommand : Command
    {
        private readonly IStringEditor Editor;
        private readonly int StringID;
        private readonly int NewSize;
        private int OldSize;

        public SetStringSizeCommand(IStringEditor editor, int id, int size) {
            Editor = editor;
            StringID = id;
            NewSize = size;
        }

        public override bool Execute() {
            OldSize = (int)StringTable.GetStringProperty(StringID, "Size");
            StringTable.SetStringProperty(StringID, "Size", NewSize);
            Editor.SetSize(StringID, NewSize);
            return true;
        }

        public override void Redo() {
            StringTable.SetStringProperty(StringID, "Size", NewSize);
            Editor.SetSize(StringID, NewSize);
        }

        public override void Undo() {
            StringTable.SetStringProperty(StringID, "Size", OldSize);
            Editor.SetSize(StringID, OldSize);
        }
    }
}
