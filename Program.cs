using System;
using System.IO;
using System.Linq;
using System.Text;

namespace PriceChangeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name of text file: (obx)");
            var documentPathInput = Console.ReadLine() + ".csv";
            DataReader.Read(documentPathInput);
        }
    }
}
