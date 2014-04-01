using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willow.Kermit.Planning.Interfaces;

namespace Willow.Kermit.Planning.ViewModels
{
    [Export(typeof(Occupancy))]
    public class OccupancyViewModel : Screen, Occupancy
    {
        public OccupancyViewModel()
        {
            DisplayName = "Bezetting";
            HasClose = true;
        }

        public bool HasClose { get; set; }
    }
}
