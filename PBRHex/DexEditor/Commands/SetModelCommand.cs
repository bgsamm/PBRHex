using System;
using PBRHex.Files;
using PBRHex.Tables;
using PBRHex.Utils;

namespace PBRHex.DexEditor.Commands
{
    public class SetModelCommand : Command<DexEditorWindow>
    {
        private readonly int MonID, FormID;
        private readonly int Gender;
        private readonly bool Shiny;
        private readonly byte[] NewModelData;
        private byte[] OldModelData;
        private readonly int[] OldBoneSlots, NewBoneSlots;
        private readonly int[] OldAnimSlots, NewAnimSlots;

        public SetModelCommand(DexEditorWindow editor, FileBuffer sdr, int dex, int form, 
                                int gender, bool shiny = false) : base(editor) {
            MonID = dex;
            FormID = form;
            Gender = gender;
            Shiny = shiny;
            NewModelData = sdr.GetData();

            OldBoneSlots = new int[ModelTable.BoneFilters.Length];
            NewBoneSlots = new int[ModelTable.BoneFilters.Length];
            OldAnimSlots = new int[ModelTable.AnimFilters.Length];
            NewAnimSlots = new int[ModelTable.AnimFilters.Length];
        }

        private void SetModelFromBytes(byte[] bytes) {
            string path = $@"{Program.TempDir}\temp.sdr";
            var temp = FileUtils.CreateFile(path, bytes);
            ModelTable.SetModel(temp, MonID, FormID, Gender, Shiny);
            FileUtils.DeleteFile(path);
        }

        private void SetBoneSlots(int[] slots) {
            for(int i = 0; i < ModelTable.BoneFilters.Length; i++) {
                ModelTable.SetBoneSlot(MonID, FormID, 0, i, slots[i]);
            }
        }

        private void SetAnimSlots(int[] slots) {
            for(int i = 0; i < ModelTable.AnimFilters.Length; i++) {
                ModelTable.SetAnimSlot(MonID, FormID, 0, i, slots[i]);
            }
        }

        public override bool Execute() {
            OldModelData = ModelTable.GetModel(MonID, FormID, Gender, Shiny).GetData();
            SetModelFromBytes(NewModelData);
            // slots are determined from the normal/base model
            if(Shiny)
                return true;
            var boneNames = ModelTable.GetBoneNames(MonID, FormID, Gender, Shiny);
            for(int i = 0; i < ModelTable.BoneFilters.Length; i++) {
                OldBoneSlots[i] = ModelTable.GetBoneSlot(MonID, FormID, Gender, i);
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
            var animNames = ModelTable.GetAnimNames(MonID, FormID, Gender, Shiny);
            for(int i = 0; i < ModelTable.AnimFilters.Length; i++) {
                OldAnimSlots[i] = ModelTable.GetAnimSlot(MonID, FormID, Gender, i);
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
            Editor.UpdateModelPageComboBoxes();
            return true;
        }

        public override void Redo() {
            SetModelFromBytes(NewModelData);
            if(!Shiny) {
                SetBoneSlots(NewBoneSlots);
                SetAnimSlots(NewAnimSlots);
                Editor.UpdateModelPageComboBoxes();
            }
        }

        public override void Undo() {
            SetModelFromBytes(OldModelData);
            if(!Shiny) {
                SetBoneSlots(OldBoneSlots);
                SetAnimSlots(OldAnimSlots);
                Editor.UpdateModelPageComboBoxes();
            }
        }
    }
}
