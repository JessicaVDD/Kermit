using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.Messages;
using Willow.Kermit.Util;

namespace Willow.Kermit.General.ViewModels
{
    public class NavigationViewModel : INavigationViewModel
    {
        public NavigationViewModel() : this(new EventAggregator())
        {
        }

        public NavigationViewModel(IEventAggregator events)
        {
            Events = events;

            Home = ImageGetter.Home;
            ArrowBack = ImageGetter.ArrowLeft;
            ArrowForward = ImageGetter.ArrowRight;
            Settings = ImageGetter.Settings;
            Help = ImageGetter.Help;
        }

        public BitmapImage Home { get; set; }
        public BitmapImage ArrowBack { get; set; }
        public BitmapImage ArrowForward { get; set; }
        public BitmapImage Settings { get; set; }
        public BitmapImage Help { get; set; }

        public IEventAggregator Events { get; private set; }

        public void GoHome()
        {
            Events.Publish(new ShowHomeMessage());
        }
    }
}