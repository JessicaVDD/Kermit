using Caliburn.Micro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Willow.Kermit.General.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Willow.Kermit.General.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Willow.Kermit.General.Controls;assembly=Willow.Kermit.General.Controls"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:EasyListControl/>
    ///
    /// </summary>


    public class EasyListControl : Control
    {
        private static string _PART_AddButton = "PART_AddButton";
        
        static EasyListControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EasyListControl), new FrameworkPropertyMetadata(typeof(EasyListControl)));
            ConventionManager.AddElementConvention<GenderControl>(GenderControl.GenderProperty, "Items", "ItemsChanged");
        }

        public static readonly DependencyProperty EasyListPanelProperty = DependencyProperty.Register("EasyListPanel", typeof(ItemsPanelTemplate), typeof(EasyListControl));
        public static readonly DependencyProperty EasyListItemProperty = DependencyProperty.Register("EasyListItem", typeof(DataTemplate), typeof(EasyListControl));
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(IEnumerable), typeof(EasyListControl));

        public static readonly RoutedEvent AddListItemEvent = EventManager.RegisterRoutedEvent("AddListItem", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(EasyListControl));
        public static readonly RoutedEvent RemoveListItemEvent = EventManager.RegisterRoutedEvent("RemoveListItem", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(EasyListControl));

        public ItemsPanelTemplate EasyListPanel
        {
            get { return (ItemsPanelTemplate)GetValue(EasyListPanelProperty); }
            set { SetValue(EasyListPanelProperty, value); }
        }

        public DataTemplate EasyListItem
        {
            get { return (DataTemplate)GetValue(EasyListItemProperty); }
            set { SetValue(EasyListItemProperty, value); }
        }

        public IEnumerable Items
        {
            get { return (IEnumerable)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeleteCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(EasyListControl), new PropertyMetadata(null));


        private void HandleDelete(object listItem)
        {
            RaiseRemoveListItemEvent(listItem);
        }

        public event RoutedEventHandler AddListItem
        {
            add { AddHandler(AddListItemEvent, value); }
            remove { RemoveHandler(AddListItemEvent, value); }
        }

        public event RoutedEventHandler RemoveListItem
        {
            add { AddHandler(RemoveListItemEvent, value); }
            remove { RemoveHandler(RemoveListItemEvent, value); }
        }

        void RaiseAddListItemEvent()
        {
            var newEventArgs = new RoutedEventArgs(EasyListControl.AddListItemEvent);
            RaiseEvent(newEventArgs);
        }

        void RaiseRemoveListItemEvent(object listItem)
        {
            var newEventArgs = new RoutedEventArgs(EasyListControl.RemoveListItemEvent, listItem);
            RaiseEvent(newEventArgs);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var addListButton = this.GetTemplateChild(_PART_AddButton) as Button;
            if (addListButton != null)
            {
                addListButton.Click += (s, e) => RaiseAddListItemEvent();
            }

            DeleteCommand = new RelayCommand(x => true, x => HandleDelete(x));
        }
    }

        public class RelayCommand : ICommand
    {
        private Predicate<object> _canExecute;
        private Action<object> _execute;
        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }

}
