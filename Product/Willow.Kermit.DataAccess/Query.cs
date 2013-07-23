using System.Collections.Generic;
using System.Data;

namespace Willow.Kermit.DataAccess
{
    public class Query 
    {
        public string Text { get; set; }
        public CommandType Type { get; set; }
        public IEnumerable<QueryParameter> Parameters { get; private set; }
    }
}