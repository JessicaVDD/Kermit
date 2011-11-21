using Machine.Specifications;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.ViewModels;
using Willow.Kermit.Specs.Utils;

namespace Willow.Kermit.Specs.General
{   
    public class StatusViewModelSpecs
    {
        public abstract class concern : ObservesWithINPC<IStatusViewModel, StatusViewModel>
        {
            Establish e = () =>
            {
                identity = "some name";
                provide_a_basic_sut_constructor_argument(identity);
            };

            protected static string identity;
        
        }

        [Subject(typeof(StatusViewModel))]
        public class when_using_the_view : concern
        {
            It should_use_the_provided_identity_in_the_welcome = () => sut.Welcome.Contains(identity).ShouldBeTrue();
            It should_has_a_busy_indicator_set_to_false = () => sut.IsBusy.ShouldBeFalse();

        }

        [Subject(typeof(StatusViewModel))]
        public class when_changing_the_busy_status : concern
        {
            Because b = () =>
            {
                sut.IsBusy = true;
            };

            It should_fire_a_notification = () =>
            {
                property_helper.has_fired(x => x.IsBusy).ShouldBeTrue();
            };
        }

        [Subject(typeof(StatusViewModel))]
        public class when_changing_the_welcome_message : concern
        {
            Because b = () => sut.Welcome = "something else";

            It should_fire_a_notification = () =>
            {
                property_helper.has_fired(x => x.Welcome).ShouldBeTrue();
            };
        }
    }
}
