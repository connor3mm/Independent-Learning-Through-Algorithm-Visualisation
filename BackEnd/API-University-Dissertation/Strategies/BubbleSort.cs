using API_University_Dissertation.Interfaces;

namespace API_University_Dissertation.Strategies;

public class BubbleSort : ISortingStrategy
{
    public IEnumerable<int[]> Sort(int[] unsortedList)
    {
        var arrayLength = unsortedList.Length;
        var currentArray = new int[arrayLength];
        Array.Copy(unsortedList, currentArray, arrayLength);

        yield return unsortedList;

        for (var i = 0; i < arrayLength - 1; i++)
        {
            for (var j = 0; j < arrayLength - i - 1; j++)
            {
                if (currentArray[j] <= currentArray[j + 1]) continue;
                (currentArray[j], currentArray[j + 1]) = (currentArray[j + 1], currentArray[j]);

                var newState = new int[arrayLength];
                Array.Copy(currentArray, newState, arrayLength);
                yield return newState;
            }
        }
    }
}