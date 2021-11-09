using System;
using PBRHex.Tables;

namespace PBRHex.Commands.StringCommands
{
    public class AddStringCommand : Command
    {
        private readonly IStringEditor Editor;
        private readonly string Text;
        private int StringID;

        public AddStringCommand(IStringEditor editor, string s) {
            Editor = editor;
            Text = s;
        }

        public override bool Execute() {
            StringID = StringTable.AddString(Text);
            var gs = StringTable.GetString(StringID);
            Editor.AddString(gs);
            return false;
        }

        public override void Redo() {
            StringID = StringTable.AddString(Text);
            var gs = StringTable.GetString(StringID);
            Editor.AddString(gs);
        }

        public override void Undo() {
            throw new NotImplementedException();
            //var gs = StringTable.RemoveString(StringID);
            //Editor.RemoveString(gs);
        }
    }
}
