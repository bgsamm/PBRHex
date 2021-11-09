using System;
using PBRHex.Tables;

namespace PBRHex.Commands.StringCommands
{
    public class SetStringTextCommand : Command
    {
        private readonly IStringEditor Editor;
        private readonly int StringID;
        private readonly string NewText;
        private string OldText;

        public SetStringTextCommand(IStringEditor editor, int id, string text) {
            Editor = editor;
            StringID = id;
            NewText = text;
        }

        public override bool Execute() {
            OldText = (string)StringTable.GetStringProperty(StringID, "Text");
            StringTable.SetStringProperty(StringID, "Text", NewText);
            Editor.SetText(StringID, NewText);
            return true;
        }

        public override void Redo() {
            StringTable.SetStringProperty(StringID, "Text", NewText);
            Editor.SetText(StringID, NewText);
        }

        public override void Undo() {
            StringTable.SetStringProperty(StringID, "Text", OldText);
            Editor.SetText(StringID, OldText);
        }
    }
}
