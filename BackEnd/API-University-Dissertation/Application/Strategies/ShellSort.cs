using API_University_Dissertation.Application.Services.Interfaces;
using API_University_Dissertation.Core.Data.Entities;

namespace API_University_Dissertation.Application.Strategies
{
    public class ShellSort : ISortingStrategy
    {
        public IEnumerable<SortablePair> Sort(int[] unsortedList)
        {
            var arrayLength = unsortedList.Length;
            var currentArray = new int[arrayLength];
            Array.Copy(unsortedList, currentArray, arrayLength);

            var swapped = new List<SortablePair> { new SortablePair(0, 0, true) };

            // Calculate gap sequence
            int gap = 1;
            while (gap < arrayLength / 3)
                gap = gap * 3 + 1;

            // Start with the largest gap and work down to a gap of 1
            while (gap >= 1)
            {
                // Do an insertion sort for the gap value
                for (int i = gap; i < arrayLength; i++)
                {
                    int j = i;
                    while (j >= gap && currentArray[j - gap] > currentArray[j])
                    {
                        var temp = currentArray[j];
                        currentArray[j] = currentArray[j - gap];
                        currentArray[j - gap] = temp;
                        swapped.Add(new SortablePair(j - gap, j, true)); // Indicate a swap
                        j -= gap;
                    }
                    if (j != i)
                        swapped.Add(new SortablePair(j, i, false)); // Indicate no swap
                }
                gap = gap / 3; // Reduce the gap
            }

            return swapped;
        }
    }
}
