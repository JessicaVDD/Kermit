using Caliburn.Micro;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.General.ViewModels
{
    public class StatusViewModel : PropertyChangedBase, IStatusViewModel
    {
        public StatusViewModel() : this(WindowsSecurity.GetUserFullName()) { }

        public StatusViewModel(string identity)
        {
            Welcome = string.Format("Welkom {0}", identity);
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