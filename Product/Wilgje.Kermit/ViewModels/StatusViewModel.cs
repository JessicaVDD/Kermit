using System.Security.Principal;
using System.Threading;
using Caliburn.Micro;
using Willow.Kermit.Util;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class StatusViewModel : PropertyChangedBase, IStatusViewModel
    {
        public StatusViewModel() : this(WindowsSecurity.GetUserFullName()) { }

        public StatusViewModel(string identity)
        {
            Welcome = string.Format("Welcome {0}", identity);
        }


        bool is_busy;
        public bool IsBusy
        {
            get { return is_busy; }
            set { is_busy = value; NotifyOfPropertyChange(() => IsBusy); }
        }

        string welcome;
        public string Welcome
        {
            get { return welcome; }
            set { welcome = value; NotifyOfPropertyChange(() => Welcome);}
        }
    }

}