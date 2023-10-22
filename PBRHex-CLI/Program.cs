using PBRHex.CLI.IO;
using PBRHex.Core;

namespace PBRHex.CLI
{
    internal static class Program
    {
        private static void Main() {
            ConsoleWrapper console = new();
            CommandParser parser = new(console);

            string vers = Application.VersionName;
            console.WriteLine("" +
                " ┌─────────────────────────────────┐\n" +
               $" │          PBRHex {vers}          │\n" +
                " │            by pjsamm            │\n" +
                " └─────────────────────────────────┘");

            console.WriteLine("For a list of available commands, run `commands`.");
            console.WriteLine("For more information about a command, run `help <command>`.");

            while (true) {
                console.WriteLine();
                console.Write(">>> ");

                string? cmd = console.ReadLine();
                if (cmd is null) {
                    break;
                }
                if (string.IsNullOrWhiteSpace(cmd)) {
                    continue;
                }
                parser.Invoke(cmd);
            }
        }
    }
}
