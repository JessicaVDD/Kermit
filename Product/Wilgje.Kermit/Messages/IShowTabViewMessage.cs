using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.Messages
{
    public interface IShowTabViewMessage
    {
        ITabViewModel Item { get; set; }
    }
}