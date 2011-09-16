using System;
using System.Windows.Media.Imaging;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        public NavigationViewModel()
        {
            Home = new BitmapImage(new Uri("file:///C:/Users/vandepe/My%20Sources/Persoonlijk/Blydhove/Kermit/Product/Wilgje.Kermit/Resources/Home.ico"));
            ArrowBack = new BitmapImage(new Uri("file:///C:/Users/vandepe/My%20Sources/Persoonlijk/Blydhove/Kermit/Product/Wilgje.Kermit/Resources/LeftArrowBlue.ico"));
            ArrowForward = new BitmapImage(new Uri("file:///C:/Users/vandepe/My%20Sources/Persoonlijk/Blydhove/Kermit/Product/Wilgje.Kermit/Resources/RightArrowBlue.ico"));
            Settings = new BitmapImage(new Uri("file:///C:/Users/vandepe/My%20Sources/Persoonlijk/Blydhove/Kermit/Product/Wilgje.Kermit/Resources/Settings.ico"));
            Help = new BitmapImage(new Uri("file:///C:/Users/vandepe/My%20Sources/Persoonlijk/Blydhove/Kermit/Product/Wilgje.Kermit/Resources/Help.ico"));
        }
        public BitmapImage Home { get; set; }
        public BitmapImage ArrowBack { get; set; }
        public BitmapImage ArrowForward { get; set; }
        public BitmapImage Settings { get; set; }
        public BitmapImage Help { get; set; }
    }
}