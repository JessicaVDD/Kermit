using System;
using System.IO;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class ArtViewModel : PropertyChangedBase, IArtViewModel
    {
        BitmapImage _defaultPicture;
        public ArtViewModel()
        {
            _defaultPicture = new BitmapImage(new Uri("file:///C:/Users/vandepe/My%20Sources/Persoonlijk/Blydhove/Kermit/Product/Wilgje.Kermit/Resources/Jaidee.png"));
            _kid = _defaultPicture;
        }

        BitmapImage _kid;
        public BitmapImage Kid
        {
            get { return _kid; }
            set
            {
                if (value == null) throw new NullReferenceException("The picture cannot be null.");
                _kid = value;
                NotifyOfPropertyChange(() => Kid);
            }
        }
    }
}
