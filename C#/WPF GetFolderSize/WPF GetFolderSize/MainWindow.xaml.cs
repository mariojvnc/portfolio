using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace WPF_GetFolderSize
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnClick(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button))
                return;

            string folder = button.Content as string;
            folder = GetFolder(folder);

            if (!Directory.Exists(folder))
            {
                MessageBox.Show($"{folder} does not exist!");
                return;
            }

            Stopwatch watch = new Stopwatch();
            watch.Start();

            long size = await GetSizeAsync(folder);
            watch.Stop();

            AddLineToGrid(folder, size, watch.ElapsedMilliseconds);

        }

        
        private void AddLineToGrid(string folder, long size, long ms)
        {
            resultGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25) });

            int rowindex = resultGrid.RowDefinitions.Count - 1;

            // 1st column: we add a link to the directory folder
            TextBlock tb = new TextBlock();

            // Add folder as link
            Hyperlink link = new Hyperlink(new Run(folder)) { NavigateUri = new Uri(folder) };
            link.RequestNavigate += OnNavigate; // Register click onto link
            tb.Inlines.Add(link);

            Grid.SetColumn(tb, 0);
            Grid.SetRow(tb, rowindex);
            resultGrid.Children.Add(tb);

            // 2nd column
            TextBlock tb2 = new TextBlock { Text = Math.Round(size / 1e6, 1).ToString() };
            Grid.SetColumn(tb2, 1);
            Grid.SetRow(tb2, rowindex);
            resultGrid.Children.Add(tb2);

            // 3rd column
            TextBlock tb3 = new TextBlock { Text = ms.ToString() };
            Grid.SetColumn(tb3, 2);
            Grid.SetRow(tb3, rowindex);
            resultGrid.Children.Add(tb3);
        }

        private Task<long> GetSizeAsync(string folder)
        {
            return Task.Run(() => GetSize(folder));
        }

        private long GetSize(string folder)
        {
            long size = 0;

            DirectoryInfo di = new DirectoryInfo(folder);

            try
            {
                foreach (FileInfo file in di.EnumerateFiles())
                {
                    size += file.Length;
                }
            }
            catch (UnauthorizedAccessException)
            {

            }

            try
            {
                foreach (DirectoryInfo subdirectory in di.EnumerateDirectories())
                {
                    size += GetSize(subdirectory.FullName);
                }
            }
            catch (UnauthorizedAccessException)
            {

            }

            return size;
        }

        private string GetFolder(string folder)
        {
            switch (folder)
            {
                case "MyDocuments": return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                case "MyPictures": return Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
                case "MyMusic": return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                case "MyVideos": return Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                case "Custom Folder": return CustomFolder.Text;
            }

            return folder;
        }

        private void OnNavigate(object sender, RequestNavigateEventArgs e)
        {
            ProcessStartInfo runExplorer = new System.Diagnostics.ProcessStartInfo();
            runExplorer.FileName = "explorer.exe";
            runExplorer.Arguments = e.Uri.ToString().Replace("file:///", "").Replace("/", @"\");
            runExplorer.UseShellExecute = false;
            System.Diagnostics.Process.Start(runExplorer); ;
        }
    }
}
