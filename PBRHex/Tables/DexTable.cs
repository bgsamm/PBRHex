using System;
using PBRHex.Files;
using PBRHex.Utils;

namespace PBRHex.Tables
{
    public static class DexTable
    {
        private static FSYS Common => FSYSTable.GetFile("common");
        private static FileBuffer Common8 => Common.Files[8];
        private static int Count => Common8.ReadInt(0);

        public static int GetRange() {
            int max = 0;
            for(int i = 0; i < Count; i++) {
                int dex = GetDexNum(i);
                if(dex > max)
                    max = dex;
            }
            return max;
        }

        // I'd really like to do everything in dex #s, but b/c of how the
        // game handles things, I'll have to wait until I can patch the DOL
        public static int GetIndex(int dex, int form) {
            for(int i = 0; i < Count; i++) {
                if(GetDexNum(i) == dex && GetFormIndex(i) == form)
                    return i;
            }
            throw new ArgumentOutOfRangeException();
        }

        public static string GetName(int dex) {
            int nameID = GetNameID(dex);
            return StringTable.GetString(nameID).Text;
        }

        private static int GetNameID(int dex) {
            return Common8.ReadShort(GetTableOffset(dex, 0) + 0x18);
        }

        public static string GetFormName(int dex, int form) {
            int nameID = GetFormNameID(dex, form);
            if(nameID == 0)
                return StringTable.GetString(0xa).Text; // "-----"
            return StringTable.GetString(nameID).Text;
        }

        private static int GetFormNameID(int dex, int form) {
            return Common8.ReadShort(GetTableOffset(dex, form) + 0x1a);
        }

        public static int GetTyping(int dex, int form, int slot) {
            if(slot > 1)
                throw new ArgumentOutOfRangeException();
            return Common8.ReadByte(GetTableOffset(dex, form) + 0x24 + slot);
        }

        public static int GetStat(int dex, int form, int stat) {
            if(stat > 5)
                throw new ArgumentOutOfRangeException();
            return Common8.ReadByte(GetTableOffset(dex, form) + 0x1e + stat);
        }

        public static int GetFormCount(int dex) {
            int count = 0;
            for(int i = 0; i < Count; i++) {
                if(dex == GetDexNum(i))
                    count++;
            }
            if(count == 0)
                throw new ArgumentException();
            return count;
        }

        public static void SetName(int dex, string name) {
            StringTable.SetStringProperty(GetNameID(dex), "Text", name);
        }

        private static void SetNameID(int dex, int id) {
            // formes should keep the same base name
            for(int i = 0; i < GetFormCount(dex); i++) {
                Common8.WriteShort(GetTableOffset(dex, i) + 0x18, (short)id);
            }
        }

        public static void SetTyping(int dex, int form, int slot, int type) {
            if(slot > 1)
                throw new ArgumentOutOfRangeException();
            Common8.WriteByte(GetTableOffset(dex, form) + 0x24 + slot, (byte)type);
        }

        public static void SetStat(int dex, int form, int stat, int value) {
            if(stat > 5)
                throw new ArgumentOutOfRangeException();
            Common8.WriteByte(GetTableOffset(dex, form) + 0x1e + stat, (byte)value);
        }

        private static int GetDexNum(int index) {
            return Common8.ReadShort(GetTableOffset(index) + 0x10);
        }

        private static int GetFormIndex(int index) {
            return Common8.ReadShort(GetTableOffset(index) + 0x12);
        }

        private static void SetDexNum(int index, int dex) {
            Common8.WriteShort(GetTableOffset(index) + 0x10, (short)dex);
        }

        private static int GetTableOffset(int dex, int form) {
            for(int i = 0; i < Count; i++) {
                if(dex == GetDexNum(i) && form == GetFormIndex(i))
                    return GetTableOffset(i);
            }
            throw new ArgumentOutOfRangeException();
        }

        private static int GetTableOffset(int index) {
            int start = Common8.ReadInt(0x10),
                cols = Common8.ReadInt(4);
            return start + index * cols;
        }

        /// <returns>index of newly added slot</returns>
        public static int AddSlot() {
            int cols = Common8.ReadInt(4);
            // add empty row
            Common8.AddRange(cols);
            // update row count
            Common8.WriteInt(0, Count + 1);
            PatchDOL();
            // dex
            int dex = GetRange() + 1;
            SetDexNum(Count - 1, dex);
            // name
            int nameID = StringTable.AddString("???");
            StringTable.SetStringProperty(nameID, "Size", 1);
            StringTable.SetStringProperty(nameID, "Spacing", 1);
            SetNameID(dex, nameID);
            // sprites
            SpriteTable.AddSpriteSlots(dex);
            // model
            ModelTable.AddModelSlot(dex);
            // ai
            AddSlotToCommonD();
            return dex;
        }

