namespace Willow.Kermit.General.Interfaces
{
    public interface ISearchResults : ITabViewModel
    {
        string SearchString { get; set; }
    }

    public interface ISearchResultsFactory : ITabViewModelFactory
    {
        ISearchResults Create(string searchText);
    }
}