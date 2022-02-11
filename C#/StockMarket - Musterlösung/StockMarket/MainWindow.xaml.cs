using System;
using System.Windows;
using System.Windows.Controls;

namespace StockMarket
{
    public partial class MainWindow : Window
    {
        const double MONEYATSTART = 10000;

        Simulation simulation;
        ConsoleWrapper console;

        SmallInvestor smallInvestor = new SmallInvestor("Max Kaufer", MONEYATSTART);
        Broker broker = new Broker(MONEYATSTART);

        public MainWindow()
        {
            InitializeComponent();

            console = new ConsoleWrapper(output);

            simulation = new Simulation();

            simulation.NewValue += OnNewValue;
            simulation.NoTrading += OnNoValue;
        }

        private void OnNoValue(DateTime d)
        {
            error.Text = $"{d.ToShortDateString()} war kein Handelstag.";
        }

        private void OnNewValue(DateTime d, double v)
        {
            date.Content = d.ToShortDateString();
            value.Content = v;
        }

        private void OnStartClick(object sender, RoutedEventArgs e)
        {
            simulation.RunAsync();

            btnStart.IsEnabled = false;
            btnPause.IsEnabled = true;
        }

        private void OnPauseClick(object sender, RoutedEventArgs e)
        {
            simulation.Pause();

            btnStart.IsEnabled = true;
            btnPause.IsEnabled = false;
        }

        private void OnBuyClick(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button))
                return;

            Label cacheLabel = null;
            Label sharesLabel = null;
            int count = 0;
            Investor investor = null;
            if (sender == buySmall)
            {
                cacheLabel = moneySmall;
                sharesLabel = sharesSmall;
                count = int.Parse(countSmall.Text.ToString());
                investor = smallInvestor;
            }
            else if (sender == buyBroker)
            {
                cacheLabel = moneyBroker;
                sharesLabel = sharesBroker;
                count = int.Parse(countBroker.Text.ToString());
                investor = broker;
            }

            double pricePerShare = double.Parse(value.Content.ToString());

            double costs = investor.CalculateCosts(pricePerShare, count);
            if (costs > investor.Money)
            {
                console.WriteLine($"{investor.Name} hat nicht genug Geld. {costs - investor.Money:C2} fehlen.");
            }
            else
            {
                investor.Buy(pricePerShare, count);
                console.WriteLine($"{investor.Name} hat {count} Aktien zu à {pricePerShare:C2} gekauft.");
                cacheLabel.Content = investor.Money.ToString();
                sharesLabel.Content = investor.Shares.ToString();
            }
        }

        private void OnSellClick(object sender, RoutedEventArgs e)
        {
            Label cacheLabel = null;
            Label sharesLabel = null;
            int count = 0;
            Investor investor = null;
            if (sender == sellSmall)
            {
                cacheLabel = moneySmall;
                sharesLabel = sharesSmall;
                count = int.Parse(countSmall.Text.ToString());
                investor = smallInvestor;
            }
            else if (sender == sellBroker)
            {
                cacheLabel = moneyBroker;
                sharesLabel = sharesBroker;
                count = int.Parse(countBroker.Text.ToString());
                investor = broker;
            }

            if (investor.Shares < count)
            {
                console.WriteLine($"{investor.Name} kann keine {count} Aktien verkaufen, weil er nur {investor.Shares} hat.");
                return;
            }

            double pricePerShare = double.Parse(value.Content.ToString());

            investor.Sell(pricePerShare, count);
            console.WriteLine($"{investor.Name} hat {count} Aktien zu à {pricePerShare:C2} verkauft.");
            cacheLabel.Content = investor.Money.ToString();
            sharesLabel.Content = investor.Shares.ToString();
        }

        private void OnStatisticsClick(object sender, RoutedEventArgs e)
        {
            double average = simulation.CalculateAverage(20);
            this.average.Text = Math.Round(average, 1).ToString();
        }
    }
}
