using System.ComponentModel.Composition;
using System.Windows.Media.Imaging;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.SocialWorkers.ViewModels;
using Willow.Kermit.Util;

namespace Willow.Kermit.SocialWorkers.Exports
{
    [Export(typeof(ITabViewModelFactory))]
    public class SocialWorkersViewModelFactory : ITabViewModelFactory
    {
        public BitmapImage Image
        {
            get { return ImageGetter.SocialWorkers; }
        }

        public string Caption
        {
            get { return "Hulpverleners"; }
        }

        public ITabViewModel Create()
        {
            return new SocialWorkersViewModel();
        }
    }

}