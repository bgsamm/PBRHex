using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PBRHex.Core
{
    public static class Application
    {
#if DEBUG
        public const string Name = "PBRHex-Debug";
#else
        public const string Name = "PBRHex";
#endif

        public static Version Version => _version ??= GetVersion();

        public static string VersionName => $"v{Version.Major}.{Version.Minor}.{Version.Build}";

        public static string DataPath => _dataPath ??= GetDataPath();

        private static Version? _version;
        private static string? _dataPath;

        static Application() {
            if (!Directory.Exists(DataPath)) {
                InitializeDataFolder();
            }
        }

        private static Version GetVersion() {
            AssemblyName name = Assembly.GetExecutingAssembly().GetName();
            return name.Version ?? new(1, 0, 0, 0);
        }

        private static string GetDataPath() {
            string localDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(localDataPath, Name);
        }

        private static void InitializeDataFolder() {
            Directory.CreateDirectory(DataPath);
        }
    }
}
