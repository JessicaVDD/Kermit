using System.Windows.Media.Imaging;
using Willow.Kermit.Messages;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface IHomeViewModel : ITabViewModel
    {
        BitmapImage NewKid { get; set; }
        BitmapImage Search { get; set; }
        BitmapImage Doctors { get; set; }
        BitmapImage Calendar { get; set; }

        void ShowTab(ITabViewModel view_model);
    }
}