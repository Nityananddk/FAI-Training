using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class PROG10
    {
        //public static String inWords(int num)
        //{
        //    // do stuff here
        //    return null;
        //}
        public static string inWords(int num)
        {
            if (num == 0)
                return "zero";

            if (num < 0)
                return "minus " + inWords(Math.Abs(num));

            string words = "";

            if ((num / 1000000) > 0)
            {
                words += inWords(num / 1000000) + " million ";
                num %= 1000000;
            }

            if ((num / 1000) > 0)
            {
                words += inWords(num / 1000) + " thousand ";
                num %= 1000;
            }

            if ((num / 100) > 0)
            {
                words += inWords(num / 100) + " hundred ";
                num %= 100;
            }

            if (num > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (num < 20)
                    words += unitsMap[num];
                else
                {
                    words += tensMap[num / 10];
                    if ((num % 10) > 0)
                        words += "-" + unitsMap[num % 10];
                }
            }

            return words;
        }
        static void Main(string[] args)
        {
            int val = Util.GetNumber("Enter a Number");
            var str = inWords(val);
            Console.WriteLine($"{val} in words is {str}");
        }   
    }
}
