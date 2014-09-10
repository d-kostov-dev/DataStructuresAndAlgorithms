namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Write a program based on dynamic programming to solve the "Knapsack Problem": 
    /// you are given N products, 
    /// each has weight Wi 
    /// and costs Ci 
    /// and a knapsack of capacity M and you want to put inside a subset of the products with highest 
    /// cost and weight ≤ M. 
    /// The numbers N, M, Wi and Ci are integers in the range [1..500]. 
    /// </summary>
    public class EntryPoint
    {
        private static int knapsackCapacity;
        private static IList<Product> availableProducts;

        public static void Main()
        {
            GetInputData();
            Console.WriteLine();

            var fittingProducts = FindBestProductsCombination();

            Console.WriteLine("Best weight/value we can get is:");
            Console.WriteLine(string.Join("\n", fittingProducts));
        }

        public static IList<Product> FindBestProductsCombination()
        {
            // Keep the best values in each capacity of the bag.
            int[,] costMatrix = new int[availableProducts.Count + 1, knapsackCapacity + 1];

            // Shoud we keep the product or not.
            bool[,] doKeep = new bool[availableProducts.Count + 1, knapsackCapacity + 1];

            // Loop through all products.
            for (int productNumber = 1, len = availableProducts.Count; productNumber <= len; productNumber++) 
            {
                var currentProduct = availableProducts[productNumber - 1];

                // Try each bag capacity options.
                for (int currentCapacity = 1; currentCapacity <= knapsackCapacity; currentCapacity++) 
                {
                    if (currentProduct.Weight <= currentCapacity) 
                    {
                        int remainingCapacity = currentCapacity - currentProduct.Weight; 

                        if (remainingCapacity > 0)
                        {
                            // The previous calculation for the same capacity.
                            int previousCost = costMatrix[productNumber - 1, currentCapacity];

                            // The previous calculation for the remaining capacity and previous product.
                            int sumValue = 
                                currentProduct.Cost + costMatrix[productNumber - 1, remainingCapacity - 1];

                            // If previous cost is better we keep it and don't save the product.
                            if (previousCost > sumValue) 
                            {
                                costMatrix[productNumber, currentCapacity] = previousCost;
                                doKeep[productNumber, currentCapacity] = false;
                            }
                            else
                            {
                                costMatrix[productNumber, currentCapacity] = sumValue;
                                doKeep[productNumber, currentCapacity] = true;
                            }
                        }
                        else
                        {
                            // No previous calculations. Best case so far. Save the product.
                            costMatrix[productNumber, currentCapacity] = currentProduct.Cost;
                            doKeep[productNumber, currentCapacity] = true;
                        }
                    }
                }
            }

           var bestCombination = new List<Product>();

            int remainingCap = knapsackCapacity;
            int product = availableProducts.Count;

            // We get the first possible product. Decrease weight...get next possible.
            while (product >= 0)
            {
                bool toBeAdded = doKeep[product, remainingCap - 1];

                if (toBeAdded)
                {
                    bestCombination.Add(availableProducts[product - 1]);
                    remainingCap -= availableProducts[product - 1].Weight;
                }

                product--;
            }

            return bestCombination;
        }

        private static void GetInputData()
        {
            Console.SetIn(new StreamReader("../../inputData.txt"));

            Console.Write("Knapsack Capacity: ");
            knapsackCapacity = int.Parse(Console.ReadLine());

            Console.Write("Numer of products: ");
            int n = int.Parse(Console.ReadLine());
            availableProducts = new List<Product>(n);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter Product 'Name Weight Price'");
                var currentInput = Console.ReadLine().Split(' ').Select(s => s.Trim()).ToArray();

                var currentProduct =
                    new Product(currentInput[0], int.Parse(currentInput[1]), int.Parse(currentInput[2]));

                availableProducts.Add(currentProduct);
            }
        }
    }
}
