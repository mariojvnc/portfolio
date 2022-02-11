using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class NoTradingException : ApplicationException
    {
        public NoTradingException(DateTime date)
            : base($"Am {date.ToShortDateString()} gab es keinen Handel.")
        {
        }
    }
}
