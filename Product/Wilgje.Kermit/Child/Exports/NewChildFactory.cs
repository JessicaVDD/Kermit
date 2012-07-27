using System.ComponentModel.Composition;
using System.Windows.Media.Imaging;
using Willow.Kermit.Child.ViewModels;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.Model;
using Willow.Kermit.Util;

namespace Willow.Kermit.Child.Exports
{
    [Export(typeof(ITabViewModelFactory))]
    public class NewChildFactory : ITabViewModelFactory
    {
        public BitmapImage Image
        {
            get { return ImageGetter.Baby; }
        }

        public string Caption
        {
            get { return "Nieuwe Kindjes"; }
        }

        public ITabViewModel Create()
        {
            return new ChildViewModel(ClientFactory.CreateNew());
        }
    }
}