using System;
using PBRHex.Files;
using PBRHex.Tables;
using PBRHex.Utils;

namespace PBRHex
{
    public static class PatchManager
    {
        private static FSYS Common => FSYSTable.GetFile("common.fsys");
        private static FileBuffer Common6 => Common.Files[0x6];
        private static FileBuffer Common8 => Common.Files[0x8];
        private static FileBuffer CommonD => Common.Files[0xd];
        private static FileBuffer Common15 => Common.Files[0x15];
        private static FileBuffer Common16 => Common.Files[0x16];

        public static uint NextFreeAddr { get; private set; }
        private static readonly uint freeSpaceStart, freeSpaceEnd;

        static PatchManager() {
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    freeSpaceStart = 0x801d9474;
                    freeSpaceEnd = 0x801df670;
                    break;
                case GameRegion.PAL:
                    freeSpaceStart = 0x801d4838;
                    freeSpaceEnd = 0x801daa30;
                    break;
                default:
                    throw new NotImplementedException();
            }
            ClearDebugFunctions();
            uint addr;
            for (addr = freeSpaceStart; addr < freeSpaceEnd; addr += 4) {
                if (DOL.ReadInstruction(addr) == 0)
                    break;
            }
            if (addr >= freeSpaceEnd)
                throw new Exception("No free space available in main.dol");
            NextFreeAddr = freeSpaceStart;
        }

        public static void DisableAntiModification() {
            uint address;
            switch (Program.ISORegion) {
                case GameRegion.NTSCJ:
                    address = 0x8021de60;
                    break;
                case GameRegion.NTSCU:
                    address = 0x8022e1e4;
                    break;
                case GameRegion.PAL:
                    address = 0x8022965c;
                    break;
                default:
                    throw new NotImplementedException();
            }
            DOL.WriteInstruction(address, "li r3, 0x1");
            DOL.WriteInstruction(address + 4, "blr");
            DOL.Write();
        }

