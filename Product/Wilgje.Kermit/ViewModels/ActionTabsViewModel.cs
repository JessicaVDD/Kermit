using System;
using System.Linq;
using Caliburn.Micro;
using Willow.Kermit.Messages;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class ActionTabsViewModel : Conductor<object>.Collection.OneActive, IActionTabsViewModel, IHandle<IShowHomeMessage>
    {
        public ActionTabsViewModel()
        {
            Items.Add(new HomeViewModel());
        }

        public void Handle(IShowHomeMessage message)
        {
            var homeViewModel = (from vm in Items where vm is IHomeViewModel select vm).FirstOrDefault();
            if (homeViewModel == null)
            {
                homeViewModel = new HomeViewModel();
                Items.Add(homeViewModel);
            }
            ActivateItem(homeViewModel);
        }

        public void CloseItem(ITabViewModel anItem)
        {
            DeactivateItem(anItem, true);
        }
    }
}