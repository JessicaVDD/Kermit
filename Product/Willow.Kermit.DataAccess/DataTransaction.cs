using System;
using System.Collections.Generic;
using System.Data;

namespace Willow.Kermit.DataAccess
{
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
}