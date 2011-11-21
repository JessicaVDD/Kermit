using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace Willow.Kermit.General.Interfaces
{
    public interface IArtViewModel : INotifyPropertyChanged
    {
        BitmapImage Kid { get; set; }
    }
}