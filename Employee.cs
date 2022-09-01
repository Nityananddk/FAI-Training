using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    [Serializable]
    public class Employee
    {
        static int empNo = 1000;
        public Employee()
        {
            EmpID = ++empNo;
        }

        public Employee(int id)
        {
            EmpID = id;
        }
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }
        public override string ToString()
        {
            return $"{EmpID}, {EmpName}, {EmpAddress}, {EmpSalary}";
        }
    }
}
