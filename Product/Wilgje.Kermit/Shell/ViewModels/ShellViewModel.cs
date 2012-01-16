using System.ComponentModel.Composition;
using Caliburn.Micro;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.ViewModels;
using Willow.Kermit.Shell.Interfaces;

namespace Willow.Kermit.Shell.ViewModels 
{
    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase ,IShell, IShellViewModel
    {
        IEventAggregator _events = new EventAggregator();

        public ShellViewModel()
        {
            Navigation = new NavigationViewModel(_events);
            Search = new SearchViewModel(_events);
            Art = new ArtViewModel();
            Status = new StatusViewModel();
            ActionTabs = new ActionTabsViewModel();

            Navigation.Events.Subscribe(ActionTabs);
            Search.Events.Subscribe(ActionTabs);
            Title = "Kermit";
        }

        public ShellViewModel(INavigationViewModel navigation, ISearchViewModel search, IArtViewModel art, IStatusViewModel status, IActionTabsViewModel action_tabs)
        {
            Navigation = navigation;
            Search = search;
            Art = art;
            Status = status;
            ActionTabs = action_tabs;
            Navigation.Events.Subscribe(ActionTabs);
        }

        string title;
        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(() => Title); }
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

        IActionTabsViewModel action_tabs;
        public IActionTabsViewModel ActionTabs
        {
            get { return action_tabs; }
            set { action_tabs = value; NotifyOfPropertyChange(() => ActionTabs); }
        }
    }
}
