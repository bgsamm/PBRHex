using System.CommandLine.Builder;
using System.CommandLine.Invocation;
using System.Text.RegularExpressions;
using PBRHex.CLI.IO;

namespace PBRHex.CLI.Extensions
{
    internal static class CommandLineBuilderExtensions
    {
        public static CommandLineBuilder UseCustomParseErrorReporting(
                this CommandLineBuilder builder,
                IOutputWriter writer)
        {
            builder.AddMiddleware(async (context, next) =>
            {
                if (context.ParseResult.Errors.Count > 0)
                {
                    context.InvocationResult = new CustomParseErrorResult(writer);
                }
                else
                {
                    await next(context);
                }
            }, MiddlewareOrder.ErrorReporting);

            return builder;
        }
    }

    internal class CustomParseErrorResult : IInvocationResult
    {
        private IOutputWriter Writer { get; }

        internal CustomParseErrorResult(IOutputWriter writer)
        {
            Writer = writer;
        }

        public void Apply(System.CommandLine.Invocation.InvocationContext context)
        {
            foreach (var error in context.ParseResult.Errors)
            {
                string message = FormatErrorMessage(error.Message);
                Writer.WriteError(message);
            }

            context.ExitCode = 1;
        }

        private string FormatErrorMessage(string message)
        {
            string pattern;

            pattern = @"Cannot parse argument '.+' for option '.+' as expected type '.+'\. Did you mean one of the following\?";
            if (Regex.IsMatch(message, pattern))
            {
                message = Regex.Replace(message, " as expected type '.+'", "");
                message = Regex.Replace(message, "\n", "\n    ");
            }

            return message;
        }
    }
}
