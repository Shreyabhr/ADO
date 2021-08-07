namespace Employees.Model
{
    public class Employee
    {
        public int _empNo;
        public string _eName;
        public string _job;
       
        public Employee(int empno, string name, string job)
        {
            _empNo = empno;
            _eName = name;
            _job = job;
           
        }

        public int EMPNO
        { get { return _empNo; } set { _empNo = value; } }
        public string ENAME
        { get { return _eName; } set { _eName = value; } }
        public string JOB
        { get { return _job; } set { _job = value; } }
       
    }
}
