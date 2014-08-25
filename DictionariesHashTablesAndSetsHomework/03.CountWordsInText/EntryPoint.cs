namespace CountWordsInText
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Write a program that counts how many times each word from given text file words.txt appears in it.
    /// The character casing differences should be ignored. 
    /// The result words should be ordered by their number of occurrences in the text. 
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            Console.SetIn(new StreamReader("../../words.txt"));

            string wholeTextParsed = ParseTextInput();
            var wordsArray = SplitTextToWords(wholeTextParsed);
            var countedWords = CountWordsOccurrenceCaseInsensitive(wordsArray);

            PrintWordsCount(countedWords);
        }

        /// <summary>
        /// Prints all words ordered by their occurrence count.
        /// </summary>
        private static void PrintWordsCount(IDictionary<string, int> countedWords)
        {
            foreach (var word in countedWords.OrderBy(word => word.Value))
            {
                Console.WriteLine("Word: {0} - Count:{1}", word.Key, word.Value);
            }
        }

        /// <summary>
        /// Counts the occurrence of each word in a words/strings enumerable.
        /// </summary>
        private static IDictionary<string, int> CountWordsOccurrenceCaseInsensitive(IEnumerable<string> words)
        {
            var countedWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string currentWord = word.ToLower();

                if (!countedWords.ContainsKey(currentWord))
                {
                    countedWords.Add(currentWord, 0);
                }

                countedWords[currentWord]++;
            }

            return countedWords;
        }

        /// <summary>
        /// Splits text to collection of words(strings).
        /// </summary>
        private static IEnumerable<string> SplitTextToWords(string textToSplit)
        {
            var clearedText = Regex.Replace(textToSplit, "[^a-zA-Z0-9% ._]", string.Empty);

            return clearedText.Split(' ');
        }

        /// <summary>
        /// Gets all content from file / console input.
        /// </summary>
        private static string ParseTextInput()
        {
            StringBuilder resultingText = new StringBuilder();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == string.Empty || inputLine == null)
                {
                    break;
                }

                resultingText.Append(inputLine);
            }

            return resultingText.ToString();
        }
    }
}
