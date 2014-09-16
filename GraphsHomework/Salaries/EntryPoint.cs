namespace Salaries
{
    using System;

    public class EntryPoint
    {
        private static long[] cachedSalaries;
        private static bool[,] employeeDependencies;

        public static void Main()
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());

            employeeDependencies = new bool[numberOfEmployees, numberOfEmployees];
            cachedSalaries = new long[numberOfEmployees];

            for (int i = 0; i < numberOfEmployees; i++)
            {
                var currentDependency = Console.ReadLine().ToCharArray();

                for (int c = 0; c < numberOfEmployees; c++)
                {
                    employeeDependencies[i, c] = currentDependency[c] == 'Y' ? true : false;
                }
            }

            long salariesSum = 0;

            for (int i = 0; i < numberOfEmployees; i++)
            {
                salariesSum += FindSalary(i);
            }

            Console.WriteLine(salariesSum);

            // PrintMatrix(employeeDependencies);
        }

        private static long FindSalary(int employeeId)
        {
            if (cachedSalaries[employeeId] > 0)
            {
                return cachedSalaries[employeeId];
            }

            long currentSalary = 0;

            for (int i = 0; i < employeeDependencies.GetLength(1); i++)
            {
                if (employeeDependencies[employeeId, i])
                {
                    currentSalary += FindSalary(i);
                }
            }

            if (currentSalary == 0)
            {
                currentSalary = 1;
            }

            cachedSalaries[employeeId] = currentSalary;

            return currentSalary;
        }

        private static void PrintMatrix<T>(T[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("[{0}]", matrix[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
