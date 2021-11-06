using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PBRTool.Utils
{
    public static class AssemblyUtils
    {
        private static readonly Dictionary<int, string> SPREncodingToName;
        private static readonly Dictionary<string, int> SPRNameToEncoding;

        static AssemblyUtils() {
            SPREncodingToName = new Dictionary<int, string>()
            {
                { 912, "GQR0" },
                { 913, "GQR1" },
                { 914, "GQR2" },
                { 915, "GQR3" },
                { 916, "GQR4" },
                { 917, "GQR5" },
                { 918, "GQR6" },
                { 919, "GQR7" },
            };
            SPRNameToEncoding = SPREncodingToName.ToDictionary(i => i.Value, i => i.Key);
        }

        /// <param name="asm">The assembly string to convert to machine code.</param>
        /// <param name="address">The address of the instruction; required for branch instructions.</param>
        /// <returns>The uint representation of the given instruction.</returns>
        public static uint Assemble(string asm, uint address = 0) {
            var args = Regex.Split(asm, @"[ ,()]+[cfr]*");
            string op = args[0], bin = asm;
            int A, B, BD, BO, BI, C, D, L, LI, LK, MB, ME, OE, Rc, S, SH, SIMM, SPR, d, spr1, spr2;
            uint target_addr;
            switch(op) {
                case "add": case "add.": case "addo": case "addo.":
                case "addc": case "addc.": case "addco": case "addco.":
                case "adde": case "adde.": case "addeo": case "addeo.":
                case "subf": case "subf.": case "subfo": case "subfo.":
                case "subfc": case "subfc.": case "subfco": case "subfco.":
                case "subfe": case "subfe.": case "subfeo": case "subfeo.":
                    D = Convert.ToInt32(args[1]);
                    A = Convert.ToInt32(args[2]);
                    B = Convert.ToInt32(args[3]);
                    OE = (op.EndsWith("o") || op.EndsWith("o.")) ? 1 : 0;
                    Rc = op.EndsWith(".") ? 1 : 0;
                    bin = $"011111{Binary(D, 5)}{Binary(A, 5)}{Binary(B, 5)}{OE}";
                    switch(op) {
                        case "add": case "add.": case "addo": case "addo.":
                            bin += "100001010";
                            break;
                        case "addc": case "addc.": case "addco": case "addco.":
                            bin += "000001010";
                            break;
                        case "adde": case "adde.": case "addeo": case "addeo.":
                            bin += "010001010";
                            break;
                        case "subf": case "subf.": case "subfo": case "subfo.":
                            bin += "000101000";
                            break;
                        case "subfc": case "subfc.": case "subfco": case "subfco.":
                            bin += "000001000";
                            break;
                        case "subfe": case "subfe.": case "subfeo": case "subfeo.":
                            bin += "010001000";
                            break;
                    }
                    bin += Rc;
                    break;
                case "addi":
                case "addic":
                case "addic.":
                case "addis":
                case "subi":
                case "subic":
                case "subic.":
                case "subis":
                    D = Convert.ToInt32(args[1]);
                    A = Convert.ToInt32(args[2]);
                    SIMM = Convert.ToInt32(args[3], 16);
                    if(op == "subi" || op == "subic" || 
                        op == "subic." || op == "subis")
                        SIMM *= -1;
                    switch(op) {
                        case "addi":
                        case "subi":
                            bin = "001110";
                            break;
                        case "addic":
                        case "subic":
                            bin = "001100";
                            break;
                        case "addic.":
                        case "subic.":
                            bin = "001101";
                            break;
                        case "addis":
                        case "subis":
                            bin = "001111";
                            break;
                    }
                    bin += $"{Binary(D, 5)}{Binary(A, 5)}{Binary(SIMM, 16)}";
                    break;
                case "b":
                case "bl":
                    target_addr = Convert.ToUInt32(args[1], 16);
                    if(op == "b" || op == "bl")
                        LI = (int)(target_addr - address) >> 2;
                    else
                        LI = (int)(target_addr >> 2);
                    LK = (op == "bl") ? 1 : 0;
                    bin = $"010010{Binary(LI, 24)}0{LK}";
                    break;
                case "bc":
                case "bcl":
                    BO = Convert.ToInt32(args[1], 16);
                    BI = Convert.ToInt32(args[2], 16);
                    target_addr = Convert.ToUInt32(args[3], 16);
                    BD = (int)(target_addr - address) >> 2;
                    LK = (op == "bcl") ? 1 : 0;
                    bin = $"010000{Binary(BO, 5)}{Binary(BI, 5)}{Binary(BD, 14)}0{LK}";
                    break;
                case "bclr":
                case "bclrl":
                    BO = Convert.ToInt32(args[1], 16);
                    BI = Convert.ToInt32(args[2], 16);
                    LK = (op == "bclrl") ? 1 : 0;
                    bin = $"010011{Binary(BO, 5)}{Binary(BI, 5)}000000000010000{LK}";
                    break;
                case "beq":
                case "bgt":
                case "ble":
                case "blt":
                case "bne":
                case "bdnz":
                    target_addr = Convert.ToUInt32(args[1], 16);
                    BD = (int)(target_addr - address) >> 2;
                    bin = $"010000";
                    switch(op) {
                        case "beq":
                            bin += "0110000010";
                            break;
                        case "bgt":
                            bin += "0110000001";
                            break;
                        case "ble":
                            bin += "0010000001";
                            break;
                        case "blt":
                            bin += "0110000000";
                            break;
                        case "bne":
                            bin += "0010000010";
                            break;
                        case "bdnz":
                            bin += "1000000000";
                            break;
                    }
                    bin += $"{Binary(BD, 14)}00";
                    break;
                case "bctr":
                case "bctrl":
                case "beqctr":
                case "bltctr":
                case "bnectr":
                case "blr":
                case "blrl":
                case "beqlr":
                case "bltlr":
                case "bnelr":
                case "bdnzlr":
                    LK = (op == "blrl" || op == "bctrl") ? 1 : 0;
                    bin = "010011";
                    switch(op) {
                        case "bctr":
                        case "bctrl":
                        case "blr":
                        case "blrl":
                            bin += "1010000000";
                            break;
                        case "beqctr":
                        case "beqlr":
                            bin += "0110000010";
                            break;
                        case "bltctr":
                        case "bltlr":
                            bin += "0110000000";
                            break;
                        case "bnectr":
                        case "bnelr":
                            bin += "0010000010";
                            break;
                        case "bdnzlr":
                            bin += "1000000000";
                            break;
                    }
                    bin += $"00000";
                    switch(op) {
                        case "bctr":
                        case "bctrl":
                        case "beqctr":
                        case "bltctr":
                        case "bnectr":
                            bin += "1000010000";
                            break;
                        case "blr":
                        case "blrl":
                        case "beqlr":
                        case "bltlr":
                        case "bnelr":
                        case "bdnzlr":
                            bin += "0000010000";
                            break;
                    }
                    bin += LK;
                    break;
                case "cmpdi":
                case "cmpwi":
                case "cmpldi":
                case "cmplwi":
                    D = (args.Length == 4) ? Convert.ToInt32(args[1]) : 0;
                    A = Convert.ToInt32(args[args.Length - 2]);
                    SIMM = HexUtils.SignedHexToInt(args[args.Length - 1]);
                    L = (op == "cmpdi") ? 1 : 0;

                    if(op == "cmpdi" || op == "cmpwi")
                        bin = "001011";
                    else if(op == "cmpldi" || op == "cmplwi")
                        bin = "001010";

                    bin += $"{Binary(D, 3)}0{L}{Binary(A, 5)}{Binary(SIMM, 16)}";
                    break;
                case "cmpld":
                case "cmplw":
                    D = (args.Length == 4) ? Convert.ToInt32(args[1]) : 0;
                    A = Convert.ToInt32(args[args.Length - 2]);
                    B = Convert.ToInt32(args[args.Length - 1]);
                    L = (op == "cmpld") ? 1 : 0;
                    bin = $"011111{Binary(D, 3)}0{L}{Binary(A, 5)}{Binary(B, 5)}00001000000";
                    break;
                case "fadd":
                case "fadd.":
                case "fadds":
                case "fadds.":
                    D = Convert.ToInt32(args[1]);
                    A = Convert.ToInt32(args[2]);
                    B = Convert.ToInt32(args[3]);
                    Rc = (op == "fadd." || op == "fadds.") ? 1 : 0;
                    if(op == "fadd" || op == "fadd.")
                        bin = "111111";
                    else if(op == "fadds" || op == "fadds.")
                        bin = "111011";
                    bin += $"{Binary(D, 5)}{Binary(A, 5)}{Binary(B, 5)}0000010101{Rc}";
                    break;
                case "fcmpo":
                    D = Convert.ToInt32(args[1]);
                    A = Convert.ToInt32(args[2]);
                    B = Convert.ToInt32(args[3]);
                    bin = $"111111{Binary(D, 3)}00{Binary(A, 5)}{Binary(B, 5)}00001000000";
                    break;
                case "fctiw":
                case "fctiw.":
                case "fctiwz":
                case "fctiwz.":
                    D = Convert.ToInt32(args[1]);
                    B = Convert.ToInt32(args[2]);
                    Rc = (op == "fctiw." || op == "fctiwz.") ? 1 : 0;
                    bin = $"111111{Binary(D, 5)}00000{Binary(B, 5)}";
                    if(op == "fctiw" || op == "fctiw.")
                        bin += "0000001110";
                    else if(op == "fctiwz" || op == "fctiwz.")
                        bin += "0000001111";
                    bin += Rc;
                    break;
                case "fdiv":
                case "fdiv.":
                case "fdivs":
                case "fdivs.":
                    D = Convert.ToInt32(args[1]);
                    A = Convert.ToInt32(args[2]);
                    B = Convert.ToInt32(args[3]);
                    Rc = (op == "fdiv." || op == "fdivs.") ? 1 : 0;
                    if(op == "fdiv" || op == "fdiv.")
                        bin = "111111";
                    else if(op == "fdivs" || op == "fdivs.")
                        bin = "111011";
                    bin += $"{Binary(D, 5)}{Binary(A, 5)}{Binary(B, 5)}0000010010{Rc}";
                    break;
                case "fsub":
                case "fsub.":
                case "fsubs":
                case "fsubs.":
                    D = Convert.ToInt32(args[1]);
                    A = Convert.ToInt32(args[2]);
                    B = Convert.ToInt32(args[3]);
                    Rc = (op == "fsub." || op == "fsubs.") ? 1 : 0;
                    if(op == "fsub" || op == "fsub.")
                        bin = "111111";
                    else if(op == "fsubs" || op == "fsubs.")
                        bin = "111011";
                    bin += $"{Binary(D, 5)}{Binary(A, 5)}{Binary(B, 5)}0000010100{Rc}";
                    break;
                case "fmr":
                case "fmr.":
                    D = Convert.ToInt32(args[1]);
                    B = Convert.ToInt32(args[2]);
                    Rc = (op == "fmr.") ? 1 : 0;
                    bin = $"111111{Binary(D, 5)}00000{Binary(B, 5)}0001001000{Rc}";
                    break;
                case "fmul":
                case "fmul.":
                case "fmuls":
                case "fmuls.":
                    D = Convert.ToInt32(args[1]);
                    A = Convert.ToInt32(args[2]);
                    C = Convert.ToInt32(args[3]);
                    Rc = (op == "fmul." || op == "fmuls.") ? 1 : 0;
                    if(op == "fmul" || op == "fmul.")
                        bin = "111111";
                    else if(op == "fmuls" || op == "fmuls.")
                        bin = "111011";
                    bin += $"{Binary(D, 5)}{Binary(A, 5)}00000{Binary(C, 5)}11001{Rc}";
                    break;
                case "lbz":
                case "lbzu":
                case "lfd":
                case "lfdu":
                case "lfs":
                case "lfsu":
                case "lha":
                case "lhau":
                case "lhz":
                case "lhzu":
                case "lwz":
                case "lwzu":
                case "stb":
                case "stbu":
                case "stfd":
                case "stfdu":
                case "stfs":
                case "stfsu":
                case "sth":
                case "sthu":
                case "stw":
                case "stwu":
                    D = Convert.ToInt32(args[1]);
                    A = Convert.ToInt32(args[3]);
                    d = HexUtils.SignedHexToInt(args[2]);
                    switch(op) {
                        case "lbz":   bin = "100010"; break;
                        case "lbzu":  bin = "100011"; break;
                        case "lfd":   bin = "110010"; break;
                        case "lfdu":  bin = "110011"; break;
                        case "lfs":   bin = "110000"; break;
                        case "lfsu":  bin = "110001"; break;
                        case "lha":   bin = "101010"; break;
                        case "lhau":  bin = "101011"; break;
                        case "lhz":   bin = "101000"; break;
                        case "lhzu":  bin = "101001"; break;
                        case "lwz":   bin = "100000"; break;
                        case "lwzu":  bin = "100001"; break;
                        case "stb":   bin = "100110"; break;
                        case "stbu":  bin = "100111"; break;
                        case "stfd":  bin = "110110"; break;
                        case "stfdu": bin = "110111"; break;
                        case "stfs":  bin = "110100"; break;
                        case "stfsu": bin = "110101"; break;
                        case "sth":   bin = "101100"; break;
                        case "sthu":  bin = "101101"; break;
                        case "stw":   bin = "100100"; break;
                        case "stwu":  bin = "100101"; break;
                    }
                    bin += $"{Binary(D, 5)}{Binary(A, 5)}{Binary(d, 16)}";
                    break;
                case "lhzx":
                case "lhzux":
                case "lwzx":
                case "lwzux":
                case "sthx":
                    D = Convert.ToInt32(args[1]);
                    A = Convert.ToInt32(args[2]);
                    B = Convert.ToInt32(args[3]);
                    bin = $"011111{Binary(D, 5)}{Binary(A, 5)}{Binary(B, 5)}";
                    switch(op) {
                        case "lhzx":
                            bin += "0100010111";
                            break;
                        case "lhzux":
                            bin += "0100110111";
                            break;
                        case "lwzx":
                            bin += "0000010111";
                            break;
                        case "lwzux":
                            bin += "0000110111";
                            break;
                        case "sthx":
                            bin += "0110010111";
                            break;
                    }
                    bin += "0";
                    break;
                case "li":
                case "lis":
                    D = Convert.ToInt32(args[1]);
                    SIMM = HexUtils.SignedHexToInt(args[2]);

                    if(op == "li")
                        bin = $"001110";
                    else if(op == "lis")
                        bin = $"001111";
                    bin += $"{Binary(D, 5)}00000{Binary(SIMM, 16)}";
                    break;
                case "mfctr":
                case "mtctr":
                case "mflr":
                case "mtlr":
                case "mfxer":
                case "mtxer":
                    D = Convert.ToInt32(args[1]);
                    bin = $"011111{Binary(D, 5)}";
                    if(op == "mfctr" || op == "mtctr")
                        bin += "0100100000";
                    else if(op == "mflr" || op == "mtlr")
                        bin += "0100000000";
                    else if(op == "mfxer" || op == "mtxer")
                        bin += "0000100000";

                    if(op == "mfctr" || op == "mflr" || op == "mfxer")
                        bin += "01010100110";
                    else if(op == "mtctr" || op == "mtlr" || op == "mtxer")
                        bin += "01110100110";
                    break;
                case "mfspr":
                    if(args[2] == "SPR")
                        SPR = Convert.ToInt32(args[3]);
                    else
                        SPR = SPRNameToEncoding[args[2]];
                    S = Convert.ToInt32(args[1]);
                    spr1 = SPR & 0x1f;
                    spr2 = SPR >> 5;
                    bin = $"011111{Binary(S, 5)}{Binary(spr1, 5)}{Binary(spr2, 5)}01010100110";
                    break;
                case "mtspr":
                    if(args[1] == "SPR")
                        SPR = Convert.ToInt32(args[2]);
                    else
                        SPR = SPRNameToEncoding[args[1]];
                    S = Convert.ToInt32(args[args.Length - 1]);
                    spr1 = SPR & 0x1f;
                    spr2 = SPR >> 5;
                    bin = $"011111{Binary(S, 5)}{Binary(spr1, 5)}{Binary(spr2, 5)}01110100110";
                    break;
                case "mr":
                case "mr.":
                case "not":
                    A = Convert.ToInt32(args[1]);
                    S = Convert.ToInt32(args[2]);
                    Rc = (op == "mr.") ? 1 : 0;
                    bin = $"011111{Binary(S, 5)}{Binary(A, 5)}{Binary(S, 5)}";
                    if(op == "mr" || op == "mr.")
                        bin += "0110111100";
                    else if(op == "not")
                        bin += "0001111100";
                    bin += Rc;
                    break;
                case "nop":
                    bin = "01100000000000000000000000000000";
                    break;
                case "nor":
                case "nor.":
                case "or":
                case "or.":
                case "orc":
                case "orc.":
                    A = Convert.ToInt32(args[1]);
                    S = Convert.ToInt32(args[2]);
                    B = Convert.ToInt32(args[3]);
                    Rc = (op == "nor." || op == "or.") ? 1 : 0;
                    bin = $"011111{Binary(S, 5)}{Binary(A, 5)}{Binary(B, 5)}";
                    if(op == "nor" || op == "nor.")
                        bin += "0001111100";
                    else if(op == "or" || op == "or.")
                        bin += "0110111100";
                    else if(op == "orc" || op == "orc.")
                        bin += "0110011100";
                    bin += Rc;
                    break;
                case "ori":
                case "oris":
                    A = Convert.ToInt32(args[1]);
                    S = Convert.ToInt32(args[2]);
                    SIMM = Convert.ToInt32(args[3], 16);
                    if(op == "ori")
                        bin = "011000";
                    else if(op == "oris")
                        bin = "011001";
                    bin += $"{Binary(S, 5)}{Binary(A, 5)}{Binary(SIMM, 16)}";
                    break;
                case "rlwinm":
                case "rlwinm.":
                    A = Convert.ToInt32(args[1]);
                    S = Convert.ToInt32(args[2]);
                    SH = Convert.ToInt32(args[3], 16);
                    MB = Convert.ToInt32(args[4], 16);
                    ME = Convert.ToInt32(args[5], 16);
                    Rc = (op == "rlwinm.") ? 1 : 0;
                    bin = $"010101{Binary(S, 5)}{Binary(A, 5)}{Binary(SH, 5)}{Binary(MB, 5)}{Binary(ME, 5)}{Rc}";
                    break;
                default:
                    return Convert.ToUInt32(bin, 16);
            }
            return Convert.ToUInt32(bin, 2);
        }

        public static string Disassemble(uint instruction, uint address) {
            var sb = new StringBuilder();
            uint target_addr;
            int A, AA, B, BD, BO, BI, C, D, L, LI, LK, MB, ME, OE, Rc, S, SH, SIMM, SPR, UIMM,
                c = (int)(instruction >> 0x1a), d, e;
            switch(c) {
                case 0xa:
                    D = (int)((instruction >> 0x17) & 0x7);
                    L = (int)((instruction >> 0x15) & 0x1);
                    A = (int)((instruction >> 0x10) & 0x1f);
                    UIMM = (int)(instruction & 0xffff);

                    if(L == 0)
                        sb.Append("cmplwi");
                    else
                        sb.Append("cmpldi");

                    if(D > 0)
                        sb.Append($" cr{D},");
                    sb.Append($" r{A}, 0x{UIMM:X}");
                    return sb.ToString();
                case 0xb:
                    D = (int)((instruction >> 0x17) & 0x7);
                    L = (int)((instruction >> 0x15) & 0x1);
                    A = (int)((instruction >> 0x10) & 0x1f);
                    SIMM = (short)(instruction & 0xffff);

                    if(L == 0)
                        sb.Append("cmpwi");
                    else
                        sb.Append("cmpdi");

                    if(D > 0)
                        sb.Append($" cr{D},");
                    sb.Append($" r{A}, {HexUtils.IntToSignedHex(SIMM)}");
                    return sb.ToString();
                case 0xc:
                case 0xd:
                case 0xe:
                case 0xf:
                    D = (int)((instruction >> 0x15) & 0x1f);
                    A = (int)((instruction >> 0x10) & 0x1f);
                    SIMM = (short)(instruction & 0xffff);

                    if(c == 0xe && A == 0)
                        return $"li r{D}, {HexUtils.IntToSignedHex(SIMM)}";
                    if(c == 0xf && A == 0)
                        return $"lis r{D}, {HexUtils.IntToSignedHex(SIMM)}";

                    if(SIMM < 0) {
                        sb.Append("subi");
                        SIMM *= -1;
                    }
                    else
                        sb.Append("addi");

                    if(c == 0xc)
                        sb.Append("c");
                    else if(c == 0xd)
                        sb.Append("c.");
                    else if(c == 0xf)
                        sb.Append("s");

                    sb.Append($" r{D}, r{A}, {HexUtils.IntToSignedHex(SIMM)}");
                    return sb.ToString();
                case 0x10:
                    BO = (int)((instruction >> 0x15) & 0x1f);
                    BI = (int)((instruction >> 0x10) & 0x1f);
                    BD = (int)((instruction >> 2) & 0x3fff);
                    AA = (int)((instruction >> 1) & 0x1);
                    LK = (int)(instruction & 0x1);

                    if(AA == 1)
                        break;
                    target_addr = (uint)((short)(BD << 2) + address);

                    if(BO == 0x4 && BI == 0x1)
                        return $"ble {target_addr:X8}";
                    if(BO == 0x4 && BI == 0x2)
                        return $"bne {target_addr:X8}";
                    if(BO == 0xc && BI == 0)
                        return $"blt {target_addr:X8}";
                    if(BO == 0xc && BI == 0x1)
                        return $"bgt {target_addr:X8}";
                    if(BO == 0xc && BI == 0x2)
                        return $"beq {target_addr:X8}";
                    if(BO == 0x10 && BI == 0)
                        return $"bdnz {target_addr:X8}";

                    sb.Append("bc");
                    if(LK == 1) sb.Append("l");

                    sb.Append($" 0x{BO:X}, 0x{BI:X}, {target_addr:X8}");
                    return sb.ToString();
                case 0x12:
                    sb.Append("b");
                    LK = (int)(instruction & 0x1);
                    AA = (int)((instruction >> 1) & 0x1);
                    LI = (int)((instruction >> 2) & 0xffffff);
                    int offset = (LI >> 23 == 1) ? (int)((LI << 2) | 0xfc000000) : LI << 2;

                    if(LK == 1)
                        sb.Append("l");
                    if(AA == 1)
                        break;
                    target_addr = (uint)(address + offset);

                    sb.Append($" {target_addr:X8}");
                    return sb.ToString();
                case 0x13:
                    BO = (int)((instruction >> 0x15) & 0x1f);
                    BI = (int)((instruction >> 0x10) & 0x1f);
                    d = (int)((instruction >> 0x1) & 0x3ff);
                    LK = (int)(instruction & 0x1);

                    bool mnemonic = true;
                    if(BO == 0x4 && BI == 0x2)
                        sb.Append("bne");
                    else if(BO == 0xc && BI == 0)
                        sb.Append("blt");
                    else if(BO == 0xc && BI == 0x2)
                        sb.Append("beq");
                    else if(BO == 0x10 && BI == 0)
                        sb.Append("bdnz");
                    else if(BO == 0x14 && BI == 0)
                        sb.Append("b");
                    else {
                        sb.Append("bc");
                        mnemonic = false;
                    }

                    if(d == 0x10)
                        sb.Append("lr");
                    else if(d == 0x210)
                        sb.Append("ctr");
                    else
                        break;

                    if(LK == 1)
                        sb.Append("l");
                    if(mnemonic)
                        return sb.ToString();

                    sb.Append($" 0x{BO:X}, 0x{BI:X}");
                    return sb.ToString();
                case 0x15:
                    sb.Append("rlwinm");
                    S = (int)((instruction >> 0x15) & 0x1f);
                    A = (int)((instruction >> 0x10) & 0x1f);
                    SH = (int)((instruction >> 0xb) & 0x1f);
                    MB = (int)((instruction >> 0x6) & 0x1f);
                    ME = (int)((instruction >> 0x1) & 0x1f);
                    Rc = (int)(instruction & 0x1);

                    if(Rc == 1)
                        sb.Append(".");
                    sb.Append($" r{A}, r{S}, 0x{SH:X}, 0x{MB:X}, 0x{ME:X}");
                    return sb.ToString();
                case 0x18:
                case 0x19:
                    S = (int)((instruction >> 0x15) & 0x1f);
                    A = (int)((instruction >> 0x10) & 0x1f);
                    UIMM = (int)(instruction & 0xffff); 
                    if(c == 0x18 && S == 0 && A == 0 && UIMM == 0)
                        return "nop";
                    sb.Append("ori");
                    if(c == 0x19)
                        sb.Append("s");
                    sb.Append($" r{A}, r{S}, 0x{UIMM:X}");
                    return sb.ToString();
                case 0x1f:
                    e = (int)((instruction >> 1) & 0x3ff);
                    switch(e) {
                        case 0x17:
                        case 0x37:
                        case 0x117:
                        case 0x137:
                        case 0x197:
                            switch(e) {
                                case 0x17:
                                case 0x37:
                                    sb.Append("lwz");
                                    break;
                                case 0x117:
                                case 0x137:
                                    sb.Append("lhz");
                                    break;
                                case 0x197:
                                    sb.Append("sth");
                                    break;
                            }
                            D = (int)((instruction >> 0x15) & 0x1f);
                            A = (int)((instruction >> 0x10) & 0x1f);
                            B = (int)((instruction >> 0xb) & 0x1f);
                            if(e == 0x37)
                                sb.Append("u");
                            sb.Append($"x r{D}, r{A}, r{B}");
                            return sb.ToString();
                        case 0x20:
                            D = (int)((instruction >> 0x17) & 0x7);
                            L = (int)((instruction >> 0x15) & 0x1);
                            A = (int)((instruction >> 0x10) & 0x1f);
                            B = (int)((instruction >> 0xb) & 0x1f);
                            if(L == 0)
                                sb.Append("cmplw");
                            else
                                sb.Append("cmpld");

                            if(D > 0)
                                sb.Append($" cr{D},");
                            sb.Append($" r{A}, r{B}");
                            return sb.ToString();
                        case 0x7c:
                        case 0x19c:
                        case 0x1bc:
                            S = (int)((instruction >> 0x15) & 0x1f);
                            A = (int)((instruction >> 0x10) & 0x1f);
                            B = (int)((instruction >> 0xb) & 0x1f);
                            Rc = (int)(instruction & 0x1);

                            if(S == B && e == 0x7c)
                                sb.Append("not");
                            else if(S == B && e == 0x1bc)
                                sb.Append("mr");
                            else if(e == 0x7c)
                                sb.Append("nor");
                            else if(e == 0x1bc)
                                sb.Append("or");
                            else if(e == 0x19c)
                                sb.Append("orc");

                            if(Rc == 1)
                                sb.Append(".");

                            sb.Append($" r{A}, r{S}");
                            if(S != B)
                                sb.Append($", r{B}");
                            return sb.ToString();
                        case 0x153:
                        case 0x1d3:
                            D = (int)((instruction >> 0x15) & 0x1f);
                            int spr1 = (int)((instruction >> 0x10) & 0x1f),
                                spr2 = (int)((instruction >> 0xb) & 0x1f);
                            SPR = (spr2 << 0x5) + spr1;
                            if(e == 0x153)
                                sb.Append("mf");
                            else if(e == 0x1d3)
                                sb.Append("mt");

                            if(SPR == 1)
                                return sb.Append($"xer r{D}").ToString();
                            if(SPR == 8)
                                return sb.Append($"lr r{D}").ToString();
                            if(SPR == 9)
                                return sb.Append($"ctr r{D}").ToString();

                            if(e == 0x153 && SPREncodingToName.ContainsKey(SPR))
                                sb.Append($"spr r{D}, {SPREncodingToName[SPR]}");
                            else if(e == 0x153)
                                sb.Append($"spr r{D}, SPR({SPR})");
                            else if(e == 0x1d3 && SPREncodingToName.ContainsKey(SPR))
                                sb.Append($"spr {SPREncodingToName[SPR]}, r{D}");
                            else if(e == 0x1d3)
                                sb.Append($"spr SPR({SPR}), r{D}");
                            return sb.ToString();
                    }
                    d = (int)((instruction >> 1) & 0x1ff);
                    switch(d) {
                        case 0x8:
                        case 0xa:
                        case 0x28:
                        case 0x88:
                        case 0x8a:
                        case 0x10a:
                            if(d == 0x8 || d == 0x28 || d == 0x88)
                                sb.Append("subf");
                            else if(d == 0xa || d == 0x8a || d == 0x10a)
                                sb.Append("add");
                            D = (int)((instruction >> 0x15) & 0x1f);
                            A = (int)((instruction >> 0x10) & 0x1f);
                            B = (int)((instruction >> 0xb) & 0x1f);
                            OE = (int)((instruction >> 0xa) & 0x1);
                            Rc = (int)(instruction & 0x1);
                            // carrying
                            if(d == 0x8 || d == 0xa)
                                sb.Append("c");
                            // extended
                            else if(d == 0x88 || d == 0x8a)
                                sb.Append("e");

                            if(OE == 1)
                                sb.Append("o");
                            if(Rc == 1)
                                sb.Append(".");
                            sb.Append($" r{D}, r{A}, r{B}");
                            return sb.ToString();
                    }
                    break;
                case 0x20: case 0x21:
                case 0x22: case 0x23:
                case 0x24: case 0x25:
                case 0x26: case 0x27:
                case 0x28: case 0x29:
                case 0x2a: case 0x2b:
                case 0x2c: case 0x2d:
                    switch(c) {
                        case 0x20:
                        case 0x21:
                            sb.Append("lwz");
                            break;
                        case 0x22:
                        case 0x23:
                            sb.Append("lbz");
                            break;
                        case 0x24:
                        case 0x25:
                            sb.Append("stw");
                            break;
                        case 0x26:
                        case 0x27:
                            sb.Append("stb");
                            break;
                        case 0x28:
                        case 0x29:
                            sb.Append("lhz");
                            break;
                        case 0x2a:
                        case 0x2b:
                            sb.Append("lha");
                            break;
                        case 0x2c:
                        case 0x2d:
                            sb.Append("sth");
                            break;
                    }
                    D = (int)((instruction >> 0x15) & 0x1f);
                    A = (int)((instruction >> 0x10) & 0x1f);
                    d = (short)(instruction & 0xffff);
                    if(c % 2 == 1) 
                        sb.Append("u");
                    sb.Append($" r{D}, {HexUtils.IntToSignedHex(d)}(r{A})");
                    return sb.ToString();
                case 0x30:
                case 0x31:
                case 0x32:
                case 0x33:
                case 0x34:
                case 0x35:
                case 0x36:
                case 0x37:
                    switch(c) {
                        case 0x30:
                        case 0x31:
                            sb.Append("lfs");
                            break;
                        case 0x32:
                        case 0x33:
                            sb.Append("lfd");
                            break;
                        case 0x34:
                        case 0x35:
                            sb.Append("stfs");
                            break;
                        case 0x36:
                        case 0x37:
                            sb.Append("stfd");
                            break;
                    }
                    D = (int)((instruction >> 0x15) & 0x1f);
                    A = (int)((instruction >> 0x10) & 0x1f);
                    d = (short)(instruction & 0xffff);

                    if(c % 2 == 1)
                        sb.Append("u");

                    sb.Append($" f{D}, {HexUtils.IntToSignedHex(d)}(r{A})");
                    return sb.ToString();
                case 0x3b:
                case 0x3f:
                    e = (int)((instruction >> 0x1) & 0x3ff);
                    switch(e) {
                        case 0xe:
                        case 0xf:
                            sb.Append("fctiw");
                            D = (int)((instruction >> 0x15) & 0x1f);
                            B = (int)((instruction >> 0xb) & 0x1f);
                            Rc = (int)(instruction & 0x1);
                            if(e == 0xf)
                                sb.Append("z");
                            if(Rc == 1)
                                sb.Append(".");
                            sb.Append($" f{D}, f{B}");
                            return sb.ToString();
                        case 0x20:
                            D = (int)((instruction >> 0x17) & 0x7);
                            A = (int)((instruction >> 0x10) & 0x1f);
                            B = (int)((instruction >> 0xb) & 0x1f);
                            return $"fcmpo cr{D}, f{A}, f{B}";
                        case 0x48:
                            sb.Append("fmr");
                            D = (int)((instruction >> 0x15) & 0x1f);
                            B = (int)((instruction >> 0xb) & 0x1f);
                            Rc = (int)(instruction & 0x1);
                            if(Rc == 1)
                                sb.Append(".");
                            sb.Append($" f{D}, f{B}");
                            return sb.ToString();
                    }
                    d = (int)((instruction >> 0x1) & 0x1f);
                    switch(d) {
                        case 0x12:
                        case 0x14:
                        case 0x15:
                            D = (int)((instruction >> 0x15) & 0x1f);
                            A = (int)((instruction >> 0x10) & 0x1f);
                            B = (int)((instruction >> 0xb) & 0x1f);
                            Rc = (int)(instruction & 0x1);
                            if(d == 0x12)
                                sb.Append("fdiv");
                            else if(d == 0x14)
                                sb.Append("fsub");
                            else if(d == 0x15)
                                sb.Append("fadd");

                            if(c == 0x3b)
                                sb.Append("s");
                            if(Rc == 1)
                                sb.Append(".");
                            sb.Append($" f{D}, f{A}, f{B}");
                            return sb.ToString();
                        case 0x19:
                            sb.Append("fmul");
                            D = (int)((instruction >> 0x15) & 0x1f);
                            A = (int)((instruction >> 0x10) & 0x1f);
                            C = (int)((instruction >> 0x6) & 0x1f);
                            Rc = (int)(instruction & 0x1);

                            if(c == 0x3b)
                                sb.Append("s");
                            if(Rc == 1)
                                sb.Append(".");
                            sb.Append($" f{D}, f{A}, f{C}");
                            return sb.ToString();
                    }
                    break;
            }
            return HexUtils.IntToHex(instruction);
        }

        private static string Binary(int i, int len) {
            string s = Convert.ToString(i, 2);
            // pad to min length = len
            s = s.PadLeft(len, '0');
            // truncate to max length = len
            s = s.Substring(s.Length - len);
            return s;
        }
    }
}
