using System;
using System.IO;
using System.Reflection;

namespace Willow.Kermit.Util
{
    public class DefaultUriResolver : UriResolver
    {
        public Uri Resolve(string path)
        {
            var assembly = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var uri = assembly.Directory == null ? null :  new Uri(string.Format("{0}/Resources/{1}", assembly.Directory.FullName , path), UriKind.RelativeOrAbsolute);
            return (uri != null && File.Exists(uri.LocalPath)) ? uri : null;
        }
    }
}