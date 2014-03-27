using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Willow.Kermit.Shell.Messages;

namespace Willow.Kermit.Shell.Interfaces
{
    public interface Main : IConductor, IHandle<ScreenItemMessage>, IHandle<NavigationMessage>
    {
        IObservableCollection<ScreenItem> Items { get; }
    }
}
