using System;
using System.Collections.Generic;
using System.IO;
namespace TestBeispielÜbungMitSchamma
{
    class Rennleitung
    {
        public List<Runner> runners { get; private set; }
        private List<Runner> _50MeterRunner = new List<Runner>();
        private List<Runner> _100MeterRunner = new List<Runner>();
        private List<Runner> _100MeterRunner_Weiblich = new List<Runner>();
        private List<Runner> _100MeterRunner_Männlich = new List<Runner>();
        public Rennleitung(string filename)
        {
            this.runners = new List<Runner>();

            StreamReader reader = new StreamReader(filename);
            reader.ReadLine(); // zeile überspringen
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(';');
                Geschlecht geschleht = Geschlecht.w;
                if (parts[2] == "m")
                    geschleht = Geschlecht.m;
                runners.Add(new Runner(int.Parse(parts[0]), parts[1], geschleht));
            }
            reader.Close();
        }

        public void Simulate()
        {
            Console.WriteLine($"Läufer beginnen zu rennen\n");
            foreach (var runner in runners)
            {
                runner._50MeterErreicht += Runner__50MeterErreicht;
                runner._100MeterErreicht += Runner__100MeterErreicht;
                Action method = runner.Run;
                method.BeginInvoke(OnFinish(runner), runner);
            }
        }

        private AsyncCallback OnFinish(Runner runner)
        {
            Console.WriteLine($"Startnummer #{runner.Startnummer} hat begonnen zu rennen");
            return null;
        }
        private void Runner__50MeterErreicht(object sender, _50MeterErreichtEventArgs e)
        {
            if (!(sender is Runner))
                throw new NullReferenceException();
            Runner runner = sender as Runner;
            Console.WriteLine($"HÄLFTE ERREICHT: {runner.Name} mit Startnummer {runner.Startnummer} Derzeitige Länge: {Math.Round(e.Length, 2)} Geschlecht: {runner.Geschlecht}");
            _50MeterRunner.Add(runner);
        }
        private void Runner__100MeterErreicht(object sender, _100MeterErreichtEventArgs e)
        {
            if (!(sender is Runner))
                throw new NullReferenceException();
            Runner runner = sender as Runner;
            Console.WriteLine($"ZIEL ERREICHT: {runner.Name} mit Startnummer {runner.Startnummer} Derzeitige Länge: {Math.Round(e.Length, 2)} Geschlecht: {runner.Geschlecht}");
            _100MeterRunner.Add(runner);

            if (runner.Geschlecht == Geschlecht.m)
                _100MeterRunner_Männlich.Add(runner);
            else
                _100MeterRunner_Weiblich.Add(runner);

            if(_100MeterRunner.Count == runners.Count)
            {
                // hier ausgeben, alle sind im ziel
                Console.WriteLine($"\nZwischenresultat aller runner bei 50m");
                for (int i = 0; i < _50MeterRunner.Count; i++)
                {
                    Console.WriteLine($"{i+1}. Platz: {_50MeterRunner[i].Name}");
                }
                Console.WriteLine();
                Console.WriteLine($"Zwischenresultat aller runner bei 100m");
                for (int i = 0; i < _100MeterRunner.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Platz: {_100MeterRunner[i].Name}");
                }
                Console.WriteLine();
                Console.WriteLine($"Zwischenresultat aller runner (weiblich) bei 100m");
                for (int i = 0; i < _100MeterRunner_Weiblich.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Platz: {_100MeterRunner_Weiblich[i].Name}");
                }
                Console.WriteLine();
                Console.WriteLine($"Zwischenresultat aller runner (männlich) bei 100m");
                for (int i = 0; i < _100MeterRunner_Männlich.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Platz: {_100MeterRunner_Männlich[i].Name}");
                }
            }
        }
    }
}
