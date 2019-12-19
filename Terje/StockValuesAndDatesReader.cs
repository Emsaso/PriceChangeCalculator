using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PriceChangeCalculator.Terje
{
    class StockValuesAndDatesReader
    {
        public static List<StockValueAndDate> Read(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Skip(1)
                .Reverse()
                .Where(line => line != null)
                .Select(line => new StockValueAndDate(line))
                .ToList();
        }

        //public static List<StockValueAndDate> Read(string filePath)
        //{
        //    var csv = new StringBuilder();
        //    var lines = File.ReadAllLines(filePath).Skip(1).Reverse();
        //    var list = new List<StockValueAndDate>();
        //    foreach (var line in lines)
        //    {
        //        if (line == null) continue;
        //        list.Add(new StockValueAndDate(line));
        //    }
        //    return list;
        //}
    }
}
