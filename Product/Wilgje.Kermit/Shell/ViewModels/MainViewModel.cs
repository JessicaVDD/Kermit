using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willow.Kermit.Shell.Interfaces;

namespace Willow.Kermit.Shell.ViewModels
{
    [Export(typeof(Main))]
    public class MainViewModel : Main
    {
    }
}
