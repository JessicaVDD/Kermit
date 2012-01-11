using Caliburn.Micro;
using Rhino.Mocks;
using Willow.Kermit.Child.Interfaces;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.Messages;
using Willow.Kermit.General.ViewModels;
using Willow.Kermit.Search.Interfaces;
using Willow.Kermit.SocialWorkers.Interfaces;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using Machine.Specifications;

namespace Willow.Kermit.Specs.General
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
                sut.AvailableButtons.Count.ShouldEqual(4);
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

        [Subject(typeof(HomeViewModel))]
        public class when_opening_a_new_view : concern
        {
            Establish c = () =>
            {
                view_model = an<ITabViewModel>();
                events = an<IEventAggregator>();
                add_pipeline_behaviour_against_sut(x => x.Events = events);
            };

            Because b = () =>
            {
                sut.ShowTab(view_model);
            };

            It should_publish_an_open_request_for_the_view = () =>
            {
                events.received(x => x.Publish(Arg<IShowTabViewMessage>.Matches(msg => ReferenceEquals(msg.Item, view_model)))).OnlyOnce();
            };

            static ITabViewModel view_model;
            static IEventAggregator events;
        }
    }
}