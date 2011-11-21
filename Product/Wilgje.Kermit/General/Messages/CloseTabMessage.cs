using Willow.Kermit.General.Interfaces;

namespace Willow.Kermit.General.Messages
{
    public class CloseTabMessage : ICloseTabMessage
    {
        public ITabViewModel Item { get; set; }
    }
}