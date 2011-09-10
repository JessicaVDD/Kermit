namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface IShellViewModel
    {
        INavigationViewModel Navigation { get; set; }
        ISearchViewModel Search { get; set; }
        IArtViewModel Art { get; set; }
        IStatusViewModel Status { get; set; }
        IActionTabViewModel ActionTabs { get; set; }
    }
}