using System.Windows.Input;
using System.Windows.Media.Imaging;
using Caliburn.Micro;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface ISearchViewModel
    {
        string SearchText { get; set; }
        BitmapImage Search { get; set; }
        IEventAggregator Events { get; }
        void DoSearch();
        void DoSearchWithEnter(KeyEventArgs e);
    }
}