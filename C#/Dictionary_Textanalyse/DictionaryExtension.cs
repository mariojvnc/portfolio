using System.Collections.Generic;
using System.Linq;

namespace Dictionary_Textanalyse // MARKOVIC Mario
{
    public static class DictionaryExtension
    {
        public static int GetDistinctKeys(this Dictionary<string, int> dictionary) => dictionary.Count;
        public static int GetTotalCountOfKeys(this Dictionary<string, int> dictionary)
        {
            int count = 0;

            foreach (var element in dictionary)
                count += element.Value;

            return count;
        }
        public static KeyValuePair<string, int> GetMostCommonKeyValuePair(this Dictionary<string, int> dictionary)
        {
            KeyValuePair<string, int> keyValuePair = new KeyValuePair<string, int>();

            foreach (var element in dictionary)
            {
                if (element.Value == dictionary.Values.Max())
                    keyValuePair = element;
            }

            return keyValuePair;
        }
        public static int GetCountOfMostCommonWordFromInitialLetter(this Dictionary<char, List<string>> dictionary, char character)
        {
            character = char.ToLower(character);

            foreach (var element in dictionary)
            {
                if (element.Key == character)
                    return element.Value.Count;
            }
            return 0;
        }
        public static KeyValuePair<string, int> GetMostCommonKeyValuePair(this Dictionary<char, List<string>> dictionary, char character)
        {
            Dictionary<string, int> dictionaryFromWordWithInitialLetter = new Dictionary<string, int>();
            character = char.ToLower(character);

            foreach(var word in dictionary[character])
            {
                string _word = word.Replace(word[0], char.ToLower(word[0]));
                if (dictionaryFromWordWithInitialLetter.ContainsKey(_word))
                    dictionaryFromWordWithInitialLetter[_word]++;
                else
                    dictionaryFromWordWithInitialLetter.Add(_word, 1);
            }

            return dictionaryFromWordWithInitialLetter.GetMostCommonKeyValuePair();
        }
    }
}
