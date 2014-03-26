using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Willow.Kermit.Shell.Interfaces;
using Willow.Kermit.Util;

namespace Willow.Kermit.General.ViewModels
{
    [Export(typeof(SearchPanel))]
    public class SearchPanelViewModel : PropertyChangedBase, SearchPanel
    {
        [ImportingConstructor]
        public SearchPanelViewModel(ImageGetter getter)
        {
            Search = getter.SearchSmall;
        }

        private string _SearchText;
        public string SearchText
        {
            get { return _SearchText; }
            set { _SearchText = value; NotifyOfPropertyChange(() => SearchText); }
        }

        public BitmapImage Search {get; private set;}

        public void DoSearch()
        {
            throw new NotImplementedException("The search button is not active");
        }

        public void DoSearchWithEnter(System.Windows.Input.KeyEventArgs e)
        {
            throw new NotImplementedException("The search box is not active");
        }
    }
}
