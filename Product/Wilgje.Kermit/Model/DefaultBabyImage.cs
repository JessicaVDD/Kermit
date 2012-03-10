using System.Windows.Media.Imaging;
using Willow.Kermit.Util;

namespace Willow.Kermit.Model
{
    public class DefaultBabyImage
    {
        public static BitmapImage For(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return ImageGetter.BabyBoy;
                case Gender.Female:
                    return ImageGetter.BabyGirl;
                default:
                    return ImageGetter.Baby;
            }
        }
    }
}