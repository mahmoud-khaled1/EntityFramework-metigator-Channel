using Dapper;
using ExecuteRawSql;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;


namespace ExecuteRawSql
{
    class Program
    {
        public static void Main()
        {

            // Load configuration to load and access appsetting file
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


            IDbConnection db = new SqlConnection(configuration.GetSection("ConnectionString").Value);

            var resultAsDynamic = db.Query("select * from WALLETS");

            Console.WriteLine("-----------------using Dynamic Qery-----------------");
            foreach (var item in resultAsDynamic)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------using Typed Qery-----------------");

            var resultAsTyped = db.Query<Wallet>("select * from WALLETS");
            foreach (var item in resultAsTyped)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}