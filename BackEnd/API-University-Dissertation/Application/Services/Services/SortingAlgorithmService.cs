using API_University_Dissertation.Application.Services.Interfaces;
using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Core.Data.Enums;

namespace API_University_Dissertation.Application.Services.Services;

public interface ISortingAlgorithmService
{
    IEnumerable<SortablePair> SortingAlgorithm(SortingStrategy sortingStrategy, int[] arr);
}

public class SortingAlgorithmService(IEnumerable<ISortingStrategy> strategies) : ISortingAlgorithmService
{
    //Strategy Pattern used for sorting algorithm family
    public IEnumerable<SortablePair> SortingAlgorithm(SortingStrategy sortingStrategy, int[] arr)
    {
        //Selecting sorting algorithm compared to the program injected classes
        var selectedStrategy =
            strategies.FirstOrDefault(strategy => strategy.GetType().Name == sortingStrategy.ToString());
        
        if (selectedStrategy == null)
        {
            throw new ArgumentException("Invalid strategy");
        }
        //Call the strategy
        return selectedStrategy.Sort(arr);
    }
}