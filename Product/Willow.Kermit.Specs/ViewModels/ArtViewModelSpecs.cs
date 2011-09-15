 using System;
 using Machine.Specifications;
 using Willow.Kermit.ViewModels;
 using Willow.Kermit.ViewModels.Interfaces;
 using developwithpassion.specifications.rhino;
using System.Windows.Media.Imaging;


namespace Willow.Kermit.Specs.ViewModels
{   
    public class ArtViewModelSpecs
    {
        public abstract class concern : Observes<IArtViewModel, ArtViewModel>
        {
        
        }

        [Subject(typeof(ArtViewModel))]
        public class when_using_the_art_view : concern
        {
            It should_always_have_a_picture = () => sut.Kid.ShouldNotBeNull();
        }

        [Subject(typeof(ArtViewModel))]
        public class when_changing_the_picture : concern
        {
            Because b = () => sut.PropertyChanged += Sut_PropertyChanged;

            static string property_changed;
            static void Sut_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                property_changed = e.PropertyName;
            }

            It should_fire_a_notify_property_changed = () =>
            {
                property_changed = null;
                sut.Kid = new BitmapImage();
                property_changed.ShouldEqual("Kid");
            };
        }

        [Subject(typeof(ArtViewModel))]
        public class when_setting_the_picture_to_null : concern
        {
            Because b = () => 
                catch_exception(() => sut.Kid = null);

            It should_throw_a_null_reference_exception = () => 
                exception_thrown_by_the_sut.ShouldBeOfType(typeof(NullReferenceException));
        }
    }
}
