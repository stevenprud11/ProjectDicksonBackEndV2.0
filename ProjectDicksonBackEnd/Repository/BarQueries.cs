using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ProjectDicksonBackEnd.Models;
using Dapper;
using System.Linq;

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

                Console.WriteLine($"Executing GetBars");

                try
                {
                    bars = connection.Query<Bar>("[dbo].[SelectBars]", commandType: CommandType.StoredProcedure).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error getting list of Bars");
                    throw e;
                }

                Console.WriteLine($"Returning list of Bars");

                return bars.OrderBy(x => x.BarName).ToList();
            }
        }

        public List<Bar> GetBars(string barName)
        {
            using (SqlConnection connection = new SqlConnection(_connString.ConnectionStringBuilder()))
            {
                List<Bar> bars = new List<Bar>();

                var parameters = new DynamicParameters();
                parameters.Add("@name", barName, dbType: DbType.String);

                Console.WriteLine($"Executing GetBars by {barName}");

                try
                {
                    bars = connection.Query<Bar>("[dbo].[SelectBarName]", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error getting list of Bars by {barName}");
                    throw e;
                }

                return bars;

            }
        }

        public List<Bar> SearchBarLocation(string location)
        {
            using (SqlConnection connection = new SqlConnection(_connString.ConnectionStringBuilder()))
            {
                List<Bar> bars = new List<Bar>();

                var parameters = new DynamicParameters();
                parameters.Add("@location", location, dbType: DbType.String);

                Console.WriteLine($"Executing GetBars by location: {location}");

                try
                {
                    bars = connection.Query<Bar>("[dbo].[SelectBarLocation]", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error getting list of Bars by location: {location}");
                    throw e;
                }

                return bars;

            }
        }
    }
}
