using System.IO;

namespace Willow.Kermit.Util
{
    public static class PathLocator
    {
        public static DirectoryInfo ScreenPluginPath
        {
            get { return new DirectoryInfo("unknown"); }
        }
    }
}