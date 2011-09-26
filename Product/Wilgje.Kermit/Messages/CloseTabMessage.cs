using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.Messages
{
    public class CloseTabMessage : ICloseTabMessage
    {
        public ITabViewModel Item { get; set; }
    }
}