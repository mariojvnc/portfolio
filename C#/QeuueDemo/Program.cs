using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QeuueDemo
{
    class Program
    {
        static void WriteQueue(Queue<string> queue)
        {
            foreach(string person in queue)
                Console.Write($"{person} ");
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            // Buffet in der HTL-Donaustadt
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("Fabian"); // Einreihen in die Warteschlange
            queue.Enqueue("Felix"); // Kommt als Zweiter in die Warteschlange
            queue.Enqueue("Schamma");

            Console.WriteLine($"Es warten {queue.Count}.");

            // Ausgabe aller Elemente in der Queue
            WriteQueue(queue);

            // Den nächsten Ausgeben
            string nextOne = queue.Peek(); // Peek() gibt den ersten zurück, entfernt ihn aber nicht
            Console.WriteLine(nextOne);
            Console.WriteLine($"Es warten {queue.Count}.");


            // Der erste Wartende kommt dran
            string person = queue.Dequeue(); // Holtden ersten aus der Wartschlange raus.
            Console.WriteLine($"{person} Der nächste Erste in der Warteschlange {queue.Peek()}");
            Console.WriteLine($"Es warten {queue.Count}.");
            WriteQueue(queue);

            // 
            Console.WriteLine($"Jetzt kommt {queue.Dequeue()} dran.");
            Console.ReadKey();
        }
    }
}
