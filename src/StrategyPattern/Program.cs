using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    internal class Program
    {
        private List<int> numbers;
        private readonly List<IList<int>> sortedResults;
        private readonly List<ISort<int>> sorters;

        public Program()
        {
            sortedResults = new List<IList<int>>();
            sorters = new List<ISort<int>> {
                new BubbleSort<int>(),
                new Quicksort<int>(),
                new MergeSort<int>(),
                new InsertionSort<int>()
            };
        }

        static void Main(string[] args)
        {
            var program = new Program();

            program.ReadNumbers();
            program.SortNumbers();
            program.Output();
        }

        private void ReadNumbers()
        {
            Console.Write("Enter a list of space-separated numbers: ");

            numbers = Console.ReadLine()
                .Split(' ')
                .Select(
                    token =>
                    {
                        int result;

                        return int.TryParse(token, out result) ? result : null as int?;
                    })
                .Where(number => number.HasValue)
                .Select(number => number.Value)
                .ToList();
        }

        private void SortNumbers()
        {
            if (numbers.Count == 0)
            {
                throw new InvalidOperationException("No numbers entered.");
            }

            foreach (var sorter in sorters)
            {
                var sorted = sorter.Sort(numbers);

                sortedResults.Add(sorted);
            }
        }

        private void Output()
        {
            for (var index = 0; index < sortedResults.Count; index++)
            {
                Console.WriteLine(sorters[index].GetType().Name);

                Console.WriteLine(string.Join(" ", sortedResults[index]));
            }
        }
    }
}
