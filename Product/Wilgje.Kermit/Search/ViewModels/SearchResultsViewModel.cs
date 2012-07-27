using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.Messages;
using Willow.Kermit.Search.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.Search.ViewModels
{
    [Export(typeof(ITabViewModel))]
    [Export(typeof(ISearchResults))]
    public class SearchResultsViewModel : Screen, ISearchResultsViewModel
    {
        string _SearchString;

        public SearchResultsViewModel()
        {
            Caption = "Zoeken";

            Image = ImageGetter.SearchIcon;

        }

        public string Caption { get; set; }

        public BitmapImage Image { get; set; }

        public IEventAggregator Events { get; set; }

        public string SearchString
        {
            get { return _SearchString; }
            set { _SearchString = value; NotifyOfPropertyChange(() => SearchString);
            }
        }

        public ObservableCollection<string> Results
        {
            get
            {
                return new ObservableCollection<string>(new[]
                {
                    string.Format("{0}: Resultaat {1}", SearchString, 1),
                    string.Format("{0}: Resultaat {1}", SearchString, 2),
                    string.Format("{0}: Resultaat {1}", SearchString, 3),
                    string.Format("{0}: Resultaat {1}", SearchString, 4),
                    string.Format("{0}: Resultaat {1}", SearchString, 5),
                    string.Format("{0}: Resultaat {1}", SearchString, 6),
                    string.Format("{0}: Resultaat {1}", SearchString, 7)
                });
            }
        } 

        public void Close()
        {
            if (Events != null)
                Events.Publish(new CloseTabMessage { Item = this });
        }

        public void Search()
        {
            NotifyOfPropertyChange(() => HasResults);
            NotifyOfPropertyChange(() => Results);
        }

        public bool HasResults { get { return !string.IsNullOrWhiteSpace(SearchString); } }
    }
}