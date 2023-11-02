using PBRHex.Core.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PBRHex.Core.Projects
{
    public class InvalidProjectException : Exception
    {
        public InvalidProjectException() { }
        public InvalidProjectException(string message) : base(message) { }
        public InvalidProjectException(string message, Exception inner) : base(message, inner) { }
    }

    public class Project
    {
        private readonly ProjectDirLayout layout;

        private readonly ProjectInfo projectInfo;
        private readonly DirectoryInfo directoryInfo;

        public string Name => projectInfo.Name;
        public string Location => directoryInfo.GetPath();

        private Project(ProjectInfo info, DirectoryInfo directory) {
            projectInfo = info;
            directoryInfo = directory;

            layout = new ProjectDirLayout(directoryInfo);
        }

        internal async Task<bool> LoadROMAsync(FileInfo rom) {
            IROMFactory factory = ServiceLocator.GetDefaultROMFactory();
            bool success = await factory.ExtractROMAsync(rom, layout.GameFilesDir);

            return success;
        }

        /// <exception cref="DirectoryNotFoundException"></exception>
        internal static Project CreateProject(ProjectInfo info, DirectoryInfo directory) {
            string path = directory.GetPath();

            if (!directory.Exists) {
                throw new DirectoryNotFoundException($"Cannot create project in '{path}' - directory does not exist");
            }

            ProjectDirLayout directoryLayout = new(directory);
            directoryLayout.CreateOnDisk();

            string projectFilePath = directoryLayout.ProjectFile.GetPath();
            string json = JsonSerializer.Serialize(info);
            File.WriteAllText(projectFilePath, json);

            return new Project(info, directory);
        }

        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="InvalidProjectException"></exception>
        internal static Project LoadProject(DirectoryInfo directory) {
            string path = directory.GetPath();

            if (!directory.Exists) {
                throw new DirectoryNotFoundException($"Cannot read project from '{path}' - directory does not exist");
            }

            bool success = TryLoadProjectInfo(directory, out ProjectInfo info);

            if (!success) {
                throw new InvalidProjectException($"Cannot read project from '{path}' - directory does not contain a valid project");
            }

            return new Project(info, directory);
        }

        private static bool TryLoadProjectInfo(DirectoryInfo directory, out ProjectInfo projectInfo) {
            ProjectDirLayout directoryLayout = new(directory);
            string projectFilePath = directoryLayout.ProjectFile.GetPath();

            projectInfo = new();

            try {
                string json = File.ReadAllText(projectFilePath);
                projectInfo = JsonSerializer.Deserialize<ProjectInfo>(json);
            }
            catch {
                return false;
            }

            return true;
        }

        private class ProjectDirLayout
        {
            private readonly DirectoryLayout layout;

            private readonly DirectoryNode gameFilesDirNode;
            private readonly FileNode projectFileNode;

            internal DirectoryInfo GameFilesDir => gameFilesDirNode.Info;
            internal FileInfo ProjectFile => projectFileNode.Info;

            internal ProjectDirLayout(DirectoryInfo directory) {
                layout = new(directory);

                gameFilesDirNode = layout.Root.AddDirectory("dump");
                projectFileNode = layout.Root.AddFile("project.json");
            }

            internal void CreateOnDisk() => layout.CreateOnDisk();
        }
    }

    internal struct ProjectInfo
    {
        [JsonInclude]
        public string Name { get; internal init; }
    }
}
