using System;

namespace StockMarket
{
    class DateAndShareValueEventArgs
    {
        public DateTime Date { get; private set; }
        public decimal ShareValue { get; private set; }
        public DateAndShareValueEventArgs(DateTime date, decimal shareValue)
        {
            Date = date;
            ShareValue = shareValue;
        }
    }
}
