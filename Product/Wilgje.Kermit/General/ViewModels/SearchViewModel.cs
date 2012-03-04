using System.Windows.Input;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.Messages;
using Willow.Kermit.Search.ViewModels;
using Willow.Kermit.Util;

namespace Willow.Kermit.General.ViewModels
{
    public class SearchViewModel : PropertyChangedBase, ISearchViewModel
    {
        IEventAggregator _events;

        public SearchViewModel(IEventAggregator events)
        {
            _events = events;
            Search = ImageGetter.SearchSmall;
            SearchText = null;
        }

        public SearchViewModel() : this(new EventAggregator()) { }

        public IEventAggregator Events { get { return _events; } }

        string search_text;
        public string SearchText
        {
            get { return search_text; }
            set { search_text = value; NotifyOfPropertyChange(()=> SearchText); }
        }

        public BitmapImage Search  { get; set; }
        public void DoSearch()
        {
            if (Events != null)
                Events.Publish(new ShowTabViewMessage { Item = new SearchResultsViewModel {SearchString = SearchText} });
            SearchText = null;
        }

        public void DoSearchWithEnter(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DoSearch();
                e.Handled = true;
            }
        }
    }
}