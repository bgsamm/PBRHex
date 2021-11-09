using System;
using PBRHex.Files;
using PBRHex.Tables;
using PBRHex.Utils;

namespace PBRHex.Commands.ModelCommands
{
    public class SetModelCommand : Command
    {
        private readonly IModelEditor Editor;
        private readonly Pokemon Pokemon;
        private readonly byte[] NewModelData;
        private byte[] OldModelData;
        private readonly int[] OldBoneSlots, NewBoneSlots;
        private readonly int[] OldAnimSlots, NewAnimSlots;

        public SetModelCommand(IModelEditor editor, FileBuffer sdr, Pokemon mon) {
            Editor = editor;
            Pokemon = mon;
            NewModelData = sdr.GetBufferCopy();

            OldBoneSlots = new int[ModelTable.BoneFilters.Length];
            NewBoneSlots = new int[ModelTable.BoneFilters.Length];
            OldAnimSlots = new int[ModelTable.AnimFilters.Length];
            NewAnimSlots = new int[ModelTable.AnimFilters.Length];
        }

        private void SetModelFromBytes(byte[] bytes) {
            string path = $@"{Program.TempDir}\temp.sdr";
            var temp = FileUtils.CreateFile(path, bytes);
            ModelTable.SetModel(temp, Pokemon);
            Editor.SetModel(Pokemon, temp);
            FileUtils.DeleteFile(path);
        }

        private void SetBoneSlots(int[] slots) {
            for(int i = 0; i < ModelTable.BoneFilters.Length; i++) {
                ModelTable.SetBoneSlot(Pokemon, i, slots[i]);
            }
        }

        private void SetAnimSlots(int[] slots) {
            for(int i = 0; i < ModelTable.AnimFilters.Length; i++) {
                ModelTable.SetAnimSlot(Pokemon, i, slots[i]);
            }
        }

        public override bool Execute() {
            OldModelData = ModelTable.GetModel(Pokemon).GetBufferCopy();
            SetModelFromBytes(NewModelData);
            // slots are determined from the normal/base model
            if(Pokemon.Shiny)
                return true;
            var boneNames = ModelTable.GetBoneNames(Pokemon);
            for(int i = 0; i < ModelTable.BoneFilters.Length; i++) {
                OldBoneSlots[i] = ModelTable.GetBoneSlot(Pokemon, i);
                // auto-fill
                for(int j = 0; j < ModelTable.BoneFilters[i].Length; j++) {
                    int idx = Array.FindIndex(boneNames, x => x == ModelTable.BoneFilters[i][j]);
                    if(idx >= 0) {
                        NewBoneSlots[i] = idx;
                        break;
                    }
                }
            }
            SetBoneSlots(NewBoneSlots);
            var animNames = ModelTable.GetAnimNames(Pokemon);
            for(int i = 0; i < ModelTable.AnimFilters.Length; i++) {
                OldAnimSlots[i] = ModelTable.GetAnimSlot(Pokemon, i);
                if(i >= 19)
                    NewAnimSlots[i] = 0xff;
                // auto-fill
                for(int j = 0; j < ModelTable.AnimFilters[i].Length; j++) {
                    int idx = Array.FindIndex(animNames, x => x == ModelTable.AnimFilters[i][j]);
                    if(idx >= 0) {
                        NewAnimSlots[i] = idx;
                        break;
                    }
                }
            }
            SetAnimSlots(NewAnimSlots);
            return true;
        }

        public override void Redo() {
            SetModelFromBytes(NewModelData);
            if(!Pokemon.Shiny) {
                SetBoneSlots(NewBoneSlots);
                SetAnimSlots(NewAnimSlots);
            }
        }

        public override void Undo() {
            SetModelFromBytes(OldModelData);
            if(!Pokemon.Shiny) {
                SetBoneSlots(OldBoneSlots);
                SetAnimSlots(OldAnimSlots);
            }
        }
    }
}
