using PBRHex.CLI.IO;
using PBRHex.Core.IO;
using PBRHex.Core.Projects;
using System.CommandLine;

namespace PBRHex.CLI.Commands
{
    internal partial class CoreCommands : ICommandLoader
    {
        public IOutputWriter Writer { get; init; }

        private readonly InvocationContext Context;

        internal CoreCommands(InvocationContext context) {
            Context = context;
            Writer = context.Output;
        }

        private partial void AddProjectHandle(string path) {
            DirectoryInfo directory = new(path);

            Project project = ProjectManager.GetProjectFromDirectory(directory);

            bool wasAdded = ProjectManager.AddProjectToList(project);
            if (wasAdded) {
                Writer.WriteLine($"Added project '{project.Name}' in '{project.Location}' to the project list.");
            }
            else {
                Writer.WriteLine($"Project '{project.Name}' in '{project.Location}' is already on the project list.");
            }
        }

        private partial void CommandsHandle() {
            Context.Help.WriteCommands(Context.Commands);
        }

        private partial void CreateDirHandle(string path) {
            DirectoryInfo directory = new(path);
            string fullPath = directory.GetPath();

            if (directory.Exists) {
                Writer.WriteLine($"The directory '{fullPath}' already exists.");
                return;
            }

            Directory.CreateDirectory(path);
            Writer.WriteLine($"Successfully created a new directory at '{fullPath}'.");
        }

        private partial void DeleteDirHandle(string path, bool force) {
            DirectoryInfo directory = new(path);
            string fullPath = directory.GetPath();

            DirectoryInfo currentDir = new(Directory.GetCurrentDirectory());
            if (currentDir.IsSubDirectoryOf(directory)) {
                Writer.WriteError($"Cannot delete {fullPath} - currently inside directory");
                return;
            }

            if (!force && directory.GetFiles(path).Length > 0) {
                Writer.WriteError($"Cannot remove non-empty directory '{fullPath}'. Use --force to override.");
                return;
            }

            Directory.Delete(path, force);
            Writer.WriteLine($"Successfully deleted the directory at '{fullPath}'.");
        }

        private partial void ExitHandle() {
            Environment.Exit(0);
        }

        private partial void GetCwdHandle() {
            string path = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;

            Writer.WriteLine(path);
        }

        private partial void HelpHandle(string command) {
            Command? cmd = Context.GetCommand(command);

            if (cmd is null) {
                Writer.WriteError($"No command exists named '{command}'.");
                return;
            }

            Context.Help.WriteHelp(cmd);
        }

        private partial void InitProjectHandle(string name, string path) {
            DirectoryInfo directory = new(path);

            ProjectManager.InitializeProject(name, directory);

            string fullPath = directory.GetPath();
            Writer.WriteLine($"Initialized project '{name}' in '{fullPath}'.");
        }

        private partial void ListDirHandle(string path) {
            foreach (string dirPath in Directory.GetDirectories(path)) {
                DirectoryInfo directory = new(dirPath);
                Writer.WriteLine(directory.GetName());
            }

            foreach (string filePath in Directory.GetFiles(path)) {
                FileInfo file = new(filePath);
                Writer.WriteLine(file.GetName());
            }
        }

        private partial void ListProjectsHandle(ListProjects.SortOrder sortOrder) {
            string[] headers = { "Name", "Path" };

            // Sort the projects list
            IEnumerable<Project> projects = ProjectManager.GetProjectList();
            switch (sortOrder) {
                case ListProjects.SortOrder.Name:
                    projects = projects.OrderBy(project => project.Name);
                    break;

                case ListProjects.SortOrder.Path:
                    projects = projects.OrderBy(project => project.Location);
                    break;
            }

            int numRows = projects.Count(),
                numCols = headers.Length;

            // Build the rows array
            string[][] rows = new string[numRows][];
            for (int i = 0; i < numRows; i++) {
                Project project = projects.ElementAt(i);

                string[] row = new string[numCols];
                row[0] = project.Name;
                row[1] = project.Location;

                rows[i] = row;
            }

            Writer.WriteTable(headers, rows);
        }

        private partial void RemoveProjectHandle(string path, bool deleteFiles) {
            DirectoryInfo projectDir = new(path);
            Project project = ProjectManager.GetProjectFromDirectory(projectDir);

            bool wasRemoved = ProjectManager.RemoveProjectFromList(project);
            if (wasRemoved) {
                Writer.WriteLine($"Removed project '{project.Name}' in '{project.Location}' from the project list.");
            }
            else {
                Writer.WriteLine($"Project '{project.Name}' in '{project.Location}' is not on the project list.");
            }

            if (deleteFiles) {
                if (projectDir.Parent is null) {
                    Writer.WriteError("Cannot delete project directory - project directory is a root directory.");
                    return;
                }

                DirectoryInfo currentDir = new(Directory.GetCurrentDirectory());

                // Move to project's parent directory if currently inside of project
                if (currentDir.IsSubDirectoryOf(projectDir)) {
                    Directory.SetCurrentDirectory(projectDir.Parent.GetPath());
                }

                projectDir.Delete(true);
            }
        }

        private partial void SetCwdHandle(string path) {
            DirectoryInfo directory = new(path);

            Directory.SetCurrentDirectory(path);

            string fullPath = directory.GetPath();
            Writer.WriteLine($"The current working directory is now '{fullPath}'.");
        }
    }
}