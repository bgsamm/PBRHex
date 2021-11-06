﻿using System;
using PBRTool.Files;
using PBRTool.Utils;

namespace PBRTool.Tables
{
    public static class ModelTable
    {
        public static readonly string[][] BoneFilters =
        {
            new string[]{ "ef_damage" }, // 0
            new string[]{ "ef_mouth" }, // 1
            new string[]{ "ef_leye", "ef_eye" }, // 2
            new string[]{ "ef_reye", "ef_eye" }, // 3
            new string[]{ "root" }, // 4
            new string[]{ "ef_lhand", "ef_lfhand", "ef_lwing" }, // 5
            new string[]{ "ef_rhand", "ef_rfhand", "ef_rwing" }, // 6
            new string[]{ "ef_lffoot", "ef_lfoot", "ef_foot" }, // 7
            new string[]{ "ef_rffoot", "ef_rfoot", "ef_foot" }, // 8
            new string[]{ "ef_o", "ef_hip" }, // 9
            new string[]{ "ct_all_move" }, // A
            new string[]{ "ef_head", "ef_horn", "ef_top" }, // B
            new string[]{ "ef_rhand", "ef_rfhand", "ef_rwing" }, // C
            new string[]{ "ef_rffoot" }, // D
            new string[]{ "root" }, // E
            new string[]{ "root" }, // F
            new string[]{ "root" }, // 10
            new string[]{ "root" }, // 11
            new string[]{ "root" }, // 12
            new string[]{ "ef_damage" }, // 13
            new string[]{ "direct_set" }, // 14
            new string[]{ "ct_bust" }, // 15
            new string[]{ "ct_bust_move" }, // 16
            new string[]{ "ct_all" }, // 17
            new string[]{ "ct_all_move" }, // 18
        };

        public static readonly string[][] AnimFilters =
        {
            new string[]{ "wait" }, // 0
            new string[]{ "move", "move_spec", "move_special" }, // 1
            new string[]{ "tackle", "move_phys", "move_physical" }, // 2
            new string[]{ "punch", "tackle", "move_phys" }, // 3
            new string[]{ "kick", "tackle", "move_phys" }, // 4
            new string[]{ "takeoff", "wait" }, // 5
            new string[]{ "dive", "wait" }, // 6
            new string[]{ "punch", "tackle", "move_phys" }, // 7
            new string[]{ "damage", "hurt" }, // 8
            new string[]{ "down", "faint" }, // 9
            new string[]{ "midair_wait", "wait" }, // A
            new string[]{ "wait" }, // B
            new string[]{ "wait" }, // C
            new string[]{ "wait" }, // D
            new string[]{ "wait" }, // E
            new string[]{ "wait" }, // F
            new string[]{ "move_stat", "wait" }, // 10
            new string[]{ "run" }, // 11
            new string[]{ "wait" }, // 12
            new string[]{ "tx_blink", "tx_wink" }, // 13
            new string[]{ "tx_sleep" }, // 14
            new string[]{ "tx_wakeup" }, // 15
        };

        private static FSYS Common => FSYSTable.GetFile("common");
        private static FileBuffer Common6 => Common.Files[6];

        public static int GetBoneCount(int dex, int form, int gender, bool shiny = false) {
            var file = GetModel(dex, form, gender, shiny);
            int skeleAddr = file.ReadInt(file.ReadInt(8));
            return file.ReadShort(skeleAddr + 6);
        }

        public static string GetBoneName(int index, int dex, int form, int gender, bool shiny = false) {
            var file = GetModel(dex, form, gender, shiny);
            int skeleAddr = file.ReadInt(file.ReadInt(8)),
                boneCount = file.ReadShort(skeleAddr + 6);
            if(index > boneCount - 1)
                throw new IndexOutOfRangeException();
            int rootBone = file.ReadInt(skeleAddr + 0x10),
                boneAddr = BoneSearch(file, index, rootBone),
                nameAddr = file.ReadInt(boneAddr + 4);
            return file.ReadString(nameAddr);
        }

        public static string[] GetBoneNames(int dex, int form, int gender, bool shiny = false) {
            int count = GetBoneCount(dex, form, gender, shiny);
            string[] names = new string[count];
            for(int i = 0; i < names.Length; i++) {
                names[i] = GetBoneName(i, dex, form, gender, shiny);
            }
            return names;
        }

        public static int GetBoneSlot(int dex, int form, int gender, int slot) {
            if(slot > 0x18)
                throw new IndexOutOfRangeException();
            int offset = GetModelTableOffset(dex, form, gender);
            return Common6.ReadByte(offset + 0x19 + slot);
        }

        public static int GetAnimCount(int dex, int form, int gender, bool shiny = false) {
            var file = GetModel(dex, form, gender, shiny);
            int skeleAddr = file.ReadInt(file.ReadInt(8));
            return file.ReadShort(skeleAddr + 8);
        }

        public static string GetAnimName(int index, int dex, int form, int gender, bool shiny = false) {
            var file = GetModel(dex, form, gender, shiny);
            int skeleAddr = file.ReadInt(file.ReadInt(8)),
                numActions = file.ReadShort(skeleAddr + 8);
            if(index > numActions - 1)
                throw new IndexOutOfRangeException();
            int actionsList = file.ReadInt(skeleAddr + 0xc),
                nameAddr = file.ReadInt(actionsList + 0x30 * index);
            return file.ReadString(nameAddr);
        }

        public static string[] GetAnimNames(int dex, int form, int gender, bool shiny = false) {
            int count = GetAnimCount(dex, form, gender, shiny);
            string[] names = new string[count];
            for(int i = 0; i < names.Length; i++) {
                names[i] = GetAnimName(i, dex, form, gender, shiny);
            }
            return names;
        }

