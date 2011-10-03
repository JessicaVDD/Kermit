using System.Windows.Media.Imaging;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface IHomeViewModel : ITabViewModel
    {
        BitmapImage NewChild { get; set; }
        BitmapImage Search { get; set; }
        BitmapImage SocialWorkers { get; set; }
        BitmapImage Calendar { get; set; }

        void ShowTab(ITabViewModel view_model);
        void ShowNewChild();
        void ShowSearchResults();
        void ShowSocialWorkers();
    }
}