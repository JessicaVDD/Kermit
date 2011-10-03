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
            NewChild = imageGetter.Get("Jaidee.png");
            Search = imageGetter.Get("Search2.ico");
            SocialWorkers = imageGetter.Get("Doctor.png");
            Calendar = imageGetter.Get("Calendar.png");
        }

        public BitmapImage NewChild { get; set; }
        public BitmapImage Search { get; set; }
        public BitmapImage SocialWorkers { get; set; }
        public BitmapImage Calendar { get; set; }

        string tab_name;
        public string Caption
        {
            get { return tab_name; }
            set { tab_name = value; NotifyOfPropertyChange(() => tab_name); }
        }

        public void ShowNewChild()
        {
            ShowTab(new NewChildViewModel());
        }

        public void ShowSearchResults()
        {
            ShowTab(new SearchResultsViewModel());
        }

        public void ShowSocialWorkers()
        {
            ShowTab(new SocialWorkersViewModel());
        }


        public void ShowTab(ITabViewModel view_model)
        {
            if (Events != null) 
                Events.Publish(new ShowTabViewMessage {Item = view_model});
        }

        void ITabViewModel.Close() { }
    }
}