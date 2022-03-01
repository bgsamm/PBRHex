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

        public static int GetMaxDexNum() {
            int max = 0;
            for (int i = 0; i < Count; i++) {
                int dex = GetDexNum(i);
                if (dex > max)
                    max = dex;
            }
            return max;
        }

        public static Pokemon GetMonByIndex(int index) {
            int dexNo = GetDexNum(index),
                formID = GetFormIndex(index);
            return new Pokemon(dexNo, formID);
        }

        public static string GetSpeciesName(int dex) {
            int nameID = GetSpeciesNameID(dex);
            return StringTable.GetString(nameID).Text;
        }

        private static int GetSpeciesNameID(int dex) {
            return Common8.ReadShort(GetTableOffset(dex, 0) + 0x18);
        }

        public static string GetFormName(Pokemon mon) {
            int nameID = GetFormNameID(mon);
            if (nameID == 0)
                return StringTable.GetString(0xa).Text; // "-----"
            return StringTable.GetString(nameID).Text;
        }

        private static int GetFormNameID(Pokemon mon) {
            return Common8.ReadShort(GetTableOffset(mon) + 0x1a);
        }

        public static PokeType GetTyping(Pokemon mon, int slot) {
            if (slot > 1)
                throw new ArgumentOutOfRangeException();
            byte type = Common8.ReadByte(GetTableOffset(mon) + 0x24 + slot);
            return (PokeType)type;
        }

        public static int GetAbility(Pokemon mon, int slot) {
            if (slot > 1)
                throw new ArgumentOutOfRangeException();
            return Common8.ReadByte(GetTableOffset(mon) + 0x30 + slot);
        }

        public static int GetStat(Pokemon mon, int stat) {
            if (stat > 5)
                throw new ArgumentOutOfRangeException();
            return Common8.ReadByte(GetTableOffset(mon) + 0x1e + stat);
        }

        public static int GetNumForms(int dex) {
            int count = 0;
            for (int i = 0; i < Count; i++) {
                if (dex == GetDexNum(i))
                    count++;
            }
            if (count == 0)
                throw new ArgumentException();
            return count;
        }

        public static void SetSpeciesName(int dex, string name) {
            int stringID = GetSpeciesNameID(dex);
            StringTable.SetStringProperty(stringID, "Text", name);
        }

        private static void SetSpeciesNameID(int dex, int id) {
            // forms should keep the same base name
            for (int i = 0; i < GetNumForms(dex); i++) {
                Common8.WriteShort(GetTableOffset(dex, i) + 0x18, (short)id);
            }
        }

        public static void SetFormName(Pokemon mon, string name) {
            int stringID = GetFormNameID(mon);
            if (stringID == 0) {
                stringID = StringTable.AddString(name);
                SetFormNameID(mon, stringID);
            } else {
                StringTable.SetStringProperty(stringID, "Text", name);
            }
        }

        private static void SetFormNameID(Pokemon mon, int id) {
            Common8.WriteShort(GetTableOffset(mon) + 0x1a, (short)id);
        }

        public static void SetTyping(Pokemon mon, int slot, PokeType type) {
            if (slot > 1)
                throw new ArgumentOutOfRangeException();
            Common8.WriteByte(GetTableOffset(mon) + 0x24 + slot, (byte)type);
        }

        public static void SetAbility(Pokemon mon, int slot, int ability) {
            if (slot > 1)
                throw new ArgumentOutOfRangeException();
            Common8.WriteByte(GetTableOffset(mon) + 0x30 + slot, (byte)ability);
        }

        public static void SetStat(Pokemon mon, int stat, int value) {
            if (stat > 5)
                throw new ArgumentOutOfRangeException();
            Common8.WriteByte(GetTableOffset(mon) + 0x1e + stat, (byte)value);
        }

        public static int GetDexNum(int index) {
            return Common8.ReadShort(RowToTableOffset(index) + 0x10);
        }

        private static int GetFormIndex(int index) {
            return Common8.ReadShort(RowToTableOffset(index) + 0x12);
        }

        private static void SetDexNum(int index, int dex) {
            Common8.WriteShort(RowToTableOffset(index) + 0x10, (short)dex);
        }

        private static void SetFormIndex(int index, int form) {
            Common8.WriteShort(RowToTableOffset(index) + 0x12, (short)form);
        }

        private static void SetFormCount(int dex, int numForms) {
            for (int i = 0; i < GetNumForms(dex); i++) {
                int offset = GetTableOffset(dex, i);
                byte b = Common8.ReadByte(offset + 0x33);
                b = (byte)((numForms << 1) + (b & 1));
                Common8.WriteByte(offset + 0x33, b);
            }
        }

        private static int GetTableOffset(Pokemon mon) {
            return GetTableOffset(mon.DexNum, mon.FormIndex);
        }

        private static int GetTableOffset(int dex, int form) {
            for (int i = 0; i < Count; i++) {
                if (GetDexNum(i) == dex && GetFormIndex(i) == form)
                    return RowToTableOffset(i);
            }
            throw new ArgumentOutOfRangeException();
        }

        private static int RowToTableOffset(int index) {
            int start = Common8.ReadInt(0x10),
                rowSize = Common8.ReadInt(4);
            return start + index * rowSize;
        }

        /// <returns>dex # of newly added slot</returns>
        public static int AddSlot() {
            int rowSize = Common8.ReadInt(4),
                dex = GetMaxDexNum() + 1,
                index = dex; // insert new mons in dex order
            // add empty row
            Common8.InsertRange(RowToTableOffset(index), rowSize);
            // update row count
            Common8.WriteInt(0, Count + 1);
            // dex
            SetDexNum(index, dex);
            SetFormCount(dex, 1);
            PatchManager.SetMaxDexNum(dex);
            // name
            int nameID = StringTable.AddString("???");
            StringTable.SetStringProperty(nameID, "Size", 1);
            StringTable.SetStringProperty(nameID, "Spacing", 1);
            SetSpeciesNameID(dex, nameID);
            var mon = new Pokemon(dex, 0);
            // sprites
            SpriteTable.AddSpriteSlots(mon);
            // model
            ModelTable.AddModelSlot(mon);
            // ai
            AITable.AddMonToLookupTable(mon);
            return dex;
        }

        public static int AddForm(int dex, string formName) {
            int rowSize = Common8.ReadInt(4),
                form = GetNumForms(dex),
                index = Count; // append new forms to end of table
            // add empty row
            Common8.InsertRange(RowToTableOffset(index), rowSize);
            // update row count
            Common8.WriteInt(0, Count + 1);
            // dex
            SetDexNum(index, dex);
            SetFormIndex(index, form);
            SetFormCount(dex, form + 1);
            var mon = new Pokemon(dex, form);
            // name
            int id = StringTable.AddString(formName);
            SetFormNameID(mon, id);
            // sprites
            SpriteTable.AddSpriteSlots(mon);
            // model
            ModelTable.AddModelSlot(mon);
            // ai
            AITable.AddMonToLookupTable(mon);
            return form;
        }

        public static void Write() {
            FSYSTable.WriteFile("common");
            StringTable.Write();
            ModelTable.Write();
            AITable.Write();
        }
    }
}