        public static void ClearDebugFunctions() {
            uint call1, call2, call3;
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    call1 = 0x800061b8;
                    call2 = 0x80006278;
                    call3 = 0x8026da80;
                    break;
                case GameRegion.PAL:
                    call1 = 0x800061b8;
                    call2 = 0x80006278;
                    call3 = 0x802690d8;
                    break;
                default:
                    throw new NotImplementedException();
            }
            // check if already cleared
            if (DOL.ReadInstruction(call1) == 0xfee15bad)
                return;
            // replace calls to debug functions w/ invalid
            // instructions in case they *are* ever reached
            for (uint i = 0; i < 4; i++) {
                DOL.WriteInstruction(call1 + i * 4, 0xfee15bad);
            }
            DOL.WriteInstruction(call2, 0xfee15bad);
            DOL.WriteInstruction(call3, 0xfee15bad);
            // clear debug functions
            for (uint addr = freeSpaceStart; addr < freeSpaceEnd; addr += 4) {
                DOL.WriteInstruction(addr, 0);
            }
            DOL.Write();
        }

        public static void ExpandDOL() {
            // reserves 0xdf00 bytes of space
            if (Program.ISORegion == GameRegion.NTSCU) {
                DOL.WriteInstruction(0x80275b5c, "lis r5, -0x7f9c");
                DOL.WriteInstruction(0x80275b5c + 0xc, "subi r5, r5, 0x6e50"); // 806391B0
                DOL.AddSection(0x8062b2b0);
            } else if (Program.ISORegion == GameRegion.PAL) {
                DOL.WriteInstruction(0x802710e4, "lis r5, -0x7f9b");
                DOL.WriteInstruction(0x802710e4 + 0xc, "addi r5, r5, 0xf50"); // 80650F50
                DOL.AddSection(0x80643050);
            } else {
                throw new NotImplementedException();
            }
            DOL.Write();
        }

        public static void PatchDex() {
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    break;
                case GameRegion.PAL:
                    break;
                default:
                    throw new NotImplementedException();
            }
            // rename model files
            if (FSYSTable.ContainsFile("pkx_600"))
                FSYSTable.RenameFile("pkx_600", "pkx_egg");
            if (FSYSTable.ContainsFile("pkx_601"))
                FSYSTable.RenameFile("pkx_601", "pkx_sub");
            ReassignEggIDs();
            PatchCommon08();
            PatchCommon0D();
            PatchCommon15();
            PatchCommon16();
            SetMaxDexNum(493);
            FSYSTable.WriteFile("common.fsys");
            DOL.Write();
        }

        public static void SetMaxDexNum(int max) {
            uint maxCmp1, maxCmp2, maxCmp3, maxCmp4, maxCmp5, maxCmp6, subAddr;
            switch (Program.ISORegion) {
                case GameRegion.NTSCJ:
                    maxCmp1 = 0x8005614c; maxCmp2 = 0x800561c4; maxCmp3 = 0x80059888;
                    maxCmp4 = 0x80059b38; maxCmp5 = 0x8005db8c; maxCmp6 = 0x8005a1d4;
                    subAddr = 0x801bbfbc;
                    break;
                case GameRegion.NTSCU:
                    maxCmp1 = 0x80058c6c; maxCmp2 = 0x80058ce4; maxCmp3 = 0x8005d1f4;
                    maxCmp4 = 0x8005d4a4; maxCmp5 = 0x8005db8c; maxCmp6 = 0x8005de38;
                    subAddr = 0x801cae90;
                    break;
                case GameRegion.PAL:
                    maxCmp1 = 0x80056c0c; maxCmp2 = 0x80056c84; maxCmp3 = 0x8005b704;
                    maxCmp4 = 0x8005b9b4; maxCmp5 = 0x8005c09c; maxCmp6 = 0x8005c348;
                    subAddr = 0x801c6254;
                    break;
                default:
                    throw new NotImplementedException();
            }
            // use signed comparisons for compatibility w/ egg ID reassignment
            DOL.WriteInstruction(maxCmp1, $"cmpwi r3, 0x{max:x}");
            DOL.WriteInstruction(maxCmp2, $"cmpwi r3, 0x{max:x}");
            DOL.WriteInstruction(maxCmp3, $"cmpwi r4, 0x{max:x}");
            DOL.WriteInstruction(maxCmp4, $"cmpwi r4, 0x{max:x}");
            DOL.WriteInstruction(maxCmp5, $"cmpwi r4, 0x{max:x}");
            DOL.WriteInstruction(maxCmp6, $"cmpwi r4, 0x{max:x}");
            // fixes AI oponent constantly switching
            DOL.WriteInstruction(subAddr, $"subi r0, r31, 0x{max + 1:x}");
            DOL.Write();
        }

        /// <summary>
        /// Assigns egg and bad egg IDs of -1 and -2, instead of 0x1ee and 0x1ef, respectively
        /// </summary>
        private static void ReassignEggIDs() {
            uint eggLoad1, eggLoad2, eggLoad3, eggLoad4, eggLoad5, badEggLoad1, badEggLoad2,
                eggCmp1, eggCmp2, eggCmp3, eggCmp4, eggCmp5,
                formCmp1, formCmp2, formCmp3, formCmp4, formCmp5, formCmp6;
            uint[] eggCompares;
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    eggLoad1 = 0x8005e580; eggLoad2 = 0x8005e6cc; eggLoad3 = 0x8005e870;
                    eggLoad4 = 0x803de6e0; eggLoad5 = 0x803de708;
                    badEggLoad1 = 0x803de8f4; badEggLoad2 = 0x803de950;
                    eggCmp1 = 0x8005e584; eggCmp2 = 0x8005e6fc; eggCmp3 = 0x8005e8a4;
                    eggCmp4 = 0x803d80a8; eggCmp5 = 0x803d81a4;
                    eggCompares = new uint[] {
                        0x803b3a14, 0x803b3b60, 0x803b3c64, 0x803b3d48, 0x803b5fb4,
                        0x803b607c, 0x803b615c, 0x803b90e8, 0x803b91e0, 0x803bb388,
                        0x803bcf5c, 0x803bd058, 0x803bd0c4, 0x803bd1a0, 0x803d59f0,
                        0x803d5bc8, 0x803d603c, 0x803d97a0, 0x803d9830, 0x803d98d0,
                        0x803da35c, 0x803da430, 0x803df458, 0x803e048c
                    };
                    formCmp1 = 0x8005d250; formCmp2 = 0x8005d52c; formCmp3 = 0x8005d85c;
                    formCmp4 = 0x8005dbe8; formCmp5 = 0x8005debc; formCmp6 = 0x8005e198;
                    break;
                case GameRegion.PAL:
                    eggLoad1 = 0x8005ca90; eggLoad2 = 0x8005cbdc; eggLoad3 = 0x8005cd80;
                    eggLoad4 = 0x803db0b0; eggLoad5 = 0x803db0d8;
                    badEggLoad1 = 0x803db2c4; badEggLoad2 = 0x803db320;
                    eggCmp1 = 0x8005ca94; eggCmp2 = 0x8005cc0c; eggCmp3 = 0x8005cdb4;
                    eggCmp4 = 0x803d4a68; eggCmp5 = 0x803d4b64;
                    eggCompares = new uint[] {
                        0x803b0328, 0x803b0474, 0x803b0578, 0x803b065c, 0x803b28c8,
                        0x803b2990, 0x803b2a70, 0x803b5a08, 0x803b5b00, 0x803b7cc8,
                        0x803b98b0, 0x803b99ac, 0x803b9a18, 0x803b9af4, 0x803d2394,
                        0x803d256c, 0x803d29f4, 0x803d6160, 0x803d61f0, 0x803d6290,
                        0x803d6d1c, 0x803d6df0, 0x803dbe28, 0x803dce5c
                    };
                    formCmp1 = 0x8005b760; formCmp2 = 0x8005ba3c; formCmp3 = 0x8005bd6c;
                    formCmp4 = 0x8005c0f8; formCmp5 = 0x8005c3cc; formCmp6 = 0x8005c6a8;
                    break;
                default:
                    throw new NotImplementedException();
            }
            // make egg and bad egg use IDs of -1 and -2, respectively
            DOL.WriteInstruction(eggLoad1, "li r31, -0x1");
            DOL.WriteInstruction(eggLoad2, "li r30, -0x1");
            DOL.WriteInstruction(eggLoad3, "li r30, -0x1");
            DOL.WriteInstruction(eggLoad4, "li r31, -0x1");
            DOL.WriteInstruction(eggLoad5, "li r31, -0x1");
            DOL.WriteInstruction(badEggLoad1, "li r3, -0x2");
            DOL.WriteInstruction(badEggLoad2, "li r3, -0x2");
            DOL.WriteInstruction(eggCmp1, "cmpwi r31, -0x1");
            DOL.WriteInstruction(eggCmp2, "cmpwi r30, -0x1");
            DOL.WriteInstruction(eggCmp3, "cmpwi r30, -0x1");
            DOL.WriteInstruction(eggCmp4, "cmpwi r23, -0x1");
            DOL.WriteInstruction(eggCmp5, "cmpwi r23, -0x1");
            foreach (uint addr in eggCompares) {
                DOL.WriteInstruction(addr, "cmpwi r3, -0x1");
            }
            // skip form checks
            // 1
            DOL.WriteInstruction(formCmp1, $"b 0x{formCmp1 + 0x50:x08}");
            // 2
            DOL.WriteInstruction(formCmp2, $"b 0x{formCmp2 + 0x50:x08}");
            // 3
            DOL.WriteInstruction(formCmp3, "nop");
            DOL.WriteInstruction(formCmp3 + 0xc, $"b 0x{formCmp3 + 0xac:x08}");
            // 4
            DOL.WriteInstruction(formCmp4, $"b 0x{formCmp4 + 0x50:x08}");
            // 5
            DOL.WriteInstruction(formCmp5, $"b 0x{formCmp5 + 0x50:x08}");
            // 6
            DOL.WriteInstruction(formCmp6, "nop");
            DOL.WriteInstruction(formCmp6 + 0xc, $"b 0x{formCmp6 + 0xac:x08}");

            // update egg ID in common:06, common:15, and common:16
            Common6.WriteShort(0xb564, -0x1);
            Common15.WriteInt(0x1758, -0x1);
            Common16.WriteInt(0xfa0, -0x1);
        }

        /// <summary>
        /// Changes:
        /// - Overwrites the wild held item columns w/ dex & form indices
        /// - Overwrites kana string indices w/ form string indices
        /// - Replaces GET_MON_ATTRS_IDX and GET_MON_TYPE with custom implementations
        /// </summary>
        private static void PatchCommon08() {
            uint getKanjiCall;
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    getKanjiCall = 0x8018125c;
                    break;
                case GameRegion.PAL:
                    getKanjiCall = 0x8017c91c;
                    break;
                default:
                    throw new NotImplementedException();
            }
            int start = Common8.ReadInt(0x10),
                rowSize = Common8.ReadInt(4),
                common16start = Common16.ReadInt(0x10),
                common16stride = Common16.ReadInt(4);
            int offset, sid;
            for (short i = 1; i <= 493; i++) {
                offset = start + i * rowSize;
                // replace wild held item columns w/ dex & form indices
                Common8.WriteShort(offset + 0x10, i);
                Common8.WriteShort(offset + 0x12, 0);
                // replace kana string index w/ form string index
                // (not 100% sure the kanji string is unused tbh)
                if (i == 201)
                    sid = StringTable.AddString("A");
                else if (i == 351)
                    sid = StringTable.AddString("Normal");
                else if (i == 386)
                    sid = StringTable.AddString("Normal Forme");
                else if (i == 412 || i == 413)
                    sid = StringTable.AddString("Plant Cloak");
                else if (i == 421)
                    sid = StringTable.AddString("Overcast Form");
                else if (i == 422 || i == 423)
                    sid = StringTable.AddString("West Sea");
                else if (i == 493)
                    sid = StringTable.AddString("Normal-type");
                else
                    sid = 0;
                Common8.WriteShort(offset + 0x1a, (short)sid);
                // replace color + flip with form count + unevolved flag (copied from common:16)
                short forms = Common16.ReadShort(common16start + common16stride * i + 0x6);
                Common8.WriteByte(offset + 0x33, (byte)forms);
            }
            // Deoxys forms
            for (short i = 1; i < 4; i++) {
                offset = start + (495 + i) * rowSize;
                Common8.WriteShort(offset + 0x10, 386);
                Common8.WriteShort(offset + 0x12, i);
                if (i == 1)
                    sid = StringTable.AddString("Attack Forme");
                else if (i == 2)
                    sid = StringTable.AddString("Defense Forme");
                else
                    sid = StringTable.AddString("Speed Forme");
                Common8.WriteShort(offset + 0x1a, (short)sid);
                Common8.WriteByte(offset + 0x33, 4 << 1);
            }
            // Wormadam forms
            for (short i = 1; i < 3; i++) {
                offset = start + (498 + i) * rowSize;
                Common8.WriteShort(offset + 0x10, 413);
                Common8.WriteShort(offset + 0x12, i);
                if (i == 1)
                    sid = StringTable.AddString("Sandy Cloak");
                else
                    sid = StringTable.AddString("Trash Cloak");
                Common8.WriteShort(offset + 0x1a, (short)sid);
                Common8.WriteByte(offset + 0x33, 3 << 1);
            }
            // Eggs
            offset = start + 494 * rowSize;
            Common8.WriteShort(offset + 0x10, -1);
            Common8.WriteByte(offset + 0x33, 4);
            offset = start + 495 * rowSize;
            Common8.WriteShort(offset + 0x10, -2);
            Common8.WriteByte(offset + 0x33, 2);
            
            int index = 496;
            // Unown
            var bytes = Common8.GetRange(start + 201 * rowSize, rowSize);
            for (short i = 1; i < 28; i++, index++) {
                offset = start + index * rowSize;
                Common8.InsertRange(offset, bytes);
                Common8.WriteShort(offset + 0x12, i); // form index
                if (i == 26)
                    sid = StringTable.AddString("!");
                else if (i == 27)
                    sid = StringTable.AddString("?");
                else
                    sid = StringTable.AddString(((char)(i + 65)).ToString());
                Common8.WriteShort(offset + 0x1a, (short)sid); // form name string ID
            }
            // Castform
            bytes = Common8.GetRange(start + 351 * rowSize, rowSize);
            for (short i = 1; i < 4; i++, index++) {
                offset = start + index * rowSize;
                Common8.InsertRange(offset, bytes);
                Common8.WriteShort(offset + 0x12, i);
                PokeType type;
                if (i == 1) {
                    sid = StringTable.AddString("Sunny Form");
                    type = PokeType.Fire;
                } else if (i == 2) {
                    sid = StringTable.AddString("Snowy Form");
                    type = PokeType.Ice;
                } else {
                    sid = StringTable.AddString("Rainy Form");
                    type = PokeType.Water;
                }
                Common8.WriteShort(offset + 0x1a, (short)sid);
                Common8.WriteByte(offset + 0x24, (byte)type);
                Common8.WriteByte(offset + 0x25, (byte)type);
            }
            // Deoxys
            index += 3;
            // Burmy
            bytes = Common8.GetRange(start + 412 * rowSize, rowSize);
            for (short i = 1; i < 3; i++, index++) {
                offset = start + index * rowSize;
                Common8.InsertRange(offset, bytes);
                Common8.WriteShort(offset + 0x12, i);
                if (i == 1)
                    sid = StringTable.AddString("Sandy Cloak");
                else
                    sid = StringTable.AddString("Trash Cloak");
                Common8.WriteShort(offset + 0x1a, (short)sid);
            }
            // Wormadam
            index += 2;
            // Cherrim
            bytes = Common8.GetRange(start + 421 * rowSize, rowSize);
            offset = start + index++ * rowSize;
            Common8.InsertRange(offset, bytes);
            Common8.WriteShort(offset + 0x12, 1);
            sid = StringTable.AddString("Sunshine Form");
            Common8.WriteShort(offset + 0x1a, (short)sid);
            // Shellos
            bytes = Common8.GetRange(start + 422 * rowSize, rowSize);
            offset = start + index++ * rowSize;
            Common8.InsertRange(offset, bytes);
            Common8.WriteShort(offset + 0x12, 1);
            sid = StringTable.AddString("East Sea");
            Common8.WriteShort(offset + 0x1a, (short)sid);
            // Gastrodon
            bytes = Common8.GetRange(start + 423 * rowSize, rowSize);
            offset = start + index++ * rowSize;
            Common8.InsertRange(offset, bytes);
            Common8.WriteShort(offset + 0x12, 1);
            sid = StringTable.AddString("East Sea");
            Common8.WriteShort(offset + 0x1a, (short)sid);
            // Arceus
            bytes = Common8.GetRange(start + 493 * rowSize, rowSize);
            for (short i = 1; i < 18; i++, index++) {
                offset = start + index * rowSize;
                Common8.InsertRange(offset, bytes);
                Common8.WriteShort(offset + 0x12, i);
                if (i == 9)
                    sid = StringTable.AddString("???-type");
                else
                    sid = StringTable.AddString($"{(PokeType)i}-type");
                Common8.WriteShort(offset + 0x1a, (short)sid);
                Common8.WriteByte(offset + 0x24, (byte)i);
                Common8.WriteByte(offset + 0x25, (byte)i);
            }

            Common8.WriteInt(0, index);
            StringTable.Write();

            // replace call to GET_KANJI_STR_NUM w/ invalid
            // instruction in case it ever *does* get reached
            DOL.WriteInstruction(getKanjiCall, 0xfee15bad);

            Patch_GET_MON_TYPE();
            Patch_GET_MON_ATTRS_IDX();
            Patch_GET_FORM_COUNT();
            Patch_IS_UNEVOLVED();
        }

        private static void Patch_GET_MON_TYPE() {
            string[] asm;
            // increase size of stack frame
            DOL.WriteInstruction(GET_MON_TYPE, "stwu r1, -0x20(r1)");
            DOL.WriteInstruction(GET_MON_TYPE + 0xc, "stw r0, 0x24(r1)");
            DOL.WriteInstruction(GET_MON_TYPE + 0x168, "lwz r0, 0x24(r1)");
            DOL.WriteInstruction(GET_MON_TYPE + 0x178, "addi r1, r1, 0x20");
            // add r29 to stack
            asm = new string[] {
                "stw r30, 0x8(r1)",
                "stw r29, 0x10(r1)"
            };
            InsertAssembly(asm, GET_MON_TYPE + 0x1c);
            asm = new string[] {
                "lwz r30, 0x8(r1)",
                "lwz r29, 0x10(r1)"
            };
            InsertAssembly(asm, GET_MON_TYPE + 0x170);
            // replace main logic (there's enough room to simply overwrite)
            asm = new string[] {
                "mr r29, r3", // save the mon index
                "mr r3, r30",
                "li r4, 0x70",
                "li r5, 0x0",
                $"bl 0x{READ_MON_DATA:x08}", // get the form index
                "mr r4, r3",
                "mr r3, r29",
                $"bl 0x{GET_MON_ATTRS_IDX:x08}", // add call to GET_MON_ATTRS_IDX
                "cmpwi r31, 0x0",
                "mr r4, r3",
                COMMON_08_PTR[0],
                COMMON_08_PTR[1],
                $"bne 0x{NextFreeAddr + 0x3c:x08}",
                $"bl 0x{GET_PRIMARY_TYPE:x08}",
                $"b 0x{NextFreeAddr + 0x40:x08}",
                $"bl 0x{GET_SECONDARY_TYPE:x08}"
            };
            InsertAssembly(asm, GET_MON_TYPE + 0xe8);
            DOL.WriteInstruction(GET_MON_TYPE + 0xec, $"b 0x{GET_MON_TYPE + 0x168:x08}");
        }

        private static void Patch_GET_MON_ATTRS_IDX() {
            // custom implementation that searches for a dex + form match
            string[] asm = {
                "mr r8, r3",
                "mr r6, r4",
                COMMON_08_PTR[0],
                COMMON_08_PTR[1],
                "lwz r4, 0x0(r3)",
                "li r3, 0x0",
                "cmpwi r4, 0x0",
                $"beq 0x{NextFreeAddr + 0x70:x08}",
                "lwz r0, 0x0(r4)",
                "lwz r10, 0x4(r4)",
                "lwz r9, 0x10(r4)",
                "li r4, 0x0",
                "mullw r5, r4, r10",
                "add r5, r9, r5",
                "lha r7, 0x10(r5)",
                "cmpw r7, r8",
                $"bne 0x{NextFreeAddr + 0x64:x08}",
                "lhz r5, 0x12(r5)",
                "cmpw r5, r6",
                $"bne 0x{NextFreeAddr + 0x58:x08}",
                "mr r3, r4",
                $"b 0x{NextFreeAddr + 0x70:x08}",
                "cmpwi r5, 0x0",
                $"bne 0x{NextFreeAddr + 0x64:x08}",
                "mr r3, r4", // returns base form index if no form match is found
                "addi r4, r4, 0x1",
                "cmpw r4, r0",
                $"blt 0x{NextFreeAddr + 0x30:x08}"
            };
            InsertAssembly(asm, GET_MON_ATTRS_IDX, true);
        }

        private static void Patch_GET_FORM_COUNT() {
            uint[] calls;
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    calls = new uint[] {
                        0x8005e5a0, 0x8005e718, 0x8005e8c0
                    };
                    break;
                case GameRegion.PAL:
                    calls = new uint[] {
                       0x8005cab0, 0x8005cc28, 0x8005cdd0
                    };
                    break;
                default:
                    throw new NotImplementedException();
            }
            foreach (uint call in calls) {
                // pass common:08 pointer instead of common:15/common:16
                DOL.WriteInstruction(call, "nop");
                DOL.WriteInstruction(call + 0x8, COMMON_08_PTR[0]);
                DOL.WriteInstruction(call + 0xc, COMMON_08_PTR[1]);
                // call GET_COLOR_GROUP, since the color group has been replaced by the form count
                DOL.WriteInstruction(call + 0x10, $"bl 0x{GET_COLOR_GROUP:x08}");
            }
        }

        private static void Patch_IS_UNEVOLVED() {
            uint call1, call2;
            string[] asm;
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    call1 = 0x8008eef0;
                    call2 = 0x800da490;
                    break;
                case GameRegion.PAL:
                    call1 = 0x8008d6c4;
                    call2 = 0x800d782c;
                    break;
                default:
                    throw new NotImplementedException();
            }
            // insert call to GET_MON_ATTRS_IDX since
            // being unevolved can depend on form
            // call 1
            asm = new string[] {
                "mr r15, r3", // save mon ID
                "mr r3, r17",
                "li r4, 0x70",
                "li r5, 0x0",
                $"bl 0x{READ_MON_DATA:x08}", // get form ID
                "mr r4, r3",
                "mr r3, r15",
                $"bl 0x{GET_MON_ATTRS_IDX:x08}", // get index in common:08
                "mr r4, r3"
            };
            InsertAssembly(asm, call1);
            DOL.WriteInstruction(call1 + 4, "addi r3, r24, 0x10"); // set r3 to common:08 ptr
            // call 2
            asm = new string[] {
                "mr r26, r3", // save mon ID
                "mr r3, r18",
                "li r4, 0x70",
                "li r5, 0x0",
                $"bl 0x{READ_MON_DATA:x08}", // get form ID
                "mr r4, r3",
                "mr r3, r26",
                $"bl 0x{GET_MON_ATTRS_IDX:x08}", // get index in common:08
                "mr r4, r3"
            };
            InsertAssembly(asm, call2);
            DOL.WriteInstruction(call2 + 4, "addi r3, r25, 0x10"); // set r3 to common:08 ptr
        }

        private static void PatchCommon0D() {
            uint addr1, addr2, addr3, addr4, addr5,
                addr4Reg1, addr4Reg2, getEntryAddrFunc;
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    addr1 = 0x80182554; addr2 = 0x8018390c; addr3 = 0x801843a4;
                    addr4 = 0x8018502c; addr5 = 0x8018726c;
                    addr4Reg1 = 25;
                    addr4Reg2 = 28;
                    getEntryAddrFunc = 0x8039d068;
                    break;
                case GameRegion.PAL:
                    addr1 = 0x8017dc58; addr2 = 0x8017f000; addr3 = 0x8017faa8;
                    addr4 = 0x801806f8; addr5 = 0x801828ec;
                    addr4Reg1 = 28;
                    addr4Reg2 = 31;
                    getEntryAddrFunc = 0x803994f0;
                    break;
                default:
                    throw new NotImplementedException();
            }
            // adjust pointers to point at rows instead of names
            int tableStart = CommonD.ReadInt(0x10),
                rowSize = CommonD.ReadInt(0x4),
                count = CommonD.ReadInt(0x1c),
                mappingAddr = CommonD.ReadInt(0x20);
            CommonD.WriteInt(0x8, tableStart);
            int dexNo, offset;
            for (int i = 0; i < count; i++) {
                offset = mappingAddr + 8 * i;
                dexNo = CommonD.ReadInt(offset + 4);
                if (dexNo > 493)
                    continue;
                else if (dexNo > 413)
                    CommonD.WriteInt(offset, tableStart + (dexNo + 5) * rowSize);
                else if (dexNo > 386)
                    CommonD.WriteInt(offset, tableStart + (dexNo + 3) * rowSize);
                else
                    CommonD.WriteInt(offset, tableStart + dexNo * rowSize);
            }
            // custom calculation of entry address
            string[] asm = {
                "mr r6, r4",
                "mr r10, r5",
                "lwz r9, 0x0(r3)",
                "li r3, 0x0",
                "cmpwi r9, 0x0",
                $"beq 0x{NextFreeAddr + 0x58:x08}",
                "lwz r0, 0x1c(r9)",
                "lwz r8, 0x20(r9)",
                "li r4, 0x0",
                "rlwinm r5, r4, 0x3, 0x0, 0x1c",
                "add r7, r8, r5",
                "lwz r5, 0x4(r7)",
                "cmpw r5, r6",
                $"bne 0x{NextFreeAddr + 0x4c:x08}",
                "lwz r3, 0x0(r7)",
                "lwz r0, 0x4(r9)",
                "mullw r5, r10, r0",
                "add r3, r3, r5",
                $"b 0x{NextFreeAddr + 0x58:x08}",
                "addi r4, r4, 0x1",
                "cmpw r4, r0",
                $"blt 0x{NextFreeAddr + 0x24:x08}"
            };
            InsertAssembly(asm, getEntryAddrFunc, true);
            // include form index in the Pokemon's in-battle data struct
            asm = new string[] {
                "mr r19, r3",
                "mr r3, r22",
                "li r4, 0x70",
                "li r5, 0x0",
                $"bl 0x{GET_MON_DATA_ATTR:x08}",
                "cmpwi r19, 0x0",
                "rlwinm r0, r3, 0x0, 0x18, 0x1f",
                $"beq 0x{NextFreeAddr + 0x1c + 8:x08}",
                "stb r0, 0xc(r19)"
            };
            InsertAssembly(asm, addr1);
            // add form index as param to call
            asm = new string[] {
                "rlwinm r0, r23, 0x2, 0xe, 0x1d",
                "lwzx r3, r26, r0",
                "lwz r3, 0x8(r3)",
                "lbz r5, 0x10(r3)", // form index
                "addi r3, r29, 0x74"
            };
            InsertAssembly(asm, addr2);
            DOL.WriteInstruction(addr2 + 8, "rlwinm r6, r24, 0x0, 0x10, 0x1f");
            // add form index as param to call
            asm = new string[] {
                "lbz r5, 0x10(r27)", // merge "add 4"
                "addi r3, r31, 0x74"
            };
            InsertAssembly(asm, addr3);
            // add form index as param to call
            asm = new string[] {
                $"lbz r5, 0xc(r{addr4Reg1})",
                $"addi r3, r{addr4Reg2}, 0x74"
            };
            InsertAssembly(asm, addr4);
            // add form index as param to call
            asm = new string[] {
                "lbz r5, 0xc(r30)",
                "addi r3, r31, 0x74"
            };
            InsertAssembly(asm, addr5);
        }

        private static void PatchCommon15() {
            // set leading unused bytes to dex + form
            int start = Common15.ReadInt(0x10),
                rowSize = Common15.ReadInt(0x4);
            int offset;
            for (short i = 1; i <= 493; i++) {
                offset = start + i * rowSize;
                Common15.WriteShort(offset, i); // dex
                Common15.WriteShort(offset + 2, 0); // form
            }
            // Add entries for all forms
            short spriteIdx;
            // Egg
            offset = start + 494 * rowSize;
            Common15.WriteShort(offset, -0x1); // dex
            Common15.WriteShort(offset + 2, 0); // form
            spriteIdx = Common15.ReadShort(offset + 4);
            SpriteTable.AddBodySpriteSlot(new Pokemon(-0x1, 1), (short)(spriteIdx + 1));
            // Unown
            spriteIdx = Common15.ReadShort(start + 201 * rowSize + 4);
            for (short i = 1; i < 28; i++) {
                SpriteTable.AddBodySpriteSlot(new Pokemon(201, i), (short)(spriteIdx + i));
            }
            // Castform
            spriteIdx = Common15.ReadShort(start + 351 * rowSize + 4);
            for (short i = 1; i < 4; i++) {
                SpriteTable.AddBodySpriteSlot(new Pokemon(351, i), (short)(spriteIdx + i));
            }
            // Deoxys
            spriteIdx = Common15.ReadShort(start + 386 * rowSize + 4);
            for (short i = 1; i < 4; i++) {
                SpriteTable.AddBodySpriteSlot(new Pokemon(386, i), (short)(spriteIdx + i));
            }
            // Burmy
            spriteIdx = Common15.ReadShort(start + 412 * rowSize + 4);
            for (short i = 1; i < 3; i++) {
                SpriteTable.AddBodySpriteSlot(new Pokemon(412, i), (short)(spriteIdx + i));
            }
            // Wormadam
            spriteIdx = Common15.ReadShort(start + 413 * rowSize + 4);
            for (short i = 1; i < 3; i++) {
                SpriteTable.AddBodySpriteSlot(new Pokemon(413, i), (short)(spriteIdx + i));
            }
            // Cherrim
            spriteIdx = Common15.ReadShort(start + 421 * rowSize + 4);
            SpriteTable.AddBodySpriteSlot(new Pokemon(421, 1), (short)(spriteIdx + 1));
            // Shellos
            spriteIdx = Common15.ReadShort(start + 422 * rowSize + 4);
            SpriteTable.AddBodySpriteSlot(new Pokemon(422, 1), (short)(spriteIdx + 1));
            // Gastrodon
            spriteIdx = Common15.ReadShort(start + 423 * rowSize + 4);
            SpriteTable.AddBodySpriteSlot(new Pokemon(423, 1), (short)(spriteIdx + 1));
            // Arceus
            spriteIdx = Common15.ReadShort(start + 493 * rowSize + 4);
            for (short i = 1; i < 18; i++) {
                SpriteTable.AddBodySpriteSlot(new Pokemon(493, i), (short)(spriteIdx + i));
            }

            Patch_GET_BODY_SPRITE_IDX();
        }

        private static void Patch_GET_BODY_SPRITE_IDX() {
            uint call1, call2, call3, call4, call5,
                getEntryAddr;
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    call1 = 0x8005db9c; call2 = 0x8005dbc0; call3 = 0x8005de70;
                    call4 = 0x8005de94; call5 = 0x8005e188;
                    getEntryAddr = 0x8039a570;
                    break;
                case GameRegion.PAL:
                    call1 = 0x8005c0ac; call2 = 0x8005c0d0; call3 = 0x8005c380;
                    call4 = 0x8005c3a4; call5 = 0x8005c698;
                    getEntryAddr = 0x803969f8;
                    break;
                default:
                    throw new NotImplementedException();
            }
            string[] asm;
            // Update calls to GET_BODY_SPRITE_IDX
            // 1
            asm = new string[] {
                "lwz r3, 0xa8(r3)",
                "mr r5, r6"
            };
            InsertAssembly(asm, call1);
            // 2
            asm = new string[] {
                "mr r4, r27",
                "mr r5, r29"
            };
            InsertAssembly(asm, call2);
            // 3
            asm = new string[] {
                "lwz r3, 0xa8(r3)",
                "mr r5, r8"
            };
            InsertAssembly(asm, call3);
            // 4
            asm = new string[] {
                "mr r4, r24",
                "mr r5, r27"
            };
            InsertAssembly(asm, call4);
            // 5
            asm = new string[] {
                "mr r4, r22",
                "mr r5, r24"
            };
            InsertAssembly(asm, call5);

            // make GET_ENTRY_ADDR a search for dex+form match
            asm = new string[] {
                "mr r8, r4",
                "mr r6, r5",
                "lwz r4, 0x0(r3)",
                "li r3, 0x0",
                "cmpwi r4, 0x0",
                $"beq 0x{NextFreeAddr + 0x5c:x08}",
                "lwz r0, 0x0(r4)",
                "lwz r10, 0x4(r4)",
                "lwz r9, 0x10(r4)",
                "li r4, 0x0",
                "mullw r5, r4, r10",
                "add r7, r9, r5",
                "lha r5, 0x0(r7)",
                "cmpw r5, r8",
                $"bne 0x{NextFreeAddr + 0x50:x08}",
                "lhz r5, 0x2(r7)",
                "cmpw r5, r6",
                $"bne 0x{NextFreeAddr + 0x50:x08}",
                "mr r3, r7",
                $"b 0x{NextFreeAddr + 0x5c:x08}",
                "addi r4, r4, 0x1",
                "cmpw r4, r0",
                $"blt 0x{NextFreeAddr + 0x28:x08}"
            };
            InsertAssembly(asm, getEntryAddr, true);
        }

        private static void PatchCommon16() {
            int start = Common16.ReadInt(0x10),
                rowSize = Common16.ReadInt(0x4);
            int offset;
            for (short i = 1; i <= 493; i++) {
                offset = start + i * rowSize;
                // set leading unused bytes to dex + form
                Common16.WriteShort(offset, i);
                Common16.WriteShort(offset + 2, 0);
            }
            short spriteIdx;
            // Egg
            offset = start + 494 * rowSize;
            Common16.WriteShort(offset, -0x1); // dex
            Common16.WriteShort(offset + 2, 0); // form
            spriteIdx = Common16.ReadShort(offset + 4);
            SpriteTable.AddFaceSpriteSlot(new Pokemon(-0x1, 1), (short)(spriteIdx + 1));
            // Unown
            spriteIdx = Common16.ReadShort(start + 201 * rowSize + 4);
            for (short i = 1; i < 28; i++) {
                SpriteTable.AddFaceSpriteSlot(new Pokemon(201, i), (short)(spriteIdx + i));
            }
            // Castform
            spriteIdx = Common16.ReadShort(start + 351 * rowSize + 4);
            for (short i = 1; i < 4; i++) {
                SpriteTable.AddFaceSpriteSlot(new Pokemon(351, i), (short)(spriteIdx + i));
            }
            // Deoxys
            spriteIdx = Common16.ReadShort(start + 386 * rowSize + 4);
            for (short i = 1; i < 4; i++) {
                SpriteTable.AddFaceSpriteSlot(new Pokemon(386, i), (short)(spriteIdx + i));
            }
            // Burmy
            spriteIdx = Common16.ReadShort(start + 412 * rowSize + 4);
            for (short i = 1; i < 3; i++) {
                SpriteTable.AddFaceSpriteSlot(new Pokemon(412, i), (short)(spriteIdx + i));
            }
            // Wormadam
            spriteIdx = Common16.ReadShort(start + 413 * rowSize + 4);
            for (short i = 1; i < 3; i++) {
                SpriteTable.AddFaceSpriteSlot(new Pokemon(413, i), (short)(spriteIdx + i));
            }
            // Cherrim
            spriteIdx = Common16.ReadShort(start + 421 * rowSize + 4);
            SpriteTable.AddFaceSpriteSlot(new Pokemon(421, 1), (short)(spriteIdx + 1));
            // Shellos
            spriteIdx = Common16.ReadShort(start + 422 * rowSize + 4);
            SpriteTable.AddFaceSpriteSlot(new Pokemon(422, 1), (short)(spriteIdx + 1));
            // Gastrodon
            spriteIdx = Common16.ReadShort(start + 423 * rowSize + 4);
            SpriteTable.AddFaceSpriteSlot(new Pokemon(423, 1), (short)(spriteIdx + 1));
            // Arceus
            spriteIdx = Common16.ReadShort(start + 493 * rowSize + 4);
            for (short i = 1; i < 18; i++) {
                SpriteTable.AddFaceSpriteSlot(new Pokemon(493, i), (short)(spriteIdx + i));
            }

            Patch_GET_FACE_SPRITE_IDX();
        }

        private static void Patch_GET_FACE_SPRITE_IDX() {
            uint call1, call2, call3, call4, call5,
                getEntryAddr;
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    call1 = 0x8005d204; call2 = 0x8005d228; call3 = 0x8005d4e0;
                    call4 = 0x8005d504; call5 = 0x8005d84c;
                    getEntryAddr = 0x80395600;
                    break;
                case GameRegion.PAL:
                    call1 = 0x8005b714; call2 = 0x8005b738; call3 = 0x8005b9f0;
                    call4 = 0x8005ba14; call5 = 0x8005bd5c;
                    getEntryAddr = 0x803908e8;
                    break;
                default:
                    throw new NotImplementedException();
            }
            string[] asm;
            // Update calls to GET_FACE_SPRITE_IDX
            // 1
            asm = new string[] {
                "lwz r3, 0x20(r3)",
                "mr r5, r6"
            };
            InsertAssembly(asm, call1);
            // 2
            asm = new string[] {
                "mr r4, r27",
                "mr r5, r29"
            };
            InsertAssembly(asm, call2);
            // 3
            asm = new string[] {
                "lwz r3, 0x20(r3)",
                "mr r5, r9"
            };
            InsertAssembly(asm, call3);
            // 4
            asm = new string[] {
                "mr r4, r23",
                "mr r5, r25"
            };
            InsertAssembly(asm, call4);
            // 5
            asm = new string[] {
                "mr r4, r22",
                "mr r5, r24"
            };
            InsertAssembly(asm, call5);

            // make GET_ENTRY_ADDR a search for dex+form match
            asm = new string[] {
                "mr r8, r4",
                "mr r6, r5",
                "lwz r4, 0x0(r3)",
                "li r3, 0x0",
                "cmpwi r4, 0x0",
                $"beq 0x{NextFreeAddr + 0x5c:x08}",
                "lwz r0, 0x0(r4)",
                "lwz r10, 0x4(r4)",
                "lwz r9, 0x10(r4)",
                "li r4, 0x0",
                "mullw r5, r4, r10",
                "add r7, r9, r5",
                "lha r5, 0x0(r7)",
                "cmpw r5, r8",
                $"bne 0x{NextFreeAddr + 0x50:x08}",
                "lhz r5, 0x2(r7)",
                "cmpw r5, r6",
                $"bne 0x{NextFreeAddr + 0x50:x08}",
                "mr r3, r7",
                $"b 0x{NextFreeAddr + 0x5c:x08}",
                "addi r4, r4, 0x1",
                "cmpw r4, r0",
                $"blt 0x{NextFreeAddr + 0x28:x08}"
            };
            InsertAssembly(asm, getEntryAddr, true);
        }

        private static void InsertAssembly(string[] asm, uint address, bool blr = false) {
            DOL.WriteInstruction(address, $"b 0x{NextFreeAddr:x08}");
            for (uint i = 0; i < asm.Length; i++) {
                DOL.WriteInstruction(NextFreeAddr, asm[i]);
                NextFreeAddr += 4;
            }
            if (blr)
                DOL.WriteInstruction(NextFreeAddr, "blr");
            else
                DOL.WriteInstruction(NextFreeAddr, $"b 0x{address + 4:x08}");
            NextFreeAddr += 4;
            DOL.Write();
        }

        // GLOBALS
        private static string[] COMMON_08_PTR {
            get {
                switch (Program.ISORegion) {
                    case GameRegion.NTSCU:
                        return new string[] {
                            "lis r3, -0x7f9e",
                            "addi r3, r3, 0x5184"
                        };
                    case GameRegion.PAL:
                        return new string[] {
                            "lis r3, -0x7f9c",
                            "subi r3, r3, 0x31bc"
                        };
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        // FUNCTIONS
        private static uint READ_MON_DATA {
            get {
                switch (Program.ISORegion) {
                    case GameRegion.NTSCU:
                        return 0x803de52c;
                    case GameRegion.PAL:
                        return 0x803daefc;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static uint GET_MON_DATA_ATTR {
            get {
                switch (Program.ISORegion) {
                    case GameRegion.NTSCU:
                        return 0x803e100c;
                    case GameRegion.PAL:
                        return 0x803dd9dc;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static uint GET_MON_ATTRS_IDX {
            get {
                switch (Program.ISORegion) {
                    case GameRegion.NTSCU:
                        return 0x803e0f0c;
                    case GameRegion.PAL:
                        return 0x803dd8dc;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static uint GET_MON_TYPE {
            get {
                switch (Program.ISORegion) {
                    case GameRegion.NTSCU:
                        return 0x80058f70;
                    case GameRegion.PAL:
                        return 0x80056f68;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static uint GET_PRIMARY_TYPE {
            get {
                switch (Program.ISORegion) {
                    case GameRegion.NTSCU:
                        return 0x8039653c;
                    case GameRegion.PAL:
                        return 0x803919c4;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static uint GET_SECONDARY_TYPE {
            get {
                switch (Program.ISORegion) {
                    case GameRegion.NTSCU:
                        return 0x80396570;
                    case GameRegion.PAL:
                        return 0x803919f8;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static uint GET_COLOR_GROUP {
            get {
                switch (Program.ISORegion) {
                    case GameRegion.NTSCU:
                        return 0x803969cc;
                    case GameRegion.PAL:
                        return 0x80391e54;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private static uint GET_FLIP_FLAG {
            get {
                switch (Program.ISORegion) {
                    case GameRegion.NTSCU:
                        return 0x80396a04;
                    case GameRegion.PAL:
                        return 0x80391e8c;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}
