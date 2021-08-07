using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace SQLInjectionSolutionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
            SqlConnection sql = new SqlConnection(connectionString);
            Console.WriteLine("Enter department no:");
            
            try
            {
                sql.Open();
                var cmd = new SqlCommand("SELECT * FROM EMP WHERE DEPTNO=@Deptno", sql);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Deptno";
                param.Value = Console.ReadLine();
                cmd.Parameters.Add(param);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}",reader["ENAME"], reader["JOB"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sql.State == ConnectionState.Open)
                {
                    sql.Close();
                }
            }
            Console.ReadLine();
        }
    }
}
