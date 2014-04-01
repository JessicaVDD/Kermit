using System;
using System.Globalization;
using System.Windows.Data;
using Willow.Kermit.General.Interfaces;

namespace Willow.Kermit.General.Converters
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var g = (Genders?)value;
            if (typeof(bool?) == targetType)
            {
                var targetGender = (Genders)Enum.Parse(typeof(Genders), (string)parameter);
                return g.HasValue &&  targetGender == g.Value;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                var b = (bool) value;
                if (b)
                    return (Genders)Enum.Parse(typeof(Genders), (string)parameter);

            }
            return Genders.Unknown;
        }
    }
}
