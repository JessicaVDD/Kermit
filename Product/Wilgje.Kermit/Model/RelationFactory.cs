using System;
namespace Willow.Kermit.Model
{
    public class RelationFactory
    {
        public static Relation CreateNew()
        {
            return new Relation();
        }
        public static Relation AddNewFor(Family fam)
        {
            var relation = new Relation { Family = fam };
            fam.Relations.Add(relation);
            return relation;
        }
    }
}