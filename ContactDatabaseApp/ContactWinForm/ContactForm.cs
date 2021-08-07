using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ContactWinForm
{
    public partial class ContactForm : Form
    {
        private SqlConnection _sql;
        public ContactForm()
        {
            InitializeComponent();
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;
            _sql = new SqlConnection(connectionString);
        }

        private void AddContact(object sender, EventArgs e)
        {
            if (_sql.State == ConnectionState.Closed)
            {
                _sql.Open();
            }
           
            System.Guid guid = System.Guid.NewGuid();
            var id = guid.ToString();
            var addid = id;

            var contactCommand = new SqlCommand("INSERT INTO CONTACT VALUES(@id,@contact,@name)", _sql);
            var addressCommand = new SqlCommand("INSERT INTO ADDRESSES VALUES(@addid,@permanentaddress,@tempaddress)", _sql);

            contactCommand.Parameters.Add(new SqlParameter("@contact",textBox1.Text));
            contactCommand.Parameters.Add(new SqlParameter("@id", id));
            contactCommand.Parameters.Add(new SqlParameter("@name", textBox4.Text));

            addressCommand.Parameters.Add(new SqlParameter("@addid", addid));
            addressCommand.Parameters.Add(new SqlParameter("@permanentaddress", textBox3.Text));
            addressCommand.Parameters.Add(new SqlParameter("@tempaddress", textBox2.Text));

            contactCommand.ExecuteNonQuery();
            addressCommand.ExecuteNonQuery();

            _sql.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Display(object sender, EventArgs e)
        {
            if (_sql.State == ConnectionState.Closed)
            {
                _sql.Open();
            }
            var command = new SqlCommand("SELECT * FROM CONTACT", _sql);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ContactID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Contact");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DataRow row = dataTable.NewRow();
                    row["ContactID"] = reader["CONTACTID"];
                    row["Name"] = reader["NAME"];
                    row["Contact"] = reader["CONTACT"];
                    dataTable.Rows.Add(row);
                }

            }
            dataGridView1.DataSource = dataTable;
            _sql.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            AddressForm form = new AddressForm(value,_sql);
            form.ShowDialog();
        }
    }
}
