using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    static class Util
    {
        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        public static int GetNumber(string question) => int.Parse(GetString(question));
        public static short GetShortNumber(string question) => short.Parse(GetString(question));
        public static long GetLongNumber(string question) => long.Parse(GetString(question));
        public static float GetFloatNumber(string question) => float.Parse(GetString(question));
        public static double GetDoubleNumber(string question)
        {
            return double.Parse(GetString(question));
        }
    }

}
