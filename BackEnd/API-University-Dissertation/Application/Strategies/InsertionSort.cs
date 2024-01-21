using System;
using System.Collections.Generic;
using API_University_Dissertation.Core.Services.Interfaces;

namespace API_University_Dissertation.Application.Strategies
{
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
                var flag = 0;
                for (var j = i - 1; j >= 0 && flag != 1;)
                {
                    if (key < currentArray[j])
                    {
                        currentArray[j + 1] = currentArray[j];
                        j--;
                        currentArray[j + 1] = key;

                        var newState = new int[arrayLength];
                        Array.Copy(currentArray, newState, arrayLength);
                        yield return newState;
                    }
                    else flag = 1;
                }
            }
        }
    }
}