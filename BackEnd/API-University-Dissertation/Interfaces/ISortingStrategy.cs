namespace API_University_Dissertation.Interfaces;

public interface  ISortingStrategy
{
    IEnumerable<int[]> Sort(int[] arr);
}