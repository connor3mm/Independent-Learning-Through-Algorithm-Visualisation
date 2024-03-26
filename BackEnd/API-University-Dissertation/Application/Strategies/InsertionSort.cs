using API_University_Dissertation.Application.Services.Interfaces;
using API_University_Dissertation.Core.Data.Entities;

namespace API_University_Dissertation.Application.Strategies
{
    /// <summary>
    /// Represents a sorting strategy using the Insertion Sort algorithm.
    /// </summary>
    public class InsertionSort : ISortingStrategy
    {
        public IEnumerable<SortablePair> Sort(int[] unsortedList)
        {
            //Initialise variables
            var arrayLength = unsortedList.Length;
            var currentArray = new int[arrayLength];
            var swapped = new List<SortablePair> { new SortablePair(0, 0, true) };// Indicate a swap
            Array.Copy(unsortedList, currentArray, arrayLength);

            for (var i = 1; i < arrayLength; ++i)
            {
                var key = currentArray[i];
                var j = i - 1;

                // Find the correct position for the key
                while (j >= 0 && currentArray[j] > key)
                {
                    var swappablePair = new SortablePair(j, j + 1, true);// Indicate a swap
                    swapped.Add(swappablePair);
                    currentArray[j + 1] = currentArray[j];
                    j = j - 1;
                }
                currentArray[j + 1] = key;
            }

            return swapped;
        }
    }
}