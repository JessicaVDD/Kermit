using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.Messages;
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

            AvailableButtons = ServiceLocator.Current.GetInstances<ITabViewModelFactory>()
                .Select(x => new ImageButton { Text = x.Caption, Image = x.Image, DoClick = () => ShowTab(x.Create()) });
        }

        public IEnumerable<ImageButton> AvailableButtons { get; private set; }

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