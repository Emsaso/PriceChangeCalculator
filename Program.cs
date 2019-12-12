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
            DocumentReader.GetDataFromCsv();
            Console.WriteLine("\tOBS      -    Siste \n");
            Console.WriteLine(DocumentReader.Csv);
        }
    }
}
