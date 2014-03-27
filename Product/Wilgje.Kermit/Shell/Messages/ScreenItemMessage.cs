using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willow.Kermit.Shell.Interfaces;

namespace Willow.Kermit.Shell.Messages
{
    public class ScreenItemMessage
    {
        public ScreenItem ScreenItem { get; set; }
        public ScreenAction Action { get; set; }
    }

    public enum ScreenAction
    {
        Activate,
        Deactivate
    }
}
