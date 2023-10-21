using System.CommandLine;

namespace PBRHex.CLI
{
    internal partial class CommandParser
    {
        private readonly Dictionary<string, Command> Commands = new();

        private static class ListProjects
        {
            internal enum SortOrder
            {
                Name,
                CreationDate,
                LastModified,
                Region,
                Path,
            }
        }

        private void InitCommands() {
            Commands.Add("add-project", CreateAddProjectCommand());
            Commands.Add("commands", CreateCommandsCommand());
            Commands.Add("create-dir", CreateCreateDirCommand());
            Commands.Add("delete-dir", CreateDeleteDirCommand());
            Commands.Add("exit", CreateExitCommand());
            Commands.Add("get-cwd", CreateGetCwdCommand());
            Commands.Add("help", CreateHelpCommand());
            Commands.Add("init-project", CreateInitProjectCommand());
            Commands.Add("list-dir", CreateListDirCommand());
            Commands.Add("list-projects", CreateListProjectsCommand());
            Commands.Add("remove-project", CreateRemoveProjectCommand());
            Commands.Add("set-cwd", CreateSetCwdCommand());
        }

        private Command CreateAddProjectCommand() {
            Command command = new("add-project", "Adds an existing project to the known projects list.");

            Argument<string> pathArgument = new("path", "The directory of the project to add");

            command.Add(pathArgument);
            command.SetHandler(AddProjectHandle, pathArgument);

            return command;
        }

        private Command CreateCommandsCommand() {
            Command command = new("commands", "Displays a list of available commands.");

            command.SetHandler(CommandsHandle);

            return command;
        }

        private Command CreateCreateDirCommand() {
            Command command = new("create-dir", "Creates a new directory at the provided path.");

            Argument<string> pathArgument = new("path", "The path of the directory to create");

            command.Add(pathArgument);
            command.SetHandler(CreateDirHandle, pathArgument);

            return command;
        }

        private Command CreateDeleteDirCommand() {
            Command command = new("delete-dir", "Deletes the specified directory.");

            Argument<string> pathArgument = new("path", "The path of the directory to delete");

            Option<bool> forceOption = new("--force", "Causes the directory to be deleted, even if not empty");

            command.Add(pathArgument);
            command.Add(forceOption);
            command.SetHandler(DeleteDirHandle, pathArgument, forceOption);

            return command;
        }

        private Command CreateExitCommand() {
            Command command = new("exit", "Exits the program.");
            command.AddAlias("quit");

            command.SetHandler(ExitHandle);

            return command;
        }

        private Command CreateGetCwdCommand() {
            Command command = new("get-cwd", "Prints the path of the current working directory.");

            command.SetHandler(GetCwdHandle);

            return command;
        }

        private Command CreateHelpCommand() {
            Command command = new("help", "Displays command help information.");

            Argument<string> commandArgument = new("command", "The command to display help information for");

            command.Add(commandArgument);
            command.SetHandler(HelpHandle, commandArgument);

            return command;
        }

        private Command CreateInitProjectCommand() {
            Command command = new("init-project", "Creates a new project.");

            Argument<string> nameArgument = new("name", "The name of the project");
            Argument<string> pathArgument = new("path", "The directory in which to create the project");
            pathArgument.SetDefaultValue(".");

            command.Add(nameArgument);
            command.Add(pathArgument);
            command.SetHandler(InitProjectHandle, nameArgument, pathArgument);

            return command;
        }

        private Command CreateListDirCommand() {
            Command command = new("list-dir", "Lists the files and subdirectories contained in the given directory.");

            Argument<string> pathArgument = new("path", "The directory whose contents to list");
            pathArgument.SetDefaultValue(".");

            command.Add(pathArgument);
            command.SetHandler(ListDirHandle, pathArgument);

            return command;
        }

        private Command CreateListProjectsCommand() {
            Command command = new("list-projects", "Lists known projects.");

            Option<ListProjects.SortOrder> sortOrderOption = new("--sort-order", "Sets the sort order for the output");

            command.Add(sortOrderOption);
            command.SetHandler(ListProjectsHandle, sortOrderOption);

            return command;
        }

        private Command CreateRemoveProjectCommand() {
            Command command = new("remove-project", "Removes the given project from the known projects list.");

            Argument<string> pathArgument = new("path", "The project directory to remove");

            Option<bool> deleteFilesOption = new("--delete-files", "Deletes the project's files from disk");

            command.Add(pathArgument);
            command.Add(deleteFilesOption);
            command.SetHandler(RemoveProjectHandle, pathArgument, deleteFilesOption);

            return command;
        }

        private Command CreateSetCwdCommand() {
            Command command = new("set-cwd", "Sets the current working directory to the given path.");

            Argument<string> pathArgument = new("path", "The directory to change to");

            command.Add(pathArgument);
            command.SetHandler(SetCwdHandle, pathArgument);

            return command;
        }

        private partial void AddProjectHandle(string path);

        private partial void CommandsHandle();

        private partial void CreateDirHandle(string path);

        private partial void DeleteDirHandle(string path, bool force);

        private partial void ExitHandle();

        private partial void GetCwdHandle();

        private partial void HelpHandle(string command);

        private partial void InitProjectHandle(string name, string path);

        private partial void ListDirHandle(string path);

        private partial void ListProjectsHandle(ListProjects.SortOrder sortOrder);

        private partial void RemoveProjectHandle(string path, bool deleteFiles);

        private partial void SetCwdHandle(string path);
    }
}