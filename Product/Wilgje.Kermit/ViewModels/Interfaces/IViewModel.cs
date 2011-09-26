using Caliburn.Micro;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface ITabViewModel : IScreen
    {
        IEventAggregator Events { get; set; }
        void Close();
    }
}