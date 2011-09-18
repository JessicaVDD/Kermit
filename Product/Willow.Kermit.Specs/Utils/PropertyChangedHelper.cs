using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Willow.Kermit.Specs.Utils
{
    public interface IPropertyChangedHelper<T> where T : INotifyPropertyChanged
    {
        void trigger_all_properties();
        bool has_fired(Expression<Func<T, object>> property);
    }

    public class PropertyChangedHelper<T> : IPropertyChangedHelper<T> where T : INotifyPropertyChanged
    {
        T _sut;
        IList<string> props_changed = new List<string>();

        public PropertyChangedHelper(T sut )
        {
            _sut = sut;
            _sut.PropertyChanged += Sut_PropertyChanged;
        }

        public void trigger_all_properties()
        {
            var props = typeof(T).GetProperties();
            foreach (var info in props)
            {
                Debug.WriteLine(string.Format("PropertyChangedHelper: Triggering {0}.", info.Name));
                var ctor = info.PropertyType.GetConstructor(Type.EmptyTypes);
                info.SetValue(_sut, ctor != null ? ctor.Invoke(null) : default(T), null);
            }

        }

        void Sut_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine(string.Format("PropertyChangedHelper: Received call for {0}", e.PropertyName));
            props_changed.Add(e.PropertyName);
        }

        public bool has_fired(Expression<Func<T, object>> property)
        {
            var memberExpression = ((property.Body is UnaryExpression) ? ((UnaryExpression) property.Body).Operand : property.Body) as MemberExpression;
            Debug.WriteLine(string.Format("PropertyChangedHelper: Checked call upon {0}", memberExpression == null ? "Illegal expression" : memberExpression.Member.Name));

            return memberExpression != null && props_changed.Contains(memberExpression.Member.Name);
        }
    }
}