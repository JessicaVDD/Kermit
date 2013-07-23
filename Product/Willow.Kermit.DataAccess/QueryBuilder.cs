using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace Willow.Kermit.DataAccess
{
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
}