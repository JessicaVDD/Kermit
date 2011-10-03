using Caliburn.Micro;
using Willow.Kermit.Messages;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
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