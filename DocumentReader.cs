using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace PriceChangeCalculator
{
    public class DocumentReader
    {
        public static StringBuilder Csv;
        public static DateTime GetDate;
        public static float GetLast;
        public static float ValueWhenPurchased;
        public static float ValueWhenSold;
        public static bool StocksPurchased;
        public static bool InitInvest;
        public static void ReadDocument(string documentPath)
        {
            var csv = new StringBuilder();
            var lines = File.ReadAllLines(documentPath).Reverse();
            foreach (var line in lines)
            {
                if (line == null) continue;
                var values = line.Split(',');
                var date = values[0];
                var last = values[1];
                var csvLine = "";
                if (date == "OBX" || last == "Siste") continue;
                ComputeCsv(date, last, csvLine, csv);
            }
            Csv = csv;
        }

        public static void ComputeCsv(string d, string l, string cl, StringBuilder c)
        {
            {

                GetDate = Convert.ToDateTime(d);
                GetLast = Convert.ToSingle(l.Replace('.', ','));
                var percentageGain = GetLast / ValueWhenPurchased * 100;
                var investmentAmount = 10000;
                if (GetLast < ValueWhenSold && !StocksPurchased || !InitInvest)
                {
                    InitInvest = true;
                    ValueWhenPurchased = GetLast;
                    StocksPurchased = true;
                    cl = $"Date: {GetDate:d} - Last: {GetLast:0.00} - Investment: {investmentAmount}kr - Purchased at: {ValueWhenPurchased}";
                }
                else if (percentageGain > 105 && StocksPurchased)
                {
                    ValueWhenSold = GetLast;
                    StocksPurchased = false;
                    cl = $"Date: {GetDate:d} - Last: {GetLast:0.00} - Sold at: {GetLast} - Return: {investmentAmount * (percentageGain / 100) - ValueWhenPurchased:0.00} ({percentageGain:0.00}%)";
                }
                else
                {
                    cl = $"Date: {GetDate:d} - Last: {GetLast:0.00}";
                }
                c.AppendLine(cl);
            }

        }
    }
}
