using Caliburn.Micro;
using Willow.Kermit.Messages;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class SocialWorkersViewModel : Screen, ISocialWorkersViewModel
    {
        public SocialWorkersViewModel()
        {
            Caption = "Hulpverl.";
        }
        public string Caption { get; set; }
        public IEventAggregator Events { get; set; }
        public void Close()
        {
            if (Events != null)
                Events.Publish(new CloseTabMessage {Item = this});
        }
    }
}