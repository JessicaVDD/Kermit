using System.Collections.Generic;
using Willow.Kermit.General.ViewModels;

namespace Willow.Kermit.General.Interfaces
{
    public interface IHomeViewModel : ITabViewModel
    {
        IEnumerable<ImageButton> AvailableButtons { get; }
        void ShowTab(ITabViewModel view_model);
        void DoShow(ImageButton ib);
    }
}