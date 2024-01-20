using API_University_Dissertation.Core.Services.Interfaces;

namespace API_University_Dissertation.Application.Strategies;

public class InsertionSort : ISortingStrategy
{
    public IEnumerable<int[]> Sort(int[] unsortedList)
    {
        var arrayLength = unsortedList.Length;
        var currentArray = new int[arrayLength];
        Array.Copy(unsortedList, currentArray, arrayLength);

        yield return currentArray;

        for (var i = 1; i < arrayLength; i++)
        {
            var key = currentArray[i];
            var j = i - 1;

            while (j >= 0 && currentArray[j] > key)
            {
                currentArray[j + 1] = currentArray[j];
                j--;

                var newState = new int[arrayLength];
                Array.Copy(currentArray, newState, arrayLength);
                yield return newState;
            }

            currentArray[j + 1] = key;
        }
    }
}