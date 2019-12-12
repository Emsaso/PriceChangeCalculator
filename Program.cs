using System;
using System.IO;
using System.Linq;
using System.Text;

namespace PriceChangeCalculator
{
    class Program
    {
        //public static readonly string DocumentPath = @"OBX2.csv";
        static void Main(string[] args)
        {
            Console.WriteLine("Name of text file: (obx)");
            var documentPath = Console.ReadLine();
            DataReader.Read(documentPath);
            Console.WriteLine("\tOBS      -    Siste \n");
            Console.WriteLine(DataReader.Csv);
        }
    }
}
