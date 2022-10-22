using Microsoft.Extensions.Configuration;
using System;

namespace ConnctionString
{
    class Program
    {
        public static void Main()
        {
            // to create appsetting file 
            /*
             * add ---> newItem ---> any Json file and rename to appsettings 
             * add connection string in the file 
             * right click on the file ---> properties ---> make buildAction to Embedded resource
             * CopyToOutpurDirctory to Copy always
             * 
             */



            // Load configuration to load and access  appsetting file
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // print connection String 
            Console.WriteLine(configuration.GetSection("ConnectionString").Value);

            Console.ReadLine();
        }
    }
}