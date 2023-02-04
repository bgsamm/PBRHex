using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PBRHex.Core
{
    public static class AssemblyInfo
    {
        public static Version Version => Assembly.GetExecutingAssembly().GetName().Version ?? new(1, 0, 0, 0);

        public static string VersionName => $"v{Version.Major}.{Version.Minor}.{Version.Build}";
    }
}
