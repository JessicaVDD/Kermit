using System;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.Messages;
using Willow.Kermit.Util;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        private IEventAggregator _events;

        public NavigationViewModel() : this(new EventAggregator())
        {
        }

        public NavigationViewModel(IEventAggregator events)
        {
            _events = events;

            var imageGetter = new ImageGetter();
            Home = imageGetter.Get("Home.ico");
            ArrowBack = imageGetter.Get("LeftArrowBlue.ico");
            ArrowForward = imageGetter.Get("RightArrowBlue.ico");
            Settings = imageGetter.Get("Settings.ico");
            Help = imageGetter.Get("Help.png"); 
        }

        public BitmapImage Home { get; set; }
        public BitmapImage ArrowBack { get; set; }
        public BitmapImage ArrowForward { get; set; }
        public BitmapImage Settings { get; set; }
        public BitmapImage Help { get; set; }
        
        public void GoHome()
        {
            _events.Publish(new ShowHomeMessage());
        }
    }
}