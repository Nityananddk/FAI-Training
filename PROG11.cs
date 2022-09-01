using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Customer
    {
        static int count = 100;
        //public Customer()
        //{
        //    CustID = ++count;
        //}
        public int CustID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public MyProperty { get; set; }
    }
    class CustomerRepo
    {
        static private List<Customer> _customers = new List<Customer>();
        //public CustomerRepo(int size)
        //{
        //    _customers = new Customer[size];
        //}
        public static void AddNewCustomer(Customer customer)
        {
            _customers.Add(new Customer { CustID = customer.CustID, Name = customer.Name, Address = customer.Address });
        }
        public static void UpdateCustomer(int id, Customer customer)
        {
            for(int i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].CustID == id)
                {
                    _customers[i].Address = customer.Address;
                    _customers[i].Name = customer.Name;
                return;
                }
            }
            throw new Exception("User not found to update");
        }
        public static void DeleteCutomer(int id)
        {
            for (int i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].CustID == id)
                {
                    _customers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("No customer was found by id " + id);

        }
        public static Customer FindCustomer(int id)
        {
            foreach(Customer customer in _customers)
            {
                if (customer.CustID == id)
                    return customer;
            }
            throw new Exception("No customer was found by id " + id);
        }
    }
    class PROG11
    {
        private static CustomerRepo repo = new CustomerRepo();
        const string menu = "CUSTOMER REPOSITORY\nTO ADD NEW CUSTOMER\t\t\tPRESS N\nTO UPDATE CUSTOMER\t\t\t\tPRESS U\nTO DELETE A CUSTOMER\t\t\tPRESS D\nTO FIND BY ID\t\t\t\tPRESS F\nPS: ANY OTHER KEY IS EXIT";
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
        {
            switch (choice)
            {
                case "N":
                    addingCutomerFeature();
                    break;
                case "U":
                    updatingCutomerFeature();
                    break;
                case "D":
                    DeletingCutomerFeature();
                    break;
                case "F":
                    findingCutomerFeature();
                    break;
                default:
                    return false;
            }
            return true;
            //throw new NotImplementedException();
        }

        private static void findingCutomerFeature()
        {
            int id = Util.GetNumber("Enter id of the customer to search");
            try
            {
               Customer foundCustomer = CustomerRepo.FindCustomer(id);
                if (foundCustomer != null) Console.WriteLine($"The customer with name {foundCustomer.Name} from {foundCustomer.Address}");
                else Console.WriteLine("Customer not found to display");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //throw new NotImplementedException();
        }

        private static void DeletingCutomerFeature()
        {
            int id = Util.GetNumber("Enter id of customer id");
            CustomerRepo.DeleteCutomer(id);
            Console.WriteLine("Customer deleted successfully");
            //throw new NotImplementedException();
        }

        private static void updatingCutomerFeature()
        {
            Customer customer = createCustomer();
            CustomerRepo.UpdateCustomer(customer.CustID,customer);
            Console.WriteLine("Customer updated successfully");
            //throw new NotImplementedException();
        }

        private static void addingCutomerFeature()
        {
            Customer customer = createCustomer();
            CustomerRepo.AddNewCustomer(customer);
            //throw new NotImplementedException();
        }
        private static Customer createCustomer()
        {
            int id = Util.GetNumber("Enter the ID of the cuatomer");
            string name = Util.GetString("Enter the name of the customer");
            string address = Util.GetString("Enter the address of the customer");
            
            //creating new book
            Customer customer = new Customer()
            {
                CustID = id,
                Name = name,
                Address = address
            };
            return customer;
        }
    }
}
