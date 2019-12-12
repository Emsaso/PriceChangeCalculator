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
        public static DateTime GetDate;
        public static float GetLast;
        public static float ValueWhenPurchased;
        public static float ValueWhenSold;
        public static bool StocksPurchased;
        public static bool InitInvest;
        public static void Read(string docPath)
        {
            var csv = new StringBuilder();
            // Kan hende lines må skrives på en annen måte
            var lines = File.ReadLines(docPath + ".csv").Skip(1).Reverse();
            Console.WriteLine("Start-date:");
            var initDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("End-date:");
            var endDate = DateTime.Parse(Console.ReadLine());
            // Liker ikke å se om i < endDate
            for (var i = initDate; i <= endDate.Date; i.Date.AddDays(1))
            {
                // Kan være feil måte å lese på
                var values = lines.ToString().Split(',');
                var date = values[0];
                // Kan skje at den ikke finner ikke values[1]
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
