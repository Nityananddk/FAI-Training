using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class PROG06
    {
        static System.DateTime dateMonthYear = new DateTime();
        static bool isValidDate(int year, int month, int day)
        {
            if (month > 12) return false;
            if (day > DateTime.DaysInMonth(year, month)) return false;
            else return true;
            // do stuff here

            
        }

        static void Main(string[] args)
        {
            int year = Util.GetNumber("Enter year");
            int month = Util.GetNumber("Enter month");
            int day = Util.GetNumber("Enter day");
            bool validity = isValidDate(year, month, day);
            Console.WriteLine($"Given year {year}, month {month}, day {day} is {(validity?"valid":"invalid")}");
        }
    }
}
