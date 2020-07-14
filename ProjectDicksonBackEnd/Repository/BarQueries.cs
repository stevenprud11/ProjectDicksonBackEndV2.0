using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjectDicksonBackEnd.Models;

namespace ProjectDicksonBackEnd.Repository
{
    public class BarQueries : IBarQueries
    {
        private readonly ConnectionString _connString;

        public BarQueries(ConnectionString connString)
        {
            _connString = connString;
        }


        public List<Bar> GetBars()
        {
            using (SqlConnection connection = new SqlConnection(_connString.ConnectionStringBuilder()))
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
            using (SqlConnection connection = new SqlConnection(_connString.ConnectionStringBuilder()))
            {
                List<Bar> bars = new List<Bar>();

                using (SqlCommand command = new SqlCommand($"Select * from Bar where BarName like '%{barName}%' order by BarName", connection))
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
            using (SqlConnection connection = new SqlConnection(_connString.ConnectionStringBuilder()))
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
