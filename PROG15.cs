using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp
{
    class SerializationComponent
    {
        //Employee employee = new Employee();
        static List<Employee> empList = new List<Employee>();
        public static List<Employee> getDataInput()
        {
            int choice = 1;
            //bool processing = true;
            do
            {
                Employee employee = new Employee();
                //employee.EmpID = Util
                employee.EmpName = Util.GetString("Enter employee name");
                employee.EmpAddress = Util.GetString("Enter Employee address");
                employee.EmpSalary = Util.GetDoubleNumber("Enter Employee salary");
                empList.Add(employee);
                choice = Util.GetShortNumber("Enter 1 to continue to input data, any other key to exit.");
            } while (choice == 1);
            return empList;
        }  
        public static void xmlStore()
        {
            getDataInput();
            var fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.Write);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Employee>));
            formatter.Serialize(fs, empList);
            fs.Close();
            //return null;
        }
        public static List<Employee> readXml()
        {
            var fs = new FileStream("Data.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer formatter = new XmlSerializer(typeof(List<Employee>));
            var list = formatter.Deserialize(fs) as List<Employee>;
            fs.Close();
            return list;
        }
        //public static Employee asCsv()
        //{
        //    var list = readXml();
        //    foreach (var member in list)
        //    {
        //        string[] details = member.
        //    }
        //}
    }
    class PROG15
    {
        static void Main(string[] args)
        {
            //SerializationComponent component = new SerializationComponent();
            //List<Employee> empList = SerializationComponent.getDataInput();
            SerializationComponent.xmlStore();
            var lists = SerializationComponent.readXml();
            foreach(var list in lists)
            {
                Console.WriteLine(list);
            }
        }
    }
}
