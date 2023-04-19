using System;
using System.Collections.Generic;
using System.CommandLine.Help;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBRHex.CLI
{
    internal static class HelpBuilderExtensions
    {
        internal static void WriteCommands(this HelpBuilder builder,
                                           IEnumerable<Command> commands,
                                           HelpContext context) {
            var sortedCommands = commands.OrderBy(cmd => cmd.Name);

            string heading = builder.LocalizationResources.HelpCommandsTitle();
            context.Output.WriteLine(heading);

            List<TwoColumnHelpRow> rows = new();
            foreach (Command command in sortedCommands) {
                string firstColumnText = string.Join(", ", command.Aliases);
                string secondColumnText = HelpBuilder.Default.GetIdentifierSymbolDescription(command);

                TwoColumnHelpRow row = new(firstColumnText, secondColumnText);
                rows.Add(row);
            }

            builder.WriteColumns(rows, context);
        }
    }

    internal class CustomHelpBuilder : HelpBuilder
    {
        public CustomHelpBuilder(LocalizationResources localizationResources)
            : base(localizationResources) { }

        public override void Write(HelpContext context) {
            base.Write(context);
            // Remove extraneous newlines
            Console.SetCursorPosition(0, Console.CursorTop - 2);
        }
    }
}
