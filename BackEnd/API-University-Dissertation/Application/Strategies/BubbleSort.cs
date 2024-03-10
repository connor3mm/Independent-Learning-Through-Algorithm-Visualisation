using API_University_Dissertation.Core.Services.Interfaces;

namespace API_University_Dissertation.Application.Strategies;

public class BubbleSort : ISortingStrategy
{
    public IEnumerable<int[]> Sort(int[] unsortedList)
    {
        var arrayLength = unsortedList.Length;
        var currentArray = new int[arrayLength];
        var swapped = new List<MyObject>();
        Array.Copy(unsortedList, currentArray, arrayLength);

        yield return unsortedList;

        for (var i = 0; i < arrayLength - 1; i++)
        {
            for (var j = 0; j < arrayLength - i - 1; j++)
            {
                if (currentArray[j] <= currentArray[j + 1])
                {
                    var test = new MyObject{ Value1 = currentArray[j], Value2 = currentArray[j + 1], IsTrue = false };
                    swapped.Add(test);
                    continue;
                }
                var test2 = new MyObject{ Value1 = currentArray[j], Value2 = currentArray[j + 1], IsTrue = true };
                swapped.Add(test2);
                (currentArray[j], currentArray[j + 1]) = (currentArray[j + 1], currentArray[j]);

                var newState = new int[arrayLength];
                Array.Copy(currentArray, newState, arrayLength);
                yield return newState;
            }
        }

        Console.WriteLine(swapped);
    }
}

class MyObject
{
    public int Value1 { get; set; }
    public int Value2 { get; set; }
    public bool IsTrue { get; set; }

    // Parameterless constructor
    public MyObject()
    {
    }

    public MyObject(int value1, int value2, bool isTrue)
    {
        Value1 = value1;
        Value2 = value2;
        IsTrue = isTrue;
    }
}
