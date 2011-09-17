using System;
using System.IO;
using System.Reflection;

namespace Willow.Kermit.Util
{
    public class UriResolver : IUriResolver
    {
        public Uri Resolve(string path)
        {
            var assembly = new FileInfo(Assembly.GetExecutingAssembly().Location);
            return new Uri(string.Format("{0}/Resources/{1}", assembly.Directory.FullName , path), UriKind.RelativeOrAbsolute);
        }
    }
}