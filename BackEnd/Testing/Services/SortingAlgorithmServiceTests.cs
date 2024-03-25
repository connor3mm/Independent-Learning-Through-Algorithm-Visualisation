using API_University_Dissertation.Application.Services.Interfaces;
using API_University_Dissertation.Application.Services.Services;
using API_University_Dissertation.Core.Data.Enums;
using API_University_Dissertation.Application.Strategies;
using API_University_Dissertation.Core.Data.Entities;

namespace Testing.Services
{
    [TestFixture]
    public class SortingAlgorithmServiceTests
    {
        [TestCase(SortingStrategy.BubbleSort)]
        public void BubbleSort_ValidStrategy_ReturnsSortedArray(SortingStrategy strategy)
        {
            // Arrange
            var strategies = new List<ISortingStrategy> { new BubbleSort() };
            var sortingAlgorithmService = new SortingAlgorithmService(strategies);
            var inputArray = new[] { 5, 2, 7, 1 };
            const int count = 6;

            // Act
            var result = sortingAlgorithmService.SortingAlgorithm(strategy, inputArray);

            // Assert
            Assert.AreEqual(count, result.Count());
        }

        [TestCase(SortingStrategy.SelectionSort)]
        public void SelectionSort_ValidStrategy_ReturnsSortedArray(SortingStrategy strategy)
        {
            // Arrange
            var strategies = new List<ISortingStrategy> { new SelectionSort() };
            var sortingAlgorithmService = new SortingAlgorithmService(strategies);
            var inputArray = new[] { 5, 2, 7, 1 };

            // Act
            var result = sortingAlgorithmService.SortingAlgorithm(strategy, inputArray);

            // Assert
            Assert.AreEqual(inputArray.Length - 1, result.Count()); // Ensure the correct number of pairs
            foreach (var pair in result)
            {
                Assert.That(pair.FirstValue <= pair.SecondValue); // Ensure the pairs are sorted
            }
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

        [Test]
        public void SortingAlgorithm_NullStrategies_ThrowsArgumentNullException()
        {
            // Arrange
            List<ISortingStrategy> strategies = null;
            var sortingAlgorithmService = new SortingAlgorithmService(strategies);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                sortingAlgorithmService.SortingAlgorithm(SortingStrategy.BubbleSort, new int[0]);
            });
        }

        [Test]
        public void SortingAlgorithm_NullInputArray_ThrowsArgumentException()
        {
            // Arrange
            var strategies = new List<ISortingStrategy>();
            var sortingAlgorithmService = new SortingAlgorithmService(strategies);

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                sortingAlgorithmService.SortingAlgorithm(SortingStrategy.BubbleSort, null);
            });
        }

        [TestCase(SortingStrategy.ShellSort)]
        public void ShellSort_ValidStrategy_ReturnsSortedArray(SortingStrategy strategy)
        {
            // Arrange
            var strategies = new List<ISortingStrategy> { new ShellSort() };
            var sortingAlgorithmService = new SortingAlgorithmService(strategies);
            var inputArray = new[] { 5, 2, 7, 1 };
            const int count = 6;

            // Act
            var result = sortingAlgorithmService.SortingAlgorithm(strategy, inputArray);

            // Assert
            Assert.AreEqual(count, result.Count());
        }

        [TestCase(SortingStrategy.QuickSort)]
        public void QuickSort_ValidStrategy_ReturnsSortedArray(SortingStrategy strategy)
        {
            // Arrange
            var strategies = new List<ISortingStrategy> { new QuickSort() };
            var sortingAlgorithmService = new SortingAlgorithmService(strategies);
            var inputArray = new[] { 5, 2, 2, 9, 10, 23, 11, 7, 1 };
            var expectedArray = new[] { 1, 2, 2, 5, 7, 9, 10, 11, 23, };

            // Act
            var swaps = sortingAlgorithmService.SortingAlgorithm(strategy, inputArray).ToList();

            // Assert
            foreach (var swap in swaps)
            {
                var temp = inputArray[swap.FirstValue];
                if (!swap.HasSwapped) continue;
                inputArray[swap.FirstValue] = inputArray[swap.SecondValue];
                inputArray[swap.SecondValue] = temp;
            }

            CollectionAssert.AreEqual(expectedArray, inputArray);
        }

        [Test]
        public void Sort_ReturnsEmptyList_WhenGivenEmptyArray()
        {
            var inputArray = new[] { 1, 2 };
            var strategies = new List<ISortingStrategy> { new InsertionSort() };
            var sortingAlgorithmService = new SortingAlgorithmService(strategies);
            var result = sortingAlgorithmService.SortingAlgorithm(SortingStrategy.InsertionSort, inputArray);

            Assert.IsEmpty(result);
        }

        [Test]
        public void Sort_ReturnsSortedList_WhenGivenUnsortedArray()
        {
            var strategies = new List<ISortingStrategy> { new InsertionSort() };
            var sortingAlgorithmService = new SortingAlgorithmService(strategies);
            var unsortedList = new int[] { 3, 1, 4, 1, 5, 9, 2, 6 };
            var expectedResult = new List<SortablePair>
            {
                new SortablePair(0, 1, true),
                new SortablePair(2, 3, true),
                new SortablePair(1, 2, true),
                new SortablePair(5, 6, true),
                new SortablePair(4, 5, true),
                new SortablePair(3, 4, true),
                new SortablePair(2, 3, true),
                new SortablePair(6, 7, true)
            };

            var result = sortingAlgorithmService.SortingAlgorithm(SortingStrategy.InsertionSort, unsortedList).ToList();

            Assert.AreEqual(expectedResult.Count, result.Count());
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].FirstValue, result[i].FirstValue);
                Assert.AreEqual(expectedResult[i].SecondValue, result[i].SecondValue);
                Assert.AreEqual(expectedResult[i].HasSwapped, result[i].HasSwapped);
            }
        }
    }
}