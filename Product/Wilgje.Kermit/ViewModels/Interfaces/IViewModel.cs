using Caliburn.Micro;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface ITabViewModel : IScreen
    {
        string Caption { get; set; }
        IEventAggregator Events { get; set; }
        void Close();
    }
}