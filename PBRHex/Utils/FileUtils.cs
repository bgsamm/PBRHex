using System;
using System.IO;
using System.Linq;
using System.Text;
using Force.Crc32;
using PBRHex.Files;
using PBRHex.Tables;

namespace PBRHex.Utils
{
    public static class FileUtils
    {
        //private static readonly object AccessLock = new object();

        public static void CreateDirectory(string path, bool overwrite) {
            if(!overwrite && Directory.Exists(path))
                return;
            if(overwrite)
                DeleteDirectory(path);
            Directory.CreateDirectory(path);
        }

        public static void DeleteDirectory(string path) {
            if(Directory.Exists(path))
                Directory.Delete(path, true);
        }

        public static void MoveContents(string inpath, string outpath, bool deleteSourceDir) {
            CreateDirectory(outpath, false);
            foreach(var path in Directory.EnumerateFileSystemEntries(inpath)) {
                Directory.Move(path, $@"{outpath}\{Path.GetFileName(path)}");
            }
            if(deleteSourceDir)
                DeleteDirectory(inpath);
        }

        public static FileBuffer CreateFile(string path, int size) {
            return CreateFile(path, new byte[size]);
        }

        public static FileBuffer CreateFile(string path, byte[] bytes) {
            File.WriteAllBytes(path, bytes);
            return new FileBuffer(path);
        }

        public static void DeleteFile(string path) {
            File.Delete(path);
        }

        public static void CopyFile(string inpath, string outpath) {
            if(inpath == outpath)
                return;
            File.Copy(inpath, outpath, true);
        }

        public static void MoveFile(string inpath, string outpath) {
            // File.Move will (from what I understand) fail if the destination path already exists
            DeleteFile(outpath);
            File.Move(inpath, outpath);
        }

        public static void RenameFile(string inpath, string name) {
            MoveFile(inpath, $@"{Path.GetDirectoryName(inpath)}\{name}");
        }

        public static string CreateWorkspace(string inpath) {
            string fname = Path.GetFileName(inpath),
                workspace = $@"{Program.TempDir}\{fname}";
            CreateDirectory(workspace, true);
            CopyFile(inpath, $@"{workspace}\{fname}");
            if(Path.GetExtension(inpath) == ".fsys") {
                CreateDirectory($@"{workspace}\files", true);
                CreateDirectory($@"{workspace}\lzss", true);
            }
            return workspace;
        }

        public static void RestoreFile(string path) {
            string backupPath = $@"{Program.BackupsDir}\{Path.GetFileName(path)}";
            MoveFile(backupPath, path);
        }

        public static void CreateBackup(FileBuffer file) {
            CopyFile(file.Path, $@"{Program.BackupsDir}\{file.Name}");
        }

        public static bool HasBackup(string name) {
            var paths = Directory.GetFiles(Program.BackupsDir);
            foreach(string p in paths) {
                if(Path.GetFileName(p) == name)
                    return true;
            }
            return false;
        }

        public static bool HasBackup(FileBuffer file) {
            return HasBackup(file.Name);
        }

        public static FileType TypeFromExtension(string ext) {
            if(ext.Length == 0)
                return FileType.NONE;
            return (FileType)Enum.Parse(typeof(FileType), ext.Substring(1).ToUpper());
        }

        public static string ExtensionFromType(FileType type) {
            if(type == FileType.NONE)
                return "";
            return $".{type.ToString().ToLower()}";
        }

        public static void WriteToISO(FileBuffer file) {
            if(!HasBackup(file))
                CreateBackup(file);
            file.Save();
            CopyFile(file.WorkingPath, file.Path);
        }

