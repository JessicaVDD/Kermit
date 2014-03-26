using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Willow.Kermit.Shell.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.Shell.ViewModels
{
    [Export(typeof(TopNavigation))]
    public class TopNavigationViewModel : TopNavigation
    {
        [ImportingConstructor]
        public TopNavigationViewModel(ImageGetter getter)
        {
            Commands = new List<CommandItem>
            {
                new CommandItem { Image = getter.Home, DoCommand = () => {throw new NotImplementedException("Home command is not implemented yet");} },
                new CommandItem { Image = getter.ArrowLeft, DoCommand = () => {throw new NotImplementedException("Left command is not implemented yet");} },
                new CommandItem { Image = getter.ArrowRight, DoCommand = () => {throw new NotImplementedException("Right command is not implemented yet");} },
                new CommandItem { Image = getter.Settings, DoCommand = () => {throw new NotImplementedException("Settings command is not implemented yet");} },
                new CommandItem { Image = getter.Help, DoCommand = () => {throw new NotImplementedException("Help command is not implemented yet");} }
            };
        }
        public List<CommandItem> Commands { get; set; }
    }

    public class CommandItem
    {
        public void Execute() { DoCommand(); }
        public BitmapImage Image { get; set; }
        public Action DoCommand { get; set; }
    }
}
