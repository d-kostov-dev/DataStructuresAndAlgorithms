namespace ProductSearching
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Write a program to read a large collection of products (name + price) 
    /// and efficiently find the first 20 products in the price range [a…b]. 
    /// Test for 500 000 products and 10 000 price searches. 
    /// Hint: you may use OrderedBag<T> and sub-ranges.
    /// </summary>
    public class EntryPoint
    {
        private const string CharsForRandomString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static readonly Random GetRandomNumber = new Random();
        private static readonly Stopwatch Timer = new Stopwatch();

        private static OrderedBag<Product> bagOfProducts;
        
        public static void Main()
        {
            bagOfProducts = new OrderedBag<Product>();

            // Populating the bag with products.
            Timer.Start();
            PopulateBag();
            Timer.Stop();
            Console.WriteLine("Adding products timer: {0}", Timer.Elapsed);
            Console.WriteLine("Items in the bag: {0}", bagOfProducts.Count);

            // Perform 10 000 random searches.
            Timer.Start();

            for (int i = 0; i < 10000; i++)
            {
                PerformRandomSearch();
            }

            Timer.Stop();
            Console.WriteLine("10 000 searches took: {0}", Timer.Elapsed);
        }

        /// <summary>
        /// Performs a search with random price values.
        /// </summary>
        private static IList<Product> PerformRandomSearch()
        {
            double minRange = GetRandomPrice();
            double maxRange = GetRandomPrice();

            while (true)
            {
                if (maxRange > minRange)
                {
                    break;
                }

                maxRange = GetRandomPrice();
            }

            return SearchInRange(minRange, maxRange);
        }

        /// <summary>
        /// Searches in the bag for products that match the range.
        /// </summary>
        /// <param name="minimalPrice">Minimal price range.</param>
        /// <param name="maximalPrice">Maximal price range.</param>
        /// <returns>List of top 20 products in the range.</returns>
        private static IList<Product> SearchInRange(double minimalPrice, double maximalPrice)
        {
            var result = new List<Product>();
            var minProduct = new Product("minProduct", minimalPrice);
            var maxProduct = new Product("maxProduct", maximalPrice);

            var itemsFound = bagOfProducts.Range(minProduct, true, maxProduct, true);

            if (itemsFound.Count > 0)
            {
                for (int i = 0; i < 20 && i < itemsFound.Count; i++)
                {
                    result.Add(itemsFound[i]);
                }
            }

            return result;
        }

        /// <summary>
        /// Populates the OrderedBag with 500k products.
        /// </summary>
        private static void PopulateBag()
        {
            for (int i = 0; i < 500000; i++)
            {
                bagOfProducts.Add(GenerateProduct());
            }
        }

        /// <summary>
        /// Generates a Product instance with random name and price.
        /// </summary>
        private static Product GenerateProduct()
        {
            string name = GenerateRandomString();
            double price = GetRandomPrice();
            var product = new Product(name, price);

            return product;
        }

        /// <summary>
        /// Generates random string. Default size is 5.
        /// </summary>
        /// <param name="size">Size of the string to be generated.</param>
        /// <returns>Random string with given length (default 5).</returns>
        private static string GenerateRandomString(int size = 5)
        {
            char[] charsSelected = new char[size];

            for (int i = 0; i < size; i++)
            {
                charsSelected[i] = CharsForRandomString[GetRandomNumber.Next(CharsForRandomString.Length)];
            }

            return new string(charsSelected);
        }

        /// <summary>
        /// Generates a random double number from 0.99 to 99.99
        /// </summary>
        private static double GetRandomPrice()
        {
            var numberGenerated = GetRandomNumber.NextDouble();

            return 0.99 + (numberGenerated * (99.99 - 0.99));
        }
    }
}
