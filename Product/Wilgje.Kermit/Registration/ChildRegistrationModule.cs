using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Willow.Kermit.Registration.Interfaces;
using Willow.Kermit.Registration.ViewModels;
using Willow.Kermit.Shell.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.Registration
{
    [Export(typeof(KermitModule))]
    public class ChildRegistrationModule : KermitModule 
    {
        IEventAggregator _Events;
        [ImportingConstructor]
        public ChildRegistrationModule(ImageGetter getter, IEventAggregator events)
        {
            _Events = events;
            Image = getter.Baby;
            Caption = "Inschrijving";
        }

        public BitmapImage Image { get; private set; }
        public string Caption { get; private set; }

        public ScreenItem Create()
        {
            return new ChildRegistrationViewModel(_Events); // This should come through MEF
        }
    }
}
