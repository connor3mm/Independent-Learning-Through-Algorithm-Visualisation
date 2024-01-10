using API_University_Dissertation.Core.Data.Enums;
using API_University_Dissertation.Core.Services.Services;
using API_University_Dissertation.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Testing.Controllers
{
    [TestFixture]
    public class SortingAlgorithmControllerTests
    {
        private SortingAlgorithmController _controller;
        private Mock<ISortingAlgorithmService> _sortingServiceMock;
        private Mock<ILogger<SortingAlgorithmController>> _loggerMock;

        [SetUp]
        public void SetUp()
        {
            _sortingServiceMock = new Mock<ISortingAlgorithmService>();
            _loggerMock = new Mock<ILogger<SortingAlgorithmController>>();
            _controller = new SortingAlgorithmController(_loggerMock.Object, _sortingServiceMock.Object);
        }

        [Test]
        public void BubbleSort_ValidInput_ReturnsOk()
        {
            // Arrange
            var inputArray = new[] { 9, 5, 2, 7, 1 };
            var sortedArray = new[] { 1, 2, 5, 7, 9 };

            _sortingServiceMock
                .Setup(x => x.SortingAlgorithm(SortingStrategy.BubbleSort, inputArray))
                .Returns(new[] { sortedArray });
            
            // Act
            var result = _controller.BubbleSort(inputArray) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result?.StatusCode);
        }

        [Test]
        public void BubbleSort_WithException_ReturnsBadRequest()
        {
            // Arrange
            _sortingServiceMock.Setup(x => x.SortingAlgorithm(SortingStrategy.BubbleSort, It.IsAny<int[]>()))
                .Throws(new Exception("Test Exception"));

            // Act
            var result = _controller.BubbleSort(Array.Empty<int>());

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual("An error occurred: Test Exception", badRequestResult?.Value);
        }

        [Test]
        public void SelectionSort_ValidInput_ReturnsOk()
        {
            // Arrange
            var inputArray = new[] { 9, 5, 2, 7, 1 };
            var sortedArray = new[] { 1, 2, 5, 7, 9 };
            _sortingServiceMock.Setup(x => x.SortingAlgorithm(SortingStrategy.SelectionSort, inputArray))
                .Returns(new[] { sortedArray });

            // Act
            var result = _controller.SelectionSort(inputArray) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result?.StatusCode);
            Assert.IsInstanceOf<int[][]>(result?.Value);
        }

        [Test]
        public void SelectionSort_WithException_ReturnsBadRequest()
        {
            // Arrange
            _sortingServiceMock.Setup(x => x.SortingAlgorithm(SortingStrategy.SelectionSort, It.IsAny<int[]>()))
                .Throws(new Exception("Test Exception"));

            // Act
            var result = _controller.SelectionSort(Array.Empty<int>());

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual("An error occurred: Test Exception", badRequestResult?.Value);
        }
    }
}