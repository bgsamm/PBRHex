using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.CommandLine.Parsing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBRHex.CLI.Properties;
using PBRHex.Core.IO;
using PBRHex.Core.Projects;

namespace PBRHex.CLI
{
    internal partial class CommandParser
    {
        private readonly HelpBuilder HelpBuilder = new CustomHelpBuilder(LocalizationResources.Instance);

        private readonly ConsoleWriter Writer = new();

        public CommandParser() {
            InitCommands();

            HelpBuilder.CustomizeSymbol(
                Commands["help"].Arguments[0],
                defaultValue: "none");
        }

        public void Invoke(string commandLine) {
            var splitter = CommandLineStringSplitter.Instance;
            string command = splitter.Split(commandLine).First();

            Command? cmd = Commands.Values.FirstOrDefault(cmd => cmd.Aliases.Contains(command));

            if (cmd is null) {
                Writer.WriteError(Resources.UnknownCommandException, command);
                return;
            }

            Parser parser = CreateParser(cmd);

            try {
                parser.Invoke(commandLine);
            }
            catch (Exception e) {
                Writer.WriteError(e.Message);
            }
        }

        private Parser CreateParser(Command command) {
            Parser parser = new CommandLineBuilder(command)
                .UseHelpBuilder(_ => HelpBuilder)
                .UseCustomParseErrorReporting(Writer)
                .Build();

            return parser;
        }

        private partial void AddProjectHandle(string path) {
            DirectoryInfo directory = new(path);

            Project project = ProjectManager.GetProjectFromDirectory(directory);
            ProjectManager.AddProjectToList(project);

            Writer.WriteLine($"Added project '{project.Name}' from '{project.Location}'.");
        }

        private partial void CommandsHandle() {
            HelpContext context = new(HelpBuilder, new RootCommand(), Writer);
            HelpBuilder.WriteCommands(Commands.Values, context);
        }

        private partial void ExitHandle() {
            Environment.Exit(0);
        }

        private partial void GetCwdHandle() {
            string path = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar;

            Writer.WriteLine($"The current working directory is '{path}'.");
        }

        private partial void HelpHandle(string command) {
            if (!Commands.ContainsKey(command)) {
                Writer.WriteError(Resources.UnknownCommandException, command);
                return;
            }

            Command cmd = Commands[command];
            HelpBuilder.Write(cmd, Writer);
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

        private partial void ListProjectsHandle(ListProjectsSortOrderValue sortOrder) {
            string[] headers = { "Name", "Path" };

            // Sort the projects list
            IEnumerable<Project> projects = ProjectManager.GetProjectList();
            switch (sortOrder) {
                case ListProjectsSortOrderValue.Name:
                    projects = projects.OrderBy(project => project.Name);
                    break;

                case ListProjectsSortOrderValue.Path:
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

            Project project;
            try {
                project = ProjectManager.GetProjectFromDirectory(projectDir);
            }
            catch (InvalidProjectException) {
                string fullPath = projectDir.GetPath();
                Writer.WriteLine($"'{fullPath}' does not contain a valid project.");
                return;
            }

            ProjectManager.RemoveProjectFromList(project);

            Writer.WriteLine($"Project '{project.Name}' in '{project.Location}' removed from the project list.");

            if (deleteFiles) {
                if (projectDir.Parent is null) {
                    Writer.WriteError("Cannot delete project directory - project directory is a root directory.");
                    return;
                }

                string currentPath = Directory.GetCurrentDirectory();
                DirectoryInfo currentDir = new(currentPath);

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
            Writer.WriteLine($"Set the current working directory to '{fullPath}'.");
        }
    }
}
