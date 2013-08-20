using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Willow.Kermit
{
    public abstract class AccessorCache<TOwner>
    {
        private readonly Dictionary<string, GetterSetterAccessor<TOwner>> _Fields = new Dictionary<string, GetterSetterAccessor<TOwner>>();
        private readonly Dictionary<string, object> _TypedFields = new Dictionary<string, object>();

        protected abstract Func<TOwner, TField> CreateGetter<TField>(string name);
        protected abstract Action<TOwner, TField> CreateSetter<TField>(string name);

        public GetterSetterAccessor<TOwner> GetAccessor(string name)
        {
            GetterSetterAccessor<TOwner> gsa;
            if (this._Fields.TryGetValue(name, out gsa)) return gsa;

            var getMethod = this.CreateGetter<object>(name);
            var setMethod = this.CreateSetter<object>(name);

            gsa = new GetterSetterAccessor<TOwner>(getMethod, setMethod);
            this._Fields.Add(name, gsa);
            return gsa;
        }

        public GetterSetterAccessor<TOwner, TField> GetAccessor<TField>(string name)
        {
            object gsaObject;
            if (this._TypedFields.TryGetValue(name, out gsaObject)) return (GetterSetterAccessor<TOwner, TField>) gsaObject;

            var getMethod = this.CreateGetter<TField>(name);
            var setMethod = this.CreateSetter<TField>(name);

            var gsa = new GetterSetterAccessor<TOwner, TField>(getMethod, setMethod);
            this._TypedFields.Add(name, gsa);
            return gsa;
        }

    }

    public abstract class StaticAccessorCache<TOwner> : AccessorCache<TOwner>
    {
        protected class SetterHelper<T>
        {
            private readonly Action<T> _SetterHelper;
            public SetterHelper(Action<T> setterHelper)
            {
                this._SetterHelper = setterHelper;
            }

            public void CreateSetter(TOwner owner, T prop)
            {
                this._SetterHelper(prop);
            }
        }

        protected class GetterHelper<T>
        {
            private readonly Func<T> _GetterHelper;
            public GetterHelper(Func<T> getterHelper)
            {
                this._GetterHelper = getterHelper;
            }

            public T CreateGetter(TOwner owner)
            {
                return this._GetterHelper();
            }
        }
    }

    public class FieldAccessorCache<TOwner> : AccessorCache<TOwner>
    {
        protected override Func<TOwner, TField> CreateGetter<TField>(string name)
        {
            return DynamicMethodGenerator.GenerateInstanceFieldGetter<TOwner, TField>(name);
        }

        protected override Action<TOwner, TField> CreateSetter<TField>(string name)
        {
            return DynamicMethodGenerator.GenerateInstanceFieldSetter<TOwner, TField>(name);
        }
    }

    public class PropertyAccessorCache<TOwner> : AccessorCache<TOwner>
    {
        protected override Func<TOwner, TProp> CreateGetter<TProp>(string name)
        {
            return DynamicMethodGenerator.GenerateInstancePropertyGetter<TOwner, TProp>(name);
        }

        protected override Action<TOwner, TProp> CreateSetter<TProp>(string name)
        {
            return DynamicMethodGenerator.GenerateInstancePropertySetter<TOwner, TProp>(name);
        }
    }

    public class StaticFieldAccessorCache<TOwner> : StaticAccessorCache<TOwner>
    {
        protected override Func<TOwner, TField> CreateGetter<TField>(string name)
        {
            var helper = new GetterHelper<TField>(DynamicMethodGenerator.GenerateStaticFieldGetter<TOwner, TField>(name));
            return helper.CreateGetter;
        }

        protected override Action<TOwner, TField> CreateSetter<TField>(string name)
        {
            var helper = new SetterHelper<TField>(DynamicMethodGenerator.GenerateStaticFieldSetter<TOwner, TField>(name));
            return helper.CreateSetter;
        }
    }

    public class StaticPropertyAccessorCache<TOwner> : StaticAccessorCache<TOwner>
    {
        protected override Func<TOwner, TProp> CreateGetter<TProp>(string name)
        {
            var helper = new GetterHelper<TProp>(DynamicMethodGenerator.GenerateStaticPropertyGetter<TOwner, TProp>(name));
            return helper.CreateGetter;
        }

        protected override Action<TOwner, TProp> CreateSetter<TProp>(string name)
        {
            var helper = new SetterHelper<TProp>(DynamicMethodGenerator.GenerateStaticPropertySetter<TOwner, TProp>(name));
            return helper.CreateSetter;
        }
    }
}