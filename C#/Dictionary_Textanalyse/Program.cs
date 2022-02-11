using System;

namespace Dictionary_Textanalyse // MARKOVIC Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "MARKOVIC Mario - DictionaryTextanalyse";
            TextAnalyzer ta = new TextAnalyzer();
            ta.ReadFile("HIF Beschreibung.txt");

            // TODO: Ausgabe der Anzahl der verschiedenen Wörter
            Console.WriteLine($"Anzahl der verschiedenen Wörter: {ta.WordToCount.GetDistinctKeys()}");

            // TODO: Ausgabe der Anzahl der gesamten Wortzahl
            Console.WriteLine($"Anzahl der Gesamtanzahl der Wörter: {ta.WordToCount.GetTotalCountOfKeys()}");

            // TODO: Ausgabe des häufigsten Worts und seiner Anzahl
            Console.WriteLine($"Das Häufgiste Wort: \"{ta.WordToCount.GetMostCommonKeyValuePair().Key}\" kommt " +
                $"{ta.WordToCount.GetMostCommonKeyValuePair().Value} Mal vor\n");


            #region ta.WordToCount Output
            /*foreach (var element in ta.ta.WordToCount)
                Console.WriteLine($"{element.Key} -> {String.Join("\n", element.Value)}");*/
            #endregion

            #region ta.InitiaLetterToListWords Output
            /*foreach (var element in ta.InitiaLetterToListWords)
                Console.WriteLine($"{element.Key} -> {String.Join(", ", element.Value)}");*/
           
            #endregion

            do
            {
                Console.Write("Geben Sie den Anfangsbuchstaben ein: ");
                if (!char.TryParse(Console.ReadLine(), out char letter))
                {
                    Console.WriteLine("Die Eingabe war ungültig. Geben Sie bitte nur ein Zeichen ein.\n");
                    continue;
                }
                // TODO: Ausgabe des häufigsten Worts mit dem Anfangsbuchstaben letter
                Console.WriteLine($"\nAnzahl der Wörter mit dem Buchstaben \"{letter}\": {ta.InitiaLetterToListWords.GetCountOfMostCommonWordFromInitialLetter(letter)}");

                // TODO: Ausgabe der gesamten Anzahl von Wörtern mit dem Anfangsbuchstaben letter
                Console.WriteLine($"Das häufgste Wort mit dem Anfangsbuchstaben \"{letter}\" lautet: \"{ta.InitiaLetterToListWords.GetMostCommonKeyValuePair(letter).Key}\" und kommt {ta.InitiaLetterToListWords.GetMostCommonKeyValuePair(letter).Value} Mal vor.");

                break;
            }
            while (true);

            Console.ReadKey();
        }
    }
}