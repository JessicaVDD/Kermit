using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.Messages
{
    public class ShowTabViewMessage : IShowTabViewMessage
    {
        public ITabViewModel Item { get; set; }
    }
}