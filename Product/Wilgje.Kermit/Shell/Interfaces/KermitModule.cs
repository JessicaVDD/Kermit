using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Willow.Kermit.Shell.Interfaces
{
    public interface KermitModule
    {
        BitmapImage Image { get; }
        string Caption { get; }
        ScreenItem Create();
    }
}
