using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willow.Kermit.Shell.Interfaces;

namespace Willow.Kermit.Shell.ViewModels
{
    [Export(typeof(Status))]
    public class StatusViewModel : PropertyChangedBase, Status
    {
        private string _User;
        private string _Status;
        private string _Message;

        public string User
        {
            get { return _User; }
            set
            {
                if (ReferenceEquals(_User, value)) return;
                _User = value;
                NotifyOfPropertyChange(() => User);
            }
        }

        public string Status
        {
            get { return _Status; }
            set
            {
                if (ReferenceEquals(_Status, value)) return;
                _Status = value;
                NotifyOfPropertyChange(() => Status);
            }
        }

        public string Message
        {
            get { return _Message; }
            set
            {
                if (ReferenceEquals(_Message, value)) return;
                _Message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }
    }
}
