using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    abstract class Account
    {
        public int AccId { get; private set; }
        public string Name { get; set; }
        public double Balance { get; private set; } = 10000;
        public void Credit (double amt ) => Balance += amt;
        public void Debit (double amt)
        {
            if (amt > Balance) throw new Exception("Insufficient funds!!!!");
            else Balance -= amt;
        }
        public abstract void CalculateInterest();
    }
    class SBAccount : Account
    {
        //If a class inherits from an Abstract class, it must implement all the abstract methods. 
        public override void CalculateInterest()//override for implementing abstract methods...
        {
            double principle = Balance;
            double rate = 0.065;
            double term = 0.5;// Half yearly

            var interest = principle * rate * term / 100;
            Credit(interest);
        }
    }
    class FDAccount : Account
    {
        public override void CalculateInterest()//override for implementing abstract methods...
        {
            double principle = Balance;
            double rate = 0.65; //different roi for fd 
            double term = 0.5;// Half yearly

            var interest = principle * rate * term / 100;
            Credit(interest);
        }
    }
    class RDAccount : Account
    {
        public override void CalculateInterest()//override for implementing abstract methods...
        {
            double principle = Balance;
            double rate = 0.080; //different roi for fd 
            double term = 0.5;// Half yearly

            var interest = principle * rate * term / 100;
            Credit(interest);
        }
    }

    class PROG12
    {
        static void Main(string[] args)
        {
            Account account = new SBAccount();
            account.CalculateInterest();
            Console.WriteLine($"Savings Bank Account balance is {account.Balance}");

            Account fdAccount = new FDAccount();
            fdAccount.CalculateInterest();
            Console.WriteLine($"Fixed Deposit Account balance is {fdAccount.Balance}");

            Account rdAccount = new RDAccount();
            rdAccount.CalculateInterest();
            Console.WriteLine($"Recurring Deposit Account balance is {rdAccount.Balance}");
            //if (account is Account)
            //{
            //    FDAccount temp = account as FDAccount;
            //    temp.CalculateInterest();
            //    Console.WriteLine($"Recurring Deposit Account balance is {temp.Balance}");
            //}
            //if (account is Account)
            //{
            //    RDAccount temp = account as RDAccount;
            //    temp.CalculateInterest();
            //    Console.WriteLine($"Fixed Deposit Account balance is {temp.Balance}");
            //}
        }
    }
}
