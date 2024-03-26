using API_University_Dissertation.Application.Services.Interfaces;
using API_University_Dissertation.Core.Data.Entities;

namespace API_University_Dissertation.Application.Strategies
{
    /// <summary>
    /// Represents a sorting strategy using the Selection Sort algorithm.
    /// </summary>
    public class SelectionSort : ISortingStrategy
    {
        public IEnumerable<SortablePair> Sort(int[] unsortedList)
        {
            //Initialise variables
            var arrayLength = unsortedList.Length;
            var currentArray = new int[arrayLength];
            var swapped = new List<SortablePair> { new SortablePair(0, 0, true) };
            Array.Copy(unsortedList, currentArray, arrayLength);

            for (var i = 0; i < arrayLength - 1; i++)
            {
                var smallestVal = i;
                var swappedThisIteration = false;
                for (var j = i + 1; j < arrayLength; j++)
                {
                    if (currentArray[j] < currentArray[smallestVal])
                    {
                        smallestVal = j;
                        swappedThisIteration = true;
                    }
                }

                if (swappedThisIteration)
                {
                    swapped.Add(new SortablePair(i, smallestVal, true));
                    // Perform swap only if necessary
                    if (i != smallestVal)
                    {
                        (currentArray[smallestVal], currentArray[i]) = (currentArray[i], currentArray[smallestVal]);
                    }
                }
                else
                {
                    swapped.Add(new SortablePair(i, i, false));
                }
            }

            return swapped;
        }
    }
}