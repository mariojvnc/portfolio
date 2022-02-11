using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MemoryWPF_3AHIF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Player> players;
        private int playerindex = 0;
        public MainWindow()
        {
            FontFamily = new FontFamily("Segoe UI");
            FontSize = 28;
            FontWeight = FontWeights.Bold;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            players = new List<Player>()
            {
                new Player("Anna"),
                new Player("Franz")
            };

            Player1.Content = players[0].ToString();
            Player2.Content = players[1].ToString();

            InitGameBoard();
        }

        private readonly List<string> cards = new List<string>()
        {
            "Array", "Events", "Lambda", "Method",
            "Array", "Events", "Lambda", "Method"
        };

        private static Random rnd = new Random();

        private void InitGameBoard()
        {
            // temp kopiert am Beginn den Inhalt von cards
            List<string> temp = new List<string>(cards);

            for (int row = 0; row < gameboard.RowDefinitions.Count; row++)
            {
                for (int col = 0; col < gameboard.ColumnDefinitions.Count; col++)
                {
                    TextBlock text = new TextBlock();

                    #region Styling
                    text.TextAlignment = TextAlignment.Center;
                    text.Background = new SolidColorBrush(Colors.LightGray);
                    text.Padding = new Thickness(left: 10, top: 20, right: 10, bottom: 20);
                    #endregion

                    // Registrierung eines Eventhandlers für linken Mausklick
                    text.MouseLeftButtonDown += Card_MouseDown;

                    int index = rnd.Next(0, temp.Count);
                    text.Tag = temp[index];
                    temp.RemoveAt(index);

                    //text.Text = $"row={row} col={col}";
                    gameboard.Children.Add(text);
                    Grid.SetRow(text, row);
                    Grid.SetColumn(text, col);
                }
            }
        }

        TextBlock first = null;
        TextBlock second = null;
        DispatcherTimer timer = null;


        // Aufruf der Methode für:
        // 1. Keine Karte ist sichtbar -> "Die Karte soll sichtbar werden" : card.Text = card.Tag
        // 2. Bereits eine Karte ist sichtbar -> Andere Karte sichtbar machen.
        //                                       Überprüfen, ob beide gleich sind.
        //                                           Falls beide gleich sind -> Einfärben + Punkte erhöhen +  Karten deaktivieren
        //                                           sonst                   -> Eine Zeit lang anzeigen und wieder verdecken
        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            players[playerindex].IsTurn = true;
            if (!(sender is TextBlock card))
                return;
            
            //MessageBox.Show(card.Tag.ToString());

            // 1.
            if (first == null && second == null)
            {
                // es ist noch keine Karte sichtbar
                card.Text = card.Tag.ToString();
                first = card;
                return;
            }
            else if (first != null && second == null && first != card)
            {
                // 2. es ist die erste Karte sichtbar
                card.Text = card.Tag.ToString();
                second = card;
                if (first.Text == second.Text)
                {
                    // Einfärben, Punkte erhöhen, weil karten gleich sind
                    first.Background = second.Background = new SolidColorBrush(Colors.AntiqueWhite);
                    first.IsEnabled = second.IsEnabled = false;
                    first = second = null;

                    // Punkte erhöhen
                    players[playerindex].IncrementPoints();
                }
                else
                {
                    // Dieser Programmblock soll erst nach 2 Sek ausgeführt werden,
                    // damit der GUI akutalisiert wird und die zweite Karte angezeigt wird
                    // Thread.Sleep(1000) ist streng verboten, weil es die Aktualisierung der Oberfläche blockiert
                    // Karten wieder umdrehen
                    timer = new DispatcherTimer();
                    timer.Interval = new TimeSpan(0, 0, 2);
                    timer.Tick += OnResultShown;
                    timer.Start();

                    // anderer spieler ist dran
                    players[playerindex].IsTurn = false;
                    if (players[0].IsTurn)
                    {
                        NextPlayer.Content = $"{players[0].Name} ist am Zug!";
                    }
                    else
                    {
                        NextPlayer.Content = $"{players[1].Name} ist am Zug!";
                    }
                }
            }

        }

        private void OnResultShown(object sender, EventArgs e)
        {
            timer.Stop();

            first.Text = second.Text = String.Empty;
            first = second = null;

            // Der nächste Spieler ist dran.
            // playerindex = 0 -> playerindex = 1 und umgekehrt
            
            playerindex = 1 - playerindex;
        }
    }
}
