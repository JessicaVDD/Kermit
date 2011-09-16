using System;
using System.Windows.Media.Imaging;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class SearchViewModel : ISearchViewModel
    {
        public SearchViewModel()
        {
            Search = new BitmapImage(new Uri("/Search.ico", UriKind.Relative));
            SearchText = null;
        }

        public string SearchText { get; set; }
        public BitmapImage Search  { get; set; }
    }
}