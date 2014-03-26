using System.ComponentModel.Composition;
using System.Windows.Media.Imaging;

namespace Willow.Kermit.Util
{
    [Export(typeof(ImageGetter))]
    public class DefaultImageGetter : ImageGetter
    {
        private UriResolver _uriResolver;

        public DefaultImageGetter()
        {
            _uriResolver = new DefaultUriResolver();
        }

        public BitmapImage Get(string imageFileName)
        {
            var uri = _uriResolver.Resolve(imageFileName);
            return uri == null ? new BitmapImage() : new BitmapImage(_uriResolver.Resolve(imageFileName));
        }

        public BitmapImage Baby
        {
            get { return new DefaultImageGetter().Get("Baby.png"); }
        }

        public BitmapImage BabyIcon
        {
            get { return new DefaultImageGetter().Get("Baby_Icon.png"); }
        }

        public BitmapImage BabyBoy
        {
            get { return new DefaultImageGetter().Get("BabyBoy.png"); }
        }

        public BitmapImage BabyGirl
        {
            get { return new DefaultImageGetter().Get("BabyGirl.png"); }
        }

        public BitmapImage Brother
        {
            get { return new DefaultImageGetter().Get("Brother.png"); }
        }

        public BitmapImage Sister
        {
            get { return new DefaultImageGetter().Get("Sister.jpg"); }
        }

        public BitmapImage Daddy
        {
            get { return new DefaultImageGetter().Get("Daddy.jpg"); }
        }

        public BitmapImage Mommy
        {
            get { return new DefaultImageGetter().Get("Mommy.jpg"); }
        }

        public BitmapImage Man
        {
            get { return new DefaultImageGetter().Get("Man.png"); }
        }

        public BitmapImage Woman
        {
            get { return new DefaultImageGetter().Get("Woman.png"); }
        }

        public BitmapImage Background
        {
            get { return new DefaultImageGetter().Get("Jaidee.png"); }
        }

        public BitmapImage Search
        {
            get { return new DefaultImageGetter().Get("Search.ico"); }
        }

        public BitmapImage SearchIcon
        {
            get { return new DefaultImageGetter().Get("Search_Icon.png"); }
        }

        public BitmapImage Calendar
        {
            get { return new DefaultImageGetter().Get("Calendar.png"); }
        }

        public BitmapImage Home
        {
            get { return new DefaultImageGetter().Get("Home.ico"); }
        }

        public BitmapImage Help
        {
            get { return new DefaultImageGetter().Get("Help.png"); }
        }

        public BitmapImage Settings
        {
            get { return new DefaultImageGetter().Get("Settings.ico"); }
        }

        public BitmapImage SocialWorkers
        {
            get { return new DefaultImageGetter().Get("Doctor.png"); }
        }

        public BitmapImage SocialWorkersIcon
        {
            get { return new DefaultImageGetter().Get("Doctor_Icon.png"); }
        }

        public BitmapImage ArrowLeft
        {
            get { return new DefaultImageGetter().Get("LeftArrowBlue.ico"); }
        }

        public BitmapImage ArrowRight
        {
            get { return new DefaultImageGetter().Get("RightArrowBlue.ico"); }
        }

        public BitmapImage SearchSmall
        {
            get { return new DefaultImageGetter().Get("SearchIcon.ico"); }
        }

    }
}