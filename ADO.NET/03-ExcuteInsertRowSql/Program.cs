using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
namespace ExecuteInsertRawSql
{
    class Program
    {
        public static void Main()
        {

            // Load configuration to load and access appsetting file
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // read from user input
            var walletToInsert = new Wallet
            {
                Holder = "mahmoud Khaled",
                Balance = 10000
            };

            SqlConnection conn = new SqlConnection(configuration.GetSection("ConnectionString").Value);

            var sql = "INSERT INTO WALLETS (Holder, Balance) VALUES"+
                $"(@Holder,@Balance)";

            SqlParameter holderParameter = new SqlParameter
            {
                ParameterName = "@Holder",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = walletToInsert.Holder,

            };
            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                Value = walletToInsert.Balance,
            };



            // writing sql query  
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add(holderParameter);
            cmd.Parameters.Add(balanceParameter);



            cmd.CommandType = CommandType.Text;

            // Opening Connection  
            conn.Open();

           
            Console.WriteLine($"wallet {walletToInsert} added successully");

            conn.Close();

            Console.ReadLine();
        }
    }
}