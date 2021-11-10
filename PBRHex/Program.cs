using System;
using System.IO;
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
        public static readonly string ISODir = $@"{DataDir}\.pbr";
        public static readonly string TempDir = $@"{DataDir}\temp";
        public static readonly string UserDir = $@"{DataDir}\user";
        public static readonly string SpritesDir = $@"{DataDir}\sprites";
        public static readonly string BackupsDir = $@"{UserDir}\backups";

        private static int WaitingCount;

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
                Cursor.Current = Cursors.WaitCursor;
        }

        public static void Log(string msg) {
            using(var w = File.AppendText($@"{DataDir}\log.txt")) {
                w.WriteLine(msg);
            }
        }
    }
}
