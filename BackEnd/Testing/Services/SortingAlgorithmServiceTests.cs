using API_University_Dissertation.Application.Strategies;
using API_University_Dissertation.Core.Data.Enums;
using API_University_Dissertation.Core.Services.Interfaces;
using API_University_Dissertation.Core.Services.Services;

namespace Testing.Services;

[TestFixture]
public class SortingAlgorithmServiceTests
{
    [TestCase(SortingStrategy.BubbleSort)]
    [TestCase(SortingStrategy.SelectionSort)]
    [TestCase(SortingStrategy.InsertionSort)]
    public void SortingAlgorithm_ValidStrategy_ReturnsSortedArray(SortingStrategy strategy)
    {
        var strategies = new List<ISortingStrategy> { new BubbleSort(), new SelectionSort(), new InsertionSort() };
        var sortingAlgorithmService = new SortingAlgorithmService(strategies);

        // Act
        var result = sortingAlgorithmService.SortingAlgorithm(strategy, new[] { 5, 2, 7, 1 });

        // Assert
        Assert.AreEqual(new[] { 1, 2, 5, 7} , result.Last());
    }

    [Test]
    public void SortingAlgorithm_InvalidStrategy_ThrowsArgumentException()
    {
        // Arrange
        var strategies = new List<ISortingStrategy>();
        var sortingAlgorithmService = new SortingAlgorithmService(strategies);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            sortingAlgorithmService.SortingAlgorithm((SortingStrategy)100, new int[0]);
        });
    }
}