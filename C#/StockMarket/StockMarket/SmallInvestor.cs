namespace StockMarket
{
    // TO DO 1: Implementiere die Klasse für Kleinanleger laut Angabe
    class SmallInvestor : Investor
    {
        public SmallInvestor(string name, decimal money)
            : base(name, money) { }
       
        public override decimal GetTransactionCosts(decimal pricePerShare, int amountShares)
        {
            // Transaktionskosten = 1 % von ($jeAktie*Anzahl) + $20
            return (pricePerShare * amountShares) / 100 + 20;
        }
    }
}
