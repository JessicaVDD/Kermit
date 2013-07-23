using System.Data.Common;

namespace Willow.Kermit.DataAccess
{
    public class ConnectionHandler
    {
        private DataConfig _dataConfig;
        private QueryBuilder builder;

        public ConnectionHandler(DataConfig dataConfig) 
        { 
            _dataConfig = dataConfig; 
        }

        public DataCommand Build(Query qry)
        {
            if (builder == null) builder = new QueryBuilder(_dataConfig.Factory);
            return builder.Build(qry);
        }

        public DbConnection CreateConnection()
        {
            var connection = _dataConfig.Factory.CreateConnection();
            connection.ConnectionString = _dataConfig.ConnectionString;
            return connection;
        }
    }
}