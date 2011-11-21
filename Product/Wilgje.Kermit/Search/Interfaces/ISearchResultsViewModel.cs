using Willow.Kermit.General.Interfaces;

namespace Willow.Kermit.Search.Interfaces
{
    public interface ISearchResultsViewModel : ITabViewModel
    {
        string SearchString { get; set; }
    }
}