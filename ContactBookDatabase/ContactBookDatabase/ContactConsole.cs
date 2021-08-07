using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ContactBookDatabase
{
    public class ContactConsole
    {
        public ContactConsole()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
            SqlConnection sql = new SqlConnection(connectionString);
            try
            {
                sql.Open();
                Console.WriteLine("1) Add contact\n2) Display Contact\n3)exit");
                int choice = 0;
                while (choice != 3)
                {
                    Console.WriteLine("Enter your choice: ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            ADD(sql);                                                                                               
                            break;
                        case 2:
                            Display(sql);                                                                                                           
                            break;
                    }
                }
            }
            catch(Exception e)
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

        }

        private void Display(SqlConnection sql)
        {
            SqlCommand display = new SqlCommand("SELECT * FROM CONTACT", sql);
            SqlDataReader reader = display.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0}", reader["CONTACT"]);
                }
            }
        }

        private void ADD(SqlConnection sql)
        {
            Console.WriteLine("Enter contact no: ");
            long contact = long.Parse(Console.ReadLine());
            SqlCommand insert = new SqlCommand("INSERT INTO CONTACT VALUES(" + contact + ")", sql);
            insert.ExecuteNonQuery();
            Console.WriteLine("inserted succesfully");
        }
    }
}
