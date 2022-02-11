using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoverkäufe__mit_zweidimensionalen_Array_
{
    class Program
    {
        public static int GetSum(int[,] array)
        {
            int sumOfAll = 0;
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    sumOfAll += array[row, col];
                }
            }
            return sumOfAll;

        }

        public static int GetSumType(int[,] array, int col)
        {
            int sum = 0;
            int rowIndex = 0;
            int rowMaxIndex = array.GetLength(0) - 1;

            while (rowIndex <= rowMaxIndex)
            {
                sum += array[rowIndex, col];
                rowIndex++;
            }
            return sum;
        }
        static void Main(string[] args)
        {

            // Array mit 3 Zeilen und 4 Spalten
            int[,] carsales = new int[,] {
                { 30, 53, 43, 8},
                { 12, 48, 5, 9},
                { 32, 65, 3, 1 }
            };


            // 1. Ausgabe der Anzahl aller verkauften SUV der Marke KIA aus (durch Zugriff auf das Array!)

            Console.WriteLine($"Verkaufte SUV´s der Marke KIA: {carsales[1, 2]}"); // --> [zeile, spalte]


            // 2. Ausgabe der Anzahl aller verkauften SUV und Transporter der Marke Dacia (durch Zugriff auf das Array!)

            Console.WriteLine($"Verkaufte SUV´s der Marke Dacia: {carsales[2, 2]}"); // --> [zeile, spalte]
            Console.WriteLine($"Verkaufte Transporter der Marke Dacia: {carsales[2, 3]}"); // --> [zeile, spalte]

            // 3. Eingabe einer Marke -> Ausgabe der Gesamtanzahl aller verkauften Autos dieser Marke
            // und des Anteils in % an der Gesamtanzahl aller verkauften Autos
            // z.B.: Es wurden insgesamt 134 VW verkauft. Das sind 43,4 % aller verkauften Fahrzeuge

            Console.Write("Gib eine Automarke ein: ");
            string brand = Console.ReadLine();

            //int row = 0;

            //switch (brand)
            //{
            //    case "VW": row = 0; break;
            //    case "KIA": row = 1; break;
            //    case "Dacia": row = 2; break;
            //    default: Console.WriteLine($"Ungültige Eingabe"); break;
            //}

            List<string> brands = new List<string>()
            {
                "VW", "KIA", "Dacia"
            };

            // 0 is for the row dimension
            // 1 is for the column dimension
            int sum = 0;
            int row = brands.IndexOf(brand);
            for (int col = 0; col < carsales.GetLength(1); col++)
            {
                // Calculates the sales in a row
                sum += carsales[row, col];
            }

            Console.WriteLine($"Es wurden {sum} Autos der Marke {brand} verkauft");

            Console.WriteLine($"Insgesamt wurden {GetSum(carsales)} Autos verkauft");

            Console.WriteLine($"{Math.Round(100.0 * sum / GetSum(carsales), 2)} % der verkauften Autos sind {brand}s");

            // 4.Eingabe eines Fahrzeugtyps -> Ausgabe der Gesamtanzahl aller verkauften Autos dieses Typs
            // und des Anteils in % an der Gesamtanzahl aller verkauften Autos

            Console.Write($"Gib einen Fahrzeugtyp ein: ");

            string carType = Console.ReadLine();
            List<string> types = new List<string>()
            {
                "Kleinstwagen", "Limousine", "SUV", "Transporter"
            };

            int _col = types.IndexOf(carType);

            Console.WriteLine($"Es wurden {GetSumType(carsales, _col)} {carType}s verkauft");

            Console.ReadKey();
        }
    }
}
