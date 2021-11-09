using System;
using PBRHex.Tables;

namespace PBRHex.Commands.StringCommands
{
    public class SetStringColorCommand : Command
    {
        private readonly IStringEditor Editor;
        private readonly int StringID;
        private readonly int NewColor;
        private int OldColor;

        public SetStringColorCommand(IStringEditor editor, int id, int color) {
            Editor = editor;
            StringID = id;
            NewColor = color;
        }

        public override bool Execute() {
            OldColor = (int)StringTable.GetStringProperty(StringID, "Color");
            StringTable.SetStringProperty(StringID, "Color", NewColor);
            Editor.SetColor(StringID, NewColor);
            return true;
        }

        public override void Redo() {
            StringTable.SetStringProperty(StringID, "Color", NewColor);
            Editor.SetColor(StringID, NewColor);
        }

        public override void Undo() {
            StringTable.SetStringProperty(StringID, "Color", OldColor);
            Editor.SetColor(StringID, OldColor);
        }
    }
}
