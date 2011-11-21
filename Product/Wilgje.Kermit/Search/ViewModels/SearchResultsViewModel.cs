using Caliburn.Micro;
using Willow.Kermit.General.Messages;
using Willow.Kermit.Search.Interfaces;

namespace Willow.Kermit.Search.ViewModels
{
    public class SearchResultsViewModel : Screen, ISearchResultsViewModel
    {
        public SearchResultsViewModel()
        {
            Caption = "Zoeken";
        }

        public string Caption { get; set; }
        public IEventAggregator Events { get; set; }

        public string SearchString { get; set; }

        public void Close()
        {
            if (Events != null)
                Events.Publish(new CloseTabMessage { Item = this });
        }
    }
}