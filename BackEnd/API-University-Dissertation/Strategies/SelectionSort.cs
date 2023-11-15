using System.Collections;
using API_University_Dissertation.Interfaces;

namespace API_University_Dissertation.Strategies;

public class SelectionSort : ISortingStrategy
{
    public IEnumerable<int> Sort()
    {
        int[] selectionSort = { 2 };
        return selectionSort;
    }
}