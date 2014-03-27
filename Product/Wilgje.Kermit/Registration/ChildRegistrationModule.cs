using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Willow.Kermit.Registration.ViewModels;
using Willow.Kermit.Shell.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.Registration
{
    [Export(typeof(KermitModule))]
    public class ChildRegistrationModule : KermitModule 
    {
        [ImportingConstructor]
        public ChildRegistrationModule(ImageGetter getter)
        {
            Image = getter.Baby;
            Caption = "Inschrijving";
        }

        public BitmapImage Image { get; private set; }
        public string Caption { get; private set; }

        public ScreenItem Create()
        {
            return new ChildRegistrationViewModel(); // This should come through MEF
        }
    }
}
