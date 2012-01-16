using System.Collections.Generic;
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
                new ImageButton {Text = "Nieuw kindjes", Image = ImageGetter.Baby, DoClick = () => ShowTab(new NewChildViewModel())},
                new ImageButton {Text = "Zoeken", Image = ImageGetter.Search, DoClick = () => ShowTab(new SearchResultsViewModel())},
                new ImageButton {Text = "Hulpverleners", Image = ImageGetter.SocialWorkers, DoClick = () => ShowTab(new SocialWorkersViewModel())},
                new ImageButton {Text = "Kalender", Image = ImageGetter.Calendar, DoClick = () => { }}
            };
        }

        public IList<ImageButton> AvailableButtons { get; private set; }

        string tab_name;
        public string Caption
        {
            get { return tab_name; }
            set { tab_name = value; NotifyOfPropertyChange(() => tab_name); }
        }

        public void DoShow(ImageButton ib)
        {
            ib.DoClick();
        }

        public void ShowTab(ITabViewModel view_model)
        {
            if (Events != null) 
                Events.Publish(new ShowTabViewMessage {Item = view_model});
        }

        void ITabViewModel.Close() { }
    }
}