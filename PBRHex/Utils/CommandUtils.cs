﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PBRHex.Utils
{
    public static class CommandUtils
    {
#if DEBUG
        private static readonly string witDir = @"C:\Program Files\Wiimm\WIT";
        private static readonly string quickbmsDir = @"C:\Program Files\quickbms";
#else
        private static readonly string witDir = $@"{AppContext.BaseDirectory}\WIT";
        private static readonly string quickbmsDir = $@"{AppContext.BaseDirectory}\quickbms";
#endif
        //private static readonly string dolphinDir = @"C:\Program Files\Dolphin\Dolphin-x64";

        public static void RunPythonScript(string path) {
            RunProcess("python", path);
        }

        public static void ExtractFSYS(string inpath, string outdir) {
            RunProcess($@"{quickbmsDir}\quickbms.exe", 
                "-K \"fsys extract and decompress script.txt\" " +
                $"\"{inpath}\" \"{outdir}\"");
        }

        public static void CompressLZSSFiles(string indir, string outdir) {
            RunProcess($@"{quickbmsDir}\quickbms.exe",
                "-K \"pokemon lzss recompress script.txt\" " +
                $"\"{indir}\\{{}}\" \"{outdir}\"");
        }

        public static void UnpackISO(string inpath) {
            FileUtils.DeleteDirectory(Program.ISODir);
            RunProcess($@"{witDir}\wit.exe", $@"EXTRACT ""{inpath}"" ""{Program.ISODir}"" --psel ""DATA""");
            FileUtils.DeleteFile($@"{Program.ISODir}\align-files.txt");
            FileUtils.DeleteFile($@"{Program.ISODir}\setup.bat");
            FileUtils.DeleteFile($@"{Program.ISODir}\setup.sh");
            FileUtils.DeleteFile($@"{Program.ISODir}\setup.txt");
        }

        public static void BuildISO(string outpath) {
            Console.WriteLine($@"COPY ""{Program.ISODir}"" ""{outpath}""");
            RunProcess($@"{witDir}\wit.exe", $@"COPY ""{Program.ISODir}"" ""{outpath}""");
        }

        public static Process RunDolphin() {
            return RunProcess($"Dolphin.exe",
                    $@"-b -e ""{Program.ISODir}\sys\main.dol""", false);
        }

        private static Process RunProcess(string path, string args, bool wait = true) {
            Process p;

            ProcessStartInfo info = new ProcessStartInfo(path, args)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = Path.GetDirectoryName(path)
            };

            try {
                Program.NotifyWaiting();
                p = Process.Start(info);
                p.EnableRaisingEvents = true;
                if(wait)
                    p.WaitForExit();
            }
            finally {
                Program.NotifyDone();
            }

            return p;
        }
    }
}
