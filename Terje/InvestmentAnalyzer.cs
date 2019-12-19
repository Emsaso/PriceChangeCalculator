using System;
using System.Collections.Generic;
using System.Text;

namespace PriceChangeCalculator.Terje
{
    class InvestmentAnalyzer
    {
        public static string AnalysisString;
        public static float ValueWhenPurchased;
        public static float ValueWhenSold;
        public static bool StocksPurchased;
        public static bool InitInvest;
        public static StringBuilder StringBuild;
        private List<StockValueAndDate> _list;

        public InvestmentAnalyzer(List<StockValueAndDate> list)
        {
            _list = list;
        }

        public AnalysisResult Analyse()
        {
            foreach (var valueAndDate in _list)
            {
                //valueAndDate.


                var percentageUp = valueAndDate.Value / ValueWhenPurchased * 100;
                var percentageDown = valueAndDate.Value / ValueWhenSold * 100;
                var investmentAmount = 10000;
                if (percentageDown < 100 && !StocksPurchased || !InitInvest)
                {
                    InitInvest = true;
                    ValueWhenPurchased = valueAndDate.Value;
                    StocksPurchased = true;
                    AnalysisString = $"Date: {valueAndDate.Date:d} - Last: {valueAndDate.Value:0.00} - Investment: {investmentAmount}kr - Purchased at: {ValueWhenPurchased} ({percentageDown:0.00}%)";
                }
                else if (percentageUp > 105 && StocksPurchased)
                {
                    ValueWhenSold = valueAndDate.Value;
                    StocksPurchased = false;
                    AnalysisString = $"Date: {valueAndDate.Date:d} - Last: {valueAndDate.Value:0.00} - Sold at: {valueAndDate.Value} - Return: {investmentAmount * (percentageUp / 100) - ValueWhenPurchased:0.00}kr ({percentageUp:0.00}%)";
                }
                else
                {
                    AnalysisString = $"Date: {valueAndDate.Date:d} - Last: {valueAndDate.Value:0.00}";
                }

                StringBuild = new StringBuilder();
                StringBuild.Append(AnalysisString);
                Console.WriteLine(StringBuild);
            }
            return new AnalysisResult();
        }
    }
}
