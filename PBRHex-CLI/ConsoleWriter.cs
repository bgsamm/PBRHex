using PBRHex.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PBRHex.CLI
{
    internal class ConsoleWriter : TextWriter
    {
        public override Encoding Encoding => Encoding.UTF8;

        public override void Write(char value) {
            Console.Out.Write(value);
        }

        public void WriteError(string message, params object[] formatArgs) {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;

            message = string.Format(message, formatArgs);
            Console.Error.WriteLine(message);

            Console.ResetColor();
        }

        public void WriteTable(string[] headers, string[][] rows) {
            Trace.Assert(rows.All(row => row.Length == headers.Length));

            int numColumns = headers.Length;

            int[] columnSizes = (from header in headers select header.Length).ToArray();

            foreach (var row in rows) {
                for (int i = 0; i < row.Length; i++) {
                    if (row[i].Length > columnSizes[i]) {
                        columnSizes[i] = row[i].Length;
                    }
                }
            }

            WriteRow(headers, columnSizes);

            string[] separators = new string[numColumns];
            for (int i = 0; i < separators.Length; i++) {
                separators[i] = new string('-', columnSizes[i]);
            }
            WriteRow(separators, columnSizes);

            foreach (var row in rows) {
                WriteRow(row, columnSizes);
            }
        }

        private void WriteRow(string[] row, int[] columnSizes) {
            Write('|');
            for (int i = 0; i < row.Length; i++) {
                string header = row[i].PadRight(columnSizes[i], ' ');

                Write($" {header} |");
            }
            WriteLine();
        }
    }
}
