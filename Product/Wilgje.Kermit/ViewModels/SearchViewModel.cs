using System;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.Messages;
using Willow.Kermit.Util;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class SearchViewModel : ISearchViewModel
    {
        IEventAggregator _events;

        public SearchViewModel(IEventAggregator events)
        {
            this._events = events;
            Search = new ImageGetter().Get("Search.ico");
            SearchText = null;
        }

        public SearchViewModel() : this(new EventAggregator()) { }

        public IEventAggregator Events { get { return _events; } }

        public string SearchText { get; set; }
        public BitmapImage Search  { get; set; }
        public void DoSearch()
        {
            if (Events != null)
                Events.Publish(new ShowTabViewMessage { Item = new SearchResultsViewModel {SearchString = SearchText} });
        }
    }
}