using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
