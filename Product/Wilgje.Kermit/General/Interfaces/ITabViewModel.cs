using System.Windows.Media.Imaging;
using Caliburn.Micro;

namespace Willow.Kermit.General.Interfaces
{
    public interface ITabViewModel : IScreen
    {
        string Caption { get; set; }
        BitmapImage Image { get; set; }
        IEventAggregator Events { get; set; }
        void Close();
    }
}