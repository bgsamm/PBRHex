using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using PBRHex.Files;
using PBRHex.Utils;

namespace PBRHex.Tables
{
    public static class FSYSTable
    {
        private static int NumFiles => GSfsys.ReadInt(0x8);
        private static int HeadersAddr => GSfsys.ReadInt(0x10);
        private static int FileNamesAddr => GSfsys.ReadInt(0x14);

        private static Dictionary<int, FSYS> LoadedFiles;
        private static Dictionary<string, int> NameToID;
        private static Dictionary<int, string> IDtoName;
        private static FileBuffer GSfsys;
        private static Thread Initializer;
        private static readonly object TableLock = new object();

        public static void Initialize() {
            var initStart = new ManualResetEvent(false);
            Initializer = new Thread(() =>
            {
                lock (TableLock) {
                    initStart.Set();
                    string tocPath = $@"{Program.ISODir}\files\GSfsys.toc";
                    GSfsys = new FileBuffer(tocPath);
                    LoadTableOfContents();
                    LoadedFiles = new Dictionary<int, FSYS>();
                    // pre-load common.fsys
                    _ = GetFile("common");
                }
            });
            Initializer.Start();
            initStart.WaitOne();
        }

        private static void LoadTableOfContents() {
            NameToID = new Dictionary<string, int>();
            IDtoName = new Dictionary<int, string>();

            for (int i = 0; i < NumFiles; i++) {
                int offset = HeadersAddr + 0x10 * i;
                int id = GSfsys.ReadInt(offset),
                    nameAddr = GSfsys.ReadInt(offset + 4);

                string name = GSfsys.ReadString(nameAddr);
                NameToID[name] = id;
                IDtoName[id] = name;
            }
        }

        public static string MakePath(string name) {
            if (!name.EndsWith(".fsys"))
                name += ".fsys";
            string path = $@"{Program.ISODir}\files\{name}";
            return path;
        }

        public static bool ContainsFile(string name) {
            name = Path.GetFileNameWithoutExtension(name);
            return NameToID.ContainsKey(name);
        }

        public static FSYS GetFile(string name) {
            lock (TableLock) {
                name = Path.GetFileNameWithoutExtension(name);
                int id = NameToID[name];
                return GetFile(id);
            }
        }

        public static FSYS GetFile(int id) {
            lock (TableLock) {
                string name = IDtoName[id];
                if (!LoadedFiles.ContainsKey(id))
                    LoadedFiles[id] = new FSYS(MakePath(name)) { ID = id };
                return LoadedFiles[id];
            }
        }

        /// <returns>The file ID of the newly added entry.</returns>
        public static int AddFile(string name) {
            lock (TableLock) {
                name = Path.GetFileNameWithoutExtension(name);
                // Insert new name, maintaining alphabetical order
                int nameAddr = 0,
                    nextNameAddr = FileNamesAddr;
                for (int i = 0; i < NumFiles; i++) {
                    string nextName = GSfsys.ReadString(nextNameAddr);
                    int comparison = name.CompareTo(nextName);
                    if (comparison == 0) {
                        throw new ArgumentException("A file already exists with that name.");
                    } else if (comparison < 0) {
                        nameAddr = nextNameAddr;
                        break;
                    }
                    nextNameAddr += nextName.Length + 1;
                }
                GSfsys.InsertRange(nameAddr, HexUtils.AsciiToBytes(name, true));
                // Re-align id list
                int idListAddr = HeadersAddr + name.Length + 1,
                    rowStart = idListAddr / 0x10 * 0x10;
                if (Array.Exists(GSfsys.GetRange(rowStart - 1, idListAddr - rowStart + 1), x => x != 0)) {
                    GSfsys.InsertRange(idListAddr, 0x10 - idListAddr + rowStart);
                    idListAddr = rowStart + 0x10;
                } else {
                    GSfsys.DeleteRange(rowStart, idListAddr - rowStart);
                    idListAddr = rowStart;
                }
                // Update name pointers
                for (int i = 0; i < NumFiles; i++) {
                    int offset = idListAddr + i * 0x10,
                        oldNameAddr = GSfsys.ReadInt(offset + 4);
                    if (oldNameAddr >= nameAddr)
                        GSfsys.WriteInt(offset + 4, oldNameAddr + name.Length + 1);
                }
                // Add new entry at the end of the file
                GSfsys.AddRange(0x10);
                int address = idListAddr + 0x10 * NumFiles,
                    id = GenerateFileID();
                GSfsys.WriteInt(address, id);
                GSfsys.WriteInt(address + 4, nameAddr);
                // Update toc header count & pointers
                GSfsys.WriteInt(0x8, NumFiles + 1);
                GSfsys.WriteInt(0x10, idListAddr);
                FileUtils.WriteToISO(GSfsys);
                // Add to file maps
                NameToID[name] = id;
                IDtoName[id] = name;
                return id;
            }
        }

