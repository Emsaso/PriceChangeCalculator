using System;
using System.IO;
using System.Linq;
using System.Text;

namespace PriceChangeCalculator
{
    class Program
    {
        private static readonly string DocumentPath = @"C:\Users\Get Academy\Downloads\OBX2.csv";
        static void Main(string[] args)
        {
            DocumentReader.ReadDocument(DocumentPath);
            Console.WriteLine("\tOBS      -    Siste \n");
            Console.WriteLine(DocumentReader.Csv);
        }
    }
}
