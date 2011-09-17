using System;
using Caliburn.Micro;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class ActionTabsViewModel : Conductor<object>.Collection.OneActive, IActionTabsViewModel
    {
        public ActionTabsViewModel()
        {
            Items.Add(new HomeViewModel());
        }
    }
}