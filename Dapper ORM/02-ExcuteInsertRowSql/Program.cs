using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;


namespace ExcuteInsertRowSql
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

            var WalletToInsert = new Wallet { Holder = "Sarah", Balance = 10000 };

            db.Execute("INSERT INTO Wallets (Holder,Balance) " +
                "VALUES (@Holder,@Balance)",new {Holder=WalletToInsert.Holder,Balance=WalletToInsert.Balance });
            
            Console.ReadLine();
        }
    }
}