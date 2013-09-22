using System.Linq;
using Caliburn.Micro;
using Willow.Kermit.Model;
using System.Collections.Generic;

namespace Willow.Kermit.Child.ViewModels
{
    public class GezinViewModel : Screen
    {
        Client child;

        public GezinViewModel(Client child)
        {
            this.child = child;
        }

        public IObservableCollection<Family> Families
        {
            get { return child.Families; }
        }

        public bool HasFamily { get { return child.Families.Count > 0; } }

        public void AddFamily()
        {
            FamilyFactory.AddNewFor(child);
            NotifyOfPropertyChange(() => HasFamily);
        }

        public void RemoveFamily(Family family)
        {
            child.Families.Remove(family);
            NotifyOfPropertyChange(() => HasFamily);
        }

        public void AddRelation(Family fam)
        {
            RelationFactory.AddNewFor(fam);
        }

        public void RemoveRelation(Relation relation)
        {
            relation.Family.Relations.Remove(relation);
        }

    }
}