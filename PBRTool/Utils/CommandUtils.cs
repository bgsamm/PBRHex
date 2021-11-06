﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PBRTool.Utils
{
    public static class CommandUtils
    {
        private const string witDir = @"C:\Program Files\Wiimm\WIT";
        private const string quickbmsDir = @"C:\Program Files\quickbms";
        private const string dolphinDir = @"C:\Program Files\Dolphin\Dolphin-x64";

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
            RunProcess($@"{witDir}\wit.exe", $@"EXTRACT ""{inpath}"" ""{Program.ISODir}""");
            RunProcess("cmd.exe", "/c del /s align-files.txt");
            RunProcess("cmd.exe", "/c del /s setup.*");
        }

        public static void BuildISO(string outpath) {
            Console.WriteLine($@"COPY ""{Program.ISODir}"" ""{outpath}""");
            RunProcess($@"{witDir}\wit.exe", $@"COPY ""{Program.ISODir}"" ""{outpath}""");
        }

        public static void PlayTest() {
            RunProcess($"{dolphinDir}\\Dolphin.exe", 
                $@"-e ""{Program.ISODir}\DATA\sys\main.dol""", false);
        }

        private static void RunProcess(string path, string args, bool wait = true) {
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
                if(wait) 
                    p.WaitForExit();
            }
            finally {
                Program.NotifyDone();
            }
        }
    }
}
