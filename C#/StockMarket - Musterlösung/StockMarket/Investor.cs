using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    abstract class Investor
    {
        public string Name { get; private set; }
        public double Money { get; private set; }
        public int Shares { get; private set; }

        protected Investor(string name, double money)
        {
            Name = name;
            Money = money;
        }

        public void Buy(double pricePerShare, int count)
        {
            Money -= CalculateCosts(pricePerShare, count);
            Shares += count;
        }

        public void Sell(double pricePerShare, int count)
        {
            Money += pricePerShare * count;
            Shares -= count;
        }

        public double CalculateCosts(double pricePerShare, int count)
        {
            double investment = pricePerShare * count;
            return investment + GetTransactionCosts(investment);
        }

        public abstract double GetTransactionCosts(double investment);
    }
}
