using System.Diagnostics;

namespace PBRHex.Core.IO
{
    internal class DirectoryLayout
    {
        internal DirectoryNode Root { get; }

        internal DirectoryLayout(DirectoryInfo rootDir) {
            Root = new DirectoryNode(rootDir);
        }

        internal void CreateOnDisk() {
            RecursiveCreateOnDisk(Root);
        }

        private void RecursiveCreateOnDisk(DirectoryNode directory) {
            directory.Info.Create();

            foreach (DirectoryNode subdirectory in directory.GetDirectories()) {
                RecursiveCreateOnDisk(subdirectory);
            }

            foreach (FileNode file in directory.GetFiles()) {
                file.Info.CreateEmpty();
            }
        }
    }

    internal class DirectoryNode
    {
        internal DirectoryInfo Info { get; }

        private readonly List<DirectoryNode> directories = new();
        private readonly List<FileNode> files = new();

        internal DirectoryNode(DirectoryInfo info) {
            Info = info;
        }

        /// <summary>
        /// <para>
        ///     Pre-conditions:
        ///     <br>- name must be a valid filename with no directory separators</br>
        /// </para>
        /// </summary>
        internal DirectoryNode AddDirectory(string name) {
            Trace.Assert(name.IndexOfAny(Path.GetInvalidFileNameChars()) < 0);

            DirectoryInfo subdir = new(Info.JoinPath(name));

            DirectoryNode directoryNode = new(subdir);
            directories.Add(directoryNode);

            return directoryNode;
        }

        /// <summary>
        /// <para>
        ///     Pre-conditions:
        ///     <br>- name must be a valid filename with no directory separators</br>
        /// </para>
        /// </summary>
        internal FileNode AddFile(string name) {
            Trace.Assert(name.IndexOfAny(Path.GetInvalidFileNameChars()) < 0);

            FileInfo file = new(Info.JoinPath(name));

            FileNode fileNode = new(file);
            files.Add(fileNode);

            return fileNode;
        }

        internal IEnumerable<DirectoryNode> GetDirectories() {
            foreach (DirectoryNode directory in directories) {
                yield return directory;
            }
        }

        internal IEnumerable<FileNode> GetFiles() {
            foreach (FileNode file in files) {
                yield return file;
            }
        }
    }

    internal class FileNode
    {
        internal FileInfo Info { get; }

        internal FileNode(FileInfo info) {
            Info = info;
        }
    }
}
