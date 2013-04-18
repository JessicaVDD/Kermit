using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willow.Kermit.DataAccess
{
    public class DataController
    {
    }

    public class Query
    {
        public string Text { get; set; }
        public CommandType Type { get; set; }
        public IEnumerable<QueryParameter> Parameters { get; private set; }
    }

    public class QueryParameter
    {
        public string Name { get; set; }
        public SqlDbType Type { get; set; } //string
        public ParameterDirection Direction { get; set; }
        public int? Size { get; set; }
        public byte? Precision { get; set; }
        public byte? Scale { get; set; }
        public object Value { get; set; }
    }

    public class DataTransaction
    {
        public object[] Query(Query qry)
        {
            var connection = new SqlConnection("Data Source=(localdb)\\Projects;Integrated Security=True;Pooling=False");
            var cmd = connection.CreateCommand();
            cmd.CommandText = qry.Text;
            cmd.CommandType = qry.Type;

            foreach (var p in qry.Parameters)
            {
                var factory = SqlClientFactory.Instance;
                
                var param = new SqlParameter(p.Name, p.Type);
                param.Value = p.Value;
                param.Direction = p.Direction;
                if (p.Size.HasValue) param.Size = p.Size.Value;
                if (p.Precision.HasValue) param.Precision = p.Precision.Value;
                if (p.Scale.HasValue) param.Scale = p.Scale.Value;
                cmd.Parameters.Add(param);
            }

            connection.Open();
            var trans = connection.BeginTransaction();
            cmd.Transaction = trans;

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
            }
            reader.Close();

            trans.Commit();
            connection.Close();


            return null;
        }

        public object GetValue()
        {
            return null;
        }

        public void Execute()
        {

        }
    }

    public class DataHandler : IDisposable
    {
        IDbConnection connection;
        public DataHandler() { }

        public IDbConnection Connection 
        { 
            get 
            { 
                if (connection == null) connection = new SqlConnection(); 
                return connection; 
            } 
        }

        public IDbCommand CreateCommand()
        {
            return connection.CreateCommand();
        }

        public IDbTransaction CreateTransaction()
        {
            if (Connection.State == ConnectionState.Open)
                return Connection.BeginTransaction();
            else
                return null;
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                //Free managed resources
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                    connection.Dispose();
                    connection = null;
                }
            }
            //Free unmanaged (called in dispose and in finalizer situations)
        }

        ~DataHandler()
        {
            Dispose(false);
        }
        #endregion
    }
}
