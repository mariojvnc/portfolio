using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace ImageDownloaderSync
{
    class Program
    {
        // Wer verändert diese Variable?
        // Antwort: Der Main-Thread erhöht die Variable und fragt im Main die Variable ab.
        //          Und alle anderen Threads verkleinern in OnFinish die Variable um 1.
        // Paralleles Zugreifen auf eine Ressource (Variablen, Collections, ...) kann RIESIGE Probleme auslösen.

        // Man muss den Zugriff darauf synchronisieren. 
        // Es darf IMMER nur ein Thread auf die Variable zugreifen.
        // The access is locked!
        // Der Zugriff auf die Variable ist eine Critical Section.
        private static int runningJobs = 0;

        // Synchronisationsinstance das von .NET zur Laufzeit verwendet wird.
        private static object obj = new object();

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

            // Wir erzeugen einen Thread mit Hilfe von BeginInvoke
            try
            {
                // 1. Delegate anlegen und einen Verweis auf die Methode speichern.
                Action<string, string> method = client.DownloadFile;

                // 2. BeginInvoke aufrufen
                // BeginInvoke erzeugt einen Threader der client.Download mit den Argumenten aufruft.
                // falls die Methode fertig ist mit dem runterladen, wird OnFinish aufgerufen.
                method?.BeginInvoke(job.url, job.name + ".jpg", OnFinish, job.name + ".jpg");

                lock(obj)   // critical section
                { 
                    runningJobs++;
                }

                // Invoke macht einen synchronen Call!
                // synchron = der Main wartet auf die Beendigung der Methode.
                // method?.Invoke(job.url, job.name + ".jpg");

                //client.DownloadFile(job.url, job.name + ".jpg");
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

        // 3. Die Callback-Methode für das Fertigmachen anlegen.
        private static void OnFinish(IAsyncResult ar)
        {
            lock (obj)   // critical section
            {
                runningJobs--;
            }

            // 4. Man kann sich das letzte Argument vom BeginInvoke-Call hier rausholen.
            AsyncResult arr = ar as AsyncResult;
            string jobname = arr.AsyncState.ToString(); // holt sich job.name vom Aufruf.

            // 5. Etwaige Resultate der Methode auslesen.
            // Ist nur erlaubt, wenn die Methode client.DownloadFile etwas zurückliefern würde.
            //Action<string, string> method = arr.AsyncDelegate as Action<string, string>;
            //method.EndInvoke(arr);

            Console.WriteLine($"Finish Download: {jobname}.Thread #{Thread.CurrentThread.ManagedThreadId}");
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

            while(stillRunning)
            {
                lock (obj)   // critical section
                {
                    stillRunning = runningJobs > 0;
                }

                //if ( runningJobs > 0 )
                //{
                //    stillRunning = true;
                //}
                //else
                //{
                //    stillRunning = false;
                //}
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
