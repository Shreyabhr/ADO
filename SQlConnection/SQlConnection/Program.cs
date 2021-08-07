using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SQlConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
            SqlConnection sql = new SqlConnection(connectionString);
            try
            {
                sql.Open();
                Console.WriteLine(sql.DataSource);
                Console.WriteLine(sql.Database);
                Console.WriteLine(sql.State);
                Console.WriteLine(sql.ConnectionTimeout);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(sql.State == ConnectionState.Open)
                {
                    sql.Close();
                }
            }
            Console.ReadLine();
            Console.WriteLine("END");

        }
    }
}