        public static void ReplaceLZSS(string name, int id, FileBuffer file) {
            FSYSTable.WriteFile(name);
            string fsysPath = FSYSTable.MakePath(name),
                workspace = CreateWorkspace(fsysPath),
                indir = $@"{workspace}\files",
                outdir = $@"{workspace}\lzss";
            CreateFile($@"{indir}\{file.Name}", file.GetBufferCopy());
            CommandUtils.CompressLZSSFiles(indir, outdir);
            var fsys = new FileBuffer(fsysPath) { WorkingDir = workspace };
            int count = fsys.ReadInt(0xc),
                lzssAddrList = fsys.ReadInt(fsys.ReadInt(0x18)),
                index = -1, lzssHeaderAddr = 0;
            for(int i = 0; i < count; i++) {
                int address = fsys.ReadInt(lzssAddrList + 4 * i);
                if(fsys.ReadInt(address) == id) {
                    lzssHeaderAddr = address;
                    index = i;
                    break;
                }
            }
            if(index == -1)
                // might not technically be the right exception but it is fitting
                throw new FileNotFoundException();
            byte[] lzssData = File.ReadAllBytes(Directory.GetFiles(outdir)[0]);
            int lzssDataAddr = fsys.ReadInt(lzssHeaderAddr + 4),
                newSize = (lzssData.Length + 0x1f) / 0x10 * 0x10,
                oldSize;
            if(index < count - 1) {
                int nextHeader = fsys.ReadInt(lzssAddrList + 4 * (index + 1)),
                    nextDataAddr = fsys.ReadInt(nextHeader + 4);
                oldSize = nextDataAddr - lzssDataAddr;
            }
            else {
                oldSize = (fsys.ReadInt(lzssHeaderAddr + 0x14) + 0xf) / 0x10 * 0x10;
            }
            fsys.WriteInt(lzssHeaderAddr + 8, file.Size);
            fsys.WriteInt(lzssHeaderAddr + 0x14, lzssData.Length + 0x10);
            // replace existing data
            fsys.DeleteRange(lzssDataAddr, oldSize);
            fsys.InsertRange(lzssDataAddr, newSize);
            fsys.WriteString(lzssDataAddr, "LZSS");
            fsys.WriteInt(lzssDataAddr + 4, file.Size);
            fsys.WriteInt(lzssDataAddr + 8, lzssData.Length + 0x10);
            uint crc32 = Crc32Algorithm.Compute(file.GetBufferCopy());
            fsys.WriteInt(lzssDataAddr + 0xc, crc32);
            fsys.SetRange(lzssDataAddr + 0x10, lzssData);
            // update existing pointers
            for(int i = index + 1; i < count; i++) {
                lzssHeaderAddr = fsys.ReadInt(lzssAddrList + 4 * i);
                int oldAddr = fsys.ReadInt(lzssHeaderAddr + 4);
                fsys.WriteInt(lzssHeaderAddr + 4, oldAddr + newSize - oldSize);
            }
            WriteToISO(fsys);
        }

