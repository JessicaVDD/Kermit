using System;
using System.Drawing;
using Caliburn.Micro;
using Willow.Kermit.Properties;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.ViewModels
{
    public class ArtViewModel : PropertyChangedBase, IArtViewModel
    {
        public ArtViewModel()
        {
            _kid = Resources.Jaidee;
        }

        Bitmap _kid;
        public Bitmap Kid
        {
            get { return _kid; }
            set
            {
                if (value == null) throw new NullReferenceException("The picture cannot be null.");
                _kid = value; NotifyOfPropertyChange(() => Kid);
            }
        }
    }
}
