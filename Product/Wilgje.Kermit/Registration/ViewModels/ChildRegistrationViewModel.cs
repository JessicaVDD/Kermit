using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willow.Kermit.Registration.Interfaces;

namespace Willow.Kermit.Registration.ViewModels
{
    [Export(typeof(ChildRegistration))]
    public class ChildRegistrationViewModel : Screen, ChildRegistration
    {
        public ChildRegistrationViewModel()
        {
            DisplayName = "Inschrijving";
            HasClose = true;
        }

        public bool HasClose { get; set; }
    }
}
