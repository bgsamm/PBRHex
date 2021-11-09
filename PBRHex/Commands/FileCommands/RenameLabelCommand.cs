using System;
using PBRHex.Files;
using PBRHex.HexLabels;

namespace PBRHex.Commands.FileCommands
{
    public class RenameLabelCommand : Command
    {
        private readonly IFileEditor Editor;
        private readonly FileBuffer File;
        private readonly HexLabel Label;
        private readonly string OldName, NewName;

        public RenameLabelCommand(IFileEditor editor, FileBuffer file, HexLabel label,
                                  string name) {
            Editor = editor;
            File = file;
            Label = label;
            OldName = label.Name;
            NewName = name;
        }

        public override bool Execute() {
            Label.Name = NewName;
            File.RenameLabel(Label.Address, NewName);
            Editor.RenameLabel(Label, NewName);
            return false;
        }

        public override void Redo() {
            Label.Name = NewName;
            File.RenameLabel(Label.Address, NewName);
            Editor.RenameLabel(Label, NewName);
        }

        public override void Undo() {
            Label.Name = OldName;
            File.RenameLabel(Label.Address, OldName);
            Editor.RenameLabel(Label, OldName);
        }
    }
}