        /// <summary>
        /// Adds a file to an existing FSYS archive in-place (i.e. without
        /// needing to decompress the entire archive first).
        /// </summary>
        /// <param name="name">The name of the FSYS archive to add the file to.</param>
        /// <param name="file">The file to be added to the archive.</param>
        /// <returns>The file ID of the new LZSS.</returns>
        public static int AddLZSS(string name, FileBuffer file) {
            FSYSTable.WriteFile(name);
            string fsysPath = FSYSTable.MakePath(name),
                workspace = CreateWorkspace(fsysPath),
                indir = $@"{workspace}\files",
                outdir = $@"{workspace}\lzss";
            CreateFile($@"{indir}\{file.Name}", file.GetBufferCopy());
            CommandUtils.CompressLZSSFiles(indir, outdir);
            var fsys = new FileBuffer(fsysPath) { WorkingDir = workspace };
            var lzss = File.ReadAllBytes(Directory.GetFiles(outdir)[0]);
            int count = fsys.ReadInt(0xc);
            // add row before file names if no room for new pointer
            int fnamesAddr = fsys.ReadInt(0x44),
                fnamesDelta = 0;
            if(count % 4 == 0) {
                fsys.InsertRange(fnamesAddr, 0x10);
                fsys.WriteInt(0x44, fnamesAddr + 0x10);
                fnamesAddr += 0x10;
                fnamesDelta = 0x10;
            }
            // add row before headers if not enough room for new file name
            int lzssAddrList = fsys.ReadInt(fsys.ReadInt(0x18)),
                firstHeaderAddr = fsys.ReadInt(lzssAddrList) + fnamesDelta,
                headersDelta = 0;
            if((count * 7) % 0x10 == 0 || (count * 7) % 0x10 > 9) {
                fsys.InsertRange(firstHeaderAddr, 0x10);
                firstHeaderAddr += 0x10;
                headersDelta = 0x10;
            }
            // add new file name
            int nameAddr = fnamesAddr + count * 7;
            fsys.WriteString(nameAddr, "(null)");
            // insert new lzss header
            int headerPtrAddr = lzssAddrList + count * 4,
                headerAddr = firstHeaderAddr + count * 0x70;
            fsys.WriteInt(headerPtrAddr, headerAddr);
            fsys.InsertRange(headerAddr, 0x70);
            // add row before lzss data if address no longer a multiple of 0x20
            int lzssDataStart = fsys.ReadInt(0x1c),
                delta = fnamesDelta + headersDelta,
                dataDelta = delta + 0x70;
            if(delta != 0x10) {
                // TODO: ends up accumulating a bunch of empty rows. If able, should actually DELETE range instead of inserting.
                fsys.InsertRange(lzssDataStart, 0x10);
                dataDelta += 0x10;
            }
            fsys.WriteInt(0x1c, lzssDataStart + dataDelta);
            fsys.WriteInt(0x48, lzssDataStart + dataDelta);
            // update header addresses + name and data pointers
            for(int i = 0; i < count; i++) {
                int offset = lzssAddrList + i * 4,
                    newHeaderAddr = fsys.ReadInt(offset) + delta,
                    newNameAddr = fsys.ReadInt(newHeaderAddr + 0x24) + fnamesDelta,
                    newDataAddr = fsys.ReadInt(newHeaderAddr + 0x4) + dataDelta;
                fsys.WriteInt(offset, newHeaderAddr);
                fsys.WriteInt(newHeaderAddr + 0x4, newDataAddr);
                fsys.WriteInt(newHeaderAddr + 0x24, newNameAddr);
            }
            // calc new data address
            int prevHeaderAddr = firstHeaderAddr + (count - 1) * 0x70,
                prevDataAddr = fsys.ReadInt(prevHeaderAddr + 4),
                prevDataSize = fsys.ReadInt(prevHeaderAddr + 0x14);
            int dataAddr = (prevDataAddr + prevDataSize + 0xf) / 0x10 * 0x10 + 0x10,
                size = (lzss.Length + 0xf) / 0x10 * 0x10 + 0x20;
            // fill in newly added header
            var ftype = TypeFromExtension(file.Extension);
            int id = GenerateFileID(fsys, ftype);
            fsys.WriteInt(headerAddr, id);
            fsys.WriteInt(headerAddr + 4, dataAddr);
            fsys.WriteInt(headerAddr + 8, file.Size);
            fsys.WriteInt(headerAddr + 0xc, 0x80000000);
            fsys.WriteInt(headerAddr + 0x14, lzss.Length);
            fsys.WriteInt(headerAddr + 0x20, (int)ftype);
            fsys.WriteInt(headerAddr + 0x24, nameAddr);
            // insert new lzss data
            fsys.InsertRange(dataAddr - 0x10, size);
            fsys.WriteString(dataAddr, "LZSS");
            fsys.WriteInt(dataAddr + 4, file.Size);
            fsys.WriteInt(dataAddr + 8, lzss.Length);
            uint crc32 = Crc32Algorithm.Compute(file.GetBufferCopy());
            fsys.WriteInt(dataAddr + 0xc, crc32);
            fsys.SetRange(dataAddr + 0x10, lzss);
            // update count
            fsys.WriteInt(0xc, count + 1);

            WriteToISO(fsys);
            return id;
        }

