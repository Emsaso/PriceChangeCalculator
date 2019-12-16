using System;
using System.Collections.Generic;
using System.Text;

namespace PriceChangeCalculator
{
    public class ComputeValues
    {
        public DateTime GetDate;
        public float GetLast;
        public void GetValues(string d, string l)
        {
            GetDate = Convert.ToDateTime(d);
            GetLast = Convert.ToSingle(l.Replace('.', ','));
        }
    }
}
