using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Willow.Kermit
{
    public static class DynamicMethodGenerator
    {
        const BindingFlags _InstanceBinding = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
        const BindingFlags _StaticBinding = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

        static string GenerateDynamicMethodName(string baseName)
        {
            return string.Format("{0}_{1:n}", baseName, Guid.NewGuid());
        }

        internal static Action<TOwner, object> GenerateInstanceFieldSetter<TOwner>(string fieldName)
        {
            var fld = typeof(TOwner).GetField(fieldName, _InstanceBinding);
            return GenerateInstanceFieldSetter<TOwner>(fld);
        }
        internal static Action<TOwner, TField> GenerateInstanceFieldSetter<TOwner, TField>(string fieldName)
        {
            var fld = typeof(TOwner).GetField(fieldName, _InstanceBinding);
            return GenerateInstanceFieldSetter<TOwner, TField>(fld);
        }
        internal static Action<TOwner, object> GenerateInstanceFieldSetter<TOwner>(FieldInfo fld)
        {
            return GenerateInstanceFieldSetter<TOwner, object>(fld);
        }
        public static Action<TOwner, TField> GenerateInstanceFieldSetter<TOwner, TField>(FieldInfo fld)
        {
            if (fld == null) throw new ArgumentNullException("fld");
            if (fld.ReflectedType != typeof(TOwner)) throw new ArgumentException("The reflected type doesn't match the TOwner", "fld");
            if (typeof(object) != typeof(TField) && fld.FieldType != typeof(TField)) throw new ArgumentException("The field type doesn't match the TField", "fld");

            var dyn = new DynamicMethod(GenerateDynamicMethodName(fld.Name), null, new[] { typeof(TOwner), typeof(TField) }, typeof(TOwner), true);
            var gen = dyn.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldarg_1);
            if (typeof(TField) == typeof(object) && fld.FieldType.IsValueType)
                gen.Emit(OpCodes.Unbox_Any, fld.FieldType);
            gen.Emit(OpCodes.Stfld, fld);
            gen.Emit(OpCodes.Ret);

            return (Action<TOwner, TField>) dyn.CreateDelegate(typeof(Action<TOwner,TField>));
        }

        internal static Func<TOwner, object> GenerateInstanceFieldGetter<TOwner>(string fieldName)
        {
            var fld = typeof(TOwner).GetField(fieldName, _InstanceBinding);
            return GenerateInstanceFieldGetter<TOwner, object>(fld);
        }
        internal static Func<TOwner, TField> GenerateInstanceFieldGetter<TOwner, TField>(string fieldName)
        {
            var fld = typeof(TOwner).GetField(fieldName, _InstanceBinding);
            return GenerateInstanceFieldGetter<TOwner, TField>(fld);
        }
        internal static Func<TOwner, object> GenerateInstanceFieldGetter<TOwner>(FieldInfo fld)
        {
            return GenerateInstanceFieldGetter<TOwner, object>(fld);
        }
        public static Func<TOwner, TField> GenerateInstanceFieldGetter<TOwner, TField>(FieldInfo fld)
        {
            if (fld == null) throw new ArgumentNullException("fld");
            if (fld.ReflectedType != typeof(TOwner)) throw new ArgumentException("The reflected type doesn't match the TOwner", "fld");
            if (typeof(TField) != typeof(object) && fld.FieldType != typeof(TField)) throw new ArgumentException("The field type doesn't match the TField", "fld");

            var dyn = new DynamicMethod(GenerateDynamicMethodName(fld.Name), typeof(TField), new[] { typeof(TOwner) }, typeof(TOwner), true);
            var gen = dyn.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldfld, fld);
            if (typeof(TField) == typeof(object) && fld.FieldType.IsValueType)
                gen.Emit(OpCodes.Box, fld.FieldType);
            gen.Emit(OpCodes.Ret);

            return (Func<TOwner, TField>)dyn.CreateDelegate(typeof(Func<TOwner,TField>));
        }

        internal static Action<TOwner, object> GenerateInstancePropertySetter<TOwner>(string propName)
        {
            var prop = typeof(TOwner).GetProperty(propName, _InstanceBinding);
            return GenerateInstancePropertySetter<TOwner>(prop);
        }
        internal static Action<TOwner, TProperty> GenerateInstancePropertySetter<TOwner, TProperty>(string propName)
        {
            var prop = typeof(TOwner).GetProperty(propName, _InstanceBinding);
            return GenerateInstancePropertySetter<TOwner, TProperty>(prop);
        }
        internal static Action<TOwner, object> GenerateInstancePropertySetter<TOwner>(PropertyInfo prop)
        {
            return GenerateInstancePropertySetter<TOwner, object>(prop);
        }
        public static Action<TOwner, TProperty> GenerateInstancePropertySetter<TOwner, TProperty>(PropertyInfo prop)
        {
            if (prop == null) throw new ArgumentNullException("prop");
            if (prop.ReflectedType != typeof(TOwner)) throw new ArgumentException("The reflected type doesn't match the TOwner", "prop");
            if (typeof(TProperty) != typeof(object) && prop.PropertyType != typeof(TProperty)) throw new ArgumentException("The property type doesn't match the TProperty", "prop");
            if (!prop.CanWrite) throw new InvalidOperationException(string.Format("The property {0} cannot be written to", prop.Name));

            var setMethod = prop.GetSetMethod(true);

            var dyn = new DynamicMethod(GenerateDynamicMethodName(prop.Name), null, new[] { typeof(TOwner), typeof(TProperty) }, typeof(TOwner), true);
            var gen = dyn.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldarg_1);
            if (typeof(TProperty) == typeof(object) && prop.PropertyType.IsValueType)
                gen.Emit(OpCodes.Unbox_Any, prop.PropertyType);
            if (setMethod.IsVirtual)
                gen.Emit(OpCodes.Callvirt, setMethod);
            else
                gen.Emit(OpCodes.Call, setMethod);
            gen.Emit(OpCodes.Ret);
            return dyn.CreateDelegate(typeof(Action<TOwner, TProperty>)) as Action<TOwner, TProperty>;
        }

        internal static Func<TOwner, object> GenerateInstancePropertyGetter<TOwner>(string propName)
        {
            var prop = typeof(TOwner).GetProperty(propName, _InstanceBinding);
            return GenerateInstancePropertyGetter<TOwner, object>(prop);
        }
        internal static Func<TOwner, TProperty> GenerateInstancePropertyGetter<TOwner, TProperty>(string propName)
        {
            var prop = typeof(TOwner).GetProperty(propName, _InstanceBinding);
            return GenerateInstancePropertyGetter<TOwner, TProperty>(prop);
        }
        internal static Func<TOwner, object> GenerateInstancePropertyGetter<TOwner>(PropertyInfo prop)
        {
            return GenerateInstancePropertyGetter<TOwner, object>(prop);
        }
        public static Func<TOwner, TProperty> GenerateInstancePropertyGetter<TOwner, TProperty>(PropertyInfo prop)
        {
            if (prop == null) throw new ArgumentNullException("prop");
            if (prop.ReflectedType != typeof(TOwner)) throw new ArgumentException("The reflected type doesn't match the TOwner", "prop");
            if (typeof(TProperty) != typeof(object) && prop.PropertyType != typeof(TProperty)) throw new ArgumentException("The property type doesn't match the TProperty", "prop");
            if (!prop.CanRead) throw new InvalidOperationException(string.Format("The property {0} cannot be read from.", prop.Name));

            var getMethod = prop.GetGetMethod(true);
            
            var dyn = new DynamicMethod(GenerateDynamicMethodName(prop.Name), typeof(TProperty), new[] { typeof(TOwner) }, typeof(TOwner), true);
            var gen = dyn.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            if (getMethod.IsVirtual)
                gen.Emit(OpCodes.Callvirt, getMethod);
            else
                gen.Emit(OpCodes.Call, getMethod);
            if (typeof(TProperty) == typeof(object) && prop.PropertyType.IsValueType)
                gen.Emit(OpCodes.Box, prop.PropertyType);
            gen.Emit(OpCodes.Ret);
            return dyn.CreateDelegate(typeof(Func<TOwner, TProperty>)) as Func<TOwner, TProperty>;
        }

        internal static Func<object> GenerateStaticFieldGetter<TOwner>(string fieldName)
        {
            var fld = typeof(TOwner).GetField(fieldName, _StaticBinding);
            return GenerateStaticFieldGetter<TOwner>(fld);
        }
        internal static Func<TField> GenerateStaticFieldGetter<TOwner, TField>(string fieldName)
        {
            var fld = typeof(TOwner).GetField(fieldName, _StaticBinding);
            return GenerateStaticFieldGetter<TOwner, TField>(fld);
        }
        internal static Func<object> GenerateStaticFieldGetter<TOwner>(FieldInfo fld)
        {
            return GenerateStaticFieldGetter<TOwner, object>(fld);
        }
        public static Func<TField> GenerateStaticFieldGetter<TOwner, TField>(FieldInfo fld)
        {
            if (fld == null) throw new ArgumentNullException("fld");
            if (fld.ReflectedType != typeof(TOwner)) throw new ArgumentException("The reflected type doesn't match the TOwner", "fld");
            if (typeof(TField) != typeof(object) && fld.FieldType != typeof(TField)) throw new ArgumentException("The field type doesn't match the TField", "fld");

            var dyn = new DynamicMethod(GenerateDynamicMethodName(fld.Name), typeof(TField), null, typeof(TOwner), true);
            var gen = dyn.GetILGenerator();
            gen.Emit(OpCodes.Ldsfld, fld);
            if (typeof(TField) == typeof(object) && fld.FieldType.IsValueType)
                gen.Emit(OpCodes.Box, fld.FieldType);
            gen.Emit(OpCodes.Ret);
            return dyn.CreateDelegate(typeof(Func<TField>)) as Func<TField>;
        }

        internal static Action<object> GenerateStaticFieldSetter<TOwner>(string fieldName)
        {
            var fld = typeof(TOwner).GetField(fieldName, _StaticBinding);
            return GenerateStaticFieldSetter<TOwner>(fld);
        }
        internal static Action<TField> GenerateStaticFieldSetter<TOwner, TField>(string fieldName)
        {
            var fld = typeof(TOwner).GetField(fieldName, _StaticBinding);
            return GenerateStaticFieldSetter<TOwner, TField>(fld);
        }
        internal static Action<object> GenerateStaticFieldSetter<TOwner>(FieldInfo fld)
        {
            return GenerateStaticFieldSetter<TOwner, object>(fld);
        }
        public static Action<TField> GenerateStaticFieldSetter<TOwner, TField>(FieldInfo fld)
        {
            if (fld == null) throw new ArgumentNullException("fld");
            if (fld.ReflectedType != typeof(TOwner)) throw new ArgumentException("The reflected type doesn't match the TOwner", "fld");
            if (typeof(TField) != typeof(object) && fld.FieldType != typeof(TField)) throw new ArgumentException("The field type doesn't match the TField", "fld");

            var dyn = new DynamicMethod(GenerateDynamicMethodName(fld.Name), null, new [] {typeof(TField)}, typeof(TOwner), true);
            var gen = dyn.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            if (typeof(TField) == typeof(object) && fld.FieldType.IsValueType)
                gen.Emit(OpCodes.Unbox_Any, fld.FieldType);
            gen.Emit(OpCodes.Stsfld, fld);
            gen.Emit(OpCodes.Ret);
            return dyn.CreateDelegate(typeof(Action<TField>)) as Action<TField>;
        }

        internal static Func<object> GenerateStaticPropertyGetter<TOwner>(string propName)
        {
            var prop = typeof(TOwner).GetProperty(propName, _StaticBinding);
            return GenerateStaticPropertyGetter<TOwner>(prop);
        }
        internal static Func<TProperty> GenerateStaticPropertyGetter<TOwner, TProperty>(string propName)
        {
            var prop = typeof(TOwner).GetProperty(propName, _StaticBinding);
            return GenerateStaticPropertyGetter<TOwner, TProperty>(prop);
        }
        internal static Func<object> GenerateStaticPropertyGetter<TOwner>(PropertyInfo prop)
        {
            return GenerateStaticPropertyGetter<TOwner, object>(prop);
        }
        public static Func<TProperty> GenerateStaticPropertyGetter<TOwner, TProperty>(PropertyInfo prop)
        {
            if (prop == null) throw new ArgumentNullException("prop");
            if (prop.ReflectedType != typeof(TOwner)) throw new ArgumentException("The reflected type doesn't match the TOwner", "prop");
            if (typeof(TProperty) != typeof(object) && prop.PropertyType != typeof(TProperty)) throw new ArgumentException("The field type doesn't match the TProperty", "prop");
            if (!prop.CanRead) throw new InvalidOperationException(string.Format("The property {0} cannot be read from.", prop.Name));

            var getMethod = prop.GetGetMethod(true);

            var dyn = new DynamicMethod(GenerateDynamicMethodName(prop.Name), typeof(TProperty), Type.EmptyTypes, typeof(TOwner), true);
            var gen = dyn.GetILGenerator();
            if (getMethod.IsVirtual)
                gen.Emit(OpCodes.Callvirt, getMethod);
            else
                gen.Emit(OpCodes.Call, getMethod);
            if (typeof(TProperty) == typeof(object) && prop.PropertyType.IsValueType)
                gen.Emit(OpCodes.Box, prop.PropertyType);
            gen.Emit(OpCodes.Ret);
            return dyn.CreateDelegate(typeof(Func<TProperty>)) as Func<TProperty>;
        }

        internal static Action<object> GenerateStaticPropertySetter<TOwner>(string propName)
        {
            var prop = typeof(TOwner).GetProperty(propName, _StaticBinding);
            return GenerateStaticPropertySetter<TOwner>(prop);
        }
        internal static Action<TProperty> GenerateStaticPropertySetter<TOwner, TProperty>(string propName)
        {
            var prop = typeof(TOwner).GetProperty(propName, _StaticBinding);
            return GenerateStaticPropertySetter<TOwner, TProperty>(prop);
        }
        internal static Action<object> GenerateStaticPropertySetter<TOwner>(PropertyInfo prop)
        {
            return GenerateStaticPropertySetter<TOwner, object>(prop);
        }
        public static Action<TProperty> GenerateStaticPropertySetter<TOwner, TProperty>(PropertyInfo prop)
        {
            if (prop == null) throw new ArgumentNullException("prop");
            if (prop.ReflectedType != typeof(TOwner)) throw new ArgumentException("The reflected type doesn't match the TOwner", "prop");
            if (typeof(TProperty) != typeof(object) && prop.PropertyType != typeof(TProperty)) throw new ArgumentException("The property type doesn't match the TProperty", "prop");
            if (!prop.CanWrite) throw new InvalidOperationException(string.Format("The property {0} cannot be written to", prop.Name));

            var setMethod = prop.GetSetMethod(true);

            var dyn = new DynamicMethod(GenerateDynamicMethodName(prop.Name), null, new[] { typeof(TProperty) }, typeof(TOwner), true);
            var gen = dyn.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            if (typeof(TProperty) == typeof(object) && prop.PropertyType.IsValueType)
                gen.Emit(OpCodes.Unbox_Any, prop.PropertyType);
            if (setMethod.IsVirtual)
                gen.Emit(OpCodes.Callvirt, setMethod);
            else
                gen.Emit(OpCodes.Call, setMethod);
            gen.Emit(OpCodes.Ret);
            return dyn.CreateDelegate(typeof(Action<TProperty>)) as Action<TProperty>;
        }

        internal static Delegate GenerateInstanceMethod(string methodName, Type delegateType, Type owner, params Type[] argumentParameters)
        {
            var instanceMethod = owner.GetMethod(methodName, _InstanceBinding, null, argumentParameters, null);
            return GenerateInstanceMethod(instanceMethod, delegateType);
        }
        internal static T GenerateInstanceMethod<T>(string methodName, Type owner, params Type[] argumentParameters) where T : class
        {
            return GenerateInstanceMethod(methodName, typeof (T), owner, argumentParameters) as T;
        }
        public static Delegate GenerateInstanceMethod(MethodInfo method, Type delegateType)
        {
            if (method == null) throw new ArgumentNullException("method");

            var methodParams = new[] { method.ReflectedType }.Concat(method.GetParameters().Select(x => x.ParameterType)).ToArray();
            var dyn = new DynamicMethod(GenerateDynamicMethodName(method.Name), method.ReturnType, methodParams.ToArray(), method.ReflectedType, true);
            var gen = dyn.GetILGenerator();
            for (var i = 0; i < methodParams.Length; i++)
                gen.Emit(OpCodes.Ldarg, i);
            if (method.IsVirtual)
                gen.Emit(OpCodes.Callvirt, method);
            else
                gen.Emit(OpCodes.Call, method);
            gen.Emit(OpCodes.Ret);

            return dyn.CreateDelegate(delegateType);
        }
        internal static T GenerateInstanceMethod<T>(MethodInfo method) where T : class
        {
            return GenerateInstanceMethod(method, typeof (T)) as T;
        }

        internal static Delegate GenerateStaticMethod(string methodName, Type delegateType, Type owner, params Type[] argumentParameters)
        {
            var instanceMethod = owner.GetMethod(methodName, _StaticBinding, null, argumentParameters, null);
            return GenerateStaticMethod(instanceMethod, delegateType);
        }
        internal static T GenerateStaticMethod<T>(string methodName, Type owner, params Type[] argumentParameters) where T : class
        {
            var staticMethod = owner.GetMethod(methodName, _StaticBinding, null, argumentParameters, null);
            return GenerateStaticMethod<T>(staticMethod);
        }
        public static Delegate GenerateStaticMethod(MethodInfo method, Type delegateType)
        {
            if (method == null) throw new ArgumentNullException("method");

            var methodParams = new[] { method.ReflectedType }.Concat(method.GetParameters().Select(x => x.ParameterType)).ToArray();
            var dyn = new DynamicMethod(GenerateDynamicMethodName(method.Name), method.ReturnType, methodParams.ToArray(), method.ReflectedType, true);
            var gen = dyn.GetILGenerator();
            for (var i = 0; i < methodParams.Length; i++)
                gen.Emit(OpCodes.Ldarg, i);
            gen.Emit(OpCodes.Call, method);
            gen.Emit(OpCodes.Ret);

            return dyn.CreateDelegate(delegateType);
        }
        internal static T GenerateStaticMethod<T>(MethodInfo method) where T : class
        {
            return GenerateStaticMethod(method, typeof(T)) as T;
        }

    }
}
