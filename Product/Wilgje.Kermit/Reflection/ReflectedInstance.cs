using System;

namespace Willow.Kermit
{
    public class ReflectedInstance<TOwner>
    {
        private readonly TOwner _Owner;
        private readonly ReflectedType<TOwner> _OwnerReflectedType;

        private readonly AccessorCache<TOwner> _FieldCache;
        private readonly AccessorCache<TOwner> _PropertyCache;
        private readonly MethodCache<TOwner> _MethodCache;
        
        public ReflectedInstance(TOwner owner)
        {
            this._Owner = owner;
            this._OwnerReflectedType = new ReflectedType<TOwner>();
            this._FieldCache = ReflectedType<TOwner>.FieldCache;
            this._PropertyCache = ReflectedType<TOwner>.PropertyCache;
            this._MethodCache = ReflectedType<TOwner>.MethodCache;
        }

        public ReflectedType<TOwner> Static { get { return this._OwnerReflectedType; } }
        public GetterSetter<TOwner> Fields(string name) { return GetterSetter.Create(this._Owner, this._FieldCache.GetAccessor(name)); }
        public GetterSetter<TOwner, TField> Fields<TField>(string name) { return GetterSetter.Create(this._Owner, this._FieldCache.GetAccessor<TField>(name)); }

        public GetterSetter<TOwner> Properties(string name) { return GetterSetter.Create(this._Owner, this._PropertyCache.GetAccessor(name)); }
        public GetterSetter<TOwner, TProperty> Properties<TProperty>(string name) { return GetterSetter.Create(this._Owner, this._PropertyCache.GetAccessor<TProperty>(name)); }

        public T Method<T>(string method) where T : class
        {
            return _MethodCache.GetAccessor<T>(method);
        }
        public Delegate Method(string method, Type returnValueType, params Type[] args)
        {
            return _MethodCache.GetAccessor(method, returnValueType, args);
        }
    }
}