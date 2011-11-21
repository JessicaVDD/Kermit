using System;
using Machine.Specifications;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.ViewModels;
using Willow.Kermit.Specs.Utils;
using System.Windows.Media.Imaging;

namespace Willow.Kermit.Specs.General
{   
    public class ArtViewModelSpecs
    {
        public abstract class concern : ObservesWithINPC<IArtViewModel, ArtViewModel>
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
            Establish e = () => 
            {
            };

            Because b = () => sut.Kid = new BitmapImage();

            It should_fire_a_notify_property_changed = () => 
            {
                property_helper.has_fired(x => x.Kid).ShouldBeTrue();
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
