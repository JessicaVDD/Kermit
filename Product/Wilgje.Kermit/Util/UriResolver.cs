using System;

namespace Willow.Kermit.Util
{
    public interface UriResolver
    {
        Uri Resolve(string path);
    }
}