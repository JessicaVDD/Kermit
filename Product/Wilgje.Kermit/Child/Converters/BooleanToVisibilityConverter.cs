using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Willow.Kermit.Child.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        private Visibility trueVisibility = Visibility.Visible;
        private Visibility falseVisibility = Visibility.Collapsed;
        private bool isInverted = false;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType == typeof(Visibility))
            {
                var theBool = (bool)value;
                return theBool ^ IsInverted ? trueVisibility : falseVisibility;
            }

            if (targetType == typeof(bool))
            {
                var theVisibility = (Visibility)value;
                return theVisibility == trueVisibility ? true ^ IsInverted : false ^ IsInverted;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType == typeof(Visibility))
            {
                var theBool = (bool)value;
                return theBool ^ IsInverted ? trueVisibility : falseVisibility;
            }

            if (targetType == typeof(bool))
            {
                var theVisibility = (Visibility)value;
                return theVisibility == trueVisibility ? true ^ IsInverted : false ^ IsInverted;
            }

            return value;
        }

        public bool IsInverted
        {
            get { return isInverted; }
            set { isInverted = value; }
        }
        public Visibility FalseVisibility
        {
            get { return falseVisibility; }
            set { falseVisibility = value; }
        }
    }
}
