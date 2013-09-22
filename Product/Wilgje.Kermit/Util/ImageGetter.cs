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
            var uri = _uriResolver.Resolve(imageFileName);
            return uri == null ? new BitmapImage() : new BitmapImage(_uriResolver.Resolve(imageFileName));
        }

        public static BitmapImage Baby
        {
            get { return new ImageGetter().Get("Baby.png"); }
        }

        public static BitmapImage BabyIcon
        {
            get { return new ImageGetter().Get("Baby_Icon.png"); }
        }

        public static BitmapImage BabyBoy
        {
            get { return new ImageGetter().Get("BabyBoy.png"); }
        }

        public static BitmapImage BabyGirl
        {
            get { return new ImageGetter().Get("BabyGirl.png"); }
        }

        public static BitmapImage Brother
        {
            get { return new ImageGetter().Get("Brother.png"); }
        }

        public static BitmapImage Sister
        {
            get { return new ImageGetter().Get("Sister.jpg"); }
        }

        public static BitmapImage Daddy
        {
            get { return new ImageGetter().Get("Daddy.jpg"); }
        }

        public static BitmapImage Mommy
        {
            get { return new ImageGetter().Get("Mommy.jpg"); }
        }

        public static BitmapImage Man
        {
            get { return new ImageGetter().Get("Man.png"); }
        }

        public static BitmapImage Woman
        {
            get { return new ImageGetter().Get("Woman.png"); }
        }

        public static BitmapImage Background
        {
            get { return new ImageGetter().Get("Jaidee.png"); }
        }

        public static BitmapImage Search
        {
            get { return new ImageGetter().Get("Search.ico"); }
        }

        public static BitmapImage SearchIcon
        {
            get { return new ImageGetter().Get("Search_Icon.png"); }
        }

        public static BitmapImage Calendar
        {
            get { return new ImageGetter().Get("Calendar.png"); }
        }

        public static BitmapImage Home
        {
            get { return new ImageGetter().Get("Home.ico"); }
        }

        public static BitmapImage Help
        {
            get { return new ImageGetter().Get("Help.png"); }
        }

        public static BitmapImage Settings
        {
            get { return new ImageGetter().Get("Settings.ico"); }
        }

        public static BitmapImage SocialWorkers
        {
            get { return new ImageGetter().Get("Doctor.png"); }
        }

        public static BitmapImage SocialWorkersIcon
        {
            get { return new ImageGetter().Get("Doctor_Icon.png"); }
        }

        public static BitmapImage ArrowLeft
        {
            get { return new ImageGetter().Get("LeftArrowBlue.ico"); }
        }

        public static BitmapImage ArrowRight
        {
            get { return new ImageGetter().Get("RightArrowBlue.ico"); }
        }

        public static BitmapImage SearchSmall
        {
            get { return new ImageGetter().Get("SearchIcon.ico"); }
        }

    }
}