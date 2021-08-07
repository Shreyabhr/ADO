using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MySQLConnectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MySQLServer"].ConnectionString;
            var connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("connection opened");
                Console.WriteLine(connection.Database);
                Console.WriteLine(connection.DataSource);
                Console.WriteLine(connection.ConnectionTimeout);
                Console.WriteLine(connection.State);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            Console.ReadLine();
        }
    }
}
