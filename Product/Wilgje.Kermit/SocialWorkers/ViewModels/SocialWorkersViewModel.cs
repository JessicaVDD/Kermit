using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.General.Messages;
using Willow.Kermit.SocialWorkers.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.SocialWorkers.ViewModels
{
    public class SocialWorkersViewModel : Screen, ISocialWorkersViewModel
    {
        public SocialWorkersViewModel()
        {
            Caption = "Hulpverl.";
            Image = new ImageGetter().Get("Doctor.png");

        }
        public string Caption { get; set; }

        public BitmapImage Image { get; set; }

        public IEventAggregator Events { get; set; }
        public void Close()
        {
            if (Events != null)
                Events.Publish(new CloseTabMessage {Item = this});
        }
    }
}