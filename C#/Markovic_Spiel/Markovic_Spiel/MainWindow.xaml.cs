using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Threading;


namespace Markovic_Spiel
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Class variables
        private static Random rnd = new Random();
        private int currentScore;
        private ImageBrush mineBrush;
        private ImageBrush klickedmineBrush;
        private ImageBrush goldBrush;
        private ImageBrush questionmarkBrush;
        private List<RadioButton> radioButtons;
        private List<Button> allButtons;
        private List<Button> minesButtons;
        private Button[,] Board_Buttons;
        private int countOfMines;
        private const int ROWS = 5;
        private const int COLS = 5;

        //  DispatcherTimer setup
        //DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        #endregion

        #region Methods
        //private void dispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //    // This will tricker every second



        //    //foreach(Button button in AllButtons)
        //    //{
        //    //    if (button.IsEnabled)
        //    //        button.Background = Brushes.Red;
        //    //}
        //}
        private void CreateBoard()
        {
            Board_Buttons = new Button[ROWS, COLS];
            int counterForList = 0;

            while (counterForList < allButtons.Count)
            {
                for (int row = 0; row < Board_Buttons.GetLength(0); row++)
                {
                    for (int col = 0; col < Board_Buttons.GetLength(0); col++)
                    {
                        Board_Buttons[row, col] = allButtons[counterForList];
                        counterForList++;
                    }
                }
            }

        }
        private void UncheckRadioButtons()
        {
            foreach (RadioButton rb in radioButtons)
            {
                rb.IsHitTestVisible = false;
            }
        }
        private int GetCountOfMines()
        {
            // Get vaule of checked rb

            if (rb_1.IsChecked == true)
                return 1;
            else if (rb_3.IsChecked == true)
                return 3;
            else if (rb_5.IsChecked == true)
                return 5;
            return 10;
        }
        private List<Button> GetRandomMines()
        {
            List<Button> mines = new List<Button>();

            int rndRow;
            int rndCol;

            for (int i = 1; i <= countOfMines; i++)
            {
                //If the Button is already taken in the mines, search for another that is not taken
                while (true)
                {
                    rndRow = rnd.Next(0, 5);
                    rndCol = rnd.Next(0, 5);
                    if (!mines.Contains(Board_Buttons[rndRow, rndCol]))
                    {
                        mines.Add(Board_Buttons[rndRow, rndCol]);
                        break;
                    }
                }
            }

            return mines;
        }
        private void IsMine(Button button)
        {
            if (minesButtons.Contains(button))
            {
                // Mine got klicked
                if (countOfMines != 1)
                    button.Background = klickedmineBrush;
                else
                    button.Background = mineBrush;
                button.Cursor = Cursors.No;
                foreach (Button btn in allButtons)
                {
                    //btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));  -- STACKOVERFLOW :(
                    if (minesButtons.Contains(btn))
                    {
                        if (btn != button)
                            btn.Background = mineBrush;
                        btn.Cursor = Cursors.No;
                    }
                    else
                    {
                        btn.Background = goldBrush;
                        btn.Cursor = Cursors.No;
                    }
                }

                startButton.IsEnabled = true;
                PlayAgainButton.Visibility = Visibility.Visible;
                startButton.Visibility = Visibility.Hidden;
            }
            else
            {
                if (PlayAgainButton.Visibility == Visibility.Hidden && button.Background != goldBrush && button.Background != questionmarkBrush)
                    currentScore++;
                scoreLabel.Content = $"Score: {currentScore}";
                button.Background = goldBrush;
                button.Cursor = Cursors.No;
            }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            //dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 0);
            //dispatcherTimer.Start();

            #region Brushes
            mineBrush = new ImageBrush();
            mineBrush.ImageSource = new BitmapImage(new Uri("assets/bomb.png", UriKind.Relative));

            klickedmineBrush = new ImageBrush();
            klickedmineBrush.ImageSource = new BitmapImage(new Uri("assets/klickedbomb.png", UriKind.Relative));

            goldBrush = new ImageBrush();
            goldBrush.ImageSource = new BitmapImage(new Uri("assets/gold.png", UriKind.Relative));

            questionmarkBrush = new ImageBrush();
            questionmarkBrush.ImageSource = new BitmapImage(new Uri("assets/questionmark.png", UriKind.Relative));
            #endregion


            // Fill readioButton list
            radioButtons = new List<RadioButton>
            {
                rb_1, rb_3, rb_5, rb_10
            };

            // Fill every button in the List
            allButtons = new List<Button>()
            {
                button_row_0_col_0,
                button_row_0_col_1,
                button_row_0_col_2,
                button_row_0_col_3,
                button_row_0_col_4,

                button_row_1_col_0,
                button_row_1_col_1,
                button_row_1_col_2,
                button_row_1_col_3,
                button_row_1_col_4,

                button_row_2_col_0,
                button_row_2_col_1,
                button_row_2_col_2,
                button_row_2_col_3,
                button_row_2_col_4,

                button_row_3_col_0,
                button_row_3_col_1,
                button_row_3_col_2,
                button_row_3_col_3,
                button_row_3_col_4,

                button_row_4_col_0,
                button_row_4_col_1,
                button_row_4_col_2,
                button_row_4_col_3,
                button_row_4_col_4,

            };

            // Creates 2d Array of the List<Button>
            CreateBoard();

        }

        #region Button Methods
        private void button_row_0_col_0_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_0_col_0);
            // or IsMine(Board_Buttons[0, 0]);
        }

        private void button_row_0_col_1_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_0_col_1);
        }

        private void button_row_0_col_2_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_0_col_2);
        }

        private void button_row_0_col_3_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_0_col_3);
        }

        private void button_row_0_col_4_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_0_col_4);
        }

        private void button_row_1_col_0_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_1_col_0);
        }

        private void button_row_1_col_1_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_1_col_1);
        }

        private void button_row_1_col_2_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_1_col_2);
        }

        private void button_row_1_col_3_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_1_col_3);
        }

        private void button_row_1_col_4_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_1_col_4);
        }

        private void button_row_2_col_0_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_2_col_0);
        }

        private void button_row_2_col_1_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_2_col_1);
        }

        private void button_row_2_col_2_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_2_col_2);
        }

        private void button_row_2_col_3_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_2_col_3);
        }

        private void button_row_2_col_4_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_2_col_4);
        }

        private void button_row_3_col_0_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_3_col_0);
        }

        private void button_row_3_col_1_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_3_col_1);
        }

        private void button_row_3_col_2_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_3_col_2);
        }

        private void button_row_3_col_3_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_3_col_3);
        }

        private void button_row_3_col_4_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_3_col_4);
        }

        private void button_row_4_col_0_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_4_col_0);
        }

        private void button_row_4_col_1_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_4_col_1);
        }

        private void button_row_4_col_2_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_4_col_2);
        }

        private void button_row_4_col_3_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_4_col_3);
        }

        private void button_row_4_col_4_Click(object sender, RoutedEventArgs e)
        {
            IsMine(button_row_4_col_4);
        }

        #endregion

        #region Start Button
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            UncheckRadioButtons();

            // Enable all buttons 
            foreach (Button button in allButtons)
                button.IsEnabled = true;

            // and Change the Cursor of all buttons
            foreach (Button button in allButtons)
                button.Cursor = Cursors.Hand;

            // Get Count of Mines
            countOfMines = GetCountOfMines();

            // Get the mines
            minesButtons = GetRandomMines();

            startButton.IsEnabled = false;
        }
        #endregion

        private void PlayAgainButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
