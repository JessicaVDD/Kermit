using Machine.Specifications;
using Willow.Kermit.ViewModels;
using Willow.Kermit.ViewModels.Interfaces;
using developwithpassion.specifications.rhino;

namespace Willow.Kermit.Specs.ViewModels
{   
    public class ShellViewModelSpecs
    {
        public abstract class concern : Observes<IShellViewModel,
                                            ShellViewModel>
        {
        
        }

        [Subject(typeof(ShellViewModel))]
        public class when_using_the_view : concern
        {
            Establish c = () =>
            {
                navigation_model = an<INavigationViewModel>();
                search_model = an<ISearchViewModel>();
                art_model = an<IArtViewModel>();
                status_model = an<IStatusViewModel>();
                action_tab_view_model = an<IActionTabViewModel>();
            };


            Because b = () => { };

            It should_have_all_child_views_initialized = () =>
            {
                sut.ActionTabs.ShouldNotBeNull();
                sut.Search.ShouldNotBeNull();
                sut.Art.ShouldNotBeNull();
                sut.Status.ShouldNotBeNull();
                sut.Navigation.ShouldNotBeNull();
            };

            static INavigationViewModel navigation_model;
            static ISearchViewModel search_model;
            static IArtViewModel art_model;
            static IStatusViewModel status_model;
            static IActionTabViewModel action_tab_view_model;
        }
    }
}
