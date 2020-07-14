using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProjectDicksonBackEnd.Models;

namespace ProjectDicksonBackEnd.Repository
{
    public class DrinkQueries : IDrinkQueries
    {
        private readonly SqlConnectionModel _sql;

        public DrinkQueries(SqlConnectionModel sql)
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


        public List<Drink> GetDrinks()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringBuilder()))
            {
                List<Drink> drinks = new List<Drink>();

                using (SqlCommand command = new SqlCommand("select Drink.Id, Drink.DrinkName, Price.Price, Bar.BarName, Category.CategoryName from Drink " +
                    "inner join Category on Category.Id = Drink.CategoryId " +
                    "inner join Price on Price.DrinkId = Drink.Id " +
                    "inner join Bar on Bar.Id = Price.BarId " +
                    "order by Drink.Id;", connection))
                {
                    try
                    {
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


        public List<Drink> GetDrinks(string drinkName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringBuilder()))
            { 
                List<Drink> drinks = new List<Drink>();

                using (SqlCommand command = new SqlCommand($"select Drink.Id, DrinkName, Price.Price, Bar.BarName, Category.CategoryName from Drink "+
                    $"join Price on Price.DrinkId = Drink.Id "+
                    $"join Bar on Bar.Id = Price.BarId "+
                    $"join Category on Category.Id = Drink.CategoryId " +
                    $"where DrinkName like '%{drinkName}%' " +
                    $"order by DrinkName;", connection))
                {
                    try
                    {
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


        public List<Drink> GetDrinksFrom(string barName)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStringBuilder()))
            {
                List<Drink> drinks = new List<Drink>();

                using (SqlCommand command = new SqlCommand($"select Drink.Id, DrinkName, Price.Price, Bar.BarName, Category.CategoryName from Drink " +
                    $"join Price on Price.DrinkId = Drink.Id " +
                    $"join Bar on Bar.Id = Price.BarId " +
                    $"join Category on Category.Id = Drink.CategoryId " +
                    $"where BarName like '%{barName}%' " +
                    $"order by DrinkName;", connection))
                {
                    try
                    {
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
