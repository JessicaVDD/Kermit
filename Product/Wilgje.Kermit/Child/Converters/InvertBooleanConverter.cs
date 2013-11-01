using System;
using System.Windows.Data;

namespace Willow.Kermit.Child.Converters
{
    public class InvertBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool)) return value;

            var theBool = (bool)value;
            return !theBool;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool)) return value;

            var theBool = (bool)value;
            return !theBool;
        }
    }
}
