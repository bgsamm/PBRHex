using System.CommandLine;
using System.CommandLine.Help;
using System.Text;
using PBRHex.CLI.IO;

namespace PBRHex.CLI
{
    internal class HelpWriter : HelpBuilder
    {
        private readonly OutputWriterWrapper writer;

        internal HelpWriter(IOutputWriter writer) : this(writer, LocalizationResources.Instance) { }

        internal HelpWriter(IOutputWriter writer, LocalizationResources localizationResources)
            : base(localizationResources) {
            this.writer = new OutputWriterWrapper(writer);
        }

        internal void WriteHelp(Command command) {
            HelpContext context = new(this, command, writer);
            Write(context);
            // Remove extraneous newlines
            Console.SetCursorPosition(0, Console.CursorTop - 2);
        }

        internal void WriteCommands(IEnumerable<Command> commands) {
            writer.WriteLine(LocalizationResources.HelpCommandsTitle());

            List<TwoColumnHelpRow> rows = new();
            foreach (Command command in commands.OrderBy(cmd => cmd.Name)) {
                string firstColumnText = string.Join(", ", command.Aliases);
                string secondColumnText = Default.GetIdentifierSymbolDescription(command);

                TwoColumnHelpRow row = new(firstColumnText, secondColumnText);
                rows.Add(row);
            }

            HelpContext context = new(this, new RootCommand(), writer);
            WriteColumns(rows, context);
        }

        // This class is necessary to instantiate HelpContext, which requires a TextWriter
        private class OutputWriterWrapper : TextWriter
        {
            public override Encoding Encoding => Encoding.Default;

            private readonly IOutputWriter writer;

            internal OutputWriterWrapper(IOutputWriter writer) {
                this.writer = writer;
            }

            public override void Write(char value) {
                writer.Write(value);
            }
        }
    }
}
