using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProjectDicksonBackEnd.Repository
{
    public class Sql : ISql
    {
        private readonly SqlConnectionModel _sql;

        public Sql(SqlConnectionModel sql)
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

        public void TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringBuilder()))
            {
                List<string> servers = new List<string>();

                using (SqlCommand command = new SqlCommand("Select BarName from Bar", connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0]);
                            }
                        }

                        connection.Close();
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
