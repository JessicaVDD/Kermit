using Caliburn.Micro;
using Willow.Kermit.Model;

namespace Willow.Kermit.Child.ViewModels
{
    public class ChildOverviewViewModel : Screen, IChildInfoPanel
    {
        Client child;

        public ChildOverviewViewModel(Client child)
        {
            this.child = child;
        }

        public string Caption { get { return "Algemeen"; } } 
    }
}