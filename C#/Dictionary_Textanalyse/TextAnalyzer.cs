using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Dictionary_Textanalyse // MARKOVIC Mario
{
    class TextAnalyzer
    {
        public Dictionary<string, int> WordToCount = new Dictionary<string, int>();
        public Dictionary<char, List<string>> InitiaLetterToListWords = new Dictionary<char, List<string>>();

        public void /*(Dictionary<string, int>, Dictionary<char, List<string>>)*/ ReadFile(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line == null || line == string.Empty)
                    continue;

                #region Replacements
                string quotationMark = $"\"";
                line = line.Replace(".", string.Empty).Replace("!", string.Empty).Replace("?", string.Empty).Replace("%", string.Empty)
                   .Replace("&", string.Empty).Replace("$", string.Empty).Replace("§", string.Empty).Replace("~", string.Empty).Replace("(", string.Empty)
                   .Replace(")", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty)
                   .Replace(";", string.Empty).Replace(",", string.Empty).Replace("-", string.Empty).Replace("_", string.Empty).Replace("'", string.Empty).Replace("–", string.Empty)
                   .Replace("<", string.Empty).Replace(">", string.Empty).Replace("`", string.Empty).Replace("´", string.Empty).Replace("*", string.Empty).Replace("“", string.Empty)
                   .Replace("+", string.Empty).Replace("-", string.Empty).Replace("/", string.Empty).Replace(quotationMark, string.Empty).Replace("„", string.Empty); // :O

                line = Regex.Replace(line, @"[\d-]", string.Empty); // removes integers
                #endregion

                string[] parts = line.Split(' ');

                // WordToCount Initialization
                foreach (string word in parts)
                {
                    if (word != "")
                    {
                        if (!WordToCount.ContainsKey(word))
                            WordToCount.Add(word, 1); // Add new word if it is not already taken and set the count (value) to 1
                        else
                            WordToCount[word]++; // Increase count (value) if word is already taken
                    }
                }

                // InitiaLetterToListWords Initialization
                foreach (string word in parts)
                {
                    string _word = word.ToLower();
                    if (word != "")
                    {
                        if (!InitiaLetterToListWords.ContainsKey(_word[0]))
                            InitiaLetterToListWords.Add(_word[0], new List<string>());
                        else /*if (InitiaLetterToListWords[_word[0]].Contains(_word))*/
                            InitiaLetterToListWords[_word[0]].Add(word);
                    }
                }
            }
            reader.Close();
        }
    }
}
