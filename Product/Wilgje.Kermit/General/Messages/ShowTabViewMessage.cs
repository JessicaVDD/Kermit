using Willow.Kermit.General.Interfaces;

namespace Willow.Kermit.General.Messages
{
    public class ShowTabViewMessage : IShowTabViewMessage
    {
        public ITabViewModel Item { get; set; }
    }
}