        public static void PatchDex() {
            for(short i = 1; i <= 493; i++) {
                int offset = GetTableOffset(i);
                // replace wild held item columns w/ dex & form indices
                Common8.WriteShort(offset + 0x10, i);
                Common8.WriteShort(offset + 0x12, 0);
                // replace kana string index w/ form string index
                // (not 100% sure the kana string is unused but I'll
                // cross that bridge when I come to it)
                int idx = 0;
                if(i == 386)
                    idx = StringTable.AddString("Normal Forme");
                else if(i == 413)
                    idx = StringTable.AddString("Plant Cloak");
                Common8.WriteShort(offset + 0x1a, (short)idx);
            }
            // Deoxys forms
            for(short i = 1; i <= 3; i++) {
                int offset = GetTableOffset(495 + i);
                Common8.WriteShort(offset + 0x10, 386);
                Common8.WriteShort(offset + 0x12, i);
                int idx = 0;
                if(i == 1)
                    idx = StringTable.AddString("Attack Forme");
                else if(i == 2)
                    idx = StringTable.AddString("Defense Forme");
                else if(i == 3)
                    idx = StringTable.AddString("Speed Forme");
                Common8.WriteShort(offset + 0x1a, (short)idx);
            }
            // Wormadam forms
            for(short i = 1; i <= 2; i++) {
                int offset = GetTableOffset(498 + i);
                Common8.WriteShort(offset + 0x10, 413);
                Common8.WriteShort(offset + 0x12, i);
                int idx = 0;
                if(i == 1)
                    idx = StringTable.AddString("Sandy Cloak");
                else if(i == 2)
                    idx = StringTable.AddString("Trash Cloak");
                Common8.WriteShort(offset + 0x1a, (short)idx);
            }
            // add empty slots for eggs in the move prediction table
            AddSlotToCommonD();
            AddSlotToCommonD();
            // add empty sprite slots for the bad egg & the Deoxys and Wormadam formes
            Common.Files[0x15].WriteInt(0, 0x1f5);
            Common.Files[0x15].AddRange(0xc * 6);
            Common.Files[0x16].WriteInt(0, 0x1f5);
            Common.Files[0x16].AddRange(0x8 * 6);
            // zero out egg dex nums in sprite tables; I think they're unused anyway
            Common.Files[0x15].WriteShort(0x175a, 0);
            Common.Files[0x16].WriteShort(0xfa2, 0);
            // zero out egg dex num in model table; probably not kosher but fine for now
            //Common.Files[6].WriteShort(0xb564, 0);
            Write();
        }

        // doesn't add a new string slot, so far doesn't seem necessary
        private static void AddSlotToCommonD() {
            var CommonD = Common.Files[0xD];
            int count1 = CommonD.ReadInt(0),
                count2 = CommonD.ReadInt(0x1c),
                length = CommonD.ReadInt(0x14),
                addr1 = CommonD.ReadInt(0x20),
                addr2 = CommonD.ReadInt(0x18),
                delta = 0x20;
            CommonD.WriteInt(0, count1 + 1);
            CommonD.WriteInt(0x14, length + 0x2c);
            if(addr1 - length - 0x1500 < 0xc)
                delta += 0x10;
            CommonD.WriteInt(0x18, addr2 + delta);
            CommonD.WriteInt(0x20, addr1 + delta);
            CommonD.InsertRange(addr1, delta);
            for(int i = 0; i < count2; i++) {
                int offset = addr2 + delta + 4 * i,
                    newAddr = CommonD.ReadInt(offset) + delta;
                CommonD.WriteInt(offset, newAddr);
            }
        }

        private static void PatchDOL() {
            uint op1 = AssemblyUtils.Assemble($"cmplwi r0, 0x{Count - 1:X}"),
                op2 = AssemblyUtils.Assemble($"cmplwi r4, 0x{Count - 1:X}");
            DOL.WriteInstruction(0x80058c6c, op1);
            DOL.WriteInstruction(0x80058ce4, op1);
            DOL.WriteInstruction(0x8005d1f4, op2);
            DOL.WriteInstruction(0x8005d4a4, op2);
            DOL.WriteInstruction(0x8005db8c, op2);
            DOL.WriteInstruction(0x8005de38, op2);
            // fixes opposing AI constantly switching
            uint op = AssemblyUtils.Assemble($"subi r0, r31, 0x{Count:X}");
            DOL.WriteInstruction(0x801cae90, op);
            DOL.Write();
        }

        public static void Write() {
            FSYSTable.WriteFile("common");
            StringTable.Write();
        }
    }
}