        private static int GenerateFileID(FileBuffer fsys, FileType type) {
            var rand = new Random();
            int count = fsys.ReadInt(0xc),
                lzssListAddr = fsys.ReadInt(fsys.ReadInt(0x18)),
                id = rand.Next(1, 0xffff);
            for(int i = 0; i < count; i++) {
                int offset = fsys.ReadInt(lzssListAddr + i * 4);
                if(id == fsys.ReadShort(offset)) {
                    id = rand.Next(1, 0xffff);
                    i = -1;
                }
            }
            return id * 0x10000 + (int)type * 0x200;
        }

        /// <returns>The path to the folder containing the extracted files.</returns>
        public static FSYS DecompressFSYS(string name) {
            string path = FSYSTable.MakePath(name),
                outdir = $@"{CreateWorkspace(path)}\files";
            CommandUtils.ExtractFSYS(path, outdir);

            var paths = Directory.GetFiles(outdir).ToList();
            // make sure list is alphabetical (= numerical order)
            paths.Sort();

            byte[] word = new byte[4];
            var file = File.OpenRead(path);
            var files = new FileBuffer[paths.Count];

            for(int i = 0; i < paths.Count; i++) {
                file.Seek(0x60 + 4 * i, SeekOrigin.Begin);
                file.Read(word, 0, 4);

                int header = HexUtils.BytesToInt(word);

                file.Seek(header, SeekOrigin.Begin);
                file.Read(word, 0, 4);
                int id = HexUtils.BytesToInt(word);
                file.Seek(0x1c, SeekOrigin.Current);
                file.Read(word, 0, 4);
                int ftype = HexUtils.BytesToInt(word);

                if(!Enum.IsDefined(typeof(FileType), ftype))
                    Console.WriteLine($"Unknown file type: {ftype}");
                string withExt = $"{paths[i]}{ExtensionFromType((FileType)ftype)}";
                File.Move(paths[i], withExt);
                paths[i] = withExt;
                if((FileType)ftype == FileType.GTX)
                    files[i] = new GTX(paths[i]);
                else
                    files[i] = new FileBuffer(paths[i]);
                files[i].ID = id;
                files[i].WorkingDir = outdir;
            }
            file.Close();
            return new FSYS(path, files)
            {
                WorkingDir = Path.GetDirectoryName(outdir),
                ExtractedDir = outdir
            };
        }

