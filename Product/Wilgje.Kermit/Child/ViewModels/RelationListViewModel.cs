using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Willow.Kermit.Model;

namespace Willow.Kermit.Child.ViewModels
{
    public class RelationListViewModel : Screen 
    {
        Client _child;

        public RelationListViewModel(Client child)
        {
            _child = child;
            Relations = _child.Relations.Select(x => new RelationVisualCardViewModel(x)).ToList();           
        }
        public IList<RelationVisualCardViewModel> Relations { get; set; }


    }
}