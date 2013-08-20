using System;

namespace Willow.Kermit
{
    public class GetterSetterAccessor<TOwner, TField>
    {
        public Action<TOwner, TField> Set { get; set; }
        public Func<TOwner, TField> Get { get; set; }

        public GetterSetterAccessor(Func<TOwner, TField> get, Action<TOwner, TField> set)
        {
            this.Set = set;
            this.Get = get;
        }
    }

    public class GetterSetterAccessor<TOwner> : GetterSetterAccessor<TOwner, object>
    {
        public GetterSetterAccessor(Func<TOwner, object> get, Action<TOwner, object> set) : base(get, set) { }
    }

}