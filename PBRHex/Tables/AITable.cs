using System;
using PBRHex.Files;
using PBRHex.Utils;

namespace PBRHex.Tables
{
    public static class AITable
    {
        private static FSYS Common => FSYSTable.GetFile("common");
        private static FileBuffer CommonD => Common.Files[0xd];

        // needs to handle adding new forms
        public static void AddMonToLookupTable(Pokemon mon) {
            int count = CommonD.ReadInt(0),
                rowSize = CommonD.ReadInt(0x4),
                sect1Length = CommonD.ReadInt(0x14),
                sect1Addr = CommonD.ReadInt(0x10),
                sect2Addr = CommonD.ReadInt(0x20),
                sect3Addr = CommonD.ReadInt(0x18);
            CommonD.WriteInt(0, count + 1);
            CommonD.WriteInt(0x14, sect1Length + rowSize);
            int newSect2Addr = (sect1Addr + sect1Length + rowSize + 0xf) / 0x10 * 0x10,
                delta = newSect2Addr - sect2Addr,
                newSect3Addr = sect3Addr + delta;
            CommonD.InsertRange(sect2Addr, delta);
            int newEntryAddr = sect1Addr + count * rowSize;
            CommonD.WriteByte(newEntryAddr + 0x2a, 1); // preferred ability
            CommonD.WriteByte(newEntryAddr + 0x2b, 0xd0); // just means unused
            // the Deoxys and Wormadam forms used #s 0x1ee - 0x1f2;
            // rather than deleting them, just reuse them if available
            int count2 = CommonD.ReadInt(0x1c),
                offset;
            if (mon.DexNum < count2) {
                for (int i = 0; i < count2; i++) {
                    offset = newSect2Addr + 8 * i;
                    if (CommonD.ReadInt(offset + 4) == mon.DexNum) {
                        CommonD.WriteInt(offset, newEntryAddr);
                        break;
                    }
                }
            } else {
                CommonD.WriteInt(0x1c, count2 + 1);
                offset = newSect2Addr + count2 * 0x8;
                if (offset == newSect3Addr) {
                    CommonD.InsertRange(newSect3Addr, 0x10);
                    newSect3Addr += 0x10;
                }
                CommonD.WriteInt(offset, newEntryAddr);
                CommonD.WriteInt(offset + 4, mon.DexNum);
                CommonD.AddRange(HexUtils.IntToBytes(offset));
            }
            CommonD.WriteInt(0x20, newSect2Addr);
            CommonD.WriteInt(0x18, newSect3Addr);
            for (int i = 0; i < count2; i++) {
                offset = newSect3Addr + i * 4;
                int oldOffset = CommonD.ReadInt(offset),
                    newOffset = oldOffset + delta;
                CommonD.WriteInt(offset, newOffset);
            }
        }

        public static void Write() {
            FSYSTable.WriteFile("common");
        }
    }
}
