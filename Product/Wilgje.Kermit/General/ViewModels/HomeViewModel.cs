using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.Child.ViewModels;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.Messages;
using Willow.Kermit.Search.ViewModels;
using Willow.Kermit.SocialWorkers.ViewModels;
using Willow.Kermit.Util;

namespace Willow.Kermit.General.ViewModels
{
    public class HomeViewModel : Screen, IHomeViewModel
    {
        public BitmapImage Image { get; set; }

        public IEventAggregator Events { get; set; }

        public HomeViewModel()
        {
            Caption = "Home";
            
            Image = ImageGetter.Home;
            NewChild = ImageGetter.Baby;
            Search = ImageGetter.Search;
            SocialWorkers = ImageGetter.SocialWorkers;
            Calendar = ImageGetter.Calendar;
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