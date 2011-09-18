using System.Windows.Media.Imaging;
using Caliburn.Micro;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface INavigationViewModel
    {
        BitmapImage Home { get; set; }
        BitmapImage ArrowBack { get; set; }
        BitmapImage ArrowForward { get; set; }
        BitmapImage Settings { get; set; }
        BitmapImage Help { get; set; }
        IEventAggregator Events { get; }
        void GoHome();
    }
}