        /// <returns>A FileBuffer for the resulting .fsys file.</returns>
        public static FileBuffer CompressFSYS(FSYS fsys) {
            // recompress LZSS files
            string outdir = $@"{fsys.WorkingDir}\lzss";
            CommandUtils.CompressLZSSFiles(fsys.ExtractedDir, outdir);

            string[] paths = Directory.GetFiles(outdir);
            // would probably be a good idea NOT to hold all of them in memory at the same time...
            var lzssData = new byte[paths.Length][];
            for(int i = 0; i < paths.Length; i++) {
                lzssData[i] = File.ReadAllBytes(paths[i]);
            }

            string outpath = $@"{outdir}\{fsys.Name}";
            DeleteFile(outpath);
            var outfile = File.OpenWrite(outpath);

            // file names addr.
            uint offset1 = 0x60 + ((uint)fsys.FileCount * 4 + 0xf) / 0x10 * 0x10;

            // 0x0
            outfile.Write(Encoding.ASCII.GetBytes("FSYS"), 0, 4);
            // 0x4 (always 0x251?)
            outfile.Write(HexUtils.IntToBytes(0x251), 0, 4);
            // 0xC (file count)
            outfile.Seek(0xc, SeekOrigin.Begin);
            outfile.Write(HexUtils.IntToBytes(fsys.FileCount), 0, 4);
            // 0x10 (either 0x80000000 or 0x80000001)
            outfile.Write(HexUtils.IntToBytes(0x80000000), 0, 4);
            // 0x14 (always 0x3?)
            outfile.Write(HexUtils.IntToBytes(0x3), 0, 4);
            // 0x18 (pointer)
            outfile.Write(HexUtils.IntToBytes(0x40), 0, 4);
            // 0x40 (pointer to lzss address list)
            outfile.Seek(0x40, SeekOrigin.Begin);
            outfile.Write(HexUtils.IntToBytes(0x60), 0, 4);
            // 0x44 (pointer to file names)
            outfile.Write(HexUtils.IntToBytes(offset1), 0, 4);

            // file names
            outfile.Seek(offset1, SeekOrigin.Begin);
            for(int i = 0; i < fsys.FileCount; i++) {
                outfile.Write(Encoding.ASCII.GetBytes("(null)"), 0, 6);
                outfile.Seek(1, SeekOrigin.Current);
            }

            // lzss headers addr.
            uint offset2 = ((uint)outfile.Position + 0xf) / 0x10 * 0x10;
            // lzss data addr. (offset must be multiple of 0x20)
            uint offset3 = (offset2 + 0x70 * (uint)fsys.FileCount + 0x1f) / 0x20 * 0x20;

            // 0x1C
            outfile.Seek(0x1c, SeekOrigin.Begin);
            outfile.Write(HexUtils.IntToBytes(offset3), 0, 4);
            // 0x48
            outfile.Seek(0x48, SeekOrigin.Begin);
            outfile.Write(HexUtils.IntToBytes(offset3), 0, 4);

            uint dataOffset = offset3;
            for(int i = 0; i < fsys.FileCount; i++) {
                var file = fsys.Files[i];

                outfile.Seek(0x60 + i * 4, SeekOrigin.Begin);
                long lzssHeader = offset2 + 0x70 * i;
                outfile.Write(HexUtils.IntToBytes((uint)lzssHeader), 0, 4);

                outfile.Seek(lzssHeader, SeekOrigin.Begin);
                // file ID
                outfile.Write(HexUtils.IntToBytes(file.ID), 0, 4);

                // data offset
                outfile.Write(HexUtils.IntToBytes(dataOffset), 0, 4);
                // unpacked size
                outfile.Write(HexUtils.IntToBytes(file.Size), 0, 4);

                // I think this is always 0x80000000?
                outfile.Write(HexUtils.IntToBytes(0x80000000), 0, 4);

                // packed size
                outfile.Seek(4, SeekOrigin.Current);
                outfile.Write(HexUtils.IntToBytes(lzssData[i].Length + 0x10), 0, 4);

                // seems to only be set when 0x10 is 0x80000001
                outfile.Seek(4, SeekOrigin.Current);
                outfile.Write(HexUtils.IntToBytes(0), 0, 4);

                // file type
                outfile.Write(HexUtils.IntToBytes((int)TypeFromExtension(file.Extension)), 0, 4);

                // file name offset
                outfile.Write(HexUtils.IntToBytes(offset1 + 7 * (uint)i), 0, 4);

                outfile.Seek(dataOffset, SeekOrigin.Begin);
                outfile.Write(Encoding.ASCII.GetBytes("LZSS"), 0, 4);
                // unpacked size
                outfile.Write(HexUtils.IntToBytes(file.Size), 0, 4);
                // packed size
                outfile.Write(HexUtils.IntToBytes(lzssData[i].Length + 0x10), 0, 4);
                // CRC-32 checksum
                uint crc32 = Crc32Algorithm.Compute(file.GetBufferCopy());
                outfile.Write(HexUtils.IntToBytes(crc32), 0, 4);
                // data
                outfile.Write(lzssData[i], 0, lzssData[i].Length);

                dataOffset += ((uint)lzssData[i].Length + 0x1f) / 0x10 * 0x10;
            }

            outfile.Seek(dataOffset + 0xc, SeekOrigin.Begin);
            outfile.Write(Encoding.ASCII.GetBytes("FSYS"), 0, 4);
            outfile.Close();

            return new FileBuffer(outpath) { WorkingDir = outdir };
        }
    }
}
