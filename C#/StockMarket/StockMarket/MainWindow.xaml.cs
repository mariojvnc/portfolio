using System;
using System.Windows;
using System.Windows.Controls;

namespace StockMarket
{
    public partial class MainWindow : Window
    {
        const decimal MONEYATSTART = 10000; // in $

        // Instanz der Simulationsklasse
        Simulation simulation;

        // TO DO 2: Lege hier die Instanzen des Kleinanlegers und des Brokers an
        //         und setze das Startkapital beider Investoren (Kleinanleger und Broker) 
        //         auf den Wert von MONEYATSTART
        SmallInvestor smallInvestor = new SmallInvestor("Max Kaufer", MONEYATSTART);
        Broker broker = new Broker("Broker", MONEYATSTART);

        public MainWindow()
        {
            InitializeComponent();

            simulation = new Simulation();
            simulation.NewSharedValueAvailable += Simulation_NewShareValueAvailable;

        }

        // TO DO Events 1 und 2: Implementiere beide Eventhandler für Event 1 und Event 2 der Klasse Simulation.
        // Eventhandler für Event 1: Setzt das Datum und den Aktienwert in den Controls date und value.
        // Eventhandler für Event 2: Gibt eine Meldung in der TextBox error aus, z. B. "2002-02-28 war kein Handelstag."
        private void Simulation_NewShareValueAvailable(object sender, DateAndShareValueEventArgs e)
        {
            date.Content = e.Date.ToShortDateString();
            value.Content = e.ShareValue;
        }

        private void OnStartClick(object sender, RoutedEventArgs e)
        {
            simulation.RunAsync();
        }

        private void OnPauseClick(object sender, RoutedEventArgs e)
        {
            simulation.Pause();
        }

        private void OnBuyClick(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button))
                return;

            // buyForSmallInvestor = true  -> Der linke Kauf-Button für den Kleinanleger wurde geklickt.
            // buyForSmallInvestor = false -> Der rechte Kauf-Button für den Broker wurde geklickt.
            bool buyForSmallInvestor = sender == buySmall;

            // TODO 12: Implementiere den Kauf von Aktien und unterscheide folgende Fälle:
            // 1. Die Kosten werden durch die Methode CalculateCost des Investors errechnet.
            //    Übergib der Methode den aktuellen Aktienwert und die gewünschte Stückanzahl an Aktien.
            // 2. Wenn diese Kosten > als das Kapital des Investors ist, kann der Kauf nicht durchgeführt werden.
            //    Gib in der TextBox output eine entsprechende Meldung aus.
            // 3. Hat der Investor genug Geld, wird der Kauf mit dessen Buy-Methode durchgeführt.
            //    Aktualisiere dann alle Controls des jeweiligen Investors korrekt.
            //    Gib in der TextBox output eine entsprechende Kaufmeldung aus.


        }

        private void OnSellClick(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button))
                return;

            // sellForSmallInvestor = true  -> Der linke Kauf-Button für den Kleinanleger wurde geklickt.
            // sellForSmallInvestor = false -> Der rechte Kauf-Button für den Broker wurde geklickt.
            bool sellForSmallInvestor = sender == sellSmall;

            // TODO 13: Implementiere den Verkauf von Aktien und unterscheide folgende Fälle:
            // 1. Der Verkauf kann nur durchgeführt werden, wenn die gewünschte Stückanzahl die Anzahl 
            //    der Aktien die der Investor besitzt, nicht übersteigt.
            // 2. Gib in der TextBox output eine Meldung aus, wenn der Verkauf nicht durchgeführt werden kann.
            // 3. Ansonsten führe den Verkauf durch die Sell-Methode des Investors durch.
            //    Aktualisiere dann alle Controls des jeweiligen Investors korrekt.
            //    Gib in der TextBox output eine entsprechende Verkaufsmeldung aus.


        }

        private void OnStatisticsClick(object sender, RoutedEventArgs e)
        {
            // TODO 14: Rufe CalculateAverageOfTheLastDays asynchron auf. Verwende BeginInvoke/EndInvoke.
            double average = simulation.CalculateAverageOfTheLastDays(20);
            this.average.Text = Math.Round(average, 2).ToString();
        }


        
    }
}
