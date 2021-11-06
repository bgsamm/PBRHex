using System;
using System.Collections.Generic;
using System.IO;
using PBRTool.Utils;

namespace PBRTool.Files
{
    public static class DOL
    {
        public static Dictionary<uint, string> Comments;
        private static int Size => Main.Size;

        // !!!THIS IS NOT THE SAME ORDER AS IN THE DOL HEADER!!!
        /// <summary>
        /// Tuples are of the form (offset, size, address).
        /// </summary>
        private static (int, int, uint)[] Sections;
        private static FileBuffer Main;

        public static void Initialize() {
            Main = new FileBuffer($@"{Program.ISODir}\DATA\sys\main.dol")
            {
                WorkingDir = FileUtils.CreateWorkspace($@"{Program.ISODir}\DATA\sys\main.dol")
            };
            Comments = new Dictionary<uint, string>();
            string path = $@"{Program.UserDir}\comments.txt";
            if(File.Exists(path)) {
                var infile = new StreamReader(path);
                while(!infile.EndOfStream) {
                    string comment = infile.ReadLine();
                    var args = comment.Split(new[] { ':' }, 2);
                    Comments[Convert.ToUInt32(args[0], 16)] = args[1];
                }
                infile.Close();
            }

            Sections = new (int, int, uint)[18];
            for(int i = 0; i < Sections.Length; i++) {
                int offset = Main.ReadInt(i * 4);
                if(offset > 0) {
                    uint memLoc = (uint)Main.ReadInt(0x48 + i * 4);
                    int size = Main.ReadInt(0x90 + i * 4);
                    Sections[i] = (offset, size, memLoc);
                }
            }
        }

        public static bool IsAddrInBounds(uint memAddr) {
            try {
                MemAddrToFileOffset(memAddr);
                return true;
            } catch {
                return false;
            }
        }

        public static bool SectionHasData(int index) {
            return Sections[index].Item1 > 0;
        }

        public static int GetSectionSize(int index) {
            return Sections[index].Item2;
        }

        public static uint GetSectionMemAddr(int index) {
            return Sections[index].Item3;
        }

        public static uint GetInstruction(uint memAddr) {
            int fileOffset = MemAddrToFileOffset(memAddr);
            return (uint)Main.ReadInt(fileOffset);
        }

        public static void InsertInstruction(uint memAddr, uint instruction) {
            int fileOffset = MemAddrToFileOffset(memAddr);
            InsertRange(fileOffset, HexUtils.IntToBytes(instruction));
        }

        public static void DeleteInstruction(uint memAddr) {
            int fileOffset = MemAddrToFileOffset(memAddr);
            DeleteRange(fileOffset, 4);
        }

        public static void WriteInstruction(uint memAddr, uint instruction) {
            int fileOffset = MemAddrToFileOffset(memAddr);
            if(fileOffset >= Size)
                InsertInstruction(memAddr, instruction);
            else
                Main.WriteInt(fileOffset, instruction);
        }

        private static int MemAddrToFileOffset(uint memAddr) {
            if(memAddr % 4 > 0)
                throw new ArgumentException("Instruction addresses must be multiples of 4.");
            foreach(var section in Sections) {
                if(memAddr >= section.Item3 && memAddr < section.Item3 + section.Item2)
                    return (int)((memAddr - section.Item3) + section.Item1);
            }
            throw new ArgumentOutOfRangeException();
        }

        private static void InsertRange(int fileOffset, byte[] bytes) {
            Main.InsertRange(fileOffset, bytes);

            var section = (0, 0, 0u);
            for(int n = 0; n < Sections.Length; n++) {
                section = Sections[n];
                if(section.Item1 > 0 && fileOffset >= section.Item1 && fileOffset <= section.Item1 + section.Item2) {
                    Sections[n].Item2 += bytes.Length;
                    section.Item2 += bytes.Length;
                    break;
                }
            }

            int BD, LI, c, offset;
            uint insertionAddress = section.Item3 + (uint)(fileOffset - section.Item1),
                op, address, target_addr;
            for(int i = section.Item2 - 4; i >= 0; i -= 4) {
                address = section.Item3 + (uint)i;
                if(Comments.ContainsKey(address) && address >= insertionAddress) {
                    var temp = Comments[address];
                    Comments.Remove(address);
                    Comments[address + 4] = temp;
                }

                if(section.Item1 + i + 4 >= Main.Size)
                    break;

                op = (uint)Main.ReadInt(section.Item1 + i);
                c = (int)(op >> 0x1a);
                if(c == 0x10) {
                    BD = (int)((op >> 2) & 0x3fff);
                    target_addr = (uint)((short)(BD << 2) + address);
                    if(address < insertionAddress && target_addr >= insertionAddress)
                        op += 0x4;
                    else if(address > insertionAddress && target_addr < insertionAddress)
                        op -= 0x4;
                    Main.WriteInt(section.Item1 + i, op);
                    continue;
                }
                if(c == 0x12) {
                    LI = (int)((op >> 2) & 0xffffff);
                    offset = (LI >> 23 == 1) ? (int)((LI << 2) | 0xfc000000) : LI << 2;
                    target_addr = (uint)(address + offset);
                    if(address < insertionAddress && target_addr >= insertionAddress)
                        op += 0x4;
                    else if(address > insertionAddress && target_addr < insertionAddress)
                        op -= 0x4;
                    Main.WriteInt(section.Item1 + i, op);
                    continue;
                }
            }
        }

