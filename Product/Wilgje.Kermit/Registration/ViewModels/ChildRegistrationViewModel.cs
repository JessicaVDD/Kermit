using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willow.Kermit.Registration.Interfaces;
using Willow.Kermit.Shell.Messages;

namespace Willow.Kermit.Registration.ViewModels
{
    [Export(typeof(ChildRegistration))][PartCreationPolicy(CreationPolicy.NonShared)]
    public class ChildRegistrationViewModel : Screen, ChildRegistration
    {
        private IEventAggregator _Events;

        [ImportingConstructor]
        public ChildRegistrationViewModel(IEventAggregator events)
        {
            _Events = events;
            DisplayName = "Inschrijving";
            HasClose = true;
        }

        public bool HasClose { get; set; }

        public void NewFamily()
        {

        }

        public void NewPerson()
        {
            _Events.Publish(new ScreenItemMessage { Action = ScreenAction.Activate, ScreenItem = IoC.Get<Person>() });
        }

        public void NewChild()
        {

        }
    }
}
