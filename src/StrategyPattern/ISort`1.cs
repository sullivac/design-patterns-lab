using System.Collections.Generic;

namespace StrategyPattern
{
    public interface ISort<T>
    {
        IList<T> Sort(IList<T> source);
    }
}
