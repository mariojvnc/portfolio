using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class StockMarketNewYork
    {
        private SortedDictionary<DateTime, double> dicDateToValue;

        private const string baseDir = @"..\..\..\data";

        public async Task LoadAsync()
        {
            string filename = Path.Combine(baseDir, "daily_values.csv");

            dicDateToValue = new SortedDictionary<DateTime, double>();

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync();
                    string[] parts = line.Split(';');

                    dicDateToValue[DateTime.Parse(parts[0])] = double.Parse(parts[1]);
                }
            }
        }

        public double GetValue(DateTime date)
        {
            if (!dicDateToValue.ContainsKey(date))
                throw new NoTradingException(date);

            return dicDateToValue[date];
        }

        public DateTime FirstDate
        {
            get
            {
                return dicDateToValue.Keys.Min();
            }
        }

        public DateTime LastDate
        {
            get
            {
                return dicDateToValue.Keys.Max();
            }
        }

        public double CalculateAverage(DateTime dtFrom, DateTime dtTo)
        {
            double sum = 0;
            int count = 0;

            for (DateTime dt = dtFrom; dt <= dtTo; dt = dt.AddDays(1))
            {
                if (dicDateToValue.ContainsKey(dt))
                {
                    sum += dicDateToValue[dt];
                    count++;
                }
            }

            return sum / count;
        }
    }
}
