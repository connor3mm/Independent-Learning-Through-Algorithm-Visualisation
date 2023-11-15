using System.Collections;
using API_University_Dissertation.Interfaces;

namespace API_University_Dissertation.Strategies;

public class BubbleSort : ISortingStrategy
{
    public IEnumerable<int> Sort()
    {
        int[] bubbleSort = { 4, 2, 1, 3 };
        return bubbleSort;
    }
}