using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StackDemo
{
    class Program
    {
        static void WriteStack(Stack<string> stapel)
        {
            foreach (string farbe in stapel)
            {
                Console.Write($"{farbe} ");
            }

            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            Stack<string> colours = new Stack<string>();
            colours.Push("schwarz");    // Hinzufügen zum Stack mit Push
            colours.Push("rot");
            colours.Push("orange");

            Console.WriteLine($"Es sind {colours.Count} Farben auf dem Stack.");

            // Ausgabe aller Elemente nur durch foreach.
            WriteStack(colours);

            // Das oberste Element anzeigen
            string obersteFarbe = colours.Peek();   // Gibt das oberste Element zurück.
            Console.WriteLine($"Die oberste Farbe ist {obersteFarbe}.");

            Console.WriteLine($"Es sind {colours.Count} Farben auf dem Stack.");
            WriteStack(colours);

            string farbe = colours.Pop();   // Holt das oberste Element vom Stapel.
            Console.WriteLine($"{farbe} wurde vom Stack geholt.");
            Console.WriteLine($"Es sind {colours.Count} Farben auf dem Stack.");
            WriteStack(colours);

            Console.WriteLine($"Die oberste Farbe ist {colours.Peek()}.");

            Console.WriteLine(colours.Pop());   // -> rot wird vom Stapel entfernt
            WriteStack(colours);

            Console.WriteLine(colours.Pop());   // -> schwarz wird vom Stapel entfernt

            if ( colours.Count > 0 )
                Console.WriteLine(colours.Pop());
            else
                Console.WriteLine("Es ist keine Farbe mehr am Stack.");

            Console.ReadKey();
        }
    }
}
