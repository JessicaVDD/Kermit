using System.ComponentModel.Composition;
using Caliburn.Micro;
using Willow.Kermit.Shell.Interfaces;


namespace Willow.Kermit.Shell.ViewModels 
{
    [Export(typeof(KermitShell))]
    public class KermitShellViewModel : PropertyChangedBase, KermitShell
    {

        [ImportingConstructor]
        public KermitShellViewModel(ArtFiller artFiller, TopNavigation topNavigation, Main mainPanel, Search searchPanel, Status statusPanel)
        {
            Navigation = topNavigation;
            Art = artFiller;
            Main = mainPanel;
            Search = searchPanel;
            Status = statusPanel;
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
        public Search Search { get; set; }
        public Status Status { get; set; }
    }
}
