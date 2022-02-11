using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace ImageDownloaderSync
{
    class Program
    {
        private static Queue<(string url, string name)> jobs = new Queue<(string url, string name)>();

        //private static readonly string defaultInputFile = Path.Combine(
        //    Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "input.csv");
        private static readonly string defaultInputFile = Path.Combine(
            Directory.GetCurrentDirectory()+ @"\..\..", "input.csv");

        // Eventhandler
        private static void DownloadNextJobSync(object sender, DoWorkEventArgs e)
        {
            if (jobs.Count == 0)
                return;

            (string url, string name) job = jobs.Dequeue();

            string filename = job.name + ".jpg";

            Console.WriteLine("Started Download: " + filename + ". Thread #" + Thread.CurrentThread.ManagedThreadId);
            WebClient client = new WebClient();

            try
            {
                client.DownloadFile(job.url, job.name + ".jpg");
            }
            catch(WebException ex)
            {
                // interpolated strings
                //Console.Error.WriteLine($"Error occurred when downloading {job.url}\nDetails: {ex.Message}");
                
                // placeholder with positions
                Console.Error.WriteLine("Error occurred when downloading {0}\nDetails: {1}",
                    job.url, ex.Message);
            }

            e.Result = $"Finished download of {job.name}.jpg";

            Console.WriteLine();    
        }

        private static bool ReadCSV(string input)
        {
            if (!File.Exists(input))
                return false;

            using (StreamReader reader = new StreamReader(input))
            {
                while (!reader.EndOfStream)
                {
                    string[] parts = reader.ReadLine().Split(';');
                    jobs.Enqueue((parts[0], parts[1]));
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            ReadCSV(defaultInputFile);

            // Start StopWatch
            Stopwatch stopwatch = new Stopwatch();

            List<BackgroundWorker> bgw = new List<BackgroundWorker>();
            
            stopwatch.Start();
            List<BackgroundWorker> workers = new List<BackgroundWorker>();

            while (jobs.Count > 0)
            {
                //Task task = new Task(DownloadNextJobSync);
                //task.Start();
                //bgw.Add(new BackgroundWorker());
                BackgroundWorker worker = new BackgroundWorker(); //  bgw[bgw.Count-1];
                worker.DoWork += DownloadNextJobSync; // entspricht new Task(DownloadNextJobSync)
                worker.RunWorkerCompleted += OnFinish;
                workers.Add(worker);
                //worker.WorkerSupportsCancellation = true;
                worker.RunWorkerAsync();
                // Der Backgroundworker wird asynchron gestartet.
                // 1. Er löst das Event DoWork aus und die Aufgabe die wir 
                //    parallel ausführen wollen, wird als EventHandler-Methode
                //    aufgerufen.
                // 2. Wenn die Aufgabe fertig ausgeführt wurde, löst der
                //    Backgroundworker das Event RunWorkerCompleted aus.
                //    VORTEIL gegenüber der Klasse Task!!!
                // 3. Ein berechnetes Ergebnis kann von DownloadNextJobSync
                //    zur zweiten Handlermethode OnFinish mittels
                //    DoWorkEventArgs.Result transportiert werden.

                // Ein SYNCHRONER Methodenaufruf ist so, dass kein Thread erzeugt wird.
                // Ein ASYNCHRONER Methodenaufruf ist ein solcher, bei dem die 
                // Methode in einem eigenen Thread abgearbeitet wird und der 
                // Aufrufer parallel weiterläuft.

                //new Task(DownloadNextJobSync).Start();

                for (int i = 0; i < workers.Count; i++)
                {
                    if (!workers[i].IsBusy)
                    {
                        //remove handlers
                        workers[i].Dispose();
                    }
                }
            }

            Console.WriteLine("AUS DER SCHLEIFE");
            Console.ReadKey();
            // Stop StopWatch
            stopwatch.Stop();

            //
            // Print elapsed time
            //

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopwatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            //bgw.ForEach(x => x.CancelAsync());

            Console.ReadLine();
        }

        private static void OnFinish(object sender, RunWorkerCompletedEventArgs e)
        { 
            Console.WriteLine("OnFinish: {0}", e.Result);
        }
    }
}
