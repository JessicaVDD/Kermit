using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Willow.Kermit.Shell.Interfaces;
using Willow.Kermit.Shell.Messages;

namespace Willow.Kermit.Shell.ViewModels
{
    [Export(typeof(Home))]
    public class HomeViewModel : Screen, Home
    {
        private IEventAggregator _Events;
        [ImportingConstructor]
        public HomeViewModel(IEventAggregator events)
        {
            DisplayName = "Home";
            _Events = events;
            Modules = new BindableCollection<KermitModule>();
        }

        [ImportMany]
        public IObservableCollection<KermitModule> Modules
        {
            get; private set;
        }

        public void DoShow(KermitModule m)
        {
            if (ReferenceEquals(_Events, null)) return;
            var screenItem = ReferenceEquals(m, null) ? null : m.Create();
            if (ReferenceEquals(screenItem, null)) return;

            _Events.Publish(new ScreenItemMessage { ScreenItem = screenItem });
        }

        public override void CanClose(Action<bool> callback)
        {
            callback(false);
        }
        public bool HasClose
        {
            get { return false; }
            set { }
        }
    }
}
