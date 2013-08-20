using System;

namespace Willow.Kermit
{
    public class ReflectedType<TOwner>
    {
        public static readonly AccessorCache<TOwner> FieldCache = new FieldAccessorCache<TOwner>();
        public static readonly AccessorCache<TOwner> PropertyCache = new PropertyAccessorCache<TOwner>();
        public static readonly MethodCache<TOwner> MethodCache = new InstanceMethodCache<TOwner>();
        private static readonly AccessorCache<TOwner> _StaticFieldCache = new StaticFieldAccessorCache<TOwner>();
        private static readonly AccessorCache<TOwner> _StaticPropertyCache = new StaticPropertyAccessorCache<TOwner>();
        private static readonly MethodCache<TOwner> _StaticMethodCache = new StaticMethodCache<TOwner>();

        public GetterSetter<TOwner> Fields(string name) { return GetterSetter.Create(_StaticFieldCache.GetAccessor(name)); }
        public GetterSetter<TOwner, TField> Fields<TField>(string name) { return GetterSetter.Create(_StaticFieldCache.GetAccessor<TField>(name)); }

        public GetterSetter<TOwner> Properties(string name) { return GetterSetter.Create(_StaticPropertyCache.GetAccessor(name)); }
        public GetterSetter<TOwner, TProperty> Properties<TProperty>(string name) { return GetterSetter.Create(_StaticPropertyCache.GetAccessor<TProperty>(name)); }

        public T Method<T>(string method) where T : class
        {
            return _StaticMethodCache.GetAccessor<T>(method);
        }
        public Delegate Method(string method, Type returnValueType, params Type[] args)
        {
            return _StaticMethodCache.GetAccessor(method, returnValueType, args);
        }
    }
}