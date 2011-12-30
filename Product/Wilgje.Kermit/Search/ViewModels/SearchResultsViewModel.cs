using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.General.Messages;
using Willow.Kermit.Search.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.Search.ViewModels
{
    public class SearchResultsViewModel : Screen, ISearchResultsViewModel
    {
        public SearchResultsViewModel()
        {
            Caption = "Zoeken";

            var imageGetter = new ImageGetter();

            Image = imageGetter.Get("Search.ico");

        }

        public string Caption { get; set; }

        public BitmapImage Image { get; set; }

        public IEventAggregator Events { get; set; }

        public string SearchString { get; set; }

        public void Close()
        {
            if (Events != null)
                Events.Publish(new CloseTabMessage { Item = this });
        }
    }
}