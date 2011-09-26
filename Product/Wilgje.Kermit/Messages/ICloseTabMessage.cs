using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.Messages
{
    public interface ICloseTabMessage
    {
        ITabViewModel Item { get; set; }
    }
}