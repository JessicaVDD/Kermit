using System.Data.Common;

namespace Willow.Kermit.DataAccess
{
    public class DataConfig 
    {
        private DbProviderFactory _factory;
        public DataConfig(string databaseName)
        {
            //insertion of database name must be insertion of some config source
            ConnectionString = "Data Source=(localdb)\\Projects;Integrated Security=True;Pooling=False";
            DataProvider = "System.Data.SqlClient";
            UseTransaction = true;
        }
        public string ConnectionString { get; set; }
        public string DataProvider { get; set; }
        public bool UseTransaction { get; set; }
        public DbProviderFactory Factory
        {
            get
            {
                if (_factory == null)
                    _factory = DbProviderFactories.GetFactory(DataProvider);
                return _factory;
            }
        }

        public static ConnectionHandler Retrieve(string databaseName)
        {
            //use a config resolver to pass to the dataconfig
            return new ConnectionHandler(new DataConfig(databaseName));
        }
    }
}