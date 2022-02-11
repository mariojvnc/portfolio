using System;

namespace Delegates_SteuernEinesAutos
{
    class Program // MARKOVIC
    {
        static void Main(string[] args)
        {
            Console.Title = "Markovic - Delegatebeispiel Auto";
            Console.Write($"Geben Sie das Modell ein: ");
            string modell = Console.ReadLine();
            Console.WriteLine();

            Auto auto = new Auto(modell);

            while (true)
            {
                Action method = null;

                Console.WriteLine($"Was möchten Sie tun");
                Console.WriteLine($"1: Gas geben");
                Console.WriteLine($"2: Vom Gas gehen");
                Console.WriteLine($"3: Kupplung treten");
                Console.WriteLine($"4: Von der Kupplung gehen ");
                Console.WriteLine($"5: Ganghebel betätigen");
                Console.WriteLine($"6: Einen kompletten Schaltvorgang (Auto kann nur in einen höheren Gang geschalten werden)");

                char c = Console.ReadKey(true).KeyChar;

                switch (c)
                {
                    case '1': method = auto.GasGeben; break;
                    case '2': method = auto.VomGasGehen; break;
                    case '3': method = auto.KupplungTreten; break;
                    case '4': method = auto.KupplungLoslassen; break;
                    case '5': method = auto.GanghebelBetätigen; break;
                    case '6':
                        method = auto.VomGasGehen;
                        method += auto.KupplungTreten;
                        method += auto.GanghebelBetätigen;
                        method += auto.GasGeben;
                        break;

                    default:
                        Console.WriteLine($"\nUngültige Eingabe. Bitte nur zahlen von 1-6 eingeben!\n");
                        continue;
                }
                method.Invoke();
                Console.WriteLine(auto);
            }

        }
    }
}
