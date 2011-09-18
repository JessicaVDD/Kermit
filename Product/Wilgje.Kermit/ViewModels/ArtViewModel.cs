using System;
using System.IO;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.Util;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class ArtViewModel : PropertyChangedBase, IArtViewModel
    {
        BitmapImage _defaultPicture;
        public ArtViewModel()
        {
            _defaultPicture = new ImageGetter().Get("Jaidee.png"); 
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
