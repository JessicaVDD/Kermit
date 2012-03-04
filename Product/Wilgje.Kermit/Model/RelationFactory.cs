namespace Willow.Kermit.Model
{
    public class RelationFactory
    {
        public static Relation CreateNew()
        {
            return new Relation {Name = "Peter", RelationType = RelationType.Broer};
        }
    }
}