        // I feel like this is uber broken, I'll need to look closer at it at some point
        private static byte[] DeleteRange(int fileOffset, int size) {
            var oldBytes = Main.DeleteRange(fileOffset, size);

            // update section header
            var section = (0, 0, 0u);
            for(int n = 0; n < Sections.Length; n++) {
                section = Sections[n];
                if(SectionHasData(n) && fileOffset >= section.Item1 && fileOffset < section.Item1 + section.Item2) {
                    Sections[n].Item2 -= size;
                    section.Item2 -= size;
                    break;
                }
            }

            // update branch instructions
            int BD, LI, c, offset;
            uint deletionAddress = section.Item3 + (uint)(fileOffset - section.Item1),
                op, address, target_addr;
            for(int i = 0; i < section.Item2; i += 4) {
                address = section.Item3 + (uint)i;
                if(Comments.ContainsKey(address) && address >= deletionAddress) {
                    var temp = Comments[address];
                    Comments.Remove(address);
                    if(address > deletionAddress)
                        Comments[address - 4] = temp;
                }
                if(section.Item1 + i >= Main.Size)
                    break;

                op = (uint)Main.ReadInt(section.Item1 + i);
                c = (int)(op >> 0x1a);
                if(c == 0x10) {
                    BD = (int)((op >> 2) & 0x3fff);
                    target_addr = (uint)((short)(BD << 2) + address);
                    if(address < deletionAddress && target_addr > deletionAddress)
                        op -= 0x4;
                    else if(address >= deletionAddress && target_addr < deletionAddress)
                        op += 0x4;
                    Main.WriteInt(section.Item1 + i, op);
                    continue;
                }
                if(c == 0x12) {
                    LI = (int)((op >> 2) & 0xffffff);
                    offset = (LI >> 23 == 1) ? (int)((LI << 2) | 0xfc000000) : LI << 2;
                    target_addr = (uint)(address + offset);
                    if(address < deletionAddress && target_addr > deletionAddress)
                        op -= 0x4;
                    else if(address >= deletionAddress && target_addr < deletionAddress)
                        op += 0x4;
                    Main.WriteInt(section.Item1 + i, op);
                    continue;
                }
            }
            return oldBytes;
        }

        /// <param name="address">The in-memory address for the section to be loaded.</param>
        /// <returns>The newly added section's index.</returns>
        public static int AddSection(uint address) {
            for(int i = 0; i < 7; i++) {
                if(!SectionHasData(i)) {
                    // offset
                    Main.WriteInt(i * 4, Main.Size);
                    // memory address
                    Main.WriteInt(0x48 + i * 4, address);
                    // size (init to zero)
                    Main.WriteInt(0x90 + i * 4, 0);
                    Sections[i] = (Main.Size, 0, address);
                    return i;
                }
            }
            throw new Exception("No empty section available.");
        }

        public static void Write() {
            // update section info
            for(int i = 0; i < Sections.Length; i++) {
                Main.WriteInt(i * 4, Sections[i].Item1);
                Main.WriteInt(0x48 + i * 4, Sections[i].Item3);
                Main.WriteInt(0x90 + i * 4, Sections[i].Item2);
            }
            FileUtils.WriteToISO(Main);
            // save comments
            string path = $@"{Program.UserDir}\comments.txt";
            if(File.Exists(path)) 
                File.Delete(path);
            var outfile = new StreamWriter(path);
            foreach(uint address in Comments.Keys) {
                outfile.WriteLine($"{address:X8}:{Comments[address]}");
            }
            outfile.Close();
        }
    }
}
