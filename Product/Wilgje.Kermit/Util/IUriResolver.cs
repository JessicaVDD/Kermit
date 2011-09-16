using System;

namespace Willow.Kermit.Util
{
    public interface IUriResolver
    {
        Uri Resolve(string path);
    }
}