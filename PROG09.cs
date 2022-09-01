using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class PROG09
    {
        public static string reverseByWords(string sentence)
        {
            string[] reversed = sentence.Split(' ');
            StringBuilder sb = new StringBuilder();
            for(int i = reversed.Length - 1; i >= 0; i--)
            {
                sb.Append(reversed[i]);
                sb.Append(" ");
            }
            // do stuff here
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            string sentence = Util.GetString("Enter the string to be reversed");
            string reversed = reverseByWords(sentence);
            Console.WriteLine($"Reversed string is {reversed}");
        }
    }
}
