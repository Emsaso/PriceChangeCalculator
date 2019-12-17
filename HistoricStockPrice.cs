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
        public static bool InvestmentPeriod;

        public void Read(StreamReader stringBuild, string path, DateTime start, DateTime end)
        {
            try
            {
                using StreamReader sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("File could not be read:");
                Console.WriteLine(e.Message);
                throw;
            }
            //var lines = File.ReadAllLines(path).Skip(1).Reverse();
            //foreach (var line in lines)
            //{
            //    if (line == null) continue;
            //    var values = line.Split(',');
            //    var date = values[0];
            //    var last = values[1];
            //    ComputeValues.GetValues(date, last);
            //    DateTime getDate = ComputeValues.GetDate;
            //    float getLast = ComputeValues.GetLast;
            //    string csvLine;
            //    var trueStart = start.ToString("dd/MM/yyyy").Replace('.', '/');
            //    var trueEnd = end.ToString("dd/MM/yyyy").Replace('.', '/');
            //    if (DateTime.Parse(date) < DateTime.Parse(trueStart) || DateTime.Parse(date) > DateTime.Parse(trueEnd)) continue;
            //    var percentageUp = getLast / ValueWhenPurchased * 100;
            //    var percentageDown = getLast / ValueWhenSold * 100;
            //    var investmentAmount = 10000;
            //    if (percentageDown < 95 && !StocksPurchased || !InitInvest)
            //    {
            //        InitInvest = true;
            //        ValueWhenPurchased = getLast;
            //        StocksPurchased = true;
            //        csvLine = $"Date: {getDate:d} - Last: {getLast:0.00} - Investment: {investmentAmount}kr - Purchased at: {ValueWhenPurchased} ({percentageDown:0.00}%)";
            //    }
            //    else if (percentageUp > 105 && StocksPurchased)
            //    {
            //        ValueWhenSold = getLast;
            //        StocksPurchased = false;
            //        csvLine = $"Date: {getDate:d} - Last: {getLast:0.00} - Sold at: {getLast} - Return: {investmentAmount * (percentageUp / 100) - ValueWhenPurchased:0.00}kr ({percentageUp:0.00}%)";
            //    }
            //    else
            //    {
            //        csvLine = $"Date: {getDate:d} - Last: {getLast:0.00}";
            //    }
            //    stringBuild.AppendLine(csvLine);
            //}
        }
    }
}
