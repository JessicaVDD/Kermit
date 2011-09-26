using Caliburn.Micro;
using Rhino.Mocks;
using Willow.Kermit.Messages;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using Machine.Specifications;
using Willow.Kermit.ViewModels;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.Specs.ViewModels
{
    public class HomeViewModelSpecs
    {
        public abstract class concern : Observes<IHomeViewModel, HomeViewModel>
        {

        }

        [Subject(typeof (HomeViewModel))]
        public class when_home_initializes : concern
        {
            private Establish ctx = () =>
            {
                
            };

            private Because b = () => { };

            private It should_initialize_the_quick_start_buttons = () =>
            {
                sut.NewKid.ShouldNotBeNull();
                sut.Search.ShouldNotBeNull();
                sut.Doctors.ShouldNotBeNull();
                sut.Calendar.ShouldNotBeNull();
            };
        }

        [Subject(typeof(HomeViewModel))]
        public class when_closing_the_view : concern
        {
            Establish c = () =>
            {
                events = an<IEventAggregator>();
                add_pipeline_behaviour_against_sut(x => x.Events = events);
            };

            Because b = () =>
            {
                sut.Close();
            };

            It should_publish_a_close_request_for_itself = () =>
            {
                events.received(x => x.Publish(Arg<ICloseTabMessage>.Matches(msg => ReferenceEquals(msg.Item, sut)))).OnlyOnce();
            };

            static IEventAggregator events;
        }
    }
}