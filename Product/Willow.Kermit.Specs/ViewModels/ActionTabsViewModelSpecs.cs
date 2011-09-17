using System.Linq;
using developwithpassion.specifications.rhino;
using Machine.Fakes;
using Machine.Specifications;
using Willow.Kermit.ViewModels;
using Willow.Kermit.ViewModels.Interfaces;

namespace Willow.Kermit.Specs.ViewModels
{
    public class ActionTabsViewModelSpecs
    {
        public abstract class concern : Observes<IActionTabsViewModel, ActionTabsViewModel>
        {
            
        }

        [Subject(typeof(ActionTabsViewModel))]
        public class when_the_action_tabs_initialize : concern
        {
            private Because b = () => { };

            private It should_have_a_home_view_model = () =>
            {
                sut.Items.Any(tab => typeof (IHomeViewModel).IsAssignableFrom(tab.GetType())).ShouldBeTrue();
            };
        }
    }
}