using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBRHex.Core.IO
{
    public static class DirectoryInfoExtensions
    {
        public static string GetName(this DirectoryInfo directoryInfo) {
            return directoryInfo.Name + Path.DirectorySeparatorChar;
        }

        public static string GetPath(this DirectoryInfo directoryInfo) {
            string path = directoryInfo.FullName;

            if (!Path.EndsInDirectorySeparator(path)) {
                path += Path.DirectorySeparatorChar;
            }

            return path;
        }

        public static bool IsSubDirectoryOf(this DirectoryInfo self, DirectoryInfo other) {
            string thisPath = self.GetPath(),
                otherPath = other.GetPath();

            return otherPath.StartsWith(thisPath);
        }
    }
}
