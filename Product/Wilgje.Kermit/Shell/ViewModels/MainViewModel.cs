using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willow.Kermit.Shell.Interfaces;
using Willow.Kermit.Shell.Messages;

namespace Willow.Kermit.Shell.ViewModels
{
    [Export(typeof(Main))]
    public class MainViewModel : Conductor<ScreenItem>.Collection.OneActive, Main
    {
        private Home _Home;
        [ImportingConstructor]
        public MainViewModel(Home home, IEventAggregator events)        
        {
            _Home = home;
            Items.Add(_Home);
            events.Subscribe(this);
        }

        public void Handle(ScreenItemMessage message)
        {
            if (ReferenceEquals(message, null)) return;
            if (ReferenceEquals(message.ScreenItem, null)) return;

            if (message.Action == ScreenAction.Activate)
                ActivateItem(message.ScreenItem);
            else
                DeactivateItem(message.ScreenItem, true);
        }

        public void Handle(NavigationMessage message)
        {
            if (ReferenceEquals(message, null)) return;
            if (message.Action == NavigationCommand.Home)
                ActivateItem(_Home);
        }
    }
}
