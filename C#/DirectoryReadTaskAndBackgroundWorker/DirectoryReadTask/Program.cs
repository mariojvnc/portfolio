using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryReadTaskAndBackgroundWorker
{
    class Program
    {
        private static Queue<string> paths = new Queue<string>();

        private static readonly string defaultInputFile = Path.Combine(
            Directory.GetCurrentDirectory() + @"\..\..\..", "directories");

        #region Directory Info Methods
        // Liefert die Anzahl aller Files in einem Directory path 
        static int GetNumberOfFiles(string path)
        {
            int anzahl = 0;

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] files;
            DirectoryInfo[] subDirs = { };

            try
            {
                files = dirInfo.GetFiles();
                anzahl += files.Length;
            }
            catch (UnauthorizedAccessException)
            {
            }

            try
            {
                subDirs = dirInfo.GetDirectories();
            }
            catch (UnauthorizedAccessException)
            {
            }

            foreach (DirectoryInfo d in subDirs)
            {
                anzahl += GetNumberOfFiles(d.FullName);
            }

            return anzahl;
        }
        // Liefert den gesamten Speicherplatz vom Directory path
        static ulong GetBytes(string path)
        {
            ulong bytes = 0;

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] files = { };
            DirectoryInfo[] subDirs = { };

            try
            {
                files = dirInfo.GetFiles();
            }
            catch (UnauthorizedAccessException)
            {
            }

            foreach (FileInfo f in files)
            {
                bytes = bytes + (ulong)f.Length;
            }

            try
            {
                subDirs = dirInfo.GetDirectories();
            }
            catch (UnauthorizedAccessException)
            {
            }

            foreach (DirectoryInfo d in subDirs)
            {
                bytes += GetBytes(d.FullName);
            }

            return bytes;
        }
        #endregion

        private static void GetInfosFromPath()
        {
            if (paths.Count == 0)
                return;

            string path = paths.Dequeue();
            Console.WriteLine("Started Getting Infos from Directory \"{0}\"", path + ". Thread #" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine();
            int filesCount = 0;
            ulong bytes = 0;

            try
            {
                filesCount = GetNumberOfFiles(path);
                bytes = GetBytes(path);
            }
            catch
            {
                Console.WriteLine($"Error occuring getting Infos from {path}");
            }


            Console.WriteLine($"--------------------------------\n{path}\nCount of files: {filesCount}\nBytes: {bytes}\n--------------------------------\n");
        }
        static bool ReadCSV(string filename)
        {
            if (!File.Exists(filename))
                return false;

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string path = reader.ReadLine();
                    paths.Enqueue(path);
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
            while (paths.Count > 0)
            {
                Task task = new Task(GetInfosFromPath);
                task.Start();
            }

            // Stop StopWatch
            stopwatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopwatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.ReadKey();
        }
    }
}
