using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.Child.Converters;
using Willow.Kermit.Model;

namespace Willow.Kermit.Child.ViewModels
{
    public class ChildVisualCardViewModel : Screen
    {
        Client _child;

        public ChildVisualCardViewModel(Client child)
        {
            _child = child;
            _child.PropertyChanged += Child_PropertyChanged;
        }

        public BitmapImage ChildImage
        {
            get { return _child.Image; }
            set { _child.Image = value; }
        }

        public string Naam
        {
            get { return _child.FirstName; }
        }

        public DateTime? BirthDate
        {
            get { return _child.BirthDate; }
        }

        public bool IsEstimatedBirthday
        {
            get { return _child.IsEstimatedBirthday; }
        }

        public string Status
        {
            get { return _child.Status; }
            set { _child.Status = value; }
        }

        public string Location
        {
            get { return _child.Location; }
            set { _child.Location = value; }
        }

        public string ResidentialGroup
        {
            get { return _child.ResidentialGroup; }
            set { _child.ResidentialGroup = value; }
        }

        void Child_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Image":
                    NotifyOfPropertyChange(() => ChildImage);
                    break;
                case "FirstName":
                    NotifyOfPropertyChange(() => Naam);
                    break;
                case "BirthDate":
                    NotifyOfPropertyChange(() => BirthDate);
                    break;
                case "IsEstimatedBirthday":
                    NotifyOfPropertyChange(() => IsEstimatedBirthday);
                    break;
                case "Status":
                    NotifyOfPropertyChange(() => Status);
                    break;
                case "Location":
                    NotifyOfPropertyChange(() => Location);
                    break;
                case "ResidentialGroup":
                    NotifyOfPropertyChange(() => ResidentialGroup);
                    break;
            }
            if (String.IsNullOrWhiteSpace(e.PropertyName))
            {
                NotifyOfPropertyChange(e.PropertyName);
            }
        }


    }
}