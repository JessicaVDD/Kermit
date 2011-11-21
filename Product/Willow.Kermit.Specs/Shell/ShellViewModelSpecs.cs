using Caliburn.Micro;
using Machine.Specifications;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.Shell.Interfaces;
using Willow.Kermit.Shell.ViewModels;
using Willow.Kermit.Specs.Utils;
using developwithpassion.specifications.extensions;

namespace Willow.Kermit.Specs.Shell
{   
    public class ShellViewModelSpecs
    {
        public abstract class concern : ObservesWithINPC<IShellViewModel, ShellViewModel>
        {
            Establish c = () =>
            {
                events = an<IEventAggregator>();
                navigation_model = the_dependency<INavigationViewModel>();
                navigation_model.setup(x => x.Events).Return(events);
                search_model = the_dependency<ISearchViewModel>();
                art_model = the_dependency<IArtViewModel>();
                status_model = the_dependency<IStatusViewModel>();
                action_tabs_view_model = the_dependency<IActionTabsViewModel>();
            };

            protected static INavigationViewModel navigation_model;
            protected static ISearchViewModel search_model;
            protected static IArtViewModel art_model;
            protected static IStatusViewModel status_model;
            protected static IActionTabsViewModel action_tabs_view_model;
            protected static IEventAggregator events;
        }

        [Subject(typeof(ShellViewModel))]
        public class when_using_the_view : concern
        {
            Because b = () => { };

            It should_have_all_child_views_initialized = () =>
            {
                sut.ActionTabs.ShouldNotBeNull();
                sut.Search.ShouldNotBeNull();
                sut.Art.ShouldNotBeNull();
                sut.Status.ShouldNotBeNull();
                sut.Navigation.ShouldNotBeNull();
            };

            It should_subscribe_the_action_tabs_to_the_navigation_events = () =>
            {
                events.received(x => x.Subscribe(action_tabs_view_model)).OnlyOnce();
            };
        }


        [Subject(typeof(ShellViewModel))]
        public class when_changing_a_property : concern
        {
            Because b = () => { property_helper.trigger_all_properties(); };

            It should_fire_a_notify_property_changed = () =>
            {
                property_helper.has_fired(x => x.ActionTabs).ShouldBeTrue();
                property_helper.has_fired(x => x.Art).ShouldBeTrue();
                property_helper.has_fired(x => x.Navigation).ShouldBeTrue();
                property_helper.has_fired(x => x.Search).ShouldBeTrue();
                property_helper.has_fired(x => x.Status).ShouldBeTrue();
            };
        }
    }
}
