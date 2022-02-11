using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDemo
{
    class Program
    {
        static void WriteQueue(Queue<string> queue)
        {
            foreach (string person in queue)
            {
                Console.Write($"{person} ");
            }

            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            // Buffet in der HTL-Donaustadt
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Fabian");    // Einreihen in die Warteschlange
            queue.Enqueue("Felix");     // Kommt als Zweiter in die Warteschlange
            queue.Enqueue("Schamma");

            Console.WriteLine($"Es warten {queue.Count}.");

            // Console.WriteLine(queue[1]); // keinen Indexzugriff

            // Ausgabe aller Elemente nur durch foreach.
            WriteQueue(queue);

            // Den nächsten Ausgeben
            string nextOne = queue.Peek();  // Peek() gibt den nächsten zurück, entfernt ihn aber nicht.
            Console.WriteLine(nextOne);

            Console.WriteLine($"Es warten {queue.Count}.");
            WriteQueue(queue);

            // Der erste Wartende kommt dran.
            string person = queue.Dequeue();    // Holt den ersten aus der Warteschlange raus.
            Console.WriteLine($"{person} Der nächste Erste in der Warteschlange {queue.Peek()}");

            Console.WriteLine($"Es warten {queue.Count}.");
            WriteQueue(queue);

            Console.WriteLine($"Jetzt kommt {queue.Dequeue()} dran.");
            Console.WriteLine($"Es warten {queue.Count}.");
            WriteQueue(queue);

            Console.ReadKey();
        }
    }
}
