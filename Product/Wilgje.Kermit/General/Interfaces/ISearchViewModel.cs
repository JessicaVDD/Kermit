using System.Windows.Input;
using System.Windows.Media.Imaging;
using Caliburn.Micro;

namespace Willow.Kermit.General.Interfaces
{
    public interface ISearchViewModel
    {
        string SearchText { get; set; }
        BitmapImage Search { get; }
        IEventAggregator Events { get; }
        void DoSearch();
        void DoSearchWithEnter(KeyEventArgs e);
    }
}