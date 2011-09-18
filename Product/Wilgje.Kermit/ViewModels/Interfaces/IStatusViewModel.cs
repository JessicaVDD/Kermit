using System.ComponentModel;

namespace Willow.Kermit.ViewModels.Interfaces
{
    public interface IStatusViewModel : INotifyPropertyChanged
    {
        bool IsBusy { get; set; }
        string Welcome { get; set; }
    }
}