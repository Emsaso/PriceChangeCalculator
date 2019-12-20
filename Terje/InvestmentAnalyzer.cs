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
            Console.WriteLine("Start-date: (02/01/1996 - 02/12/2019)");
            var initDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("End-date: (02/01/1996 - 02/12/2019)");
            var endDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Investment amount: (~10000)");
            var investmentAmount = float.Parse(Console.ReadLine());
            Console.WriteLine("Buy percentage: (~95)");
            var buyPercentage = float.Parse(Console.ReadLine());
            Console.WriteLine("Sell percentage: (~105)");
            var sellPercentage = float.Parse(Console.ReadLine());
            var trueStart = initDate.ToString("dd/MM/yyyy").Replace('.', '/');
            var trueEnd = endDate.ToString("dd/MM/yyyy").Replace('.', '/');
            foreach (var valueAndDate in _list)
            {
                if (valueAndDate.Date < DateTime.Parse(trueStart) || valueAndDate.Date > DateTime.Parse(trueEnd)) continue;
                var percentageUp = valueAndDate.Value / ValueWhenPurchased * 100;
                var percentageDown = valueAndDate.Value / ValueWhenSold * 100;
                //var investmentAmount = 10000;
                if (percentageDown < buyPercentage && !StocksPurchased || !InitInvest)
                {
                    InitInvest = true;
                    ValueWhenPurchased = valueAndDate.Value;
                    StocksPurchased = true;
                    AnalysisString = $"Date: {valueAndDate.Date:d} - Last: {valueAndDate.Value:0.00} - Investment: {investmentAmount}kr - Purchased at: {ValueWhenPurchased} ({percentageDown:0.00}%)";
                }
                else if (percentageUp > sellPercentage && StocksPurchased)
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
