using Caliburn.Micro;
using Willow.Kermit.Model;

namespace Willow.Kermit.Child.ViewModels
{
    public class RelationVisualCardViewModel : Screen
    {
        Relation _relation;

        public RelationVisualCardViewModel() : this(RelationFactory.CreateNew()) { }
        public RelationVisualCardViewModel(Relation relation)
        {
            _relation = relation;
        }

        public RelationType RelationType { get { return _relation.RelationType; } }
        public string FirstName { get { return _relation.Name; } }
    }
}