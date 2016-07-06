using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public class MergeSort<T> : ISort<T>
    {
        public IList<T> Sort(IList<T> source)
        {
            var result = source.ToList();

            Sort(result, 0, result.Count - 1);

            return result;
        }

        private void Sort(IList<T> arr, int low, int high)
        {
            int midpoint = 0;
            if (low < high)
            {
                midpoint = (low + high) / 2;

                Sort(arr, low, midpoint);
                Sort(arr, midpoint + 1, high);

                Merge(arr, low, midpoint, high);
            }
        }

        private void Merge(IList<T> list, int low, int midpoint, int high)
        {
            var temp = new T[list.Count];
            int l = low;
            int r = high;
            int m = midpoint + 1;
            int k = l;

            while (l <= midpoint && m <= r)
            {
                if (Comparer<T>.Default.Compare(list[l], list[m]) <= 0)
                {
                    temp[k++] = list[l++];
                }
                else
                {
                    temp[k++] = list[m++];
                }
            }

            while (l <= midpoint)
                temp[k++] = list[l++];
            while (m <= r)
            {
                temp[k++] = list[m++];
            }

            for (int i1 = low; i1 <= high; i1++)
            {
                list[i1] = temp[i1];
            }
        }
    }
}
