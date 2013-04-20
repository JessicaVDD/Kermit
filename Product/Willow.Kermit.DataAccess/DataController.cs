using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Willow.Kermit.DataAccess
{
    public class DataController
    {
    }

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

    public class Query 
    {
        public string Text { get; set; }
        public CommandType Type { get; set; }
        public IEnumerable<QueryParameter> Parameters { get; private set; }
    }

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

    public class ParameterValue 
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }

    public class QueryBuilder 
    {
        DbProviderFactory _factory;
        public QueryBuilder(DbProviderFactory factory)
        {
            _factory = factory;
        }

        public DataCommand Build(Query q)
        {
            var cmd = _factory.CreateCommand();
            cmd.CommandText = q.Text;
            cmd.CommandType = q.Type;

            foreach (var p in q.Parameters)
            {
                var param = cmd.CreateParameter();
                param.ParameterName = p.Name;
                param.Direction = p.Direction;
                SetDbType(param, p.Type);
                if (p.Size.HasValue) param.Size = p.Size.Value;
                var iDbDataParam = param as IDbDataParameter;
                if (iDbDataParam != null)
                {
                    if (p.Precision.HasValue) iDbDataParam.Precision = p.Precision.Value;
                    if (p.Scale.HasValue) iDbDataParam.Scale = p.Scale.Value;
                }
                cmd.Parameters.Add(param);
            }

            return new DataCommand(cmd);
        }

        private static Dictionary<Type, PropertyInfo> _DbTypePropertyCache = new Dictionary<Type, PropertyInfo>();
        public static void SetDbType(DbParameter param, string type)
        {
            if (param == null) return;
            if (string.IsNullOrWhiteSpace(type)) return;

            var paramType = param.GetType();
            PropertyInfo dbTypeProp = null;
            if (!_DbTypePropertyCache.TryGetValue(paramType, out dbTypeProp))
            {
                dbTypeProp = paramType.GetProperties().Where(x => x.GetCustomAttributes(typeof(DbProviderSpecificTypePropertyAttribute), true).Any()).FirstOrDefault();
                _DbTypePropertyCache[paramType] = dbTypeProp;
            }
            if (dbTypeProp == null) return;

            try { dbTypeProp.SetValue(param, Enum.Parse(dbTypeProp.PropertyType, type)); }
            catch (ArgumentException) { }
        }
    }

    public class DataCommand 
    {
        private DbCommand _command;
        public DataCommand(DbCommand cmd)
        {
            _command = cmd;
        }

        public IDbTransaction OpenConnection(DataTransaction dt)
        {
            var dbTrans = dt.Transaction as DbTransaction;
            DbConnection connection = dt.Transaction == null ? null : (DbConnection)dt.Transaction.Connection;

            if (connection == null)
            {
                connection = dt.Handler.CreateConnection();
                connection.Open();
            }
            _command.Connection = connection;

            if (dt.UseTransaction)
            {
                if (dbTrans == null) dbTrans = connection.BeginTransaction();
            }
            _command.Transaction = dbTrans;

            return dbTrans == null ? new NonTransaction(connection) : (IDbTransaction)dbTrans;
        }

        public DataCommand FillParameters(Query qry, IEnumerable<ParameterValue> paramValues)
        {
            foreach (var p in _command.Parameters.Cast<DbParameter>())
            {
                var pv = paramValues.FirstOrDefault(x => x.Name == p.ParameterName);
                if (pv != null)
                    p.Value = pv.Value == null ? DBNull.Value : pv.Value;
                else
                {
                    var defaultValue = qry.Parameters.First(x => x.Name == p.ParameterName).DefaultValue;
                    if (defaultValue != null) p.Value = defaultValue;
                }
            }
            return this;
        }

        public IDataReader ExecuteReader()
        {
            return _command.ExecuteReader();
        }

        public int ExecuteNonQuery()
        {
            return _command.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            return _command.ExecuteScalar();
        }
    }

    public class NonTransaction : IDbTransaction
    {
        private IDbConnection _connection;
        public NonTransaction(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Commit()
        {
        }

        public IDbConnection Connection
        {
            get { return _connection; }
        }

        public IsolationLevel IsolationLevel
        {
            get { return IsolationLevel.Chaos; }
        }

        public void Rollback()
        {
        }

        public void Dispose()
        {
        }
    }

    public class DataTransaction : IDisposable
    {
        private ConnectionHandler _handler;
        public DataTransaction(ConnectionHandler handler, bool useTransaction)
        {
            if (handler == null) throw new ArgumentNullException("handler");
            _handler = handler;
            UseTransaction = useTransaction;
        }

        public IDbTransaction Transaction { get; private set;}
        public ConnectionHandler Handler { get { return _handler; } }
        public bool UseTransaction { get; set; }

        public object[] Load(Query qry, IEnumerable<ParameterValue> paramValues)
        {
            var cmd = _handler.Build(qry);
            Transaction = cmd.OpenConnection(this);

            var reader = cmd.FillParameters(qry, paramValues).ExecuteReader();
            while (reader.Read())
            {
            }
            reader.Close();
            //treat the return values of the function!!! cmd.FillReturnParameters(paramValues)

            return null;
        }

        public object LoadObject(Query qry, IEnumerable<ParameterValue> paramValue) 
        {
            var cmd = _handler.Build(qry);
            Transaction = cmd.OpenConnection(this);
            var reader = cmd.FillParameters(qry, paramValue).ExecuteReader();
            if (reader.Read())
            {
            }
            reader.Close();
            //treat the return values of the function!!!
            return null;
        }

        public object GetValue(Query qry, IEnumerable<ParameterValue> paramValue)
        {
            var cmd = _handler.Build(qry);
            Transaction = cmd.OpenConnection(this);
            return cmd.FillParameters(qry, paramValue).ExecuteScalar();
            //treat the return values of the function!!!
        }

        public void Execute(Query qry, IEnumerable<ParameterValue> paramValue)
        {
            var cmd = _handler.Build(qry);
            Transaction = cmd.OpenConnection(this);
            cmd.FillParameters(qry, paramValue).ExecuteNonQuery();
            //treat the return values of the function!!!
        }

        public void Commit()
        {
            if (Transaction == null) return;

            Transaction.Commit();
            var trans = new NonTransaction(Transaction.Connection);
            Transaction.Dispose();
            Transaction = trans;
        }

        public void Rollback()
        {
            if (Transaction == null) return;

            Transaction.Rollback();
            var trans = new NonTransaction(Transaction.Connection);
            Transaction.Dispose();
            Transaction = trans;
        }

        public void Close()
        {
            if (Transaction == null) return;
            Transaction.Commit();
            Transaction.Connection.Dispose();
            Transaction.Dispose();
            Transaction = null;
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
                if (Transaction != null)
                {
                    Transaction.Commit();
                }
            }
            //Free unmanaged (called in dispose and in finalizer situations)
            if (Transaction != null)
            {
                Transaction.Connection.Dispose();
                Transaction.Dispose();
            }
            Transaction = null;
        }

        ~DataTransaction()
        {
            Dispose(false);
        }
        #endregion

    }

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
