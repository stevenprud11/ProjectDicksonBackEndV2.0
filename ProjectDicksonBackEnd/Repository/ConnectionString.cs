using System;
using System.Data.SqlClient;

namespace ProjectDicksonBackEnd.Repository
{
    public class ConnectionString : IConnectionString
    {
        private readonly SqlConnectionModel _sql;

        public ConnectionString(SqlConnectionModel sql)
        {
            _sql = sql;
        }

        public string ConnectionStringBuilder()
        {
            string BaseConnectionString = _sql.BaseConnectionString;

            var builder = new SqlConnectionStringBuilder(BaseConnectionString)
            {
                DataSource = _sql.Hostname,
                InitialCatalog = _sql.Database,
                UserID = _sql.Username,
                Password = _sql.Password
            };

            return builder.ToString();
        }
    }
}
