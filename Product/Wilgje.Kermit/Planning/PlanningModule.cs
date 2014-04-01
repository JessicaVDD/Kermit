using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Willow.Kermit.Planning.Interfaces;
using Willow.Kermit.Shell.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.Planning
{
    [Export(typeof(KermitModule))]
    public class PlanningModule : KermitModule
    {
        [ImportingConstructor]
        public PlanningModule(ImageGetter getter)
        {
            Image = getter.Calendar;
            Caption = "Planning";
        }
        public BitmapImage Image { get; private set; }

        public string Caption { get; private set; }

        public ScreenItem Create()
        {
            return IoC.Get<Occupancy>();
        }
    }
}
