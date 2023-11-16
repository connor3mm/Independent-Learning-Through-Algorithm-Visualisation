using API_University_Dissertation.Interfaces;

namespace API_University_Dissertation.Strategies;

public class SelectionSort : ISortingStrategy
{
    public IEnumerable<int[]> Sort(int[] arr)
    {
        var arrayLength = arr.Length;
        var currentArray = new int[arrayLength];
        Array.Copy(arr, currentArray, arrayLength);
        yield return currentArray;

        for (var i = 0; i < arrayLength - 1; i++)
        {
            var smallestVal = i;
            for (var j = i + 1; j < arrayLength; j++)
            {
                if (currentArray[j] < currentArray[smallestVal])
                {
                    smallestVal = j;
                }
            }

            if (smallestVal == i) continue;
            (currentArray[smallestVal], currentArray[i]) = (currentArray[i], currentArray[smallestVal]);

            var newState = new int[arrayLength];
            Array.Copy(currentArray, newState, arrayLength);
            yield return newState;
        }
    }
}