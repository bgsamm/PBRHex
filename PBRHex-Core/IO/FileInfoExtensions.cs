namespace PBRHex.Core.IO
{
    public static class FileInfoExtensions
    {
        public static string GetName(this FileInfo fileInfo) {
            return fileInfo.Name;
        }

        public static string GetPath(this FileInfo fileInfo) {
            return fileInfo.FullName;
        }

        public static void CreateEmpty(this FileInfo fileInfo) {
            fileInfo.Create().Close();
        }

        /// <summary>
        /// <para>
        ///     Notes:
        ///     <br>- Comparison is case-sensitive</br>
        /// </para>
        /// </summary>
        public static bool PathEquals(this FileInfo fileInfo, string path) {
            string thisPath = fileInfo.FullName.TrimEnd(Path.DirectorySeparatorChar);
            string thatPath = Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar);
            return thisPath.Equals(thatPath, StringComparison.Ordinal);
        }
    }
}
