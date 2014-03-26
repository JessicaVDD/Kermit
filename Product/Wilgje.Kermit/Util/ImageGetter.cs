using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace Willow.Kermit.Util
{
    public interface ImageGetter
    {
        BitmapImage Get(string imageFileName);

        BitmapImage Baby { get; }
        BitmapImage BabyIcon { get; }
        BitmapImage BabyBoy { get; }
        BitmapImage BabyGirl { get; }
        BitmapImage Brother { get; }
        BitmapImage Sister { get; }
        BitmapImage Daddy { get; }
        BitmapImage Mommy { get; }
        BitmapImage Man { get; }
        BitmapImage Woman { get; }
        BitmapImage Background { get; }
        BitmapImage Search { get; }
        BitmapImage SearchIcon { get; }
        BitmapImage Calendar { get; }
        BitmapImage Home { get; }
        BitmapImage Help { get; }
        BitmapImage Settings { get; }
        BitmapImage SocialWorkers { get; }
        BitmapImage SocialWorkersIcon { get; }
        BitmapImage ArrowLeft { get; }
        BitmapImage ArrowRight { get; }
        BitmapImage SearchSmall { get; }
    }
}
