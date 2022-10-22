using ExecuteRawSql;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
namespace ConnctionString
{
    class Program
    {
        public static void Main()
        {
            
            // Load configuration to load and access appsetting file
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


            SqlConnection conn = new SqlConnection(configuration.GetSection("ConnectionString").Value);

            var sql = "SELECT * FROM WALLETS";

            // writing sql query  
            SqlCommand cmd = new SqlCommand(sql,conn);

            cmd.CommandType=CommandType.Text;

            // Opening Connection  
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Wallet wallet;
            while(reader.Read())
            {
                wallet = new Wallet()
                {
                    Id=Convert.ToInt32(reader["id"]),
                    Holder = reader["Holder"].ToString(),
                    Balance =Convert.ToDecimal(reader["Balance"])
                };
                Console.WriteLine(wallet);
            }
           
            conn.Close();
               
            Console.ReadLine();
        }
    }
}