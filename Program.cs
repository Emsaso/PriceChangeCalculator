using System;
using System.IO;
using System.Linq;
using System.Text;
using PriceChangeCalculator.Terje;

namespace PriceChangeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name of text file: (obx)");
            var documentPathInput = Console.ReadLine() + ".csv";
            //DataReader.Read(documentPathInput);

            var data = StockValuesAndDatesReader.Read(documentPathInput);
            var analyzer = new InvestmentAnalyzer(data);
            analyzer.Analyse();
        }
    }
}
