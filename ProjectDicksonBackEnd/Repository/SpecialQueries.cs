using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using ProjectDicksonBackEnd.Models;
using Dapper;
using System.Linq;

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

                Console.WriteLine("Executing GetSpecials");

                try
                {
                    specials = connection.Query<Special>("[dbo].[GetSpecials]",  commandType: CommandType.StoredProcedure).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error getting list of specials");
                    throw e;
                }

                Console.WriteLine("Returning list of specials");
                return specials;
            }
        }

        public List<Special> GetSpecialsByBar(string barname)
        {
            using (SqlConnection connection = new SqlConnection(_connString.ConnectionStringBuilder()))
            {
                List<Special> specials = new List<Special>();
                var parameters = new DynamicParameters();
                parameters.Add("@barname", barname, dbType: DbType.String);

                Console.WriteLine($"Executing GetSpecialsByBar for {barname}");

                try
                {
                    specials = connection.Query<Special>("[dbo].[GetSpecialsByBar]", parameters,  commandType: CommandType.StoredProcedure).ToList();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error getting list of specials by bar");
                    throw e;
                }
                if (specials.Count == 0)
                    Console.WriteLine($"No specials for Bar {barname}");

                Console.WriteLine($"Returning list of specials for bar {barname}");

                return specials;
            }
        }
    }
}
