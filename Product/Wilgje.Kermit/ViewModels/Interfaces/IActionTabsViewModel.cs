using System;
using Caliburn.Micro;
using Willow.Kermit.Messages;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface IActionTabsViewModel
    {
        Caliburn.Micro.IObservableCollection<object> Items { get; }
        object ActiveItem { get; set; }
        void Handle(IShowHomeMessage message);
        //void CloseItem(IDeactivate anItem);
    }
}