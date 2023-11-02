using PBRHex.Core.IO;

namespace PBRHex.Core
{
    public interface IROMFactory
    {
        public IEnumerable<string> Extensions { get; }
        public Task<bool> ExtractROMAsync(FileInfo rom, DirectoryInfo outdir);
    }

    internal class MetaROMFactory : IROMFactory
    {
        public IEnumerable<string> Extensions => Array.Empty<string>();

        private readonly IEnumerable<IROMFactory> romFactories;

        internal MetaROMFactory(IEnumerable<IROMFactory> factories) {
            romFactories = factories;
        }

        public async Task<bool> ExtractROMAsync(FileInfo rom, DirectoryInfo outdir) {
            bool success = false;

            foreach (IROMFactory factory in romFactories) {
                if (!factory.Extensions.Contains(rom.Extension)) {
                    continue;
                }

                success = await factory.ExtractROMAsync(rom, outdir);

                if (success) {
                    break;
                }

                // Remove any leftover files from failed extraction
                outdir.DeleteContents();
            }

            return success;
        }
    }
}
