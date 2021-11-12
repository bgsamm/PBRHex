using System;
using PBRHex.Files;

namespace PBRHex.Tables
{
    public static class MoveTable
    {
        public static int Count => Common1E.ReadInt(0);

        private static FSYS Common => FSYSTable.GetFile("common");
        private static FileBuffer Common1E => Common.Files[0x1e];

        public static string GetName(int index) {
            return StringTable.GetString(GetStringID(index)).Text;
        }

        private static int GetStringID(int index) {
            return Common1E.ReadShort(GetTableOffset(index) + 8);
        }

        private static int GetTableOffset(int index) {
            int start = Common1E.ReadInt(0x10),
                stride = Common1E.ReadInt(4);
            return start + index * stride;
        }
    }
}
