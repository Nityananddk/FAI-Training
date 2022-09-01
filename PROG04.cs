using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class PROG04
    {
        static void Main(string[] args)
        {
            int size = Util.GetNumber("Enter the size of the array");
            int[] evenOddArray = new int[size];
            getData(evenOddArray, size);
            int even = 0, odd = 0;
            evenOddSum(evenOddArray, ref even, ref odd);
            Console.WriteLine($"Sum of all even numbers in the array {even}\nSum of all odd numbers in the array {odd}");
        }

        private static void evenOddSum(int[] evenOddArray, ref int even, ref int odd)
        {
            foreach (int member in evenOddArray)
            {
                if (member % 2 == 0) even += member;
                else odd += member;
            }
        }

        private static void getData(int[] evenOddArray,int size)
        {
            
            for (int i = 0; i < size; ++i)
            {
                evenOddArray[i] = Util.GetNumber($"Enter {i + 1}th element");
            }

            //return evenOddArray;
        }
    }
}
