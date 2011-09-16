using System.Windows.Media.Imaging;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface ISearchViewModel
    {
        string SearchText { get; set; }
        BitmapImage Search { get; set; }
    }
}