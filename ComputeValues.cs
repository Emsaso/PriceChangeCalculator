using System;
using System.Collections.Generic;
using System.Text;

namespace PriceChangeCalculator
{
    public class ComputeValues
    {
        public static DateTime GetDate { get; set; }
        public static float GetLast { get; set; }
        public static void GetValues(string d, string l)
        {
            GetDate = Convert.ToDateTime(d);
            GetLast = Convert.ToSingle(l.Replace('.', ','));
        }
    }
}
