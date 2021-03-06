﻿using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ProjectDicksonBackEnd.Models;

namespace ProjectDicksonBackEnd.Repository
{
    public class BarQueries : IBarQueries
    {
        private readonly IConnectionString _connString;

        public BarQueries(IConnectionString connString)
        {
            _connString = connString;
        }


        public List<Bar> GetBars()
        {
            using (SqlConnection connection = new SqlConnection(_connString.ConnectionStringBuilder()))
            {
                List<Bar> bars = new List<Bar>();

                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;

                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[SelectBars]";

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

                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;

                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[SelectBarName]";

                        command.Parameters.AddWithValue("@name", barName);

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

                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;

                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[SelectBarLocation]";

                        command.Parameters.AddWithValue("@location", location);

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
