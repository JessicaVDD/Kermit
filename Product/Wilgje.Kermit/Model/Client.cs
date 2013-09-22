using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using Caliburn.Micro;

namespace Willow.Kermit.Model
{
    public class Client : PropertyChangedBase
    {
        readonly IObservableCollection<Family> families = new BindableCollection<Family>();
        DateTime? birth_date;
        Gender gender;
        BitmapImage image;
        bool is_estimated_birthday;
        string status;
        string location;
        string residential_group;
        string first_name;
        string birth_place;
        string last_name;

        public Client()
        {
            is_estimated_birthday = true;
        }

        public BitmapImage Image
        {
            get
            {
                if (image == null)
                    return DefaultBabyImage.For(Gender);
                return image;
            }
            set { image = value; NotifyOfPropertyChange(() => Image); }
        }

        public DateTime? BirthDate
        {
            get { return birth_date; }
            set
            {
                birth_date = value; 
                is_estimated_birthday = !birth_date.HasValue || birth_date > DateTime.Today;
                NotifyOfPropertyChange(() => BirthDate);
                NotifyOfPropertyChange(() => IsEstimatedBirthday);
                if (is_estimated_birthday) BirthPlace = null;
            }
        }
        public bool IsEstimatedBirthday
        {
            get { return is_estimated_birthday; }
        }

        public string BirthPlace
        {
            get { return birth_place; }
            set { birth_place = value; NotifyOfPropertyChange(() => BirthPlace); }
        }

        public Gender Gender
        {
            get { return gender; }
            set
            {
                gender = value; 
                NotifyOfPropertyChange(() => Gender);
                NotifyOfPropertyChange(() => Image);
            }
        }

        public string Status
        {
            get { return status; }
            set { status = value; NotifyOfPropertyChange(() => Status); }
        }

        public string Location
        {
            get { return location; }
            set { location = value; NotifyOfPropertyChange(() => Location); }
        }

        public string ResidentialGroup
        {
            get { return residential_group; }
            set { residential_group = value; NotifyOfPropertyChange(() => ResidentialGroup); }
        }

        public string FirstName
        {
            get { return first_name; }
            set
            {
                first_name = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public string LastName
        {
            get { return last_name; }
            set { last_name = value; NotifyOfPropertyChange(() => LastName);}
        }

        public IObservableCollection<Family> Families { get { return families; } }
    }
}