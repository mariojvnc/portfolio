using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class SmallInvestor : Investor
    {
        public SmallInvestor(string name, double money)
            : base(name, money)
        {
        }

        public override double GetTransactionCosts(double investment)
        {
            return investment * 0.01 + 20;
        }
    }
}
