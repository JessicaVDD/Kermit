using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Willow.Kermit.Model;
using Willow.Kermit.Util;

namespace Willow.Kermit.Child.Converters
{
    public class RelationTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var r = (string) value;

            if (targetType == typeof(ImageSource))
            {
                switch (r)
                {
                    case "Broer":
                        return new DefaultImageGetter().Get("Brother.png");
                    case "Zus":
                        return new DefaultImageGetter().Get("Sister.jpg");
                    case "Papa":
                        return new DefaultImageGetter().Get("Daddy.jpg");
                    case "Mama":
                        return new DefaultImageGetter().Get("Mommy.jpg");
                    case "Opa":
                        return new DefaultImageGetter().Get("Man.png");
                    case "Oma":
                        return new DefaultImageGetter().Get("Woman.png");
                    case "Man":
                        return new DefaultImageGetter().Get("Man.png");
                    default:
                        return new DefaultImageGetter().Get("Woman.png");
                }
            }
            return r.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}