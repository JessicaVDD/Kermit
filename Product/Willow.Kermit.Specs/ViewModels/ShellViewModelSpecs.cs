using System.Collections.Generic;
using System.Diagnostics;
using Machine.Specifications;
using Willow.Kermit.Specs.Utils;
using Willow.Kermit.ViewModels;
using Willow.Kermit.ViewModels.Interfaces;
using developwithpassion.specifications.rhino;

namespace Willow.Kermit.Specs.ViewModels
{   
    public class ShellViewModelSpecs
    {
        public abstract class concern : ObservesWithINPC<IShellViewModel, ShellViewModel>
        {
            Establish c = () =>
            {
                navigation_model = an<INavigationViewModel>();
                search_model = an<ISearchViewModel>();
                art_model = an<IArtViewModel>();
                status_model = an<IStatusViewModel>();
                action_tab_view_model = an<IActionTabViewModel>();
            };

            protected static INavigationViewModel navigation_model;
            protected static ISearchViewModel search_model;
            protected static IArtViewModel art_model;
            protected static IStatusViewModel status_model;
            protected static IActionTabViewModel action_tab_view_model;
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
