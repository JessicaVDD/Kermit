using System.ComponentModel.Composition;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels 
{
    [Export(typeof(IShell))]
    public class ShellViewModel : IShell, IShellViewModel {

        public ShellViewModel()
        {
            
        }

        public ShellViewModel(INavigationViewModel navigation, ISearchViewModel search, IArtViewModel art, IStatusViewModel status, IActionTabViewModel action_tabs)
        {
            Navigation = navigation;
            Search = search;
            Art = art;
            Status = status;
            ActionTabs = action_tabs;
        }

        public INavigationViewModel Navigation { get; set; }
        public ISearchViewModel Search { get; set; }
        public IArtViewModel Art { get; set; }
        public IStatusViewModel Status { get; set; }
        public IActionTabViewModel ActionTabs { get; set; }
    }
}
