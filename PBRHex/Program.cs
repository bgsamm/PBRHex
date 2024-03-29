﻿using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using PBRHex.Utils;

namespace PBRHex
{
    public static class Program
    {
        public static readonly string DataDir =
#if DEBUG
            AppContext.BaseDirectory;
#else
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\PBRHex";
#endif
        public static readonly string ISODir = Path.Combine(DataDir, ".pbr");
        public static readonly string TempDir = Path.Combine(DataDir, "temp");
        public static readonly string UserDir = Path.Combine(DataDir, "user");
        public static readonly string SpritesDir = Path.Combine(DataDir, "sprites");
        public static readonly string BackupsDir = Path.Combine(UserDir, "backups");

        public static GameRegion ISORegion;

        private static int WaitingCount;
        private static readonly object LoggerLock = new object();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(OnUnhandledException);

            CreateFolders();
            Log("==================================================");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.Run(new MainWindow());
        }

        static void Application_ApplicationExit(object sender, EventArgs args) {
            FileUtils.DeleteDirectory(TempDir);
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs args) {
            Log(args.ExceptionObject.ToString());
        }

        private static void CreateFolders() {
            FileUtils.CreateDirectory(TempDir, true);
            FileUtils.CreateDirectory(UserDir, false);
            FileUtils.CreateDirectory(BackupsDir, false);
        }

        public static void NotifyWaiting() {
            WaitingCount++;
            Cursor.Current = Cursors.WaitCursor;
        }

        public static void NotifyDone() {
            if(WaitingCount > 0)
                WaitingCount--;
            if(WaitingCount == 0)
                Cursor.Current = Cursors.Default;
        }

        public static void Log(string msg) {
            lock(LoggerLock) {
                using(var w = File.AppendText($@"{DataDir}\log.txt")) {
                    w.WriteLine(msg);
                }
            }
        }
    }
}
