using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public class InsertionSort<T> : ISort<T>
    {
        public IList<T> Sort(IList<T> source)
        {
            var result = source.ToList();

            for (int i = 1; i < result.Count; i++)
            {
                int j = i - 1;
                var temp = result[i];
                while (j >= 0 && Comparer<T>.Default.Compare(temp, result[j]) < 0)
                {
                    result[j + 1] = result[j];
                    j--; ;
                }
                result[j + 1] = temp;
            }

            return result;
        }
    }
}
