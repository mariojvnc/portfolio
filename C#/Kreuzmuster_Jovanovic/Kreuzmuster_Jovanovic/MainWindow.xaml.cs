using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kreuzmuster_Jovanovic
{
    /// <summary>
    /// Interaktionslogik for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();
        private int[] surface = new int[99999];
        private List<Button> buttons = new List<Button>();
        private List<int> pattern_file_numbers = new List<int>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int counter = 1;
            // Create Grid with buttons
            for (int row = 0; row < button_grid.RowDefinitions.Count; row++)
            {
                for (int col = 0; col < button_grid.ColumnDefinitions.Count; col++)
                {
                    Button button = new Button();
                    button.Name = $"_" + counter.ToString();
                    button.Click += Button_Click;
                    button.Content = counter.ToString();
                    button_grid.Children.Add(button);
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);
                    buttons.Add(button);
                    counter++;
                }
            }
        }

        private void SaveFileDialog(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text file|*.txt";

            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, string.Join(",", pattern_file_numbers));
                MessageBox.Show($"{dlg.FileName} was saved successfully");
            }
        }
        private void OpenFileDialog(object sender, RoutedEventArgs e)
        {
            var fileContent = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text file|*.txt";

            if (ofd.ShowDialog() == true)
                MessageBox.Show($"{ofd.FileName} was selected successfully");
            
            //Read the contents of the file into a stream
            var fileStream = ofd.OpenFile();

            using (StreamReader reader = new StreamReader(fileStream))
                fileContent = reader.ReadToEnd();

            List<string> parts = fileContent.Split(',').ToList();

            foreach (var part in parts)
                pattern_file_numbers.Add(int.Parse(part));

            for (int i = 0; i < surface.Length; i++)
            {
                if (parts.Count > 0)
                {
                    if (int.Parse(parts[0]) == i)
                    {
                        surface[i] = 1;
                        parts.RemoveAt(0);
                    }
                    else
                        surface[i] = 0;
                }
                else
                    surface[i] = 0;
            }

            CheckGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button))
                throw new InvalidDataException();

            Button button = sender as Button;

            if (surface[int.Parse(button.Name.Substring(1)) /*get number of button (number after the "_") */] == 2)
            {
                surface[int.Parse(button.Name.Substring(1))] = 0;
                CheckGrid();
            }
            else
            {
                surface[int.Parse(button.Name.Substring(1))] = 1;
                CheckGrid();
            }
            pattern_file_numbers.Add(int.Parse(button.Name.Substring(1)));
        }

        public void CheckGrid()
        {
            // Every button will be checked, if there is another
            // right
            // left
            // under
            // or above

            // 0 = origin backgroundcolor (gray)
            // 1 = no cross, but selected backgroundcolor (red)
            // 2 = cross backgroundcolor (green)

            for (int i = 0; i < surface.Length; i++)
            {
                if (surface[i] == 1)
                {
                    if (surface[i + 1] == 1)
                    {
                        if (surface[i - 1] == 1)
                        {
                            if (surface[i + 10] == 1)
                            {
                                if (surface[i - 10] == 1)
                                {
                                    surface[i] = 2;
                                    surface[i + 1] = 2; // right
                                    surface[i - 1] = 2; // left
                                    surface[i + 10] = 2; // above
                                    surface[i - 10] = 2; // under
                                }
                            }
                        }
                    }
                }
            }

            foreach (var button in buttons)
            {
                if (surface[int.Parse(button.Name.Substring(1))] == 2)
                    button.Background = Brushes.Green;
                if (surface[int.Parse(button.Name.Substring(1))] == 1)
                    button.Background = Brushes.Red;
            }
        }

    }
}
