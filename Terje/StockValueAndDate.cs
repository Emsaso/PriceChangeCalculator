using System;

namespace PriceChangeCalculator.Terje
{
    class StockValueAndDate
    {
        public DateTime Date { get; }
        public float Value { get; }

        public StockValueAndDate(DateTime date, float value)
        {
            Date = date;
            Value = value;
        }

        public StockValueAndDate(string line)
        {
            var parts = line.Split(',');
            Date = Convert.ToDateTime(parts[0]);
            Value = Convert.ToSingle(parts[1].Replace('.', ','));
        }
    }
}
