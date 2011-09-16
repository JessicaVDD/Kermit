using Machine.Specifications;
using Willow.Kermit.ViewModels;
using Willow.Kermit.ViewModels.Interfaces;
using developwithpassion.specifications.rhino;
using developwithpassion.specifications.extensions;

namespace Willow.Kermit.Specs.ViewModels
{   
    public class NavigationViewModelSpecs
    {
        public abstract class concern : Observes<INavigationViewModel, NavigationViewModel>
        {
        
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
    }
}
