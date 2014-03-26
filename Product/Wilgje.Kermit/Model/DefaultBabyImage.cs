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
                    return new DefaultImageGetter().BabyBoy;
                case Gender.Female:
                    return new DefaultImageGetter().BabyGirl;
                default:
                    return new DefaultImageGetter().Baby;
            }
        }
    }
}