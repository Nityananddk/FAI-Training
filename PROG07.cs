using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class PROG07
    {
        static bool isPrimeNumber(int num)
        {
            if (num == 0) return false;
            bool count = true;
            for(int i = 0; i <= num/2; ++i)
            {
                count = num % 2 == 0 ? false : true;
            }
            return count; //? true : false;
            //if (count>0)
            //    return false;
            //else return true; 
            // do stuff here
            //return false;
        }

        static void Main(string[] args)
        {
            int prime = Util.GetNumber("Enter a number");
            bool ifPrime = isPrimeNumber(prime);
            Console.WriteLine($"Entered number {prime} is {(ifPrime?"a prime number":"not a prime number")}");
        }
    }
}
