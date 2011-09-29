using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.Messages;
using Willow.Kermit.Util;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class HomeViewModel : Screen, IHomeViewModel
    {
        public IEventAggregator Events { get; set; }

        public HomeViewModel()
        {
            Caption = "Home";
            var imageGetter = new ImageGetter();
            NewKid = imageGetter.Get("Jaidee.png");
            Search = imageGetter.Get("Search2.ico");
            Doctors = imageGetter.Get("Doctor.png");
            Calendar = imageGetter.Get("Calendar.png");
        }

        public BitmapImage NewKid { get; set; }
        public BitmapImage Search { get; set; }
        public BitmapImage Doctors { get; set; }
        public BitmapImage Calendar { get; set; }

        string tab_name;
        public string Caption
        {
            get { return tab_name; }
            set { tab_name = value; NotifyOfPropertyChange(() => tab_name); }
        }

        public void Close()
        {
            if (Events != null)
                Events.Publish(new CloseTabMessage {Item = this});
        }

        public void CreateNewKid()
        {
            ShowTab(new NewKidViewModel());
        }

        public void ShowTab(ITabViewModel view_model)
        {
            if (Events != null) 
                Events.Publish(new ShowTabViewMessage {Item = view_model});
        }
    }

    public enum HomeViewButtons
    {
        NewKid,
        Search,
        Doctors,
        Calendar
    }
}