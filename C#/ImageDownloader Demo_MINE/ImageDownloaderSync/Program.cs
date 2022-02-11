using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ImageDownloaderSync
{
    class Program
    {
        private static Queue<(string url, string name)> jobs = new Queue<(string url, string name)>();

        //private static readonly string defaultInputFile = Path.Combine(
        //    Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, "input.csv");
        private static readonly string defaultInputFile = Path.Combine(
            Directory.GetCurrentDirectory()+ @"\..\..", "input.csv");

        private static void DownloadNextJobSync()
        {
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

            stopwatch.Start();
            while (jobs.Count > 0)
                DownloadNextJobSync();

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
