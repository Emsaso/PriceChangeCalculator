using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PriceChangeCalculator
{
    public class DataReader
    {
        public static StringBuilder Csv;
        public static void Read(string docPath)
        {
            Csv = new StringBuilder();
            var fullList = new HistoricStockPrice();
            Console.WriteLine("Start-date:");
            var initDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("End-date:");
            var endDate = DateTime.Parse(Console.ReadLine());
            fullList.Read(Csv, docPath, initDate, endDate);
            Console.WriteLine(Csv);
        }
    }
}
