using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ProjectDicksonBackEnd.Models;

namespace ProjectDicksonBackEnd.Repository
{
    public class PriceQueries : IPriceQueries
    {
        private readonly IConnectionString _connString;

        public PriceQueries(IConnectionString connString)
        {
            _connString = connString;
        }

        public List<Drink> GetDrinkUnderPrice(double price)
        {
            using (SqlConnection connection = new SqlConnection(_connString.ConnectionStringBuilder()))
            {
                List<Drink> drinks = new List<Drink>();

                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;

                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[DrinkUnderPrice]";

                        command.Parameters.AddWithValue("@price", price);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                drinks.Add(new Drink
                                {
                                    Id = Convert.ToString(reader[0]),
                                    DrinkName = Convert.ToString(reader[1]),
                                    Price = Convert.ToString(reader[2]),
                                    BarName = Convert.ToString(reader[3]),
                                    Category = Convert.ToString(reader[4])
                                });
                            }
                        }

                        connection.Close();
                        return drinks;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }

        public List<Drink> GetDrinkBetweenPrice(double low, double high)
        {
            using (SqlConnection connection = new SqlConnection(_connString.ConnectionStringBuilder()))
            {
                List<Drink> drinks = new List<Drink>();

                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;

                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "[dbo].[DrinkBetweenPrice]";

                        command.Parameters.AddWithValue("@low", low);
                        command.Parameters.AddWithValue("@high", high);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                drinks.Add(new Drink
                                {
                                    Id = Convert.ToString(reader[0]),
                                    DrinkName = Convert.ToString(reader[1]),
                                    Price = Convert.ToString(reader[2]),
                                    BarName = Convert.ToString(reader[3]),
                                    Category = Convert.ToString(reader[4])
                                });
                            }
                        }

                        connection.Close();
                        return drinks;
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
