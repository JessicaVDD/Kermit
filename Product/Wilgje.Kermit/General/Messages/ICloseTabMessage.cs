using Willow.Kermit.General.Interfaces;

namespace Willow.Kermit.General.Messages
{
    public interface ICloseTabMessage
    {
        ITabViewModel Item { get; set; }
    }
}