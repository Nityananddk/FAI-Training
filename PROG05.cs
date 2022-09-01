using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class PROG05
    {
        public static void getData(out double principle, out float roi, out float time) 
        {
            principle = Util.GetDoubleNumber("Enter principle amount");
            roi = Util.GetFloatNumber("Enter interest rate");
            time = Util.GetFloatNumber("Enter time duration");
        }
        private static double calculateInterest(double principle, float roi, float time)
        {
            double interest = (principle * time * roi) / 100;
            return interest;
            //throw new NotImplementedException();
        }
        static void Main(string[] args)
        {
            double principle;
            float roi;
            float time;
            getData(out principle,out roi,out time);
            double interest = calculateInterest(principle, roi, time);
            Console.WriteLine($"Interest for the amount {principle} at the rate of interest {roi} for the duration {time} is {interest}");
        }

    }
}
