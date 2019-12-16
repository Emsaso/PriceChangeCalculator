﻿using System;
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
            Console.WriteLine("Start-date: (02/01/1996 - 02/12/2019)");
            var initDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("End-date: (02/01/1996 - 02/12/2019)");
            var endDate = DateTime.Parse(Console.ReadLine());
            fullList.Read(Csv, docPath, initDate, endDate);
            Console.WriteLine(Csv);
        }
    }
}
