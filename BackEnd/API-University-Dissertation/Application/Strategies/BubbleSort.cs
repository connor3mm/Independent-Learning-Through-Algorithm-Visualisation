using API_University_Dissertation.Application.Services.Interfaces;
using API_University_Dissertation.Core.Data.Entities;

namespace API_University_Dissertation.Application.Strategies;

/// <summary>
/// Represents a sorting strategy using the Bubble Sort algorithm.
/// </summary>
public class BubbleSort : ISortingStrategy
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
            for (var j = 0; j < arrayLength - i - 1; j++)
            {
                if (currentArray[j] <= currentArray[j + 1])
                {
                    var swappablePair = new SortablePair(j, j + 1, false);
                    swapped.Add(swappablePair);// Indicate a swap
                    continue;
                }

                var secondSwappablePair = new SortablePair
                    (j, j + 1, true);
                swapped.Add(secondSwappablePair);// Indicate a swap
                (currentArray[j], currentArray[j + 1]) = (currentArray[j + 1], currentArray[j]);

                var newState = new int[arrayLength];
                Array.Copy(currentArray, newState, arrayLength); //copy array for next iterartion
            }
        }

        return swapped;
    }
}