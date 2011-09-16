using System;
using System.Windows.Media.Imaging;
using Willow.Kermit.Util;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        public NavigationViewModel()
        {
            var uriResolver = new UriResolver();
            Home = new BitmapImage(uriResolver.Resolve("Home.ico"));
            ArrowBack = new BitmapImage(uriResolver.Resolve("LeftArrowBlue.ico"));
            ArrowForward = new BitmapImage(uriResolver.Resolve("RightArrowBlue.ico"));
            Settings = new BitmapImage(uriResolver.Resolve("Settings.ico"));
            Help = new BitmapImage(uriResolver.Resolve("Help.ico"));
        }
        public BitmapImage Home { get; set; }
        public BitmapImage ArrowBack { get; set; }
        public BitmapImage ArrowForward { get; set; }
        public BitmapImage Settings { get; set; }
        public BitmapImage Help { get; set; }
    }
}