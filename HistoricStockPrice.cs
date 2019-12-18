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
        public static bool ReadValues;

        public void Read(StringBuilder stringBuilder, string path, DateTime start, DateTime end)
        {
            //var lines = File.ReadAllLines(path).Skip(1).Reverse();
            //List<ObxSelectedValue> ObxSelectedObject = new List<ObxSelectedValue>{new ObxSelectedValue()
            //{
            //    Date = ,
            //    Last = 
            //}};


            //var values = lines.ToString().Split(',');
            //if (values[0] == null || values[1] == null) return;
            //var date = values[0];
            //var last = values[1];
            //var trueStart = start.ToString("dd/MM/yyyy").Replace('.', '/');
            //var trueEnd = end.ToString("dd/MM/yyyy").Replace('.', '/');
            //if (DateTime.Parse(date) == DateTime.Parse(trueStart))
            //{
            //    ReadValues = true;
            //}
            //else if (DateTime.Parse(date) == DateTime.Parse(trueEnd))
            //{
            //    ReadValues = false;
            //}
            //if (!ReadValues) return;
            //ComputeValues.GetValues(date, last);
            //var contextualDay = $"date: {date}, last: {last}";
            //stringBuilder = new StreamReader(contextualDay);
            //Console.WriteLine(stringBuilder);


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
                var trueStart = start.ToString("dd/MM/yyyy").Replace('.', '/');
                var trueEnd = end.ToString("dd/MM/yyyy").Replace('.', '/');
                if (DateTime.Parse(date) < DateTime.Parse(trueStart) || DateTime.Parse(date) > DateTime.Parse(trueEnd)) continue;
                CorrectSentenceStructure(stringBuilder, getDate, getLast);
            }
        }

        public static void CorrectSentenceStructure(StringBuilder sr, DateTime gd, float gl)
        {
                var percentageUp = gl / ValueWhenPurchased * 100;
                var percentageDown = gl / ValueWhenSold * 100;
                var investmentAmount = 10000;
                string csvLine;
                if (percentageDown < 100 && !StocksPurchased || !InitInvest)
                {
                    InitInvest = true;
                    ValueWhenPurchased = gl;
                    StocksPurchased = true;
                    csvLine = $"Date: {gd:d} - Last: {gl:0.00} - Investment: {investmentAmount}kr - Purchased at: {ValueWhenPurchased} ({percentageDown:0.00}%)";
                }
                else if (percentageUp > 105 && StocksPurchased)
                {
                    ValueWhenSold = gl;
                    StocksPurchased = false;
                    csvLine = $"Date: {gd:d} - Last: {gl:0.00} - Sold at: {gl} - Return: {investmentAmount * (percentageUp / 100) - ValueWhenPurchased:0.00}kr ({percentageUp:0.00}%)";
                }
                else
                {
                    csvLine = $"Date: {gd:d} - Last: {gl:0.00}";
                }
                sr.AppendLine(csvLine);
        }
    }
}
