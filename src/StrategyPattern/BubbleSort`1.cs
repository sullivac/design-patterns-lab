using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public class BubbleSort<T> : ISort<T>
    {
        public IList<T> Sort(IList<T> source)
        {
            var result = source.ToList();

            if (source.Count < 2) { return result; }

            bool swapped;
            do
            {
                swapped = false;

                for (var index = 1; index < result.Count; index++)
                {
                    if (Comparer<T>.Default.Compare(result[index - 1], result[index]) > 0)
                    {
                        var temp = result[index];
                        result[index] = result[index - 1];
                        result[index - 1] = temp;

                        swapped = true;
                    }
                }
            } while (swapped);

            return result;
        }
    }
}
