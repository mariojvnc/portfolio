using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImageDownloaderSync
{
    class Program
    {
        // merken, wieviele Jobs schon gestartet sind
        private static int runningJobs = 0;

        // Hilfsweg, weil die Methoden alle statisch sind
        private static object obj = new object();

        private static Queue<(string url, string name)> jobs = new Queue<(string url, string name)>();

        //private static readonly string defaultInputFile = Path.Combine(
        //    Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "input.csv");
        private static readonly string defaultInputFile = Path.Combine(
            Directory.GetCurrentDirectory() + @"\..\..", "input.csv");

        private static void DownloadNextJobSync()
        {
            (string url, string name) job = jobs.Dequeue();

            string filename = job.name + ".jpg";

            Console.WriteLine("Started Download: " + filename + ". Thread #" + Thread.CurrentThread.ManagedThreadId);

            WebClient client = new WebClient();
            Action<string, string> downloadaction = client.DownloadFile;
            downloadaction.BeginInvoke(job.url, job.name + ".jpg", OnFinishedDownload, job.name);
            //client.DownloadFile(job.url, job.name + ".jpg");

            lock (obj)
            {
                runningJobs++;
            }
        }

        private static void OnFinishedDownload(IAsyncResult ar)
        {
            lock (obj)
            {   // lock ist immer um den Zugriff auf den Shared Memory
                runningJobs--;
            }

            AsyncResult arr = ar as AsyncResult;
            //Action<string, string> downloadaction = arr.AsyncDelegate as Action<string, string>;
            //downloadaction.EndInvoke(ar);
            Console.WriteLine("Finished Download: " + arr.AsyncState.ToString() + ". Thread #" + Thread.CurrentThread.ManagedThreadId);
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

            stopwatch.Start();
            while (jobs.Count > 0)
                DownloadNextJobSync();

            bool stillRunning = true;

            while (stillRunning)
            {
                lock (obj)
                {
                    stillRunning = runningJobs > 0;
                }
            }

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

            Console.ReadLine();
        }
    }
}
