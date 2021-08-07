using System; 
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SQlOperationApp
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
                Console.WriteLine("1)Insert\n2)Delete\n3)Update\n4)Display");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: 
                        Insert(sql);
                        break;

                    case 2:
                        Delete(sql);
                        break;

                    case 3:
                        Update(sql);
                        break;
                    case 4:
                        Display(sql);
                        break;
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
            Console.WriteLine("END");
        }

        private static void Display(SqlConnection sql)
        {
            SqlCommand display = new SqlCommand("SELECT * FROM EMP", sql);
            SqlDataReader reader = display.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader["ENAME"],reader["JOB"],reader["MGR"],reader["SAL"],reader["COMM"].ToString(),reader["DEPTNO"]);
                }
            }
        }

        private static void Update(SqlConnection sql)
        {
            SqlCommand update = new SqlCommand("UPDATE EMP SET JOB = 'SALESMAN' WHERE ENAME = 'abc'",sql);
            update.ExecuteNonQuery();
            Console.WriteLine("Updated succesfully");

        }

        private static void Delete(SqlConnection sql)
        {
            SqlCommand delete = new SqlCommand("DELETE FROM EMP WHERE ENAME = 'abc'",sql);
            delete.ExecuteNonQuery();
            Console.WriteLine("Deleted succesfully");
        }

        private static void Insert(SqlConnection sql)
        {
            SqlCommand insert = new SqlCommand("INSERT INTO EMP VALUES(7888,'abc','CLERK',7782,'05-MAY-99',1500,NULL,10)",sql);
            insert.ExecuteNonQuery();
            Console.WriteLine("Inserted succesfully");
        }
    }
}
