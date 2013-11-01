using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willow.Kermit.Model
{
    public class FamilyFactory
    {
        public static Family AddNewFor(Client child)
        {
            var fam = new Family() { Name = "Een gezin", Address = new Address { Street="Urselweg", NumberBus="21A", PostalCode="9990", City="Maldegem", Country="België" }, IsExpanded = true };
            RelationFactory.AddNewFor(fam);
            child.Families.Add(fam);
            return fam;
        }
    }
}
