using Willow.Kermit.General.Interfaces;

namespace Willow.Kermit.General.Messages
{
    public interface IShowTabViewMessage
    {
        ITabViewModel Item { get; set; }
    }
}