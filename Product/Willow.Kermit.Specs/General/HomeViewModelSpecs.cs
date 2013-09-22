using Caliburn.Micro;
using Rhino.Mocks;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.Messages;
using Willow.Kermit.General.ViewModels;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;
using Machine.Specifications;
using System.Linq;
using Action = System.Action;

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
                sut.AvailableButtons.Count().ShouldBeGreaterThan(0);
            };
        }

        [Subject(typeof(HomeViewModel))]
        public class when_asking_to_show_a_new_view : concern
        {
            Establish c = () =>
            {
                do_click = an<Action>();
                image_button = new ImageButton {DoClick = do_click};
            };

            Because b = () =>
            {
                sut.DoShow(image_button);
            };

            It should_call_the_DoClick_on_the_clicked_button = () =>
            {
                do_click.received(x => x()).OnlyOnce();
            };

            static ImageButton image_button;
            static Action do_click;
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