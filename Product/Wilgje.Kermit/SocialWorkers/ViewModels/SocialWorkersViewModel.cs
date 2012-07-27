using System.ComponentModel.Composition;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.Messages;
using Willow.Kermit.SocialWorkers.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.SocialWorkers.ViewModels
{
    [Export(typeof(ITabViewModel))]
    public class SocialWorkersViewModel : Screen, ISocialWorkersViewModel
    {
        public SocialWorkersViewModel()
        {
            Caption = "Hulpverl.";
            Image = ImageGetter.SocialWorkersIcon;

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