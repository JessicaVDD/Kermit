using System;
using System.Windows;
using System.Windows.Media;

namespace Willow.Kermit.General.Controls
{
    /// <summary>
    /// Interaction logic for HomeViewButtion.xaml
    /// </summary>
    public partial class ImageButton
    {
        public static RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Direct, typeof(EventHandler), typeof(ImageButton));
        public ImageButton()
        {
            InitializeComponent();
            BehindButton.Click += (sender, args) => RaiseEvent(new RoutedEventArgs {RoutedEvent = ClickEvent});
        }

        public event EventHandler Click
        {
            add{ AddHandler(ClickEvent, value);}
            remove {RemoveHandler(ClickEvent, value);}
        }

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(ImageButton), new UIPropertyMetadata(null));


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(ImageButton), new UIPropertyMetadata(""));
    }
}
