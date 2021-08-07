using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Model
{
    public class Department
    {
        public int _deptNo;
        public string _dName;
        public string _location;

        public Department(int deptno, string dname, string loc)
        {
            _deptNo = deptno;
            _dName = dname;
            _location = loc;
        }

        public int DEPTNO 
        { get { return _deptNo; } set { _deptNo = value; } }
        public string DNAME
        { get { return _dName; } set { _dName = value; } }
        public string LOC
        { get { return _location; } set { _location = value; } }
    }
}