        public static int GetAnimSlot(int dex, int form, int gender, int slot) {
            if(slot > 0x15)
                throw new IndexOutOfRangeException();
            int offset = GetModelTableOffset(dex, form, gender);
            return Common6.ReadByte(offset + 0x32 + slot);
        }

        public static void SetBoneSlot(int dex, int form, int gender, int slot, int bone) {
            if(slot > 0x18)
                throw new IndexOutOfRangeException();
            int offset = GetModelTableOffset(dex, form, gender);
            Common6.WriteByte(offset + 0x19 + slot, (byte)bone);
        }

        /// <returns>The index of the bone with the given name, or -1 if no match found.</returns>
        public static int FindBone(string name, int dex, int form, int gender, bool shiny = false) {
            var numBones = GetBoneCount(dex, form, gender, shiny);
            for(int i = 0; i < numBones; i++) {
                if(name == GetBoneName(i, dex, form, gender, shiny))
                    return i;
            }
            return -1;
        }

        /// <returns>The index of the animation with the given name, or -1 if no match found.</returns>
        public static int FindAnim(string name, int dex, int form, int gender, bool shiny = false) {
            var numAnims = GetAnimCount(dex, form, gender, shiny);
            for(int i = 0; i < numAnims; i++) {
                if(name == GetAnimName(i, dex, form, gender, shiny))
                    return i;
            }
            return -1;
        }

        public static void SetAnimSlot(int dex, int form, int gender, int slot, int anim) {
            if(slot > 0x15)
                throw new IndexOutOfRangeException();
            int offset = GetModelTableOffset(dex, form, gender);
            Common6.WriteByte(offset + 0x32 + slot, (byte)anim);
        }

        private static int BoneSearch(FileBuffer file, int index, int boneAddr) {
            if(file.ReadShort(boneAddr + 8) == index)
                return boneAddr;
            int childAddr = file.ReadInt(boneAddr + 0x24);
            if(childAddr > 0) {
                int addr = BoneSearch(file, index, childAddr);
                if(addr > -1)
                    return addr;
            }
            int nextAddr = file.ReadInt(boneAddr + 0x28);
            if(nextAddr > 0) {
                int addr = BoneSearch(file, index, nextAddr);
                if(addr > -1)
                    return addr;
            }
            return -1;
        }

        /// <param name="gender">male/unknown: 0, female: 1</param>
        public static FileBuffer GetModel(int dex, int form, int gender, bool shiny) {
            int fsysID = GetModelFSYSID(dex, form, gender),
                fileID = GetModelFileID(dex, form, gender, shiny);
            var fsys = FSYSTable.GetFile(fsysID);
            return fsys.GetFile(fileID);
        }

        private static int GetModelFSYSID(int dex, int form, int gender) {
            int offset = GetModelTableOffset(dex, form, gender);
            return Common6.ReadInt(offset + 4);
        }

        private static int GetModelFileID(int dex, int form, int gender, bool shiny) {
            int offset = GetModelTableOffset(dex, form, gender);
            return Common6.ReadInt(offset + (shiny ? 0xc : 8));
        }

        private static int GetModelTableOffset(int dex, int form, int gender) {
            int start = Common6.ReadInt(0x10),
                cols = Common6.ReadInt(4),
                idx = GetModelTableIndex(dex, form, gender);
            return start + cols * idx;
        }

        private static int GetModelTableIndex(int dex, int form, int gender) {
            int start = Common6.ReadInt(0x10),
                rows = Common6.ReadInt(0),
                cols = Common6.ReadInt(4),
                dexID = DexTable.GetIndex(dex, form);
            int idx = -1;
            for(int i = 0; i < rows; i++) {
                int offset = start + cols * i;
                if(dexID == Common6.ReadShort(offset + 0x14) && form == Common6.ReadByte(offset + 0x18)) {
                    idx = i;
                    int flags = Common6.ReadInt(offset);
                    if(((flags >> 26) & 1) == gender)
                        break;
                }
            }
            if(idx == -1)
                throw new ArgumentException();
            return idx;
        }

        public static void SetModel(FileBuffer sdr, int dex, int form, int gender, bool shiny = false) {
            int fsysID = GetModelFSYSID(dex, form, gender),
                fileID = GetModelFileID(dex, form, gender, shiny);
            var fsys = FSYSTable.GetFile(fsysID);
            FileUtils.ReplaceLZSS(fsys.Name, fileID, sdr);
        }

        public static void AddModelSlot(int dex) {
            string fname = $"pkx_{dex:D3}";
            FileUtils.CopyFile(FSYSTable.MakePath("pkx_sub"), FSYSTable.MakePath(fname));
            int fsysID = FSYSTable.AddFile(fname);
            var subModel = FSYSTable.GetFile("pkx_sub");
            int shinyID = FileUtils.AddLZSS(fname, subModel.Files[0]);
            // add new entry
            int start = Common6.ReadInt(0x10),
                rows = Common6.ReadInt(0),
                cols = Common6.ReadInt(4),
                address = start + rows * cols;
            Common6.AddRange(cols);
            Common6.WriteInt(address, 0x60D0D0D0); // first byte dictates "spacing" in some sense
            Common6.WriteInt(address + 4, fsysID);
            Common6.WriteInt(address + 8, subModel.Files[0].ID); // 0x97A0400 = Substitute doll's file ID
            Common6.WriteInt(address + 0xc, shinyID);
            Common6.WriteFloat(address + 0x10, 20.0); // run speed
            Common6.WriteShort(address + 0x14, (short)DexTable.GetIndex(dex, 0));
            // update count
            Common6.WriteInt(0, rows + 1);
        }

        public static void Write() {
            FSYSTable.WriteFile("common");
        }
    }
}
