using System;
namespace Willow.Kermit.Model
{
    public class RelationFactory
    {
        public static Relation CreateNew()
        {
            return new Relation { IsExpanded = true };
        }
        public static Relation AddNewFor(Family fam)
        {
            var relation = new Relation { Family = fam, IsExpanded = true };
            fam.Relations.Add(relation);
            return relation;
        }
    }
}