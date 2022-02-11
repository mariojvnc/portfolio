using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace DirectoryLesen
{
    class Program
    {
        // Liefert die Anzahl aller Files in einem Directory path 
        static int GetNumberOfFiles(string path)
        {
            int anzahl = 0;

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] files;
            DirectoryInfo[] subDirs = {};

            try
            { 
                files = dirInfo.GetFiles();
                anzahl += files.Length;
            }
            catch(UnauthorizedAccessException)
            { 
            }

            try
            {
                subDirs = dirInfo.GetDirectories();
            }
            catch (UnauthorizedAccessException)
            {
            }

            foreach ( DirectoryInfo d in subDirs )
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
            FileInfo[] files = {};
            DirectoryInfo[] subDirs = {};

            try
            {
                files = dirInfo.GetFiles();
            }
            catch (UnauthorizedAccessException)
            {
            }

            foreach(FileInfo f in files)
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

        // Findet das größte File von allen Verzeichnissen
        static string FindLargestFile(string pfad)
        {
            return "";
        }

        [STAThread]
        static void Main(string[] args)
        {
            //string path = @"\\gstiess\2DHIF\_Shared\_Programmieren und Software Engineering_\2DHIF vonSLOG\Daten";
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                Environment.Exit(0);

            string path = dlg.SelectedPath;

            Console.WriteLine(path);

            // Hier gehts los!
            Stopwatch uhr = new Stopwatch();
            uhr.Start();

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            Console.WriteLine("Created at: " + dirInfo.CreationTime);
            Console.WriteLine("DirectoryInfo.Name="+dirInfo.Name);
            Console.WriteLine("DirectoryInfo.FullName=" + dirInfo.FullName + "\n" + new string('-',40));
            DirectoryInfo[] subDirs = dirInfo.GetDirectories();
            Console.WriteLine("{0} Verzeichnis(se):", subDirs.Length);

            for (int i = 0; i < subDirs.Length; i++)
            {
                DirectoryInfo d = subDirs[i];
                Console.WriteLine(d.Name);
            }

            FileInfo[] files = dirInfo.GetFiles();
            Console.WriteLine("{0} File(s):", files.Length);
            foreach (FileInfo f in files)
            {
                Console.WriteLine(f.Name + ": " + f.Length + " Bytes");
            }

            uhr.Stop();
            Console.WriteLine((double)uhr.ElapsedMilliseconds / 1000 + " s");

            Console.WriteLine("Drücke eine Taste für eine rekursive Suche");
            Console.ReadKey();

            uhr.Restart();
            int anzahl = GetNumberOfFiles(path);
            Console.WriteLine(anzahl + "Files");
            uhr.Stop();
            Console.WriteLine((double)uhr.ElapsedMilliseconds / 1000 + " s");

            ulong bytes = GetBytes(path);
            Console.WriteLine(bytes + " Bytes");
            Console.ReadKey();
        }
    }
}
