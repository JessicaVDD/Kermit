using Caliburn.Micro;
using Willow.Kermit.Model;

namespace Willow.Kermit.Child.ViewModels
{
    public class GezinViewModel : Screen
    {
        Client child;

        public GezinViewModel(Client child)
        {
            this.child = child;
        }
    }
}