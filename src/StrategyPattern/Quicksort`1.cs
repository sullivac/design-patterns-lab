using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public class Quicksort<T> : ISort<T>
    {
        public IList<T> Sort(IList<T> source)
        {
            var result = source.ToList();

            Sort(result, 0, result.Count - 1);

            return result;
        }

        private void Sort(IList<T> elements, int left, int right)
        {
            int i = left;
            int j = right;
            var pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (Comparer<T>.Default.Compare(elements[i], pivot) < 0)
                {
                    i++;
                }

                while (Comparer<T>.Default.Compare(elements[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    var temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Sort(elements, left, j);
            }

            if (i < right)
            {
                Sort(elements, i, right);
            }
        }
    }
}
