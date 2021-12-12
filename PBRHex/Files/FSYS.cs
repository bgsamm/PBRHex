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
            foreach(var file in Files) {
                if(file.ID == id)
                    return file;
            }
            return null;
        }

        public FileBuffer AddFile(string inpath) {
            string outpath = $@"{WorkingDir}\files\(null)_{Files.Count:x8}{System.IO.Path.GetExtension(inpath)}";
            FileUtils.CopyFile(inpath, outpath);
            var newFile = new FileBuffer(outpath, $@"{WorkingDir}\files");
            newFile.ID = FileUtils.GenerateFileID(this, newFile);
            Files.Add(newFile);
            return newFile;
        }

        /// <summary>
        /// Copies the supplied file into the archive, returning the newly created file.
        /// </summary>
        public FileBuffer AddFile(FileBuffer file) {
            string path = $@"{WorkingDir}\files\(null)_{Files.Count:x8}";
            FileUtils.CreateFile(path, file.GetBufferCopy());
            var newFile = new FileBuffer(path, $@"{WorkingDir}\files");
            if(file.ID != 0)
                newFile.ID = file.ID;
            else
                newFile.ID = FileUtils.GenerateFileID(this, newFile);
            Files.Add(newFile);
            return newFile;
        }

        public void RemoveFile(int id) {
            var file = GetFile(id);
            FileUtils.DeleteFile($@"{WorkingDir}\files\{file.Name}");
            Files.Remove(file);
        }
    }
}
