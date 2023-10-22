using System.CommandLine;

namespace PBRHex.CLI.IO
{
    public interface IInputReader
    {
        public char? Read();
        public string? ReadLine();
    }

    public interface IOutputWriter
    {
        public void Write(char c);
        public void Write(string text);
        public void WriteLine();
        public void WriteLine(string text, params object[] formatArgs);
        public void WriteError(string text, params object[] formatArgs);
        public void WriteTable(string[] headers, string[][] rows);
    }
}