        public static int RemoveFile(string name) {
            lock (TableLock) {
                if (!ContainsFile(name))
                    throw new ArgumentException("No file exists with that name.");
                name = Path.GetFileNameWithoutExtension(name);
                // Remove name from file list
                int nameAddr = 0,
                    nextNameAddr = FileNamesAddr;
                for (int i = 0; i < NumFiles; i++) {
                    string nextName = GSfsys.ReadString(nextNameAddr);
                    int comparison = name.CompareTo(nextName);
                    if (comparison == 0) {
                        nameAddr = nextNameAddr;
                        break;
                    }
                    nextNameAddr += nextName.Length + 1;
                }
                GSfsys.DeleteRange(nameAddr, name.Length + 1);
                // Re-align id list
                int headersAddr = HeadersAddr - name.Length - 1,
                    rowStart = headersAddr / 0x10 * 0x10;
                if (Array.Exists(GSfsys.GetRange(rowStart - 1, headersAddr - rowStart + 1), x => x != 0)) {
                    GSfsys.InsertRange(headersAddr, 0x10 - headersAddr + rowStart);
                    headersAddr = rowStart + 0x10;
                } else {
                    GSfsys.DeleteRange(rowStart, headersAddr - rowStart);
                    headersAddr = rowStart;
                }
                // Update name pointers
                for (int i = 0; i < NumFiles; i++) {
                    int offset = headersAddr + i * 0x10,
                        oldNameAddr = GSfsys.ReadInt(offset + 4);
                    if (oldNameAddr >= nameAddr)
                        GSfsys.WriteInt(offset + 4, oldNameAddr - name.Length - 1);
                }
                // Remove entry
                int id = NameToID[name],
                    headerAddr = -1;
                for (int i = 0; i < NumFiles; i++) {
                    headerAddr = HeadersAddr + 0x10 * i;
                    if (GSfsys.ReadInt(headerAddr) == id)
                        break;
                }
                GSfsys.DeleteRange(headerAddr, 0x10);
                // Update toc header count & pointers
                GSfsys.WriteInt(0x8, NumFiles - 1);
                GSfsys.WriteInt(0x10, headersAddr);
                FileUtils.WriteToISO(GSfsys);
                // Remove from file maps
                NameToID.Remove(name);
                IDtoName.Remove(id);
                return id;
            }
        }

        private static int GenerateFileID() {
            var rand = new Random();
            int id;
            do {
                id = rand.Next(1, 0xffff);
            } while (IDtoName.ContainsKey(id));
            return id;
        }

        public static void RenameFile(string oldName, string newName) {
            lock (TableLock) {
                if (!newName.EndsWith(".fsys"))
                    newName += ".fsys";
                FileUtils.RenameFile(MakePath(oldName), newName);
                oldName = Path.GetFileNameWithoutExtension(oldName);
                newName = Path.GetFileNameWithoutExtension(newName);
                int id = NameToID[oldName],
                    nameAddr = -1;
                for (int i = 0; i < NumFiles; i++) {
                    int offset = HeadersAddr + i * 0x10;
                    if (GSfsys.ReadInt(offset) == id) {
                        nameAddr = GSfsys.ReadInt(offset + 4);
                        break;
                    }
                }
                int delta = newName.Length - oldName.Length;
                GSfsys.DeleteRange(nameAddr, oldName.Length);
                GSfsys.InsertRange(nameAddr, HexUtils.AsciiToBytes(newName));
                for (int i = 0; i < NumFiles; i++) {
                    int offset = HeadersAddr + i * 0x10,
                        oldAddr = GSfsys.ReadInt(offset + 4);
                    if (oldAddr > nameAddr)
                        GSfsys.WriteInt(offset + 4, oldAddr + delta);
                }
                int newStart = HeadersAddr + delta,
                    rowStart = newStart / 0x10 * 0x10;
                // alignment
                if (!Array.Exists(GSfsys.GetRange(rowStart - 1, newStart - rowStart + 1), b => b != 0)) {
                    GSfsys.DeleteRange(rowStart, newStart - rowStart);
                    GSfsys.WriteInt(0x10, rowStart);
                } else {
                    GSfsys.InsertRange(newStart, 0x10 - newStart + rowStart);
                    GSfsys.WriteInt(0x10, rowStart + 0x10);
                }
                FileUtils.WriteToISO(GSfsys);
                NameToID.Remove(oldName);
                NameToID[newName] = id;
                IDtoName[id] = newName;
            }
        }

        public static void WriteFile(string name) {
            lock (TableLock) {
                Program.NotifyWaiting();
                name = Path.GetFileNameWithoutExtension(name);
                int id = NameToID[name];
                if (!LoadedFiles.ContainsKey(id))
                    return;
                Console.WriteLine("writing " + name);
                var fsys = LoadedFiles[id];
                foreach (var file in fsys.Files) {
                    file.Save();
                }
                var temp = FileUtils.CompressFSYS(fsys);
                fsys.Overwrite(temp.GetBytes());
                FileUtils.WriteToISO(fsys);
                LoadedFiles.Remove(id);
                Program.NotifyDone();
            }
        }

        public static void CloseFile(string name) {
            lock (TableLock) {
                name = Path.GetFileNameWithoutExtension(name);
                int id = NameToID[name];
                if (!LoadedFiles.ContainsKey(id))
                    return;
                LoadedFiles.Remove(id);
            }
        }
    }
}
