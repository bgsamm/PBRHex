using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PBRHex.CLI.Properties;
using PBRHex.Core;

namespace PBRHex.CLI
{
    internal static class Program
    {
        private static void Main() {
            CommandParser parser = new();

            string vers = Application.VersionName;
            Console.WriteLine("" +
                " ┌─────────────────────────────────┐\n" +
               $" │          PBRHex {vers}          │\n" +
                " │            by pjsamm            │\n" +
                " └─────────────────────────────────┘");

            Console.WriteLine("For a list of available commands, run `commands`.");
            Console.WriteLine("For more information about a command, run `help <command>`.");

            while (true) {
                Console.WriteLine();
                Console.Write(">>> ");
                string cmd = Console.ReadLine()!.Trim();
                if (cmd == "") {
                    continue;
                }
                parser.Invoke(cmd);
            }
        }
    }
}
