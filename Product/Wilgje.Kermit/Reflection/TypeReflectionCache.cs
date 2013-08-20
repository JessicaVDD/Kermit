using System;
using System.Collections.Generic;

namespace Willow.Kermit
{
    public class TypeReflectionCache
    {
        private readonly static Dictionary<Type, TypeReflectionCache> _cache = new Dictionary<Type, TypeReflectionCache>();
        public static TypeReflectionCache GetCache(Type t)
        {
            TypeReflectionCache trc;
            if (!_cache.TryGetValue(t, out trc))
            {
                trc = CreateInstance(t);
                _cache[t] = trc;
            }
            return trc;
        }

        private static TypeReflectionCache CreateInstance(Type t)
        {
            return new TypeReflectionCache();
        }

        public static TypeReflectionCache GetCache<T>()
        {
            return GetCache(typeof(T));
        }


    }
}