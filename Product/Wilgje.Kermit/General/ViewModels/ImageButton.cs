using System;
using System.Windows.Media.Imaging;

namespace Willow.Kermit.General.ViewModels
{
    public class ImageButton
    {
        public BitmapImage Image { get; set; }
        public string Text { get; set; }
        public Action DoClick { get; set; }
    }
}