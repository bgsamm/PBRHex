using PBRHex.Core.IO;
using System.ComponentModel.Composition.Hosting;

namespace PBRHex.Core
{
    internal class PluginLoader
    {
        private readonly AggregateCatalog catalog;

        internal PluginLoader() {
            catalog = new AggregateCatalog();
        }

        internal void AddDirectory(DirectoryInfo directory) {
            string path = directory.GetPath();
            catalog.Catalogs.Add(new DirectoryCatalog(path));
        }

        internal IEnumerable<T> GetTypes<T>() {
            CompositionContainer container = new(catalog);
            return container.GetExportedValues<T>();
        }
    }
}
