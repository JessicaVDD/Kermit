using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willow.Kermit.Registration.Interfaces;

namespace Willow.Kermit.Registration.ViewModels
{
    public class PersonViewModel : Screen, Person
    {
        public bool HasClose
        {
            get
            {
                return true;
            }
            set
            {
                
            }
        }
    }
}
