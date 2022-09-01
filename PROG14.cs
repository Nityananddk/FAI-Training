using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    interface CRUD
    {
        void Create();
        List<Employee> Read();
        void Update(int id);
        void Delete(int id);

    }
    class fileComponent : CRUD
    {
        const string fileName = "EmployeeDetails.txt";
        static List<Employee> empList = new List<Employee>();
        public void Create()
        {

            empList.Add(new Employee
            {
                EmpName = Util.GetString("Enter Name"),
                EmpAddress = Util.GetString("Enter Address"),
                EmpSalary = Util.GetDoubleNumber("Enter Salary")
            });
            Console.WriteLine("Employee Added Successfully");
            storeFile();
            //throw new NotImplementedException();
        }
        public void storeFile()
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            foreach (var member in empList)
            {
                writer.WriteLine(member);//since overridden
            }
            writer.Close();
        }
        public List<Employee> Read()
        {
            if (File.Exists(fileName))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs);
                string[] data = File.ReadAllLines(fileName);
                foreach (var member in data)
                {
                    string[] details = member.Split(',');
                    Employee emp = new Employee(int.Parse(details[0]));
                    emp.EmpName = details[1];
                    emp.EmpAddress = details[2];
                    emp.EmpSalary = int.Parse(details[3]);
                    empList.Add(emp);
                }
                fs.Close();
                return empList;
            }
            throw new Exception("File does not exists");
        }

        public void Update(int id)
        {
            empList = Read();
            foreach(var member in empList)
            {
                if (member.EmpID == id)
                {
                    empList.Remove(member);
                    empList.Add(new Employee { EmpID = id, EmpName = Util.GetString("Enter Updated Name"), EmpAddress = Util.GetString("Enter Updated Address"), EmpSalary = Util.GetDoubleNumber("Enter Updated Salary") });

                }
                else throw new Exception("Employee not found to update");
            }
            storeFile();
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            empList = Read();
            foreach (var member in empList)
            {
                if (member.EmpID == id)
                {
                    empList.Remove(member);
                }
                else throw new Exception("Employee not found to update");
            }
            storeFile();
            //throw new NotImplementedException();
        }

    }
    class PROG14
    {
        private static CRUD empRepo = new fileComponent();
        const string menu = "EMPLOYEE REPOSITORY\nTO ADD NEW EMPLOYEE \t\t\tPRESS N\nTO UPDATE EMPLOYEE\t\t\t\tPRESS U\nTO DELETE EMPLOYEE\t\t\tPRESS D\nTO READ EMPLOYEE DETAILS\t\t\t\tPRESS R\nPS: ANY OTHER KEY IS EXIT";
        static void Main(string[] args)
        {
            var processing = true;
            do
            {
                string choice = Util.GetString(menu);
                processing = processMenu(choice.ToUpper());
            } while (processing);
        }
        private static bool processMenu(string choice)
        { fileComponent component = new fileComponent();
            switch (choice)
            {
                case "N"://for adding
                    addingEmployeeFeature();
                    break;
                case "U"://for updating
                    updatingEmployeeFeature();
                    break;
                case "D"://for deleting
                    deletingEmployeeFeature();
                    break;
                case "R"://for finding by id
                    readEmployeeDetailsFeature();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void readEmployeeDetailsFeature()
        {
            //int id = Util.GetNumber("Enter ID of the employee to search");
            List<Employee> newEmp = empRepo.Read();
            foreach(var member in newEmp)
            {
                Console.WriteLine(member);
            }
        }

        private static void deletingEmployeeFeature()
        {
            int id = Util.GetNumber("Enter ID of the employee to be deleted");
            empRepo.Delete(id);
        }

        private static void updatingEmployeeFeature()
        {
            int id = Util.GetNumber("Enter ID of the employee to be updated");
            empRepo.Update(id);
        }

        private static void addingEmployeeFeature()
        {
            empRepo.Create();
        }
    }
}
