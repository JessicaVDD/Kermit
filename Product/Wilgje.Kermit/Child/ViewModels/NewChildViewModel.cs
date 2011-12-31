using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.Child.Interfaces;
using Willow.Kermit.General.Messages;
using Willow.Kermit.Util;

namespace Willow.Kermit.Child.ViewModels
{
    public class NewChildViewModel : Screen, INewChildViewModel
    {
        public NewChildViewModel()
        {
            Caption = "Nieuw";
            Image = ImageGetter.Baby;
        }

        public BitmapImage Image { get; set; }
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