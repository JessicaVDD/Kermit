using System;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.Util;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class HomeViewModel : Screen, IHomeViewModel
    {
        public HomeViewModel()
        {
            var imageGetter = new ImageGetter();
            NewKid = imageGetter.Get("Jaidee.png");
            Search = imageGetter.Get("Search.ico");
            Doctors = imageGetter.Get("Doctor.png");
            Calendar = imageGetter.Get("Calendar.jpg");
        }

        public BitmapImage NewKid { get; set; }
        public BitmapImage Search { get; set; }
        public BitmapImage Doctors { get; set; }
        public BitmapImage Calendar { get; set; }
    }
}