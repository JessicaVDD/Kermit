using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Willow.Kermit.Shell.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.Shell.ViewModels
{
    [Export(typeof(ArtFiller))]
    public class ArtFillerViewModel : ArtFiller
    {
        [ImportingConstructor]
        public ArtFillerViewModel(ImageGetter getter)
        {
            Image = getter.Background;
        }

        public BitmapImage Image { get; set; }
    }
}
