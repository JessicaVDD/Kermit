using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Caliburn.Micro;

namespace Willow.Kermit.Model
{
    public class Client : PropertyChangedBase
    {
        public Client()
        {
            IsEstimatedBirthday = true;
        }

        public BitmapImage Image { get; set; }

        DateTime? birth_date;
        public DateTime? BirthDate
        {
            get { return birth_date; }
            set
            {
                birth_date = value; 
                NotifyOfPropertyChange(()=> BirthDate);
                IsEstimatedBirthday = !birth_date.HasValue || birth_date > DateTime.Today;
            }
        }

        public bool IsEstimatedBirthday { get; set; }
        public string AgeFormatted { get { return GetAgeString(); } }

        Gender gender;
        public Gender Gender
        {
            get { return gender; }
            set { gender = value; NotifyOfPropertyChange(() => Gender); }
        }

        public string Status { get; set; }
        public string Location { get; set; }
        public string ResidentialGroup { get; set; }
        public string FirstName { get; set; }
        public string FirstNameTitle { get { return FirstName ?? "(Nog geen naam)"; } }

        public IList<Relation> Relations { get; set; }

        public string LastName { get; set; }

        public string BirthPlace { get; set; }

        string GetAgeString()
        {
            if (!BirthDate.HasValue) return "(leeftijd onbekend)";

            var bDay = BirthDate.Value;
            if (bDay <= DateTime.Today)
            {
                return (IsEstimatedBirthday ? "Geschatte Leeftijd: " : "Leeftijd: ") + FormatTimeSpan(DateTime.Today - bDay);
            }
            else
            {
                return "Geboorte in: " + FormatTimeSpan(bDay - DateTime.Today);
            }
        }
        string FormatTimeSpan(TimeSpan time_span)
        {
            if (time_span.Days < 31)
                return time_span.Days == 1 ? "1 dag" : time_span.Days.ToString("N0") + " dagen";
            if (time_span.Days < 366)
                return (time_span.Days / 30) < 2 ? "1 maand" : (time_span.Days / 30).ToString("N0") + " maanden";
            if (time_span.Days <= 366 * 2)
            {
                double days = (time_span.Days - 365);
                if (days < 31)
                    return "1 jaar";
                return "1 jaar " + (days / 30 < 2 ? "1 maand" : (days / 30).ToString("N0") + " maanden");
            }
            return (time_span.Days / 365).ToString("N0") + "jaar";
        }
    }
}