using API_University_Dissertation.Application.Services.Interfaces;
using API_University_Dissertation.Core.Data.Entities;

namespace API_University_Dissertation.Application.Strategies
{
    /// <summary>
    /// Represents a sorting strategy using the Quick Sort algorithm.
    /// </summary>
    public class QuickSort : ISortingStrategy
    {
        private static readonly Random Rand = new Random();

        public IEnumerable<SortablePair> Sort(int[] unsortedList)
        {
            //Initialise variables
            var arr = (int[])unsortedList.Clone();
            var swaps = new List<SortablePair> { new SortablePair(0, 0, true) };
            QuickSortAlgorithm(arr, 0, arr.Length - 1, swaps);

            return swaps;
        }

        private void QuickSortAlgorithm(int[] a, int low, int high, List<SortablePair> swaps)
        {
            if (low < high)
            {
                // Choose a random pivot element
                var randomIndex = Rand.Next(low, high + 1);
                Swap(a, low, randomIndex, swaps);

                var pivotIndex = Partition(a, low, high, swaps);

                QuickSortAlgorithm(a, low, pivotIndex - 1, swaps);
                QuickSortAlgorithm(a, pivotIndex + 1, high, swaps);
            }
        }

        private int Partition(int[] a, int low, int high, List<SortablePair> swaps)
        {
            var pivot = a[low];
            var k = low;

            // Rearrange elements around the pivot
            for (var i = low + 1; i <= high; i++)
            {
                if (a[i] < pivot)
                {
                    k++;
                    Swap(a, k, i, swaps);
                }
            }

            Swap(a, low, k, swaps);

            return k;
        }

        private void Swap(int[] a, int i, int j, List<SortablePair> swaps)
        {
            // Swap elements if they are not already in the correct position
            if (i != j)
            {
                int temp = a[i];
                a[i] = a[j];
                a[j] = temp;

                swaps.Add(new SortablePair(i, j, true));// Indicate a swap
            }
            else
            {
                swaps.Add(new SortablePair(i, j, false));// Indicate a swap
            }
        }
    }
}