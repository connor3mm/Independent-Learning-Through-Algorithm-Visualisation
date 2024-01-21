using API_University_Dissertation.Core.Data.Enums;
using API_University_Dissertation.Core.Services.Interfaces;

namespace API_University_Dissertation.Core.Services.Services;

public interface ISortingAlgorithmService
{
    IEnumerable<int[]> SortingAlgorithm(SortingStrategy sortingStrategy, int[] arr);
}

public class SortingAlgorithmService(IEnumerable<ISortingStrategy> strategies) : ISortingAlgorithmService
{
    public IEnumerable<int[]> SortingAlgorithm(SortingStrategy sortingStrategy, int[] arr)
    {
        var selectedStrategy =
            strategies.FirstOrDefault(strategy => strategy.GetType().Name == sortingStrategy.ToString());
        
        if (selectedStrategy == null)
        {
            throw new ArgumentException("Invalid strategy");
        }
        
        return selectedStrategy.Sort(arr);
    }
}