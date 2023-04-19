using System;
using System.Collections.Generic;
using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PBRHex.CLI
{
    internal static class CommandLineBuilderExtensions
    {
        public static CommandLineBuilder UseCustomParseErrorReporting(
                this CommandLineBuilder builder,
                ConsoleWriter writer) {
            builder.AddMiddleware(async (context, next) => {
                if (context.ParseResult.Errors.Count > 0) {
                    context.InvocationResult = new CustomParseErrorResult(writer);
                }
                else {
                    await next(context);
                }
            }, MiddlewareOrder.ErrorReporting);

            return builder;
        }
    }

    internal class CustomParseErrorResult : IInvocationResult
    {
        private ConsoleWriter Writer { get; }

        internal CustomParseErrorResult(ConsoleWriter writer) {
            Writer = writer;
        }

        public void Apply(InvocationContext context) {
            foreach (var error in context.ParseResult.Errors) {
                string message = FormatErrorMessage(error.Message);
                Writer.WriteError(message);
            }

            context.ExitCode = 1;
        }

        private string FormatErrorMessage(string message) {
            string pattern;

            pattern = @"Cannot parse argument '.+' for option '.+' as expected type '.+'\. Did you mean one of the following\?";
            if (Regex.IsMatch(message, pattern)) {
                message = Regex.Replace(message, " as expected type '.+'", "");
                message = Regex.Replace(message, "\n", "\n    ");
            }

            return message;
        }
    }
}
