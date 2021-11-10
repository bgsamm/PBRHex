﻿using System;
using PBRHex.Tables;

namespace PBRHex.Commands.DexCommands
{
    public class SetSpeciesNameCommand : Command
    {
        private readonly IDexEditor Editor;
        private readonly Pokemon Pokemon;
        private readonly string NewName;
        private string OldName;

        public SetSpeciesNameCommand(IDexEditor editor, Pokemon mon, string name) {
            Editor = editor;
            Pokemon = mon;
            NewName = name;
        }

        public override bool Execute() {
            OldName = DexTable.GetSpeciesName(Pokemon.DexNo);
            DexTable.SetSpeciesName(Pokemon.DexNo, NewName);
            Editor.SetSpeciesName(Pokemon, NewName);
            return true;
        }

        public override void Redo() {
            DexTable.SetSpeciesName(Pokemon.DexNo, NewName);
            Editor.SetSpeciesName(Pokemon, NewName);
        }

        public override void Undo() {
            DexTable.SetSpeciesName(Pokemon.DexNo, OldName);
            Editor.SetSpeciesName(Pokemon, OldName);
        }
    }
}
