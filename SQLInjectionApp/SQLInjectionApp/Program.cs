using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLInjectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
            SqlConnection sql = new SqlConnection(connectionString);
            Console.WriteLine("Enter the employee no:");
            string empno = Console.ReadLine();
            try
            {
                sql.Open();
                var cmd = new SqlCommand("SELECT * FROM EMP WHERE EMPNO=" + empno, sql);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["ENAME"]);
                        Console.WriteLine(reader["JOB"]);
                    }
                }
               
            }catch(Exception e)
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
        }
    }
}
