using System.Collections;
using API_University_Dissertation.Enums;
using API_University_Dissertation.Interfaces;

namespace API_University_Dissertation.Services;

public interface ISortingAlgorithmService
{
    IEnumerable<int[]> SortingAlgorithm(SortingStrategy sortingStrategy, int[] arr);
}

public class SortingAlgorithmService(IEnumerable<ISortingStrategy> strategies) : ISortingAlgorithmService
{
    public IEnumerable<int[]> SortingAlgorithm(SortingStrategy sortingStrategy, int[] arr)
    {
        var selectedStrategy = strategies.FirstOrDefault(strategy => strategy.GetType().Name == sortingStrategy.ToString());
        CheckValidStrategy(selectedStrategy);

        return selectedStrategy.Sort(arr);
    }

    private void CheckValidStrategy(ISortingStrategy selectedStrategy)
    {
        if (selectedStrategy == null)
        {
            throw new ArgumentException("Invalid strategy");
        }
    }
}