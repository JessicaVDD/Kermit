using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Willow.Kermit.DataAccess
{
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
}