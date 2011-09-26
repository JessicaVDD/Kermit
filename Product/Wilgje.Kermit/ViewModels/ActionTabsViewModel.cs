using System.Linq;
using Caliburn.Micro;
using Willow.Kermit.Messages;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class ActionTabsViewModel : Conductor<IScreen>.Collection.OneActive, IActionTabsViewModel
    {
        IEventAggregator _events;

        public ActionTabsViewModel()
        {
            _events = new EventAggregator();
            _events.Subscribe(this);
            Items.Add(new HomeViewModel());
        }

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
            DeactivateItem(anItem, true);
        }

        public void Handle(IShowHomeMessage message)
        {
            var homeViewModel = Items.Where(vm => vm is IHomeViewModel).FirstOrDefault();
            if (homeViewModel == null)
            {
                homeViewModel = new HomeViewModel();
                Items.Add(homeViewModel);
            }
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