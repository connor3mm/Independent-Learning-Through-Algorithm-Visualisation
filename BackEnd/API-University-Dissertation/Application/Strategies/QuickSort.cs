using API_University_Dissertation.Core.Services.Interfaces;
namespace API_University_Dissertation.Application.Strategies;

public class QuickSort : ISortingStrategy
{
    private static Random rand = new Random();

    public IEnumerable<int[]> Sort(int[] unsortedList)
    {
        // Clone the array to avoid modifying the original array
        int[] arr = (int[])unsortedList.Clone();
        List<int[]> steps = new List<int[]>();

        // Include the initial unsorted array in the steps
        steps.Add((int[])arr.Clone());

        QuickSortAlgorithm(arr, 0, arr.Length - 1, steps);

        // Include the final sorted array in the steps
       
        
        HashSet<int[]> hashSet = new HashSet<int[]>(steps);

        return hashSet;
    }

    private void QuickSortAlgorithm(int[] a, int low, int high, List<int[]> steps)
    {
        if (low < high)
        {
            // Choose random pivot and swap with the first element
            int randomIndex = rand.Next(low, high + 1);
            Swap(a, low, randomIndex, steps);

            // 2-way partition
            int pivotIndex = Partition(a, low, high, steps);

            // Recursive sorts
            QuickSortAlgorithm(a, low, pivotIndex - 1, steps);
            QuickSortAlgorithm(a, pivotIndex + 1, high, steps);
        }
    }

    private int Partition(int[] a, int low, int high, List<int[]> steps)
    {
        int pivot = a[low];
        int k = low;

        for (int i = low + 1; i <= high; i++)
        {
            if (a[i] < pivot)
            {
                k++;
                Swap(a, k, i, steps);
            }
        }

        Swap(a, low, k, steps);

        return k;
    }

    private void Swap(int[] a, int i, int j, List<int[]> steps)
    {
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;

        // Include the current step in the list of steps
        if (!ArraysEqual(steps[steps.Count - 1], a))
        {
            steps.Add((int[])a.Clone());
        }
    }

    private bool ArraysEqual(int[] arr1, int[] arr2)
    {
        if (arr1.Length != arr2.Length)
        {
            return false;
        }

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
            {
                return false;
            }
        }

        return true;
    }
}