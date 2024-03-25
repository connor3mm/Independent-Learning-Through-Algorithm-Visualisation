using API_University_Dissertation.Application.Services.Interfaces;
using API_University_Dissertation.Core.Data.Entities;

namespace API_University_Dissertation.Application.Strategies
{
    public class QuickSort : ISortingStrategy
    {
        private static Random rand = new Random();

        public IEnumerable<SortablePair> Sort(int[] unsortedList)
        {
            int[] arr = (int[])unsortedList.Clone();
            var swaps = new List<SortablePair> { new SortablePair(0, 0, true) };
            QuickSortAlgorithm(arr, 0, arr.Length - 1, swaps);

            return swaps;
        }

        private void QuickSortAlgorithm(int[] a, int low, int high, List<SortablePair> swaps)
        {
            if (low < high)
            {
                int randomIndex = rand.Next(low, high + 1);
                Swap(a, low, randomIndex, swaps);

                int pivotIndex = Partition(a, low, high, swaps);

                QuickSortAlgorithm(a, low, pivotIndex - 1, swaps);
                QuickSortAlgorithm(a, pivotIndex + 1, high, swaps);
            }
        }

        private int Partition(int[] a, int low, int high, List<SortablePair> swaps)
        {
            int pivot = a[low];
            int k = low;

            for (int i = low + 1; i <= high; i++)
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
            if (i != j)
            {
                int temp = a[i];
                a[i] = a[j];
                a[j] = temp;

                swaps.Add(new SortablePair(i, j, true));
            }
            else
            {
                swaps.Add(new SortablePair(i, j, false));
            }
        }
    }
}