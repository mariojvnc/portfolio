namespace StockMarket
{

    // TO DO 1: Implementiere die Basisklasse beider Investorklassen laut Angabe
    abstract class Investor
    {
        public string Name { get; }
        public decimal Money { get; set; }
        public int Shares { get; private set; }

        protected Investor(string name, decimal money)
        {
            Name = name;
            Money = money;
        }
        public abstract decimal GetTransactionCosts(decimal pricePerShare, int amountShares);
        public void Buy(decimal pricePerShare, int amountShares)
        {
            Money -= (pricePerShare * amountShares) + GetTransactionCosts(pricePerShare, amountShares);
            Shares += amountShares;
        }
        public void Sell(decimal pricePerShare, int amountShares)
        {
            Money += pricePerShare * amountShares;
            Shares -= amountShares;
        }
    }
}
