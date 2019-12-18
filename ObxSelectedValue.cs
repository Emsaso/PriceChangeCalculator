using System;
using System.Collections.Generic;
using System.Text;

namespace PriceChangeCalculator
{
    class ObxSelectedValue
    {
        public string Date { get; set; }
        public string Last { get; set; }

        public ObxSelectedValue(string date, string last)
        {
            Date = date;
            Last = last;
        }
    }
}
