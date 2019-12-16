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
            var documentPath = Console.ReadLine() + ".csv";
            DataReader.Read(documentPath);
        }
    }
}
