using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PriceChangeCalculator
{
    public class HistoricStockPrice
    {
        public static float ValueWhenPurchased;
        public static float ValueWhenSold;
        public static bool StocksPurchased;
        public static bool InitInvest;
        
        public void Read(StringBuilder csv, string path, DateTime start, DateTime end)
        {
            var lines = File.ReadAllLines(path).Skip(1).Reverse();
            foreach (var line in lines)
            {
                if (line == null) continue;
                var values = line.Split(',');
                var date = values[0];
                var last = values[1];
                ComputeValues.GetValues(date, last);
                DateTime getDate = ComputeValues.GetDate;
                float getLast = ComputeValues.GetLast;
                string csvLine;
                var trueStart = start.ToString("dd/MM/yyyy").Replace('.', '/');
                var trueEnd = end.ToString("dd/MM/yyyy").Replace('.', '/');
                // date (xx/xx/xxxx) og Start/End (xx.xx.xxxx xx:xx:xx)
                if (DateTime.Parse(date) < DateTime.Parse(trueStart) || DateTime.Parse(date) > DateTime.Parse(trueEnd)) continue;
                var percentageGain = getLast / ValueWhenPurchased * 100;
                var investmentAmount = 10000;
                if (getLast * 1.05 < ValueWhenSold && !StocksPurchased || !InitInvest)
                {
                    InitInvest = true;
                    ValueWhenPurchased = getLast;
                    StocksPurchased = true;
                    csvLine = $"Date: {getDate:d} - Last: {getLast:0.00} - Investment: {investmentAmount}kr - Purchased at: {ValueWhenPurchased} ({(getLast/ValueWhenSold * 100):0.00}%)";
                }
                else if (percentageGain > 105 && StocksPurchased)
                {
                    ValueWhenSold = getLast;
                    StocksPurchased = false;
                    csvLine = $"Date: {getDate:d} - Last: {getLast:0.00} - Sold at: {getLast} - Return: {investmentAmount * (percentageGain / 100) - ValueWhenPurchased:0.00} ({percentageGain:0.00}%)";
                }
                else
                {
                    csvLine = $"Date: {getDate:d} - Last: {getLast:0.00}";
                }
                csv.AppendLine(csvLine);
            }
        }
    }
}
