using Caliburn.Micro;
using Willow.Kermit.General.Messages;

namespace Willow.Kermit.General.Interfaces
{
    public interface IActionTabsViewModel : IConductor,
        IHandle<IShowHomeMessage>,
        IHandle<IShowTabViewMessage>,
        IHandle<ICloseTabMessage>

    {
        IObservableCollection<IScreen> Items { get; }
        IScreen ActiveItem { get; set; }
        void CloseItem(ITabViewModel anItem);
    }
}