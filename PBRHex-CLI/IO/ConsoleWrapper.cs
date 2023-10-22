using System.Diagnostics;

namespace PBRHex.CLI.IO
{
    internal class ConsoleWrapper : IOutputWriter, IInputReader
    {
        public char? Read()
        {
            int c = Console.Read();
            return c == -1 ? null : (char)c;
        }

        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(char c)
        {
            Console.Out.Write(c);
        }

        public void Write(string text)
        {
            Console.Out.Write(text);
        }

        public void WriteLine()
        {
            Console.Out.WriteLine();
        }

        public void WriteLine(string text, params object[] formatArgs)
        {
            Console.ResetColor();

            text = string.Format(text, formatArgs);
            Console.Out.WriteLine(text);
        }

        public void WriteError(string text, params object[] formatArgs)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;

            text = string.Format(text, formatArgs);
            Console.Error.WriteLine(text);

            Console.ResetColor();
        }

        public void WriteTable(string[] headers, string[][] rows)
        {
            Trace.Assert(rows.All(row => row.Length == headers.Length));

            int numColumns = headers.Length;

            int[] columnSizes = (from header in headers select header.Length).ToArray();

            foreach (var row in rows)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i].Length > columnSizes[i])
                    {
                        columnSizes[i] = row[i].Length;
                    }
                }
            }

            WriteRow(headers, columnSizes);

            string[] separators = new string[numColumns];
            for (int i = 0; i < separators.Length; i++)
            {
                separators[i] = new string('-', columnSizes[i]);
            }
            WriteRow(separators, columnSizes);

            foreach (var row in rows)
            {
                WriteRow(row, columnSizes);
            }
        }

        private void WriteRow(string[] row, int[] columnSizes)
        {
            Write('|');
            for (int i = 0; i < row.Length; i++)
            {
                string header = row[i].PadRight(columnSizes[i], ' ');

                Write($" {header} |");
            }
            WriteLine();
        }
    }
}
