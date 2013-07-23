using System.Data;

namespace Willow.Kermit.DataAccess
{
    public class QueryParameter 
    {
        public string Name { get; set; }
        public string Type { get; set; } //SqlDbType
        public ParameterDirection Direction { get; set; }
        public int? Size { get; set; }
        public byte? Precision { get; set; }
        public byte? Scale { get; set; }
        public object DefaultValue { get; set; }
    }
}