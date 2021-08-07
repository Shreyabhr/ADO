using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeDataAdapter
{
    public partial class DisplayData : Form
    {
        private DataSet set;
        public DisplayData()
        {
            InitializeComponent();
        }

        private void DisplayData_Load(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
            SqlConnection sql = new SqlConnection(connectionString);

            var cmd_emp = new SqlCommand("SELECT * FROM EMP", sql);
            var cmd_dept = new SqlCommand("SELECT * FROM DEPT", sql);
            set = new DataSet();

            var da = new SqlDataAdapter(cmd_emp);            
            da.Fill(set, "EMPTable");

            da = new SqlDataAdapter(cmd_dept);
            da.Fill(set, "DEPTTable");
        }

        private void ShowEmp(object sender, EventArgs e)
        {
            dataGridView1.DataSource = set.Tables[0];          
        }

        private void ShowDept(object sender, EventArgs e)
        {
            dataGridView2.DataSource = set.Tables[1];
        }
    }
}
