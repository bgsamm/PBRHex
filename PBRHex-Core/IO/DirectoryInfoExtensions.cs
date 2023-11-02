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
        /// <summary>
        /// <para>
        ///     Notes:
        ///     <br>- Includes a trailing directory separator</br>
        /// </para>
        /// </summary>
        public static string GetName(this DirectoryInfo directoryInfo) {
            string name = directoryInfo.Name;

            if (!Path.EndsInDirectorySeparator(name)) {
                name += Path.DirectorySeparatorChar;
            }

            return name;
        }

        /// <summary>
        /// <para>
        ///     Notes:
        ///     <br>- Includes a trailing directory separator</br>
        /// </para>
        /// </summary>
        public static string GetPath(this DirectoryInfo directoryInfo) {
            string path = directoryInfo.FullName;

            path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

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
        public static bool PathEquals(this DirectoryInfo directoryInfo, string otherPath) {
            string thisPath = directoryInfo.GetPath();
            otherPath = new DirectoryInfo(otherPath).GetPath();
            return thisPath.Equals(otherPath, StringComparison.Ordinal);
        }

        public static string JoinPath(this DirectoryInfo directoryInfo, string subPath) {
            string thisPath = directoryInfo.GetPath();
            return Path.Join(thisPath, subPath);
        }

        public static void DeleteContents(this DirectoryInfo directoryInfo) {
            foreach (DirectoryInfo dir in directoryInfo.EnumerateDirectories()) {
                dir.Delete(true);
            }

            foreach (FileInfo file in directoryInfo.EnumerateFiles()) {
                file.Delete();
            }
        }
    }
}
