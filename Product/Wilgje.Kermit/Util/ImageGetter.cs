using System.Windows.Media.Imaging;

namespace Willow.Kermit.Util
{
    public class ImageGetter
    {
        private IUriResolver _uriResolver;

        public ImageGetter()
        {
            _uriResolver = new UriResolver();
        }

        public BitmapImage Get(string imageFileName)
        {
            return new BitmapImage(_uriResolver.Resolve(imageFileName));
        }
    }
}