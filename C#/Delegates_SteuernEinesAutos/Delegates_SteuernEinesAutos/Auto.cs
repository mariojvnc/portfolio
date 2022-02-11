using System;

namespace Delegates_SteuernEinesAutos
{
    class Auto // MARKOVIC
    {
        public string Modell { get; private set; }
        public int Drehzahl { get; private set; }
        public bool Kupplung { get; private set; }
        public int Gang { get; private set; }
        public double Geschwindigkeit => Drehzahl / 100 * Gang;


        public Auto(string modell)
        {
            Modell = modell;
        }

        public void GasGeben()
        {
            Console.WriteLine($"\nEs wurde gas gegeben. Geschwindigkeit: {Geschwindigkeit}, Drehzahl: {Drehzahl}");
            Drehzahl += 100;
        }
        public void VomGasGehen()
        {
            Console.WriteLine($"\nGas wurde losgelassen. Geschwindigkeit: {Geschwindigkeit}, Drehzahl: {Drehzahl}");
            if (Drehzahl >= 100)
                Drehzahl -= 100;
            else
                Console.WriteLine($"\nVom Gas gehen funktioniert nur, wenn die Drehzhahl mind. 100 beträgt! (Aktuelle Drehzahl: {Drehzahl})");
        }
        public void KupplungTreten() { Console.WriteLine($"\nKupplung wurde getreten. Geschwindigkeit: {Geschwindigkeit}, Drehzahl: {Drehzahl}"); Kupplung = true; }
        public void KupplungLoslassen() { Console.WriteLine($"\nKupplung wurde losgelassen. Geschwindigkeit: {Geschwindigkeit}, Drehzahl: {Drehzahl}"); Kupplung = false; }
        public void GanghebelBetätigen()
        {
            if (!Kupplung)
            {
                Console.WriteLine($"\nGanghebel konnte nicht betätigt werden - Kupplung betätigen!");
                return;
            }
            if (Gang < 5)
            {
                Console.WriteLine($"\nGang wurde erhöht (Aktueller Gang: {Gang}). Geschwindigkeit: {Geschwindigkeit}, Drehzahl: {Drehzahl}");
                Gang++;
            }
        }
        
        public override string ToString() => $"Modell: {Modell}\nAktuelle Drehzahl: {Drehzahl}\nAkteller Gang: {Gang}\nKupplung gerade getreten?: {Kupplung}\n";
    }
}
