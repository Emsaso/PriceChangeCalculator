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
            DataReader.Read();
            Console.WriteLine("\tOBS      -    Siste \n");
            Console.WriteLine(DataReader.Csv);
        }
    }
}
