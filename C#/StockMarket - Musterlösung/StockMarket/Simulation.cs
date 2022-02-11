using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class Simulation
    {
        private StockMarketNewYork stockmarket;

        public event Action<DateTime, double> NewValue;
        public event Action<DateTime> NoTrading;

        DateTime current;
        bool isRunning = false;

        public async void RunAsync()
        {
            if (stockmarket == null)
            {
                stockmarket = new StockMarketNewYork();

                await stockmarket.LoadAsync();
                current = stockmarket.FirstDate;
            }

            isRunning = true;

            for (;
                 current <= stockmarket.LastDate && isRunning;
                 current = current.AddDays(1))
            {
                try
                {
                    double value = stockmarket.GetValue(current);
                    NewValue?.Invoke(current, value);
                }
                catch (NoTradingException)
                {
                    NoTrading?.Invoke(current);
                }

                await Task.Delay(500);
            }
        }

        public void Pause()
        {
            isRunning = false;
        }

        public double CalculateAverage(int days)
        {
            return stockmarket.CalculateAverage(current.AddDays(-days+1), current);
        }
    }
}
