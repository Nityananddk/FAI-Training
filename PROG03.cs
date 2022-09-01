using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Calculator
    {
        public static double addValues(double val1, double val2) 
        {
            var sum = val1 + val2;
            return sum; 
        }
        public static double subValues(double val1, double val2) 
        {
            var sum = val1 - val2;
            return sum;
        }
        public static double mulValues(double val1, double val2) 
        {
            var sum = val1 * val2;
            return sum;
        }
        public static double divValues(double val1, double val2) 
        {///<system>
         ///Divides Value 1 by Value 2
         ///<exception cref="DivideByZeroException">Division by zero is not possible
         ///</exception>
         ///
         ///</system>
            var sum = val1 / val2;
            if (val2 != 0)
                return sum;
            else throw new DivideByZeroException();
        }
        public static double sqrValue(double val1) 
        {
            var sum = val1 * val1;
            return sum;
        }
        public static double sqrtValue(double val1) 
        {
            var sum = Math.Sqrt(val1);
            return 0; 
        }

    }
    class PROG03
    {
        static void Main(string[] args)
        {
            const string menu = "CALCULATOR\nADDITION\t\tPRESS 1\nSUBTRACTION\t\tPRESS 2\nMULTIPLICATION\t\tPRESS 3\nDIVISION\t\tPRESS 4\nSQUARE\t\t\tPRESS 5\nSQUARE ROOT\t\tPRESS 6\nPS : ANY OTHER KEY IS EXIT";
            string choice = "";
            var processing = true;
            do
            {
                choice = Util.GetString(menu);
                processing = processMenu(choice);
            } while (processing);

        }

        private static bool processMenu(string choice)
        {
            switch (choice)
            {
                case "1":
                    addValuesFeature();
                    break;
                case "2":
                    subValuesFeature();
                    break;
                case "3":
                    mulValuesFeature();
                    break;
                case "4":
                    divValuesFeature();
                    break;
                case "5":
                    sqrValueFeature();
                    break;
                case "6":
                    sqrtValueFeature();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void sqrtValueFeature()
        {
            double val1 = Util.GetDoubleNumber("Enter value");
            //double val2 = Util.GetDoubleNumber("Enter second value");
            double sum = Calculator.sqrtValue(val1);
            Console.WriteLine(sum);
            //throw new NotImplementedException();
        }

        private static void sqrValueFeature()
        {
            double val1 = Util.GetDoubleNumber("Enter value");
            //double val2 = Util.GetDoubleNumber("Enter second value");
            double sum = Calculator.sqrValue(val1);
            Console.WriteLine(sum);
            //throw new NotImplementedException();
        }

        private static void divValuesFeature()
        {
            double val1 = Util.GetDoubleNumber("Enter first value");
            double sum = 0;
            RETRY:
            double val2 = Util.GetDoubleNumber("Enter second value");
            try
            {
                sum = Calculator.divValues(val1, val2);
            }
            catch
            {
                Console.WriteLine("Division by zero is not possible");
                goto RETRY;
            }
            Console.WriteLine(sum);
            //throw new NotImplementedException();
        }

        private static void mulValuesFeature()
        {
            double val1 = Util.GetDoubleNumber("Enter first value");
            double val2 = Util.GetDoubleNumber("Enter second value");
            double sum = Calculator.mulValues(val1, val2);
            Console.WriteLine(sum);
            //throw new NotImplementedException();
        }

        private static void subValuesFeature()
        {
            double val1 = Util.GetDoubleNumber("Enter first value");
            double val2 = Util.GetDoubleNumber("Enter second value");
            double sum = Calculator.subValues(val1, val2);
            Console.WriteLine(sum);
            throw new NotImplementedException();
        }

        private static void addValuesFeature()
        {
            double val1 = Util.GetDoubleNumber("Enter first value");
            double val2 = Util.GetDoubleNumber("Enter second value");
            double sum = Calculator.addValues(val1, val2);
            Console.WriteLine(sum);
            //throw new NotImplementedException();
        }
    }
}
