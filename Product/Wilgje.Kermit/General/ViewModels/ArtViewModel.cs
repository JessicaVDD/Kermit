using System;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.General.ViewModels
{
    public class ArtViewModel : PropertyChangedBase, IArtViewModel
    {
        BitmapImage _defaultPicture;
        public ArtViewModel()
        {
            _defaultPicture = ImageGetter.Background;
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
