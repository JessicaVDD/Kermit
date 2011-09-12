using System.ComponentModel;
using System.Drawing;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface IArtViewModel : INotifyPropertyChanged
    {
        Bitmap Kid { get; set; }
    }
}