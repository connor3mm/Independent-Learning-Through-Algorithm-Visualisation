namespace API_University_Dissertation.Core.Services.Interfaces;

public interface  ISortingStrategy
{
    IEnumerable<int[]> Sort(int[] unsortedList);
}