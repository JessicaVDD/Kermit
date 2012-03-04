using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.Model;

namespace Willow.Kermit.Child.ViewModels
{
    public class ChildVisualCardViewModel : Screen
    {
        Client _child;

        public ChildVisualCardViewModel(Client child)
        {
            _child = child;
        }

        public BitmapImage ChildImage
        {
            get { return _child.Image; }
            set { _child.Image = value; NotifyOfPropertyChange(() => ChildImage); }
        }

        public string Naam
        {
            get { return _child.FirstNameTitle; }
        }

        public string Age
        {
            get { return _child.AgeFormatted; }
        }

        public string Status
        {
            get { return _child.Status; }
            set { _child.Status = value; NotifyOfPropertyChange(() => Status); }
        }

        public string Location
        {
            get { return _child.Location; }
            set { _child.Location = value; NotifyOfPropertyChange(() => Location); }
        }

        public string ResidentialGroup
        {
            get { return _child.ResidentialGroup; }
            set { _child.ResidentialGroup = value; NotifyOfPropertyChange(() => ResidentialGroup); }
        }

    }
}