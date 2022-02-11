using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;
using Application = System.Windows.Forms.Application;

namespace Zufallszahlengenerator_testen
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int countOfMaxRandomNumbers;
        private const int MIN_INTEGER = 1;
        private const int MAX_INTEGER = 100;
        System.Windows.Application Application = System.Windows.Application.Current;
        List<int> listRandomNumbers_http;
        List<int> listRandomNumbers_randomclass;

        List<(int x, int y)> listOfTuples_randomclass;
        List<(int x, int y)> listOfTuples_http;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                countOfMaxRandomNumbers = int.Parse(countInput.Text);
            }
            catch
            {
                MessageBox.Show("Gib eine gültige Zahl ein! (Ganzzahl)");
                Application.Shutdown();
            }

            string url = $"https://www.random.org/integers/?num={countOfMaxRandomNumbers.ToString()}&min=1&max=100&col=1&base=10&format=html&rnd=new";

            GetRandomIntegers();
            GetRandomIntegers(url);
        }
        private void GetRandomIntegers()
        {
            listRandomNumbers_randomclass = new List<int>();
            Random rnd = new Random();
            int i = 1;
            while (i <= countOfMaxRandomNumbers)
            {
                listRandomNumbers_randomclass.Add(rnd.Next(MIN_INTEGER, MAX_INTEGER));
                i++;
            }
            foreach (var element in listRandomNumbers_randomclass)
            {
                testboxs1.Text += $"{element}\n";
            }
            testboxs1.Text += "\n" + listRandomNumbers_randomclass.Count.ToString();

            GetTuplesFromList(listOfTuples_randomclass, listRandomNumbers_randomclass);
        }
        private async void GetRandomIntegers(string url)
        {
            listRandomNumbers_http = new List<int>();
            WebClient webClient = new WebClient();
            string sourceCode = string.Empty;
            try
            {
                sourceCode = await webClient.DownloadStringTaskAsync(url);
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message);
                Application.Shutdown();
                return;
            }
            //testboxs.Text = sourceCode;
            string onlyNumbersString = sourceCode.Split(new string[] { "<pre class=\"data\">", "</pre>" }, StringSplitOptions.None)[1];
            //testboxs.Text = onlyNumbersString;
            // "59\n90\n15\n" -> das steht in "onlyNumbersString"
            string[] parts = onlyNumbersString.Split(new[] { "\n" }, StringSplitOptions.None);

            foreach (string part in parts)
            {
                if (part != "")
                    listRandomNumbers_http.Add(int.Parse(part));
            }

            foreach (var element in listRandomNumbers_http)
            {
                testboxs.Text += $"{element}\n";
            }


            GetTuplesFromList(listOfTuples_http, listRandomNumbers_http);

        }

        private void GetTuplesFromList(List<(int x, int y)> listOfTuples, List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {

            }
        }
    }
}
