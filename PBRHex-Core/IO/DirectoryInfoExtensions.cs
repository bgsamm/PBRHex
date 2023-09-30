using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBRHex.Core.IO
{
    public class DirectoryNotEmptyException : Exception
    {
        public DirectoryNotEmptyException() { }
        public DirectoryNotEmptyException(string message) : base(message) { }
        public DirectoryNotEmptyException(string message, Exception inner) : base(message, inner) { }
    }

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

            return thisPath.StartsWith(otherPath);
        }

        /// <summary>
        /// <para>
        ///     Notes:
        ///     <br>- Comparison is case-sensitive</br>
        /// </para>
        /// </summary>
        public static bool PathEquals(this DirectoryInfo directoryInfo, string path) {
            string thisPath = directoryInfo.FullName.TrimEnd(Path.DirectorySeparatorChar);
            string thatPath = Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar);
            return thisPath.Equals(thatPath, StringComparison.Ordinal);
        }
    }
}
