using System;
using System.Collections.Generic;
using PBRHex.Utils;

namespace PBRHex.Files
{
    public class FSYS : FileBuffer
    {
        public List<FileBuffer> Files { get; private set; }
        public int FileCount => Files.Count;
        public string ExtractedDir { get; set; }

        public FSYS(string path, FileBuffer[] files) : base(path) {
            Files = new List<FileBuffer>(files.Length);
            Files.AddRange(files);
        }

        public FileBuffer GetFile(int id) {
            foreach(var file in Files) {
                if(file.ID == id)
                    return file;
            }
            return null;
        }

        public FileBuffer AddFile() {
            string outpath = $@"{ExtractedDir}\(null)_{Files.Count.ToString("X8").ToLower()}";
            FileUtils.CreateFile(outpath, 800);
            var file = new FileBuffer(outpath) { WorkingDir = ExtractedDir };
            Files.Add(file);
            return file;
        }

        public FileBuffer AddFile(string inpath) {
            string outpath = $@"{ExtractedDir}\(null)_{Files.Count.ToString("X8").ToLower()}";
            FileUtils.CopyFile(inpath, outpath);
            var file = new FileBuffer(outpath) { WorkingDir = ExtractedDir };
            Files.Add(file);
            return file;
        }

        public void DeleteFile(FileBuffer file) {
            FileUtils.DeleteFile($@"{ExtractedDir}\{file.Name}");
            Files.Remove(file);
        }
    }
}
