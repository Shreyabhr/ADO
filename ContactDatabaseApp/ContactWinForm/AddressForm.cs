using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ContactWinForm
{
    public partial class AddressForm : Form
    {
        public AddressForm(string value, SqlConnection sql)
        {
            InitializeComponent();
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            
            var command = new SqlCommand("SELECT * FROM ADDRESSES WHERE CONTACTID = @guid", sql);
            SqlParameter param = new SqlParameter("@guid", value);
            command.Parameters.Add(param);
            var reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Permanent");
            dataTable.Columns.Add("Temporary");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(1));
                    DataRow row = dataTable.NewRow();
                    var val = reader.GetString(1);
                    row["Permanent"] = reader[1].ToString();
                    row["Temporary"] = reader[2].ToString();
                    dataTable.Rows.Add(row);
                }
            }
            dataGridView1.DataSource = dataTable;
            sql.Close();
        }
    }
}
