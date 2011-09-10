using Machine.Specifications;
using Willow.Kermit.ViewModels;
using Willow.Kermit.ViewModels.Interfaces;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;

namespace Willow.Kermit.Specs.ViewModels
{   
    public class ShellViewModelSpecs
    {
        public abstract class concern : Observes<IShellViewModel,
                                            ShellViewModel>
        {
        
        }

        [Subject(typeof(ShellViewModel))]
        public class when_initializing : concern
        {
            Establish c = () =>
            {
                navigation_model = An<INavigationViewModel>();
                search_model = An<ISearchViewModel>();
                art_model = An<IArtViewModel>();
                status_model = An<IStatusViewModel>();
                action_tab_view_model = An<IActionTabViewModel>();

                sut.setup(x => x.Navigation).Return(navigation_model);
                sut.setup(x => x.Search).Return(search_model);
                sut.setup(x => x.Art).Return(art_model);
                sut.setup(x => x.Status).Return(status_model);
                sut.setup(x => x.ActionTabs).Return(action_tab_view_model);
            };



            It should_create_the_other_view_models = () =>
            {
            };

            static INavigationViewModel navigation_model;
            static ISearchViewModel search_model;
            static IArtViewModel art_model;
            static IStatusViewModel status_model;
            static IActionTabViewModel action_tab_view_model;
        }
    }
}
