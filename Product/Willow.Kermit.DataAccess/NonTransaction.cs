using System.Data;

namespace Willow.Kermit.DataAccess
{
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
}