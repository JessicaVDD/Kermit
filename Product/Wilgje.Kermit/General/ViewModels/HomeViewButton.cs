using System.Windows.Media.Imaging;
using Caliburn.Micro;

namespace Willow.Kermit.General.ViewModels
{
    public class HomeViewButton : Screen
    {
        BitmapImage image_source;
        public BitmapImage ImageSource
        {
            get { return image_source; }
            set { image_source = value; NotifyOfPropertyChange(() => image_source); }
        }

        string tab_name;
        public string ButtonCaption
        {
            get { return tab_name; }
            set { tab_name = value; NotifyOfPropertyChange(() => tab_name); }
        }
    }
}