﻿using System;
using PBRHex.Files;
using PBRHex.Tables;
using PBRHex.Utils;

namespace PBRHex
{
    public static class PatchManager
    {
        private static FSYS Common => FSYSTable.GetFile("common.fsys");

        public static uint NextFreeAddr { get; private set; }
        private static readonly uint freeSpaceStart, freeSpaceEnd;

        static PatchManager() {
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    freeSpaceStart = 0x801d9474;
                    freeSpaceEnd = 0x801df670;
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
            if (addr == freeSpaceEnd)
                throw new Exception("No free space available in main.dol");
            //nextFreeAddr = addr;
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
                default:
                    throw new NotImplementedException();
            }
            // check if already cleared
            if (DOL.ReadInstruction(call1) == 0xDEADC0DE)
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
            uint address;
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    address = 0x80275b5c;
                    break;
                default:
                    throw new NotImplementedException();
            }
            DOL.WriteInstruction(address, "lis r5, -0x7f9c");
            DOL.WriteInstruction(address + 0xc, "subi r5, r5, 0x6d50");
            DOL.AddSection(0x8062b2b0);
            DOL.Write();
        }

        public static void PatchDex() {
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
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
            Common.Files[0x6].WriteShort(0xb564, -0x1);
            Common.Files[0x15].WriteInt(0x1758, -0x1);
            Common.Files[0x16].WriteInt(0xfa0, -0x1);
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
                default:
                    throw new NotImplementedException();
            }
            var common08 = Common.Files[0x8];
            var common16 = Common.Files[0x16];
            int common8start = common08.ReadInt(0x10),
                common8stride = common08.ReadInt(4),
                common16start = common16.ReadInt(0x10),
                common16stride = common16.ReadInt(4);
            int offset;
            for (short i = 1; i <= 493; i++) {
                offset = common8start + i * common8stride;
                // replace wild held item columns w/ dex & form indices
                common08.WriteShort(offset + 0x10, i);
                common08.WriteShort(offset + 0x12, 0);
                // replace kana string index w/ form string index
                // (not 100% sure the kanji string is unused)
                int idx = 0;
                if (i == 386)
                    idx = StringTable.AddString("Normal Forme");
                else if (i == 413)
                    idx = StringTable.AddString("Plant Cloak");
                common08.WriteShort(offset + 0x1a, (short)idx);
                // replace color + flip with form count + unevolved flag (copied from common:16)
                short forms = common16.ReadShort(common16start + common16stride * i + 0x6);
                common08.WriteByte(offset + 0x33, (byte)forms);
            }
            // Deoxys forms
            for (short i = 1; i <= 3; i++) {
                offset = common8start + (495 + i) * common8stride;
                common08.WriteShort(offset + 0x10, 386);
                common08.WriteShort(offset + 0x12, i);
                int idx;
                if (i == 1)
                    idx = StringTable.AddString("Attack Forme");
                else if (i == 2)
                    idx = StringTable.AddString("Defense Forme");
                else
                    idx = StringTable.AddString("Speed Forme");
                common08.WriteShort(offset + 0x1a, (short)idx);
                common08.WriteByte(offset + 0x33, 8);
            }
            // Wormadam forms
            for (short i = 1; i <= 2; i++) {
                offset = common8start + (498 + i) * common8stride;
                common08.WriteShort(offset + 0x10, 413);
                common08.WriteShort(offset + 0x12, i);
                int idx;
                if (i == 1)
                    idx = StringTable.AddString("Sandy Cloak");
                else
                    idx = StringTable.AddString("Trash Cloak");
                common08.WriteShort(offset + 0x1a, (short)idx);
                common08.WriteByte(offset + 0x33, 6);
            }
            // Eggs
            offset = common8start + 494 * common8stride;
            common08.WriteShort(offset + 0x10, -1);
            common08.WriteByte(offset + 0x33, 4);
            offset = common8start + 495 * common8stride;
            common08.WriteShort(offset + 0x10, -2);
            common08.WriteByte(offset + 0x33, 2);

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
                        0x8005e8c0, 0x8005e5a0, 0x8005e718
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
                getEntryAddrFunc, unkFunc;
            switch (Program.ISORegion) {
                case GameRegion.NTSCU:
                    addr1 = 0x80182554;
                    addr2 = 0x8018390c;
                    addr3 = 0x801843a4;
                    addr4 = 0x8018502c;
                    addr5 = 0x8018726c;
                    getEntryAddrFunc = 0x8039d068;
                    unkFunc = 0x801c8774;
                    break;
                default:
                    throw new NotImplementedException();
            }
            // adjust pointers to point at rows instead of names
            var common0D = Common.Files[0xd];
            int tableStart = common0D.ReadInt(0x10),
                rowSize = common0D.ReadInt(0x4),
                count = common0D.ReadInt(0x1c),
                mappingAddr = common0D.ReadInt(0x20);
            common0D.WriteInt(0x8, tableStart);
            int dexNo, offset;
            for (int i = 0; i < count; i++) {
                offset = mappingAddr + 8 * i;
                dexNo = common0D.ReadInt(offset + 4);
                if (dexNo > 493)
                    continue;
                else if (dexNo > 413)
                    common0D.WriteInt(offset, tableStart + (dexNo + 5) * rowSize);
                else if (dexNo > 386)
                    common0D.WriteInt(offset, tableStart + (dexNo + 3) * rowSize);
                else
                    common0D.WriteInt(offset, tableStart + dexNo * rowSize);
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
                $"bl 0x{unkFunc:x08}",
                "lbz r5, 0xc(r3)", // form index
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
                "lbz r5, 0xc(r25)",
                "addi r3, r28, 0x74"
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
            var common15 = Common.Files[0x15];
            int start = common15.ReadInt(0x10),
                rowSize = common15.ReadInt(0x4);
            int offset;
            for (short i = 1; i <= 493; i++) {
                offset = start + i * rowSize;
                common15.WriteShort(offset, i); // dex
                common15.WriteShort(offset + 2, 0); // form
            }
            // Add entries for all forms
            short spriteIdx;
            // Egg
            offset = start + 494 * rowSize;
            common15.WriteShort(offset, -0x1); // dex
            common15.WriteShort(offset + 2, 0); // form
            spriteIdx = common15.ReadShort(offset + 4);
            SpriteTable.AddBodySpriteSlot(new Pokemon(-0x1, 1), (short)(spriteIdx + 1));
            // Unown
            spriteIdx = common15.ReadShort(start + 201 * rowSize + 4);
            for (short i = 1; i < 28; i++) {
                SpriteTable.AddBodySpriteSlot(new Pokemon(201, i), (short)(spriteIdx + i));
            }
            // Castform
            spriteIdx = common15.ReadShort(start + 351 * rowSize + 4);
            for (short i = 1; i < 4; i++) {
                SpriteTable.AddBodySpriteSlot(new Pokemon(351, i), (short)(spriteIdx + i));
            }
            // Deoxys
            spriteIdx = common15.ReadShort(start + 386 * rowSize + 4);
            for (short i = 1; i < 4; i++) {
                SpriteTable.AddBodySpriteSlot(new Pokemon(386, i), (short)(spriteIdx + i));
            }
            // Burmy
            spriteIdx = common15.ReadShort(start + 412 * rowSize + 4);
            for (short i = 1; i < 3; i++) {
                SpriteTable.AddBodySpriteSlot(new Pokemon(412, i), (short)(spriteIdx + i));
            }
            // Wormadam
            spriteIdx = common15.ReadShort(start + 413 * rowSize + 4);
            for (short i = 1; i < 3; i++) {
                SpriteTable.AddBodySpriteSlot(new Pokemon(413, i), (short)(spriteIdx + i));
            }
            // Cherrim
            spriteIdx = common15.ReadShort(start + 421 * rowSize + 4);
            SpriteTable.AddBodySpriteSlot(new Pokemon(421, 1), (short)(spriteIdx + 1));
            // Shellos
            spriteIdx = common15.ReadShort(start + 422 * rowSize + 4);
            SpriteTable.AddBodySpriteSlot(new Pokemon(422, 1), (short)(spriteIdx + 1));
            // Gastrodon
            spriteIdx = common15.ReadShort(start + 423 * rowSize + 4);
            SpriteTable.AddBodySpriteSlot(new Pokemon(423, 1), (short)(spriteIdx + 1));
            // Arceus
            spriteIdx = common15.ReadShort(start + 493 * rowSize + 4);
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
                    call1 = 0x8005db9c;
                    call2 = 0x8005dbc0;
                    call3 = 0x8005de70;
                    call4 = 0x8005de94;
                    call5 = 0x8005e188;
                    getEntryAddr = 0x8039a570;
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
            var common16 = Common.Files[0x16];
            int start = common16.ReadInt(0x10),
                rowSize = common16.ReadInt(0x4);
            int offset;
            for (short i = 1; i <= 493; i++) {
                offset = start + i * rowSize;
                // set leading unused bytes to dex + form
                common16.WriteShort(offset, i);
                common16.WriteShort(offset + 2, 0);
            }
            short spriteIdx;
            // Egg
            offset = start + 494 * rowSize;
            common16.WriteShort(offset, -0x1); // dex
            common16.WriteShort(offset + 2, 0); // form
            spriteIdx = common16.ReadShort(offset + 4);
            SpriteTable.AddFaceSpriteSlot(new Pokemon(-0x1, 1), (short)(spriteIdx + 1));
            // Unown
            spriteIdx = common16.ReadShort(start + 201 * rowSize + 4);
            for (short i = 1; i < 28; i++) {
                SpriteTable.AddFaceSpriteSlot(new Pokemon(201, i), (short)(spriteIdx + i));
            }
            // Castform
            spriteIdx = common16.ReadShort(start + 351 * rowSize + 4);
            for (short i = 1; i < 4; i++) {
                SpriteTable.AddFaceSpriteSlot(new Pokemon(351, i), (short)(spriteIdx + i));
            }
            // Deoxys
            spriteIdx = common16.ReadShort(start + 386 * rowSize + 4);
            for (short i = 1; i < 4; i++) {
                SpriteTable.AddFaceSpriteSlot(new Pokemon(386, i), (short)(spriteIdx + i));
            }
            // Burmy
            spriteIdx = common16.ReadShort(start + 412 * rowSize + 4);
            for (short i = 1; i < 3; i++) {
                SpriteTable.AddFaceSpriteSlot(new Pokemon(412, i), (short)(spriteIdx + i));
            }
            // Wormadam
            spriteIdx = common16.ReadShort(start + 413 * rowSize + 4);
            for (short i = 1; i < 3; i++) {
                SpriteTable.AddFaceSpriteSlot(new Pokemon(413, i), (short)(spriteIdx + i));
            }
            // Cherrim
            spriteIdx = common16.ReadShort(start + 421 * rowSize + 4);
            SpriteTable.AddFaceSpriteSlot(new Pokemon(421, 1), (short)(spriteIdx + 1));
            // Shellos
            spriteIdx = common16.ReadShort(start + 422 * rowSize + 4);
            SpriteTable.AddFaceSpriteSlot(new Pokemon(422, 1), (short)(spriteIdx + 1));
            // Gastrodon
            spriteIdx = common16.ReadShort(start + 423 * rowSize + 4);
            SpriteTable.AddFaceSpriteSlot(new Pokemon(423, 1), (short)(spriteIdx + 1));
            // Arceus
            spriteIdx = common16.ReadShort(start + 493 * rowSize + 4);
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
                    call1 = 0x8005d204;
                    call2 = 0x8005d228;
                    call3 = 0x8005d4e0;
                    call4 = 0x8005d504;
                    call5 = 0x8005d84c;
                    getEntryAddr = 0x80395600;
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
                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}