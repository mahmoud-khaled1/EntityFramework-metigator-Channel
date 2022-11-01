using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;


namespace ExecuteDelete
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

            var walletToUpdate = new Wallet { Id = 5, Holder = "amaar", Balance = 15000 };

            var walletToDelete = new Wallet
            {
                Id = 5
            };

            var sql = "DELETE FROM Wallets WHERE Id = @Id;";


            var parameters =
                new
                {
                    Id = walletToDelete.Id
                };

            db.Execute(sql, parameters);
            Console.ReadLine();
        }
    }
}