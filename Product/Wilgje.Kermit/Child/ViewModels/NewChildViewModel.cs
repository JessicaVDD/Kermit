using Caliburn.Micro;
using Willow.Kermit.Child.Interfaces;
using Willow.Kermit.General.Messages;

namespace Willow.Kermit.Child.ViewModels
{
    public class NewChildViewModel : Screen, INewChildViewModel
    {
        public NewChildViewModel()
        {
            Caption = "Nieuw";
        }
        public IEventAggregator Events { get; set; }

        string _caption;
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; NotifyOfPropertyChange(() => _caption); }
        }
        public void Close()
        {           
            if (Events != null)
                Events.Publish(new CloseTabMessage {Item = this});
        }
    }
}