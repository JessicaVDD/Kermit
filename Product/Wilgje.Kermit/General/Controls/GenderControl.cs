using Caliburn.Micro;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Willow.Kermit.General.Interfaces;
namespace Willow.Kermit.General.Controls
{
    public class GenderControl : Control
    {
        static GenderControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GenderControl), new FrameworkPropertyMetadata(typeof(GenderControl)));
            ConventionManager.AddElementConvention<GenderControl>(GenderControl.GenderProperty, "Gender", "GenderChanged");
        }

        public Genders Gender
        {
            get { return (Genders)GetValue(GenderProperty); }
            set { SetValue(GenderProperty, value); }
        }

        public static readonly DependencyProperty GenderProperty = DependencyProperty.Register("Gender", typeof(Genders), typeof(GenderControl), new PropertyMetadata(Genders.Unknown));
    }
}
