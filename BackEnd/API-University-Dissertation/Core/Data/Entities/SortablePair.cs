namespace API_University_Dissertation.Core.Data.Entities;

public class SortablePair
{
    public int FirstValue { get; set; }
    public int SecondValue { get; set; }
    public bool HasSwapped { get; set; }

    public SortablePair(int firstValue, int secondValue, bool hasSwapped)
    {
        FirstValue = firstValue;
        SecondValue = secondValue;
        HasSwapped = hasSwapped;
    }
}