using API_University_Dissertation.Core.Data.Entities;

namespace API_University_Dissertation.Application.Services.Interfaces;

public interface ISortingStrategy
{
    //Interface for strategy pattern
    IEnumerable<SortablePair> Sort(int[] unsortedList);
}