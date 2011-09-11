using System.ComponentModel;
using System.ComponentModel.Composition;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels 
{
    [Export(typeof(IShell))]
    public class ShellViewModel : Caliburn.Micro.PropertyChangedBase ,IShell, IShellViewModel {

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

        INavigationViewModel navigation;
        public INavigationViewModel Navigation
        {
            get { return navigation; }
            set { navigation = value;  NotifyOfPropertyChange(() => Navigation);}
        }

        ISearchViewModel search;
        public ISearchViewModel Search
        {
            get { return search; }
            set { search = value; NotifyOfPropertyChange(() => Search); }
        }

        IArtViewModel art;
        public IArtViewModel Art
        {
            get { return art; }
            set { art = value; NotifyOfPropertyChange(() => Art); }
        }

        IStatusViewModel status;
        public IStatusViewModel Status
        {
            get { return status; }
            set { status = value; NotifyOfPropertyChange(() => Status); }
        }

        IActionTabViewModel action_tabs;
        public IActionTabViewModel ActionTabs
        {
            get { return action_tabs; }
            set { action_tabs = value; NotifyOfPropertyChange(() => ActionTabs); }
        }
    }
}
