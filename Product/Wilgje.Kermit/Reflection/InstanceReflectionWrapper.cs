using System;
using System.Reflection;

namespace Willow.Kermit
{
    public class InstanceReflectionWrapper : StaticReflectionWrapper
    {
        const BindingFlags _InstanceBinding = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        readonly object _BaseObject;

        public InstanceReflectionWrapper(object baseObject) : base(baseObject == null ? null : baseObject.GetType())
        {
            if (baseObject == null) throw new ArgumentNullException("baseObject");

            this._BaseObject = baseObject;
        }

        public object Method(string methodName, params object[] parameters)
        {
            var method = BaseType.GetMethod(methodName, _InstanceBinding);
            if (method == null) throw new ArgumentException("The method cannot be found.", "methodName");
            
            return method.Invoke(this._BaseObject, _InstanceBinding, null, parameters.Length == 0 ? null : parameters, null);
        }

        public T Method<T>(string methodName, params object[] parameters)
        {
            return (T) this.Method(methodName, parameters);
        }

        public object GetField(string fieldName)
        {
            var field = BaseType.GetField(fieldName, _InstanceBinding);
            if (field == null) throw new ArgumentException("The field cannot be found.", "fieldName");
            
            return field.GetValue(this._BaseObject);
        }

        public T GetField<T>(string fieldName)
        {
            return (T)this.GetField(fieldName);
        }
    }
}