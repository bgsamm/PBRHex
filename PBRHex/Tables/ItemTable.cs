using System;
using PBRHex.Files;

namespace PBRHex.Tables
{
    public static class ItemTable
    {
        public static int Count => Common13.ReadInt(0);

        private static FSYS Common => FSYSTable.GetFile("common");
        private static FileBuffer Common13 => Common.Files[0x13];

        public static string GetName(int index) {
            return StringTable.GetString(GetStringID(index)).Text;
        }

        public static int GetEffectID(int index) {
            return Common13.ReadByte(GetTableOffset(index) + 8);
        }

        private static int GetStringID(int index) {
            return Common13.ReadShort(GetTableOffset(index) + 2);
        }

        private static int GetTableOffset(int index) {
            int start = Common13.ReadInt(0x10),
                stride = Common13.ReadInt(4);
            return start + index * stride;
        }
    }
}
