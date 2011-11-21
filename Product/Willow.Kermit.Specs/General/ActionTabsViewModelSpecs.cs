using System;
using System.Linq;
using Rhino.Mocks;
using Willow.Kermit.General.Interfaces;
using Willow.Kermit.General.Messages;
using Willow.Kermit.General.ViewModels;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhino;
using Machine.Specifications;

namespace Willow.Kermit.Specs.General
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
            Because b = () => sut.Handle(an<ShowHomeMessage>());

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
                add_pipeline_behaviour_against_sut(x => x.Items.Clear());
            };

            private Because b = () => sut.Handle(an<ShowHomeMessage>());

            private It should_activate_the_home_view_model = () =>
            {
                sut.Items.Any(tab => tab is IHomeViewModel).ShouldBeTrue();
                sut.ActiveItem.ShouldBeOfType(typeof(IHomeViewModel));
            };
        }

        [Subject(typeof(ActionTabsViewModel))]
        public class when_a_tab_is_asked_to_close : concern
        {
            private Establish ctx = () =>
            {
                item_to_deactivate = an<ITabViewModel>();
                add_pipeline_behaviour_against_sut(x => x.ActivateItem(item_to_deactivate));
            };

            Because b = () =>
            {
                sut.CloseItem(item_to_deactivate);
            };

            It should_ask_the_item_if_it_can_close = () =>
            {
                item_to_deactivate.received(x => x.CanClose(Arg<Action<bool>>.Is.Anything)).OnlyOnce();
            };

            private static ITabViewModel item_to_deactivate;
        }

        [Subject(typeof(ActionTabsViewModel))]
        public class when_a_tab_asks_to_be_closed : concern
        {
            Establish c = () =>
            {
                a_close_message = an<ICloseTabMessage>();
                a_tab_view_model = an<ITabViewModel>();
                a_close_message.Item = a_tab_view_model;
            };

            Because b = () =>
            {
                sut.Handle(a_close_message);
            };

            It should_try_to_close_the_view_model_in_the_message = () =>
            {
                a_tab_view_model.received(x => x.CanClose(Arg<Action<bool>>.Is.Anything)).OnlyOnce();
            };

            static ICloseTabMessage a_close_message;
            static ITabViewModel a_tab_view_model;
        }

        [Subject(typeof(ActionTabsViewModel))]
        public class when_a_new_view_must_be_shown : concern
        {
            Establish c = () =>
            {
                a_tab_view = an<ITabViewModel>();
                a_show_tab_view_message = an<IShowTabViewMessage>();
                a_show_tab_view_message.Item = a_tab_view;
            };

            Because b = () =>
            {
                sut.Handle(a_show_tab_view_message);
            };

            It should_activate_the_new_view = () =>
            {
                sut.Items.Contains(a_tab_view).ShouldBeTrue();
            };

            static ITabViewModel a_tab_view;
            static IShowTabViewMessage a_show_tab_view_message;
        }
    }
}