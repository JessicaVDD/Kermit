using System.ComponentModel;
using Willow.Kermit.General.Interfaces;

namespace Willow.Kermit.Shell.Interfaces
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