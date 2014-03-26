using System.ComponentModel;

namespace Willow.Kermit.Shell.Interfaces
{
    public interface IShellViewModel : INotifyPropertyChanged
    {
        TopNavigation Navigation { get; set; }
        //ISearchViewModel Search { get; set; }
        ArtFiller Art { get; set; }
        //IStatusViewModel Status { get; set; }
        //IActionTabsViewModel ActionTabs { get; set; }
    }
}