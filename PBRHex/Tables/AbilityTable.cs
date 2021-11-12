using System;
using PBRHex.Files;

namespace PBRHex.Tables
{
    public static class AbilityTable
    {
        public static int Count => Common17.ReadInt(0);

        private static FSYS Common => FSYSTable.GetFile("common");
        private static FileBuffer Common17 => Common.Files[0x17];

        public static string GetName(int index) {
            return StringTable.GetString(GetStringID(index)).Text;
        }

        private static int GetStringID(int index) {
            return Common17.ReadShort(GetTableOffset(index));
        }

        private static int GetTableOffset(int index) {
            int start = Common17.ReadInt(0x10),
                stride = Common17.ReadInt(4);
            return start + index * stride;
        }
    }
}
