using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Einheitenumrechner_Mario
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int tabIndex = 0; // 0 is "Länge"
                                  // 0 is "Volumen"
                                  // ...
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnTabSelected(object sender, RoutedEventArgs e)
        {
            // TAB WURDE AUSGEWHÄHLT
            var tab = sender as TabItem;
            if (tab != null)
            {
                if (tab == Länge_tab)
                {
                    // Länge Tab
                    
                    tabIndex = 0;
                }
                else if (tab == Volumen_tab)
                {
                    // Volumen Tab


                    tabIndex = 1;
                }
                else if (tab == Fläche_tab)
                {
                    // Fläche Tab


                    tabIndex = 2;
                }
                else
                    MessageBox.Show("Error");

            }

            //_SelectedTab.Content = tabIndex.ToString();
        }
        public void GetUnitFrom(TabItem item)
        {
            string unitInput = string.Empty;


            EinheitVon.Content = unitInput;
        }

        private bool handle = true;
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (handle)Handle(cmb);
            handle = true;
        }

        private void ComboBox_Länge_Von_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle(cmb);
        }

        private void Handle(ComboBox cmb)
        {
            if(cmb == ComboBox_Länge_Von)
            {
                switch (cmb.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
                {
                    case "1":
                        //Handle for the first combobox
                        EinheitVon.Content = "Meter";
                        break;
                    case "2":
                        //Handle for the second combobox

                        break;
                    case "3":
                        //Handle for the third combobox
                        break;
                }

            }
        }
    }
}
