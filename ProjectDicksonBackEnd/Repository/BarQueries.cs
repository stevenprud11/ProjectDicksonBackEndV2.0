using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjectDicksonBackEnd.Models;

namespace ProjectDicksonBackEnd.Repository
{
    public class BarQueries : IBarQueries
    {
        private readonly SqlConnectionModel _sql;

        public BarQueries(SqlConnectionModel sql)
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


        public List<Bar> GetBars()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringBuilder()))
            {
                List<Bar> bars = new List<Bar>();

                using (SqlCommand command = new SqlCommand("Select * from Bar", connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bars.Add(new Bar { Id = Convert.ToString(reader[0]),
                                    Name = (string)reader[1],
                                    Location = (string)reader[2],
                                    Phone = (string)reader[3]
                                });
                            }
                        }

                        connection.Close();
                        return bars;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }

        public List<Bar> GetBars(string barName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringBuilder()))
            {
                List<Bar> bars = new List<Bar>();

                using (SqlCommand command = new SqlCommand($"Select * from Bar where BarName like '%{barName}%'", connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bars.Add(new Bar
                                {
                                    Id = Convert.ToString(reader[0]),
                                    Name = (string)reader[1],
                                    Location = (string)reader[2],
                                    Phone = (string)reader[3]
                                });
                            }
                        }

                        connection.Close();
                        return bars;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }

        public List<Bar> SearchBarLocation(string location)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringBuilder()))
            {
                List<Bar> bars = new List<Bar>();

                using (SqlCommand command = new SqlCommand($"Select * from Bar where BarLocation like '%{location}%'", connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bars.Add(new Bar
                                {
                                    Id = Convert.ToString(reader[0]),
                                    Name = (string)reader[1],
                                    Location = (string)reader[2],
                                    Phone = (string)reader[3]
                                });
                            }
                        }

                        connection.Close();
                        return bars;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }
    }
}
