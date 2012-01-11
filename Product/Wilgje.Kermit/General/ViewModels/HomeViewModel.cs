using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            AvailableButtons = new List<ImageButton>
            {
                new ImageButton {Text = "Nieuw kindjes", Image = ImageGetter.Baby},
                new ImageButton {Text = "Zoeken", Image = ImageGetter.Search},
                new ImageButton {Text = "Hulpverleners", Image = ImageGetter.SocialWorkers},
                new ImageButton {Text = "Kalender", Image = ImageGetter.Calendar}
            };
        }

        public IList<ImageButton> AvailableButtons { get; private set; }

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