using System.Windows.Media.Imaging;

namespace Willow.Kermit.General.Interfaces
{
    public interface ITabViewModelFactory
    {
        BitmapImage Image { get; }
        string Caption { get; }
        ITabViewModel Create();
    }
}