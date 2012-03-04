using System.Collections.Generic;
using Willow.Kermit.Util;

namespace Willow.Kermit.Model
{
    public class ClientFactory
    {
        public static Client CreateNew()
        {
            var rs = new List<Relation>
            {
                RelationFactory.CreateNew()
            };

            return new Client
            {
                Image = ImageGetter.Baby, 
                BirthDate = null, 
                Location = "", 
                ResidentialGroup = "", 
                Status = "Eerste Inschrijving",
                FirstName = null,
                Relations = rs
            };
        }
    }
}