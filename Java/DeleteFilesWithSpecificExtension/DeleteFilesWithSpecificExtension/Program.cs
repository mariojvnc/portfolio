using System;
using System.Collections.Generic;
using System.Linq;

namespace DeleteFilesWithSpecificExtension // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Path: ");
            string path = Console.ReadLine();

            Console.Write("Extension (with \".\"): ");
            string extenstion = Console.ReadLine();

            foreach (string sFile in System.IO.Directory.GetFiles(path, $"*{extenstion}"))
            {
                System.IO.File.Delete(sFile);
            }

            Console.ReadKey();
        }
    }
}