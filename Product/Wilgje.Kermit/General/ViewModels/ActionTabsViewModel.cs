using System.Linq;
using Caliburn.Micro;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.Messages;

namespace Willow.Kermit.General.ViewModels
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
            var homeViewModel = Items.FirstOrDefault(vm => vm is IHomeViewModel) ?? new HomeViewModel();
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