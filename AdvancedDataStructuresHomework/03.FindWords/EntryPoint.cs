namespace FindWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using FindWords.TrieTree;

    /// <summary>
    /// Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file).
    /// Print how many times each word occurs in the text. 
    /// Hint: you may find a C# trie in Internet. 
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            // Create the tree.
            var wordsTree = new Trie();

            // Get the input.
            Console.SetIn(new StreamReader("../../words.txt"));
            string wholeTextParsed = ParseTextInput();
            var wordsArray = SplitTextToWords(wholeTextParsed);

            // Add all words in the tree.
            foreach (var word in wordsArray)
            {
                wordsTree.AddWord(word);
            }

            // Search in the tree
            string[] wordsToSearch = new string[] { "Lorem", "Ipsum", "text" };

            foreach (var word in wordsToSearch)
            {
                if (wordsTree.WordExists(word))
                {
                    Console.WriteLine("{0} exists with count {1}", word, wordsTree.GetWordOccurrenceCount(word));
                }
            }
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
