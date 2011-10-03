using System.Diagnostics;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Willow.Kermit.Messages;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class ActionTabsViewModel : Conductor<IScreen>.Collection.OneActive, IActionTabsViewModel
    {
        IEventAggregator _events;

        public ActionTabsViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
            Items.Add(new HomeViewModel());
            
        }
        public ActionTabsViewModel() : this(new EventAggregator()) { }

        public override void ActivateItem(IScreen item)
        {
            var tabItem = item as ITabViewModel;
            if (tabItem != null) tabItem.Events = _events;
            base.ActivateItem(item);
        }

        public override void DeactivateItem(IScreen item, bool close)
        {
            var tabItem = item as ITabViewModel;
            if (tabItem != null) tabItem.Events = null;
            base.DeactivateItem(item, close);
        }

        public void CloseItem(ITabViewModel anItem)
        {
            if (!(anItem is HomeViewModel))
                DeactivateItem(anItem, true);
        }

        public void Handle(IShowHomeMessage message)
        {
            var homeViewModel = Items.Where(vm => vm is IHomeViewModel).FirstOrDefault() ?? new HomeViewModel();
            ActivateItem(homeViewModel);
        }

        public void Handle(ICloseTabMessage message)
        {
            CloseItem(message.Item);
        }

        public void Handle(IShowTabViewMessage message)
        {
            ActivateItem(message.Item);
        }
    }
}