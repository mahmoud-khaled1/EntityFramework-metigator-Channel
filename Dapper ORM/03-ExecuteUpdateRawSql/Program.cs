using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;


namespace ExecuteUpdateRawSql
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

            var walletToUpdate = new Wallet {Id=5, Holder = "amaar", Balance = 15000 };

            var sql = "UPDATE Wallets SET Holder = @Holder , Balance = @Balance " +
                     "WHERE Id = @Id;";

            var parameters =
                new
                {
                    Id = walletToUpdate.Id,
                    Holder = walletToUpdate.Holder,
                    Balance = walletToUpdate.Balance
                };

            db.Execute(sql, parameters);

            Console.ReadLine();
        }
    }
}