using System.ComponentModel.Composition;
using System.Windows.Media.Imaging;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.Search.ViewModels;
using Willow.Kermit.Util;

namespace Willow.Kermit.Search.Exports
{
    [Export(typeof(ITabViewModelFactory))]
    [Export(typeof(ISearchResultsFactory))]
    public class SearchResultsViewModelFactory : ISearchResultsFactory
    {
        public BitmapImage Image
        {
            get { return ImageGetter.Search; }
        }

        public string Caption
        {
            get { return "Zoeken"; }
        }

        public ITabViewModel Create()
        {
            return new SearchResultsViewModel();
        }

        public ISearchResults Create(string searchText)
        {
            return new SearchResultsViewModel { SearchString = searchText };
        }
    }

}