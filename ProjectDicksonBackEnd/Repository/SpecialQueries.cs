using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ProjectDicksonBackEnd.Models;

namespace ProjectDicksonBackEnd.Repository
{
    public class SpecialQueries : ISpecialQueries
    {
        private readonly IConnectionString _connString;

        public SpecialQueries(IConnectionString connString)
        {
            _connString = connString;
        }

        public List<Special> GetSpecials()
        {
            using (SqlConnection connection = new SqlConnection(_connString.ConnectionStringBuilder()))
            {
                List<Special> specials = new List<Special>();

                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;

                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[GetSpecials]";


                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                specials.Add(new Special
                                {
                                    Id = Convert.ToString(reader[0]),
                                    Day = Convert.ToString(reader[1]),
                                    BarName = Convert.ToString(reader[2]),
                                    CategoryName = Convert.ToString(reader[3]),
                                    Price = Convert.ToString(reader[4]),
                                }); ;
                            }
                        }

                        connection.Close();
                        return specials;
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
