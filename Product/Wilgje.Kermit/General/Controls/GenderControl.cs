using Caliburn.Micro;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Willow.Kermit.General.Interfaces;
namespace Willow.Kermit.General.Controls
{
    public class GenderControl : Control
    {
        public static readonly DependencyProperty GenderProperty = DependencyProperty.Register("Gender", typeof(Genders), typeof(GenderControl), new PropertyMetadata(Genders.Unknown));
        public static readonly DependencyProperty MaleProperty = DependencyProperty.Register("Male", typeof(string), typeof(GenderControl), new PropertyMetadata("Mannelijk"));
        public static readonly DependencyProperty FemaleProperty = DependencyProperty.Register("Female", typeof(string), typeof(GenderControl), new PropertyMetadata("Vrouwelijk"));
        public static readonly DependencyProperty UnknownProperty = DependencyProperty.Register("Unknown", typeof(string), typeof(GenderControl), new PropertyMetadata("Onbekend"));

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

        public string Male
        {
            get { return (string)GetValue(MaleProperty); }
            set { SetValue(MaleProperty, value); }
        }

        public string Female
        {
            get { return (string)GetValue(FemaleProperty); }
            set { SetValue(FemaleProperty, value); }
        }

        public string Unknown
        {
            get { return (string)GetValue(UnknownProperty); }
            set { SetValue(UnknownProperty, value); }
        }
    }
}
