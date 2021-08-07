using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TransactionApp
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
                Console.WriteLine("Enter customerId: ");
                var cid = Console.ReadLine();
                Console.WriteLine("Enter MerchantId: ");
                var mid = Console.ReadLine();
                Console.WriteLine("Enter the purchase amount: ");
                var amt = Console.ReadLine();
                var cutomercmd = new SqlCommand("UPDATE CUSTOMER SET AMOUNT = AMOUNT-@amt WHERE CUSTOMERID = @Cid", sql);
                var merchantcmd = new SqlCommand("UPDATE MERCHANT SET AMOUNT = AMOUNT-@merchantamt WHERE MERCHANDID = @Mid", sql);
                SqlParameter param = new SqlParameter("@Cid",cid);
                cutomercmd.Parameters.Add(param);

                SqlParameter merchantId = new SqlParameter("@Mid",mid);
                merchantcmd.Parameters.Add(merchantId);
            
                SqlParameter cusAmount = new SqlParameter("@amt",amt);
                cutomercmd.Parameters.Add(cusAmount);

                SqlParameter merchantamount = new SqlParameter("@merchantamt",amt);
                merchantcmd.Parameters.Add(merchantamount);
            
                merchantcmd.ExecuteNonQuery();
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
            Console.ReadLine();
        }
    }
}
