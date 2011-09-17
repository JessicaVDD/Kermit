using System.ComponentModel;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface IShellViewModel : INotifyPropertyChanged
    {
        INavigationViewModel Navigation { get; set; }
        ISearchViewModel Search { get; set; }
        IArtViewModel Art { get; set; }
        IStatusViewModel Status { get; set; }
        IActionTabsViewModel ActionTabs { get; set; }
    }
}