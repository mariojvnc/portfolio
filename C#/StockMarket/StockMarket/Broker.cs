namespace StockMarket
{
    // TO DO 1: Implementiere die Klasse für Broker laut Angabe
    class Broker : Investor
    {
        public Broker(string name, decimal money)
            : base(name, money) { }
        
        public override decimal GetTransactionCosts(decimal pricePerShare, int amountShares)
        {
            // Transaktionskosten = 3 % von ($jeAktie*Anzahl)
            return 3 * (pricePerShare * amountShares) / 100;
        }
    }
}
