using API_University_Dissertation.Interfaces;

namespace API_University_Dissertation.Strategies;

public class BubbleSort : ISortingStrategy
{
    public IEnumerable<int[]> Sort(int[] arr)
    {
        var n = arr.Length;
        var currentArray = new int[n];
        Array.Copy(arr, currentArray, n);

        yield return arr;

        for (var i = 0; i < n - 1; i++)
        {
            for (var j = 0; j < n - i - 1; j++)
            {
                if (currentArray[j] <= currentArray[j + 1]) continue;
                (currentArray[j], currentArray[j + 1]) = (currentArray[j + 1], currentArray[j]);

                var newState = new int[n];
                Array.Copy(currentArray, newState, n);
                yield return newState;
            }
        }
    }
}