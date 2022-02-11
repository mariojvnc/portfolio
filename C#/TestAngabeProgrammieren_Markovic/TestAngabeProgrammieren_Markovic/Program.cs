using System;
using System.Collections.Generic;
using System.IO;

namespace TestAngabeProgrammieren_Markovic
{
    class Program
    {
        static (List<AngestellterIn> angestellte, List<Gerät> geräte) LiesDateiEin(string filename)
        {
            List<AngestellterIn> angestellte = new List<AngestellterIn>();
            List<Gerät> geräte = new List<Gerät>();
            //angestellte = null;
            //geräte = null;

            StreamReader reader = new StreamReader(filename);
            reader.ReadLine();
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string[] parts = reader.ReadLine().Split(',');
                if (parts.Length == 4)
                {
                    // Angestellte

                    string[] partsName = parts[0].Split(' ');
                    string vorname = partsName[0];
                    string nachname = partsName[1];
                    string manager = "Manager";
                    string trainer = "Trainer";
                    if (parts[3] == manager)
                        angestellte.Add(new Manager(vorname, nachname, DateTime.Parse(parts[1]), DateTime.Parse(parts[2])));
                    else if (parts[3] == trainer)
                        angestellte.Add(new Trainer(vorname, nachname, DateTime.Parse(parts[1]), DateTime.Parse(parts[2])));
                    /*else
                        throw new Exception("Ungültige Daten");*/

                }
                else if (parts.Length == 5)
                {
                    // Geräte


                    if( parts[4] == "hantel")
                    {
                        // Hanteln
                        if (int.Parse(parts[0]) >= 10 && int.Parse(parts[0]) <= 35)
                            geräte.Add(new Kurzhantel(double.Parse(parts[0]), DateTime.Parse(parts[1]), int.Parse(parts[2]), parts[3] == "defekt" ? true : false));
                        else if(int.Parse(parts[0]) >= 120 && int.Parse(parts[0]) <= 150)
                            geräte.Add(new Langhantel(double.Parse(parts[0]), DateTime.Parse(parts[1]), int.Parse(parts[2]), parts[3] == "defekt" ? true : false));

                    }
                    else if (parts[4] == "ausdauergerät")
                    {
                        // Ausdauergerät
                        if (int.Parse(parts[0]) == 120)
                            geräte.Add(new Laufband(double.Parse(parts[0]), DateTime.Parse(parts[1]), int.Parse(parts[2]), parts[3] == "defekt" ? true : false));
                        else if (int.Parse(parts[0]) == 140)
                            geräte.Add(new Stepper(double.Parse(parts[0]), DateTime.Parse(parts[1]), int.Parse(parts[2]), parts[3] == "defekt" ? true : false));
                    }
                    /*else
                        throw new Exception("Ungültige Daten");*/
                }
                else
                    throw new Exception("Ungültige Daten");

            }
            reader.Close();

            return (angestellte, geräte);
        }
        static double BerechneGesamtGewichtAllerGeräte(List<Gerät> geräte)
        {
            double sum = 0;
            foreach (Gerät gerät in geräte)
                sum += gerät.Gewicht;
            return sum;
        }
        static void Main(string[] args)
        {
            string filename = "Fitnesscenter.txt";

            #region 1, 2 & 3
            (List<AngestellterIn> angestellte, List<Gerät> geräte) fitnesscenter = LiesDateiEin(filename);
            foreach (var angestellter in fitnesscenter.angestellte)
            {
                if(angestellter is Trainer)
                    Console.WriteLine($"{angestellter} --> Position: Trainer");
                else
                    Console.WriteLine($"{angestellter} --> Position: Manager");

            }

            foreach(var gerät in fitnesscenter.geräte)
            {
                if(gerät is Kurzhantel)
                    Console.WriteLine($"{gerät} --> Art: Kurzhantel");
                else if (gerät is Langhantel)
                    Console.WriteLine($"{gerät} --> Art: Langhantel");
                else if (gerät is Laufband)
                    Console.WriteLine($"{gerät} --> Art: Laufband"); 
                else
                    Console.WriteLine($"{gerät} --> Art: Stepper");

            }
            #endregion

            #region 4
            Console.WriteLine($"\nGesamtgewicht aller Geräte: {BerechneGesamtGewichtAllerGeräte(fitnesscenter.geräte)}kg");
            #endregion

            // 5.1
            fitnesscenter.angestellte.Sort();
            Console.WriteLine($"\nAngestellte sortiert nach Arbetsbeginn (absteigend)");
            Console.WriteLine(string.Join("\n", fitnesscenter.angestellte));

            // 5.2
            fitnesscenter.geräte.Sort();
            Console.WriteLine($"\nGeräte sortiert nach Gewicht (aufsteigend)");
            Console.WriteLine(string.Join("\n", fitnesscenter.geräte));

            // 5.3
            List<Gerät> defekteGeräte = new List<Gerät>();
            foreach (Gerät gerät in fitnesscenter.geräte)
                if (gerät.IstDefekt)
                    defekteGeräte.Add(gerät);

            defekteGeräte.Sort(new SortiereDefekteGeräte());
            Console.WriteLine($"\nDefekte Geräte sortiert");
            Console.WriteLine(string.Join("\n", defekteGeräte));

            Console.ReadKey();
        }
    }
}
