using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class PROG02
    {
        static Dictionary<string, List<int>> evenOdd = new Dictionary<string, List<int>>();
        static void Main(string[] args)
        {
            int size = Util.GetNumber("Enter the size of the array");
            int[] evenOddArray = new int[size];
            for (int i = 0; i < size; ++i)
            {
                evenOddArray[i] = Util.GetNumber($"Enter {i + 1}th element");
            }
            Console.WriteLine("Even \t\tOdd");
            foreach (var member in evenOddArray)
            {
                if (member % 2 == 0)
                {
                    evenOdd["Even"].Add(member);
                }
                //Console.WriteLine(member);
                else
                {
                    evenOdd["Odd"].Add(member);
                }
                //Console.WriteLine($" \t\t{member}");
            }
            foreach (KeyValuePair<string, List<int>> member in evenOdd)
            {
                Console.WriteLine($"{member.Key},{member.Value}");
            }
            //foreach (var val in member.Value) val
        }
    }
}
