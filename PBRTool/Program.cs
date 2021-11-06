using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PBRTool.Utils;

namespace PBRTool
{
    public static class Program
    {
        public static string ISODir = Path.GetFullPath(".pbr");
        public static string TempDir = Path.GetFullPath("temp");
        public static string UserDir = Path.GetFullPath("user");
        public static string SpritesDir = Path.GetFullPath("sprites");
        public static string BackupsDir = $@"{UserDir}\backups";

        private static int WaitingCount;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            CreateFolders();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.Run(new MainWindow());
        }

        private static void CreateFolders() {
            FileUtils.CreateDirectory(TempDir, true);
            FileUtils.CreateDirectory(UserDir, false);
            FileUtils.CreateDirectory(BackupsDir, false);
        }

        static void Application_ApplicationExit(object sender, EventArgs args) {
            FileUtils.DeleteDirectory(TempDir);
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

        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern IntPtr GetOpenClipboardWindow();

        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        //public static Process GetProcessLockingClipboard() {
        //    GetWindowThreadProcessId(GetOpenClipboardWindow(), out int processId);
        //    return Process.GetProcessById(processId);
        //}
    }
}
