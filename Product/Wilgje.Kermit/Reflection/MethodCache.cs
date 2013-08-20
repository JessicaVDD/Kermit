using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Willow.Kermit
{
    public abstract class MethodCache<TOwner>
    {
        private readonly Dictionary<MethodKey, Delegate> _Methods = new Dictionary<MethodKey, Delegate>();
        public Delegate GetAccessor(string method, Type returnValueType, params Type[] args)
        {
            var methodKey = new MethodKey(method, returnValueType, args);
            Delegate d;
            if (this._Methods.TryGetValue(methodKey, out d)) return d;

            d = this.GetMethodDelegate(method, returnValueType, args);
            this._Methods[methodKey] = d;
            return d;
        }

        public T GetAccessor<T>(string method) where T : class
        {
            var methodKey = new MethodKey(method, typeof(T));
            Delegate d;
            if (this._Methods.TryGetValue(methodKey, out d)) return d as T;

            d = this.GetMethodDelegate<T>(method);
            this._Methods[methodKey] = d;
            return d as T;
        }

        protected abstract Delegate GetMethodDelegate(string method, Type returnValueType, Type[] args);
        protected abstract Delegate GetMethodDelegate<T>(string method) where T : class;
    }

    public class StaticMethodCache<TOwner> : MethodCache<TOwner>
    {
        protected override Delegate GetMethodDelegate(string method, Type returnValueType, Type[] args)
        {
            var parameters = new List<Type>(args) { returnValueType };
            var delegateType = Expression.GetDelegateType(parameters.ToArray());

            return DynamicMethodGenerator.GenerateStaticMethod(method, delegateType, typeof(TOwner), args);
        }

        protected override Delegate GetMethodDelegate<T>(string method)
        {
            if (!typeof(T).IsSubclassOf(typeof(Delegate))) throw new ArgumentException("The generic type must be a delegate.");

            var delegateMethod = typeof(T).GetMethod("Invoke");
            var delegateMethodParameters = delegateMethod.GetParameters().Select(p => p.ParameterType).ToArray();

            return DynamicMethodGenerator.GenerateStaticMethod(method, typeof(T), typeof(TOwner), delegateMethodParameters);
        }
    }

    public class InstanceMethodCache<TOwner> : MethodCache<TOwner>
    {
        protected override Delegate GetMethodDelegate(string method, Type returnValueType, Type[] args)
        {
            var parameters = new List<Type> { typeof(TOwner) };
            parameters.AddRange(args);
            parameters.Add(returnValueType);

            var delegateType = Expression.GetDelegateType(parameters.ToArray());

            return DynamicMethodGenerator.GenerateInstanceMethod(method, delegateType, typeof(TOwner), args);
        }

        protected override Delegate GetMethodDelegate<T>(string method)
        {
            if (!typeof(T).IsSubclassOf(typeof(Delegate))) throw new ArgumentException("The generic type must be a delegate.");

            var delegateMethod = typeof(T).GetMethod("Invoke");
            var delegateMethodParameters = delegateMethod.GetParameters().Select(p => p.ParameterType).ToArray();
            if (delegateMethodParameters.First() != typeof(TOwner)) throw new ArgumentException(string.Format("The first argument type must be {0} on an instance method.", typeof(T).Name));

            return DynamicMethodGenerator.GenerateInstanceMethod(method, typeof(T), typeof(TOwner), delegateMethodParameters.Skip(1).ToArray());
        }
    }

}