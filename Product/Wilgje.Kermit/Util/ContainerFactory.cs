using System.ComponentModel.Composition.Hosting;

namespace Willow.Kermit.Util
{
    internal class ContainerFactory
    {
        public static ExportProvider Create()
        {
            var catalog = new AggregateCatalog();

            // Add this assembly's catalog parts
            var asm = typeof (ContainerFactory).Assembly;
            catalog.Catalogs.Add(new AssemblyCatalog(asm));

            // Add screens
            var pluginPath = PathLocator.ScreenPluginPath;
            if (pluginPath.Exists)
                catalog.Catalogs.Add(new DirectoryCatalog(pluginPath.FullName));

            return new CompositionContainer(catalog);
        }
    }
}