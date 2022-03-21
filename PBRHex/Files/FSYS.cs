using System;
using System.Collections.Generic;
using PBRHex.Utils;

namespace PBRHex.Files
{
    public class FSYS : FileBuffer
    {
        public int FileCount => Files.Count;
        public readonly List<FileBuffer> Files;

        public FSYS(string path) : base(path) {
            Files = new List<FileBuffer>(FileUtils.DecompressFSYS(Path));
        }

        public FileBuffer GetFile(int id) {
            foreach (var file in Files) {
                if (file.ID == id)
                    return file;
            }
            return null;
        }

        public FileBuffer AddFile(string inpath) {
            string outpath = $@"{WorkingDir}\files\(null)_{Files.Count:x8}{System.IO.Path.GetExtension(inpath)}";
            FileUtils.CopyFile(inpath, outpath);
            var newFile = new FileBuffer(outpath, Name);
            newFile.ID = FileUtils.GenerateFileID(this, newFile);
            Files.Add(newFile);
            return newFile;
        }

        /// <summary>
        /// Copies the supplied file into the archive, returning the newly created file.
        /// </summary>
        public FileBuffer AddFile(FileBuffer file) {
            string path = $@"{WorkingDir}\files\(null)_{Files.Count:x8}";
            FileUtils.CreateFile(path, file.GetBytes());
            var newFile = new FileBuffer(path, Name);
            if (file.ID != 0)
                newFile.ID = file.ID;
            else
                newFile.ID = FileUtils.GenerateFileID(this, newFile);
            Files.Add(newFile);
            return newFile;
        }

        /// <returns>The newly added file</returns>
        public FileBuffer ReplaceFile(int id, string path) {
            for (int i = 0; i < Files.Count; i++) {
                if (Files[i].ID == id) {
                    var oldFile = Files[i];
                    FileUtils.DeleteFile(oldFile.Path);
                    string ext = System.IO.Path.GetExtension(path),
                        newPath = $@"{oldFile.WorkingDir}\{oldFile.NameNoExt}{ext}";
                    FileUtils.CopyFile(path, newPath);
                    var newFile = new FileBuffer(newPath, Name)
                    {
                        ID = (int)(id & 0xffff0000) + ((int)FileUtils.TypeFromExtension(ext) << 9)
                    };
                    Files[i] = newFile;
                    return newFile;
                }
            }
            return null;
        }

        public void RemoveFile(int id) {
            var file = GetFile(id);
            FileUtils.DeleteFile($@"{WorkingDir}\files\{file.Name}");
            Files.Remove(file);
        }
    }
}
