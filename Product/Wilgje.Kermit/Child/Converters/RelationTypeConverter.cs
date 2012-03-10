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
            var r = (RelationType) value;

            if (targetType == typeof(ImageSource))
            {
                switch (r)
                {
                    case RelationType.Broer:
                        return new ImageGetter().Get("Brother.png");
                    case RelationType.Zus:
                        return new ImageGetter().Get("Sister.jpg");
                    case RelationType.Papa:
                        return new ImageGetter().Get("Daddy.jpg");
                    case RelationType.Mama:
                        return new ImageGetter().Get("Mommy.jpg");
                    case RelationType.Opa:
                        return new ImageGetter().Get("Man.png");
                    case RelationType.Oma:
                        return new ImageGetter().Get("Woman.png");
                    case RelationType.Man:
                        return new ImageGetter().Get("Man.png");
                    default:
                        return new ImageGetter().Get("Woman.png");
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