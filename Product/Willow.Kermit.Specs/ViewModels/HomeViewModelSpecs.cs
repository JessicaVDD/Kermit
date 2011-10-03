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
        public abstract class concern : Observes<IHomeViewModel, HomeViewModel> { }

        [Subject(typeof (HomeViewModel))]
        public class when_home_initializes : concern
        {
            private Establish ctx = () =>
            {
                
            };

            private Because b = () => { };

            private It should_initialize_the_quick_start_buttons = () =>
            {
                sut.NewChild.ShouldNotBeNull();
                sut.Search.ShouldNotBeNull();
                sut.SocialWorkers.ShouldNotBeNull();
                sut.Calendar.ShouldNotBeNull();
            };
        }

        [Subject(typeof(HomeViewModel))]
        public class when_clicking_the_buttons : concern
        {
            Establish c = () =>
            {
                events = an<IEventAggregator>();
                add_pipeline_behaviour_against_sut(x => x.Events = events);
            };

            Because b = () =>
            {
                sut.ShowNewChild();
                sut.ShowSearchResults();
                sut.ShowSocialWorkers();
            };

            It should_publish_a_open_request_for_each_of_the_buttons = () =>
            {
                events.received(x => x.Publish(Arg<IShowTabViewMessage>.Matches(msg => msg.Item is INewChildViewModel))).OnlyOnce();
                events.received(x => x.Publish(Arg<IShowTabViewMessage>.Matches(msg => msg.Item is ISearchResultsViewModel))).OnlyOnce();
                events.received(x => x.Publish(Arg<IShowTabViewMessage>.Matches(msg => msg.Item is ISocialWorkersViewModel))).OnlyOnce();
            };

            static IEventAggregator events;
        }
    }
}