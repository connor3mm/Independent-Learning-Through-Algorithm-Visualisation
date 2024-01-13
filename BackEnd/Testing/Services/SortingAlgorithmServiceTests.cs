// using API_University_Dissertation.Application.Strategies;
// using Moq;
//
// namespace Testing.Services;
//
// [TestFixture]
// public class SortingAlgorithmService
// {
//     
//     private SortingAlgorithmService _service;
//     private Mock<BubbleSort> _sortingStrategyMock;
//     [SetUp]
//     public void SetUp()
//     {
//         _sortingStrategyMock = new Mock<BubbleSort>();
//         _service = new SortingAlgorithmService();
//     }
//     
//     [Test]
//     public void BubbleSort_ValidInput_Returns_Sorted_List()
//     {
//         // Arrange
//         var inputArray = new[] { 9, 5, 2, 7, 1 };
//         var sortedArray = new[] { 1, 2, 5, 7, 9 };
//
//         _service.
//             
//         // Act
//         var result = _controller.BubbleSort(inputArray) as ObjectResult;
//
//         // Assert
//         Assert.IsNotNull(result);
//         Assert.AreEqual(200, result?.StatusCode);
//     }
// }