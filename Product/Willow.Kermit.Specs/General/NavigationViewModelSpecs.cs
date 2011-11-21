using Caliburn.Micro;
using Machine.Specifications;
using Rhino.Mocks;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.Messages;
using Willow.Kermit.General.ViewModels;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;

namespace Willow.Kermit.Specs.General
{   
    public class NavigationViewModelSpecs
    {
        public abstract class concern : Observes<INavigationViewModel, NavigationViewModel>
        {
            private Establish ctx = () =>
            {
                event_aggregator = the_dependency<IEventAggregator>();
            };

            protected static IEventAggregator event_aggregator;
        }

        [Subject(typeof(NavigationViewModel))]
        public class when_using_the_model : concern
        {
            It should_start_with_default_buttons = () =>
            {
                sut.Home.ShouldNotBeNull();
                sut.ArrowBack.ShouldNotBeNull();
                sut.ArrowForward.ShouldNotBeNull();
                sut.Settings.ShouldNotBeNull();
                sut.Help.ShouldNotBeNull();
            };
        }

        [Subject(typeof(NavigationViewModel))]
        public class when_gohome_is_pressed : concern
        {
            Because b = () => sut.GoHome();

            private It should_tell_the_shell_to_show_the_home_view = () =>
            {
                event_aggregator.received(x => x.Publish(Arg<IShowHomeMessage>.Is.Anything)).OnlyOnce();
            };
        }
    }
}
