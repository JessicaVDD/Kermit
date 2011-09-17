using System;
using System.Windows.Media.Imaging;
using Willow.Kermit.Util;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class SearchViewModel : ISearchViewModel
    {
        public SearchViewModel()
        {
            Search = new BitmapImage(new UriResolver().Resolve("Search.ico"));
            SearchText = null;
        }

        public string SearchText { get; set; }
        public BitmapImage Search  { get; set; }
    }
}