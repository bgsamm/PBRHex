using System;
using System.Collections.Generic;
using System.IO;
using PBRHex.Utils;

namespace PBRHex.Files
{
    public static class DOL
    {
        public static Dictionary<uint, string> Comments;
        private static int Size => Main.Size;

        private static Section[] Sections;
        private static FileBuffer Main;

        public static void Initialize() {
            Main = new FileBuffer($@"{Program.ISODir}\sys\main.dol");
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

            Sections = new Section[18];
            for(int i = 0; i < Sections.Length; i++) {
                int offset = Main.ReadInt(i * 4);
                if(offset > 0) {
                    uint memLoc = (uint)Main.ReadInt(0x48 + i * 4);
                    int size = Main.ReadInt(0x90 + i * 4);
                    Sections[i] = new Section(offset, size, memLoc);
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
            return Sections[index].Offset > 0;
        }

        public static int GetSectionSize(int index) {
            return Sections[index].Size;
        }

        public static uint GetSectionMemAddr(int index) {
            return Sections[index].Address;
        }

        public static uint GetInstruction(uint memAddr) {
            int fileOffset = MemAddrToFileOffset(memAddr);
            return (uint)Main.ReadInt(fileOffset);
        }

        public static void InsertInstruction(uint memAddr, uint instruction) {
            int index = GetSectionIndex(memAddr);
            var section = Sections[index];
            InsertRange(index, (int)(memAddr - section.Address), HexUtils.IntToBytes(instruction));
        }

        public static void DeleteInstruction(uint memAddr) {
            int index = GetSectionIndex(memAddr);
            var section = Sections[index];
            DeleteRange(index, (int)(memAddr - section.Address), 4);
        }

        public static void WriteInstruction(uint memAddr, uint instruction) {
            int fileOffset = MemAddrToFileOffset(memAddr);
            if(fileOffset >= Size)
                InsertInstruction(memAddr, instruction);
            else
                Main.WriteInt(fileOffset, instruction);
        }

        public static void OverwriteSection(int index, byte[] bytes) {
            var section = Sections[index];
            if(section.Size > 0)
                DeleteRange(index, 0, section.Size);
            InsertRange(index, 0, bytes);
        }

        public static int GetSectionIndex(uint memAddr) {
            if(memAddr % 4 > 0)
                throw new ArgumentException("Instruction addresses must be multiples of 4.");
            for(int i = 0; i < Sections.Length; i++) {
                var section = Sections[i];
                if(memAddr >= section.Address && memAddr < section.Address + section.Size)
                    return i;
            }
            throw new ArgumentOutOfRangeException("Address out of bounds");
        }

        private static int MemAddrToFileOffset(uint memAddr) {
            int index = GetSectionIndex(memAddr);
            var section = Sections[index];
            return (int)(memAddr - section.Address) + section.Offset;
        }

        private static void InsertRange(int sectionIndex, int sectionOffset, byte[] bytes) {
            var section = Sections[sectionIndex];
            if(sectionOffset > section.Size)
                throw new ArgumentOutOfRangeException();
            int fileOffset = section.Offset + sectionOffset;
            Main.InsertRange(fileOffset, bytes);

            int size = bytes.Length;
            // update section headers
            section.Size += size;
            for(int i = 0; i < Sections.Length; i++) {
                if(Sections[i].Offset > section.Offset)
                    Sections[i].Offset += size;
            }
            Sections[sectionIndex] = section;

            int BD, LI, c, offset;
            uint insertionAddress = section.Address + (uint)(fileOffset - section.Offset),
                op, address, target_addr;
            // iterate over instructions starting at the end of the section
            for(int i = section.Size - 4; i >= 0; i -= 4) {
                address = section.Address + (uint)i;
                // shift comment addresses forward
                if(Comments.ContainsKey(address) && address >= insertionAddress) {
                    var temp = Comments[address];
                    Comments.Remove(address);
                    Comments[address + (uint)size] = temp;
                }
                // I don't recall why I need to do this
                if(section.Offset + i + 4 >= Main.Size)
                    break;

                op = (uint)Main.ReadInt(section.Offset + i);
                c = (int)(op >> 0x1a);
                // update branches
                if(c == 0x10 || c == 0x12) {
                    // conditional branch
                    if(c == 0x10) {
                        BD = (int)((op >> 2) & 0x3fff);
                        target_addr = (uint)((short)(BD << 2) + address);
                    } 
                    // unconditional branch
                    else {
                        LI = (int)((op >> 2) & 0xffffff);
                        offset = (LI >> 23 == 1) ? (int)((LI << 2) | 0xfc000000) : LI << 2;
                        target_addr = (uint)(address + offset);
                    }
                    // if instruction is before insertion and target is after,
                    // increase target offset in pos. direction
                    if(address < insertionAddress && target_addr >= insertionAddress)
                        op += (uint)size;
                    // if instruction is after insertion and target is before,
                    // increase target offset in neg. direction
                    else if(address > insertionAddress && target_addr < insertionAddress)
                        op -= (uint)size;
                    Main.WriteInt(section.Offset + i, op);
                    continue;
                }
            }
        }

        /// <param name="fileOffset">The file offset to delete data from</param>
        /// <param name="size">The size of the range to delete</param>
        /// <returns>The deleted bytes</returns>
        private static byte[] DeleteRange(int sectionIndex, int sectionOffset, int size) {
            var section = Sections[sectionIndex];
            if(sectionOffset >= section.Size)
                throw new ArgumentOutOfRangeException();
            int fileOffset = section.Offset + sectionOffset;
            var oldBytes = Main.DeleteRange(fileOffset, size);

            // update section headers
            section.Size -= size;
            for(int i = 0; i < Sections.Length; i++) {
                if(Sections[i].Offset > section.Offset)
                    Sections[i].Offset -= size;
            }
            Sections[sectionIndex] = section;

            // update branch instructions
            int BD, LI, c, offset;
            uint deletionAddress = section.Address + (uint)(fileOffset - section.Offset),
                op, address, target_addr;
            // iterate over instructions starting at the beginning of the section
            for(int i = 0; i < section.Size; i += 4) {
                address = section.Address + (uint)i;
                // remove comments in range and shift comments in front back
                if(Comments.ContainsKey(address) && address >= deletionAddress) {
                    var temp = Comments[address];
                    Comments.Remove(address);
                    if(address > deletionAddress)
                        Comments[address - (uint)size] = temp;
                }
                // again, I don't recall why I need to do this
                if(section.Offset + i >= Main.Size)
                    break;

                op = (uint)Main.ReadInt(section.Offset + i);
                c = (int)(op >> 0x1a);
                // update branches
                if(c == 0x10 || c == 0x12) {
                    // conditional branch
                    if(c == 0x10) {
                        BD = (int)((op >> 2) & 0x3fff);
                        target_addr = (uint)((short)(BD << 2) + address);
                    }
                    // unconditional branch
                    else {
                        LI = (int)((op >> 2) & 0xffffff);
                        offset = (LI >> 23 == 1) ? (int)((LI << 2) | 0xfc000000) : LI << 2;
                        target_addr = (uint)(address + offset);
                    }
                    // if instruction is before deletion and target is after,
                    // decrease target offset in pos. direction
                    if(address < deletionAddress && target_addr > deletionAddress)
                        op -= (uint)size;
                    // if instruction is after deletion and target is before,
                    // decrease target offset in neg. direction
                    else if(address >= deletionAddress && target_addr < deletionAddress)
                        op += (uint)size;
                    Main.WriteInt(section.Offset + i, op);
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
                    Sections[i] = new Section(Main.Size, 0, address);
                    return i;
                }
            }
            throw new Exception("No empty section available.");
        }

        public static void Write() {
            // update section info
            for(int i = 0; i < Sections.Length; i++) {
                Main.WriteInt(i * 4, Sections[i].Offset);
                Main.WriteInt(0x48 + i * 4, Sections[i].Address);
                Main.WriteInt(0x90 + i * 4, Sections[i].Size);
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

    struct Section
    {
        public int Offset;
        public int Size;
        public uint Address;

        public Section(int offset, int size, uint addr) {
            Offset = offset;
            Size = size;
            Address = addr;
        }
    }
}
