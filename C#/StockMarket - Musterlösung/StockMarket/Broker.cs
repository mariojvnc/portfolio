using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class Broker : Investor
    {
        public Broker(double money)
            : base("Broker", money)
        {
        }

        public override double GetTransactionCosts(double investment)
        {
            return investment * 0.03;
        }
    }
}
