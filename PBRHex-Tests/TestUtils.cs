using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBRHex_Tests
{
    internal static class TestUtils
    {
        internal static string GetTempDirectory() {
            string name = Guid.NewGuid().ToString();

            string path = Path.Combine(Path.GetTempPath(), name);

            return path;
        }

        internal static void CreateEmptyFile(string dirPath) {
            string name = Guid.NewGuid().ToString();

            string filePath = Path.Combine(dirPath, name);

            File.Create(filePath).Close();
        }
    }
}
