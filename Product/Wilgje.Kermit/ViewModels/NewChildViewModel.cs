using Caliburn.Micro;
using Willow.Kermit.Messages;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
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