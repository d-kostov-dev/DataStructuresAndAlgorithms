namespace CompanyArticles
{
    using System;
    using Wintellect.PowerCollections;

    /// <summary>
    /// A large trade company has millions of articles, each described by barcode, vendor, title and price. 
    /// Implement a data structure to store them that allows fast retrieval of all articles in given price range [x…y].
    /// Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET. 
    /// </summary>
    public class EntryPoint
    {
        private const string CharsForRandomString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly Random GetRandomNumber = new Random();

        public static void Main()
        {
            var orderedDict = new OrderedMultiDictionary<double, Article>(false);

            // Generate some articles.
            for (int i = 0; i < 50000; i++)
            {
                var currentArticle = GenerateArticle();
                orderedDict.Add(currentArticle.Price, currentArticle);
            }

            // Get articles in range.
            var articlesInRange = orderedDict.Range(1.0, true, 200.0, true);

            // Print result.
            foreach (var item in articlesInRange)
            {
                foreach (var article in item.Value)
                {
                    Console.WriteLine(
                        "Title: {0}, Vendor: {1}, Price: {2}, Barcode: {3}", 
                        article.Title, 
                        article.Vendor, 
                        article.Price, 
                        article.Barcode);
                }
            }
        }

        /// <summary>
        /// Generates a Article instance with random values.
        /// </summary>
        private static Article GenerateArticle()
        {
            string title = GenerateRandomString();
            string vendor = GenerateRandomString();
            double price = GetRandomPrice();
            int barcode = GetRandomNumber.Next(10000, 99999);

            var article = new Article()
            {
                Title = title,
                Vendor = vendor,
                Price = price,
                Barcode = barcode
            };

            return article;
        }

        /// <summary>
        /// Generates random string. Default size is 7.
        /// </summary>
        /// <param name="size">Size of the string to be generated.</param>
        /// <returns>Random string with given length (default 7).</returns>
        private static string GenerateRandomString(int size = 7)
        {
            char[] charsSelected = new char[size];

            for (int i = 0; i < size; i++)
            {
                charsSelected[i] = CharsForRandomString[GetRandomNumber.Next(CharsForRandomString.Length)];
            }

            return new string(charsSelected);
        }

        /// <summary>
        /// Generates a random double number from 0.99 to 999.99
        /// </summary>
        private static double GetRandomPrice()
        {
            var numberGenerated = GetRandomNumber.NextDouble();

            return 0.99 + (numberGenerated * (999.99 - 0.99));
        }
    }
}
