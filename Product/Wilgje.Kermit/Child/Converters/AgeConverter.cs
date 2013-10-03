using System;
using System.Globalization;
using System.Windows.Data;

namespace Willow.Kermit.Child.Converters
{
    public class AgeConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2) return null;

            var bday = (DateTime?)values[0];
            var isEstimated = System.Convert.ToBoolean(values[1] ?? false);
            return GetAgeString(bday, isEstimated);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] {null, null};
        }

        static string GetAgeString(DateTime? birthDate, bool isEstimated)
        {
            if (!birthDate.HasValue) return "Leeftijd: Onbekend";

            var bDay = birthDate.Value;
            if (bDay > DateTime.Today)
            {
                var weken = (bDay - DateTime.Today).Days / 7;
                if (weken == 0)
                    return string.Format("Geboorte in: {0} dagen", (bDay - DateTime.Today).Days);
                return string.Format("Geboorte in: {0} {1}", weken, weken == 1 ? "week" : "weken");
            }

            return string.Format("{0}: {1}", isEstimated ? "Geschatte leeftijd" : "Leeftijd", FormatAge(bDay));
        }

        static string FormatAge(DateTime bday)
        {
            var today = DateTime.Today;
            var age = today - bday;

            if (age.Days < 7)
            {
                return string.Format("{0} {1}", age.Days, age.Days == 1 ? "dag" : "dagen");
            }
            if (today < bday.AddMonths(3))
            {
                var weeks = age.Days / 7;
                return string.Format("{0} {1}", weeks, weeks == 1 ? "week" : "weken");
            }
            if (today < bday.AddYears(1))
            {
                var months = today.Month - bday.Month < 0 ? today.Month - bday.Month + 12 : today.Month - bday.Month;
                return string.Format("{0} {1}", months, months == 1 ? "maand" : "maanden");
            }
            if (today < bday.AddYears(2))
            {
                var months = today.Month - bday.AddYears(1).Month < 0 ? today.Month - bday.AddYears(1).Month + 12 : today.Month - bday.AddYears(1).Month;
                
                if (months == 0) 
                    return "1 jaar";

                return string.Format("1 jaar en {0} {1}", months, months == 1 ? "maand" : "maanden");
            }
            return string.Format("{0} jaar", today.Year - bday.Year);
        }

    }
}
