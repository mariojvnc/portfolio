using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace BeginInvokeForMathRound
{
    class Program
    {
        // Aufgabe: Parallelisiere das Runden mit Math.Round mit BeginInvoke/EndInvoke


        private static void OnFinish(IAsyncResult ar)
        {
            var result = ar as AsyncResult;
            double number = double.Parse(result.AsyncState.ToString());
            Func<double, int, double> method = result.AsyncDelegate as Func<double, int, double>;
            double finishedNumber = method.EndInvoke(result);

            Console.WriteLine($"{number} gerundet ist {finishedNumber}");
            // hier counter sinken
            lock (obj)
            {
                results.Add(finishedNumber);
                counter--;
            }
        }

        static List<double> results = new List<double>();
        static int counter = 0;
        static object obj = new object();
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>{
                45.34545,
                Math.PI,
                Math.E,
                -4594569.9474
            };

            foreach (double number in numbers)
            {
                Func<double, int, double> method = Math.Round;
                method.BeginInvoke(number, 3, OnFinish, number);

                // hier counter erhöhen
                lock (obj) { counter++; }

                double rounded = Math.Round(number, 3);
                Console.WriteLine($"{number} gerundet ist {rounded} Thread #{ Thread.CurrentThread.ManagedThreadId} ");
            }

            while (true)
            {
                lock (obj)
                {
                    if (counter == 0)
                        break;
                }
            }

            Console.WriteLine($"Alles fertig!\n\n");
            foreach(var number in results)
                Console.WriteLine(number);

            Console.ReadKey();
        }
    }
}
