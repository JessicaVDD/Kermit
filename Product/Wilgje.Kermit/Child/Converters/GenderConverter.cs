using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Willow.Kermit.Model;

namespace Willow.Kermit.Child.Converters
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var g = (Gender)value;
            if (typeof(Brush) == targetType)
            {
                switch (g)
                {
                    case Gender.Male:
                        return Brushes.CornflowerBlue;
                    case Gender.Female:
                        return Brushes.Plum;
                    default:
                        return Brushes.DarkGray;
                }
            }
            if (typeof(bool?) == targetType)
            {
                var targetGender = (Gender) Enum.Parse(typeof(Gender), (string)parameter);
                return targetGender == g;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var c = value as Brush;
            if (c != null)
            {
                if (c == Brushes.CornflowerBlue)
                    return Gender.Male;
                if (c == Brushes.Plum)
                    return Gender.Female;
                return Gender.Unknown;
            }

            if (value is bool)
            {
                var b = (bool) value;
                if (b)
                    return (Gender)Enum.Parse(typeof(Gender), (string)parameter);

            }


            return null;
        }
    }
}
