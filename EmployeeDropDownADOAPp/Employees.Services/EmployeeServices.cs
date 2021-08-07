using Employees.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Employees.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private SqlConnection _sqlConnection;

        public EmployeeServices()
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString);
        }

        public List<Employee> GetEmployee(int deptNo)
        {
            _sqlConnection.Open();

            var sqlCommand = new SqlCommand("SELECT * FROM EMP WHERE DEPTNO = @deptno", _sqlConnection);
            sqlCommand.Parameters.Add(new SqlParameter("@deptno", deptNo));
            var dr = sqlCommand.ExecuteReader();

            List<Employee> employees = new List<Employee>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employees.Add(new Employee(Convert.ToInt32(dr[0]), Convert.ToString(dr[1]), Convert.ToString(dr[2])));
                }
            }
            _sqlConnection.Close();
            return employees;
        }

        public List<Department> GetDepartment()
        {
            _sqlConnection.Open();
            var sqlCommand = new SqlCommand("SELECT DISTINCT * FROM DEPT", _sqlConnection);
            var dr = sqlCommand.ExecuteReader();

            List<Department> departments = new List<Department>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    departments.Add(new Department(Convert.ToInt32(dr[0]), dr.GetString(1), dr.GetString(2)));
                }
            }
            _sqlConnection.Close();
            return departments;
        }
    }
}
