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
    }
}