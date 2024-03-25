using API_University_Dissertation.Core.Data.Entities;

namespace API_University_Dissertation.Application.Services.Interfaces;

public interface ISortingStrategy
{
    IEnumerable<SortablePair> Sort(int[] unsortedList);
}