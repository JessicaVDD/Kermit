using System.ComponentModel.Composition;
using Caliburn.Micro;
using Willow.Kermit.Shell.Interfaces;

namespace Willow.Kermit.Shell.ViewModels 
{
    [Export(typeof(IShell))]
    public class ShellViewModel : PropertyChangedBase ,IShell, IShellViewModel
    {

        [ImportingConstructor]
        public ShellViewModel(ArtFiller artFiller, TopNavigation topNavigation, Main mainPanel, SearchPanel searchPanel)
        {
            Navigation = topNavigation;
            Art = artFiller;
            Main = mainPanel;
            Search = searchPanel;
            //Navigation.Events.Subscribe(ActionTabs);
            //Search.Events.Subscribe(ActionTabs);
            Title = "Kermit";
        }

        string title;
        public string Title
        {
            get { return title; }
            set { title = value; NotifyOfPropertyChange(() => Title); }
        }

        public TopNavigation Navigation { get; set; }
        public ArtFiller Art { get; set; }
        public Main Main { get; set; }
        public SearchPanel Search { get; set; }
    }
}
