using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PriceChangeCalculator
{
    public class DocumentReader
    {
        public static readonly string DocumentPath = @"OBX2.csv";
        public static StringBuilder Csv;
        public static DateTime GetDate;
        public static float GetLast;
        public static float ValueWhenPurchased;
        public static float ValueWhenSold;
        public static bool StocksPurchased;
        public static bool InitInvest;
        public static void Read()
        {
            var csv = new StringBuilder();
            var lines = File.ReadAllLines(DocumentPath).Skip(1).Reverse();
            foreach (var line in lines)
            {
                var values = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                var date = values[0];
                var last = values[1];
                string csvLine;

                GetDate = Convert.ToDateTime(date);
                GetLast = Convert.ToSingle(last.Replace('.', ','));
                var percentageGain = GetLast / ValueWhenPurchased * 100;
                var investmentAmount = 10000;
                if (GetLast < ValueWhenSold && !StocksPurchased || !InitInvest)
                {
                    InitInvest = true;
                    ValueWhenPurchased = GetLast;
                    StocksPurchased = true;
                    csvLine = $"Date: {GetDate:d} - Last: {GetLast:0.00} - Investment: {investmentAmount}kr - Purchased at: {ValueWhenPurchased}";
                }
                else if (percentageGain > 105 && StocksPurchased)
                {
                    ValueWhenSold = GetLast;
                    StocksPurchased = false;
                    csvLine = $"Date: {GetDate:d} - Last: {GetLast:0.00} - Sold at: {GetLast} - Return: {investmentAmount * (percentageGain / 100) - ValueWhenPurchased:0.00} ({percentageGain:0.00}%)";
                }
                else
                {
                    csvLine = $"Date: {GetDate:d} - Last: {GetLast:0.00}";
                }
                csv.AppendLine(csvLine);
            }
            Csv = csv;
        }
    }
}
