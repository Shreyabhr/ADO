using Employees.Model;
using System.Collections.Generic;

namespace Employees.Services
{
    public interface IEmployeeServices
    {
        List<Department> GetDepartment();
        List<Employee> GetEmployee(int deptNo);
    }
}