using System;
using System.Linq;
using System.Reflection;

namespace Willow.Kermit
{
    public class StaticReflectionWrapper
    {
        const BindingFlags _StaticBinding = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public;
        readonly Type _BaseType;

        public Type BaseType { get { return this._BaseType; } }

        public StaticReflectionWrapper(Type baseType)
        {
            if (baseType == null) throw new ArgumentNullException("baseType");
            this._BaseType = baseType;
        }

        public object StaticMethod(string methodName, params object[] parameters)
        {
            var method = this._BaseType.GetMethod(methodName, _StaticBinding);
            if (method == null) throw new ArgumentException("The method cannot be found.", "methodName");
            
            return method.Invoke(null, _StaticBinding, null, parameters.Length == 0 ? null : parameters, null);
        }

        public T StaticMethod<T>(string methodName, params object[] parameters)
        {
            return (T)this.StaticMethod(methodName, parameters);
        }

        public object GetStaticField(string fieldName)
        {
            var field = this._BaseType.GetField(fieldName, _StaticBinding);
            if (field == null) throw new ArgumentException("The field cannot be found.", "fieldName");
            
            return field.GetValue(null);
        }

        public T GetStaticField<T>(string fieldName)
        {
            return (T)this.GetStaticField(fieldName);
        }

        public static StaticReflectionWrapper Resolve(Assembly assembly, string typeName)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");

            var t = assembly.GetTypes().FirstOrDefault(x => x.Name == typeName);
            if (t == null) throw new ArgumentException("The type cannot be found.", "typeName");
            
            return new StaticReflectionWrapper(t);
        }
    }
}