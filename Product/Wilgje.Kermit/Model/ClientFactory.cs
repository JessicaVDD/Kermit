using System.Collections.Generic;
using System.Collections.ObjectModel;
using Willow.Kermit.Util;

namespace Willow.Kermit.Model
{
    public class ClientFactory
    {
        public static Client CreateNew()
        {
            var rs = new ObservableCollection<Relation>
            {
                RelationFactory.CreateNew()
            };

            return new Client
            {
                BirthDate = null, 
                Location = "", 
                ResidentialGroup = "", 
                Status = "Eerste Inschrijving",
                FirstName = null
            };
        }
    }
}