using PBRHex.CLI.Commands;
using PBRHex.CLI.Extensions;
using PBRHex.CLI.IO;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

namespace PBRHex.CLI
{
    public interface ICommandLoader
    {
        public IOutputWriter Writer { get; init; }
        public IEnumerable<Command> LoadCommands();
    }

    internal class InvocationContext
    {
        internal required IOutputWriter Output { get; init; }
        internal required IEnumerable<Command> Commands { get; init; }
        internal required HelpWriter Help { get; init; }

        internal Command? GetCommand(string name) {
            return Commands.FirstOrDefault(cmd => cmd.Aliases.Contains(name));
        }
    }

    internal partial class CommandParser
    {
        private readonly InvocationContext Context;

        public CommandParser(IOutputWriter writer) {
            HelpWriter helpWriter = new(writer);

            List<Command> commands = new();
            Context = new()
            {
                Output = writer,
                Commands = commands,
                Help = helpWriter
            };

            CoreCommands core = new(Context);
            commands.AddRange(core.LoadCommands());
        }

        public void Invoke(string commandLine) {
            var splitter = CommandLineStringSplitter.Instance;
            string command = splitter.Split(commandLine).First();

            Command? cmd = Context.GetCommand(command);

            if (cmd is null) {
                Context.Output.WriteError($"No command exists named '{command}'.");
                return;
            }

            Parser parser = CreateParser(cmd);

            try {
                parser.Invoke(commandLine);
            }
            catch (Exception e) {
                Context.Output.WriteError(e.Message);
            }
        }

        private Parser CreateParser(Command command) {
            Parser parser = new CommandLineBuilder(command)
                .UseHelpBuilder(_ => Context.Help)
                .UseCustomParseErrorReporting(Context.Output)
                .Build();

            return parser;
        }
    }
}
