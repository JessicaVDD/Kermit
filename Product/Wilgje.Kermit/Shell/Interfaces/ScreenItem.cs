using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willow.Kermit.Shell.Interfaces
{
    public interface ScreenItem : IScreen
    {
        bool HasClose { get; set; }
    }
}
