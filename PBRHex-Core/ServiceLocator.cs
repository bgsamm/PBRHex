namespace PBRHex.Core
{
    internal static class ServiceLocator
    {
        internal static IROMFactory GetDefaultROMFactory() => defaultROMFactory;

        private static readonly PluginLoader pluginLoader;

        private static readonly MetaROMFactory defaultROMFactory;

        static ServiceLocator() {
            pluginLoader = new();
            //pluginLoader.AddDirectory(Application.PluginsDir);

            defaultROMFactory = new MetaROMFactory(pluginLoader.GetTypes<IROMFactory>());
        }
    }
}
