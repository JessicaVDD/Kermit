using Caliburn.Micro;
using Willow.Kermit.Messages;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface IActionTabsViewModel
    {
        IObservableCollection<object> Items { get; }
        object ActiveItem { get; set; }
        void Handle(IShowHomeMessage message);
        void CloseItem(ITabViewModel anItem);
    }
}