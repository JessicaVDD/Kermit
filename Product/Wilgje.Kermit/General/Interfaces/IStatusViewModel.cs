using System.ComponentModel;

namespace Willow.Kermit.General.Interfaces
{
    public interface IStatusViewModel : INotifyPropertyChanged
    {
        bool IsBusy { get; set; }
        string Welcome { get; set; }
    }
}