using System.Collections;

namespace API_University_Dissertation.Interfaces;

public interface  ISortingStrategy
{
    IEnumerable<int> Sort();
}