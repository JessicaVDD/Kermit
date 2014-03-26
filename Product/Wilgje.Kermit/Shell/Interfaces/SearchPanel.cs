using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Willow.Kermit.Shell.Interfaces
{
    public interface SearchPanel
    {
        string SearchText { get; set; }
        BitmapImage Search { get; }
        void DoSearch();
        void DoSearchWithEnter(KeyEventArgs e);
    }
}
