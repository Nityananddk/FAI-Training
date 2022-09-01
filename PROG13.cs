using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Patient
    {
        public int PID { get; set; }
        public string PName { get; set; }
        public long PhoneNo { get; set; }
        public double BillAmt { get; set; }
        public override string ToString()
        {
            return $"{PID}, {PName}, {PhoneNo}, {BillAmt}";
        }
    }
    class PROG13
    {
        const string filename = "PatientDetails.txt";
        static Patient patient = new Patient();
        public static void writeToFile()
        {
            dataInput();
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(patient);
            writer.Close();
            fs.Close();
        }
        public static Patient readFromFile()
        {
            if (File.Exists(filename))
            {
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs);
                string data = reader.ReadLine();
                string[] details = data.Split(',');
                //Patient patient1 = new Patient();
                patient.PID = int.Parse(details[0]);//format exception
                patient.PName = details[1];
                patient.PhoneNo = long.Parse(details[2]);//format exception
                patient.BillAmt = double.Parse(details[3]);//format exception catch
                fs.Close();
                return patient;
            }
            else throw new Exception("File does not exist");
        }
        public static void dataInput()
        {
            patient.PID = Util.GetNumber("Enter Patient ID");
            patient.PName = Util.GetString("Enter Patient name");
            patient.PhoneNo = Util.GetLongNumber("Enter Patient Phone Number");
            patient.BillAmt = Util.GetDoubleNumber("Enter Patient bill amount");
        }
        
        static void Main(string[] args)
        {
            writeToFile();
            var data = readFromFile();
            Console.WriteLine($"Data stored is Patient ID - {data.PID}, Patient Name - {data.PName}, patient Phone No - {data.PhoneNo}, Patient Bill Amount - {data.BillAmt}");

        }
    }
}
