using CliWrap;
using CliWrap.Buffered;
using PBRHex.Core.IO;
using System.Diagnostics;

namespace PBRHex.Core.External
{
    public static class Wit
    {
        private static string WitPath => $@"{Application.BaseDirectory}\wit\wit.exe";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iso"></param>
        /// <param name="outDir"></param>
        /// <returns></returns>
        public static CommandTask<BufferedCommandResult> ExtractIsoAsync(FileInfo iso, DirectoryInfo outDir) {
            Trace.Assert(iso.Extension == ".iso");

            string[] args = { "EXTRACT", iso.GetPath(), outDir.GetPath() };

            Command command = Cli.Wrap(WitPath)
                                 .WithArguments(args)
                                 .WithValidation(CommandResultValidation.None);

            return command.ExecuteBufferedAsync();
        }
    }
}
