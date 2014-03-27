using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willow.Kermit.Shell.Interfaces
{
    public interface Status : INotifyPropertyChanged
    {
        string User { get; set; }
        string Status { get; set; }
        string Message { get; set; }
    }
}
