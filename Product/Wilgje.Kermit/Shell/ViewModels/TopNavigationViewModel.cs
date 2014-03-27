using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Willow.Kermit.Shell.Interfaces;
using Willow.Kermit.Shell.Messages;
using Willow.Kermit.Util;

namespace Willow.Kermit.Shell.ViewModels
{
    [Export(typeof(TopNavigation))]
    public class TopNavigationViewModel : TopNavigation
    {
        private IEventAggregator _Events;

        [ImportingConstructor]
        public TopNavigationViewModel(ImageGetter getter, IEventAggregator events)
        {
            _Events = events;
            Commands = new List<CommandItem>
            {
                new CommandItem { Image = getter.Home, DoCommand = () => {_Events.Publish(new NavigationMessage { Action = NavigationCommand.Home });} },
                new CommandItem { Image = getter.ArrowLeft, DoCommand = () => {throw new NotImplementedException("Left command is not implemented yet");} },
                new CommandItem { Image = getter.ArrowRight, DoCommand = () => {throw new NotImplementedException("Right command is not implemented yet");} },
                new CommandItem { Image = getter.Settings, DoCommand = () => {throw new NotImplementedException("Settings command is not implemented yet");} },
                new CommandItem { Image = getter.Help, DoCommand = () => {throw new NotImplementedException("Help command is not implemented yet");} }
            };
        }
        public List<CommandItem> Commands { get; set; }
    }

    public enum NavigationCommand
    {
        Home,
        Left,
        Right,
        Settings,
        Help
    }

    public class CommandItem
    {
        public void Execute() { DoCommand(); }
        public BitmapImage Image { get; set; }
        public System.Action DoCommand { get; set; }
    }
}
