using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Help;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBRHex.CLI.Properties;

namespace PBRHex.CLI
{
    internal partial class CommandParser
    {
        private readonly HelpBuilder HelpBuilder = 
            new HelpBuilderExtensions.CustomHelpBuilder(LocalizationResources.Instance);

        private readonly ConsoleWriter Writer = new();

        public CommandParser() {
            InitCommands();

            HelpBuilder.CustomizeSymbol(
                Commands["help"].Arguments[0],
                defaultValue: "none");
        }

        public int Invoke(string commandLine) {
            var splitter = CommandLineStringSplitter.Instance;
            string command = splitter.Split(commandLine).First();

            Command? cmd = Commands.Values.FirstOrDefault(cmd => cmd.Aliases.Contains(command));

            if (cmd is null) {
                Writer.WriteError(Resources.UnknownCommandException, command);
                return 1;
            }

            Parser parser = CreateParser(cmd);

            return parser.Invoke(commandLine);
        }

        private Parser CreateParser(Command command) {
            Parser parser = new CommandLineBuilder(command)
                .UseHelpBuilder(_ => HelpBuilder)
                .UseParseErrorReporting()
                .Build();

            return parser;
        }

        private partial void CommandsHandle() {
            HelpContext context = new(HelpBuilder, new RootCommand(), Writer);
            HelpBuilder.WriteCommands(Commands.Values, context);
        }

        private partial void ExitHandle() {
            Environment.Exit(0);
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
            throw new NotImplementedException();
        }

        private partial void ListProjectsHandle() {
            throw new NotImplementedException();
        }
    }
}
