using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;

namespace Wortanalyse_BeginInvoke_EndInvoke
{
    class Program
    {
        #region static variables
        static int counter = 0;
        static object obj = new object();
        static object obj_1 = new object();
        static object obj_2 = new object();
        static SortedDictionary<int, int> wordLengthToCount_ALL_TXT_FILES = new SortedDictionary<int, int>();
        #endregion

        #region Methods
        static SortedDictionary<int, int> ReadFile(string filename)
        {
            SortedDictionary<int, int> wordLengthToCount = new SortedDictionary<int, int>();
            
            StreamReader reader = new StreamReader(filename);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line == null || line == string.Empty)
                    continue;

                #region Replacements
                char x = '\'';
                line = line.Trim(new char[] { '!', '?', '%', '&', '$', '§', '~', '(', ')', '{', '}', '[', ']', ';', ',', '-', '_', x, '–', '<', '>', '`', '´', '*', '“', '+', '-', '/', '"', '„' });
                line = Regex.Replace(line, @"[\d-]", string.Empty); // removes integers
                #endregion

                string[] parts = line.Split(' ');

                // WordlengthToCount Initialization
                foreach (string word in parts)
                {
                    if (word != "")
                    {
                        if (word.Length >= 2 & word.Length <= 23) // 2 bis 23 Buchstaben
                        {
                            if (!wordLengthToCount.ContainsKey(word.Length))
                                wordLengthToCount.Add(word.Length, 1); // Add new wordlength if it is not already taken and set the count (value) to 1
                            else
                                wordLengthToCount[word.Length]++; // Increase count (value) if word length is already taken
                        }
                    }
                }
            }
            reader.Close();
            return wordLengthToCount;
        }
        private static void OnFinish(IAsyncResult ar)
        {
            var result = ar as AsyncResult;
            string textfile = result.AsyncState.ToString();
            Func<string, SortedDictionary<int, int>> method = result.AsyncDelegate as Func<string, SortedDictionary<int, int>>;
            SortedDictionary<int, int> wordLengthToCount = method.EndInvoke(result);

            lock (obj_1)
            {
                foreach (var element in wordLengthToCount)
                {
                    if (!wordLengthToCount_ALL_TXT_FILES.ContainsKey(element.Key))
                        wordLengthToCount_ALL_TXT_FILES.Add(element.Key, element.Value); // new wordlength
                    else
                        wordLengthToCount_ALL_TXT_FILES[element.Key] += wordLengthToCount[element.Key]; // add wordlength_VALUE 
                }
            }

            textfile = textfile.Remove(0, textfile.Length - 9);

            Console.WriteLine($"{textfile} hat insgesamt {wordLengthToCount.Keys.Count} verschiedene Wortlängen\n(Wortlänge -> Wie oft sie vorkommt)");
            foreach (var element in wordLengthToCount)
                Console.WriteLine($"{element.Key} -> {element.Value}");
            Console.WriteLine();

            // hier counter sinken
            lock (obj)
                counter--;


        }
        #endregion

        static void Main(string[] args)
        {
            // Aufgabe 1
            //      Erstelle mit BeginInvoke / EndInvoke - Threads, mit denen die Texte parallel eingelesen werden und von
            //      jedem Wort die Anzahl der Zeichen zählt. Zähle mit, wie oft welche Wortlänge vorkommt. Relevant für die
            //      Aufgabe sind Worte mit einer Länge von 2 bis 23 Buchstaben.
            //      Beachte dabei:
            //      Sonderzeichen wie Punkt, Beistrich und Strichpunkt zählen natürlich nicht als Zeichen von Wörtern und
            //      dürfen nicht mitgezählt werden.

            // Zähle mit, wie oft welche Wortlänge vorkommt -> lengthToCount

            List<string> textFiles = new List<string>{
                Path.Combine(Directory.GetCurrentDirectory()+ @"\..\..", "text1.txt"),
                Path.Combine(Directory.GetCurrentDirectory()+ @"\..\..", "text2.txt"),
                Path.Combine(Directory.GetCurrentDirectory()+ @"\..\..", "text3.txt"),
                Path.Combine(Directory.GetCurrentDirectory()+ @"\..\..", "text4.txt"),
                Path.Combine(Directory.GetCurrentDirectory()+ @"\..\..", "data1.txt"),
                Path.Combine(Directory.GetCurrentDirectory()+ @"\..\..", "data2.txt"),
                Path.Combine(Directory.GetCurrentDirectory()+ @"\..\..", "data3.txt"),

            };

            foreach (var file in textFiles)
            {
                Func<string, SortedDictionary<int, int>> method = ReadFile;
                method.BeginInvoke(file, OnFinish, file);

                // hier counter erhöhen
                lock (obj) { counter++; }

                //double rounded = Math.Round(number, 3);
                //Console.WriteLine($"{number} gerundet ist {rounded} Thread #{ Thread.CurrentThread.ManagedThreadId} ");
            }

            while (true)
            {
                lock (obj)
                {
                    if (counter == 0)
                        break;
                }
            }

            Console.WriteLine($"(Aufgabe 1) Alles fertig!");

            // Create new Dictionary with procentual values
            double sum = 0;
            SortedDictionary<int, double> wordLengthToCount_for_csv = new SortedDictionary<int, double>();


            lock (obj_1) // Aufgabe 2 Dictionary
            {
                Console.WriteLine($"\n-----------------------------------\n\nAlle Textdateien\n(Wortlänge -> Wie oft sie vorkommt)\n");
                foreach (var element in wordLengthToCount_ALL_TXT_FILES)
                    Console.WriteLine($"{element.Key} -> {element.Value}");

                foreach (var element in wordLengthToCount_ALL_TXT_FILES) // for sum
                    sum += wordLengthToCount_ALL_TXT_FILES[element.Key];

                foreach (var element in wordLengthToCount_ALL_TXT_FILES)
                {
                    double procentualvalue = element.Value / sum * 100;
                    wordLengthToCount_for_csv.Add(element.Key, procentualvalue);
                }

                Console.WriteLine();
            }
            Console.WriteLine($"Aufgabe 2 fertig!\n\n");
            

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine($"(Wortlänge -> Wie oft sie in % vorkommt)\n");
            foreach (var element in wordLengthToCount_for_csv)
                Console.WriteLine($"{element.Key} -> {Math.Round(element.Value, 3)} %");

            using (StreamWriter writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory() + @"\..\..\data.csv")))
            {
                foreach (var element in wordLengthToCount_for_csv)
                    writer.WriteLine("{0}-{1}", element.Key, element.Value);
            }

            Console.WriteLine($"\nSuccessfully created data.csv (seperator: \"-\")");

            Console.ReadKey();
        }
    }
}
