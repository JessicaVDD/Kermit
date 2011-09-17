using System.Linq;
using Caliburn.Micro;
using developwithpassion.specifications.rhino;
using Machine.Fakes;
using Machine.Specifications;
using Willow.Kermit.Messages;
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

        [Subject(typeof(ActionTabsViewModel))]
        public class when_a_show_home_message_is_published : concern
        {
            Because b = () => sut.Handle(An<IShowHomeMessage>());

            It should_activate_the_home_view_model = () =>
            {
                sut.Items.Any(tab => typeof(IHomeViewModel).IsAssignableFrom(tab.GetType())).ShouldBeTrue();
                sut.ActiveItem.ShouldBeOfType(typeof(IHomeViewModel));
            };

            private It should_not_put_a_second_home_view_model_in_its_items_collection = () =>
            {
                sut.Items.Count(item => item is IHomeViewModel).ShouldEqual(1);
            };
        }

        [Subject(typeof (ActionTabsViewModel))]
        public class when_a_show_home_message_is_received_and_there_is_no_home_view_in_the_items_collection : concern
        {
            private Establish ctx = () =>
            {
                create_sut_using(() =>
                {
                    var thesut = new ActionTabsViewModel();
                    thesut.Items.Clear();
                    return thesut;
                });
            };

            private Because b = () => sut.Handle(an<IShowHomeMessage>());

            private It should_activate_the_home_view_model = () =>
            {
                sut.Items.Any(tab => typeof(IHomeViewModel).IsAssignableFrom(tab.GetType())).ShouldBeTrue();
                sut.ActiveItem.ShouldBeOfType(typeof(IHomeViewModel));
            };
        }

        //[Subject(typeof (ActionTabsViewModel))]
        //public class when_a_tab_is_asked_to_close : concern
        //{
        //    private Establish ctx = () =>
        //    {
        //        deactivated_item = An<IDeactivate>();
        //    };
        //    Because b = () => { sut.CloseItem(deactivated_item); };

        //    It should_deactivate_the_item = () =>
        //    {
        //        deactivated_item.WasToldTo(item => item.Deactivate(true)).OnlyOnce();
        //    };

        //    private static IDeactivate deactivated_item;
        //}
    }
}