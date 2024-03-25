using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Application.Services.Services;
using API_University_Dissertation.Presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Testing.Controllers;

public class QuizControllerTests
{
    private QuizController _controller;
    private Mock<IQuizService> _quizServiceMock;
    private Mock<ILogger<QuizController>> _loggerMock;

    [SetUp]
    public void SetUp()
    {
        _quizServiceMock = new Mock<IQuizService>();
        _loggerMock = new Mock<ILogger<QuizController>>();
        _controller = new QuizController(_loggerMock.Object, _quizServiceMock.Object);
    }
    
    [TestCase(new[] { 1, 2, 3 })]
    [TestCase(new[] { -7, 2, 100 })]
    [TestCase(new[] { 91, 2, 3, 5 })]
    public void GenerateQuiz_ReturnsOkResult_WhenQuizGeneratedSuccessfully(int[] quizQuestionIds)
    {
        // Arrange
        int[] quizTypeIds = { 1, 2, 3 };
        _quizServiceMock.Setup(x => x.GenerateQuiz(quizQuestionIds))
            .Returns(new List<QuizQuestionsDTO>());

        // Act
        var result = _controller.GenerateQuiz(quizQuestionIds) as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result.StatusCode);
    }

    [Test]
    public void GenerateQuiz_ReturnsBadRequest_WhenExceptionOccurs()
    {
        // Arrange
        int[] quizTypeIds = { 1, 2, 3 };
        _quizServiceMock.Setup(x => x.GenerateQuiz(quizTypeIds))
            .Throws(new Exception("Test error"));

        // Act
        var result = _controller.GenerateQuiz(quizTypeIds) as BadRequestObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result.StatusCode);
        Assert.AreEqual("An error occurred: Test error", result.Value);
    }
}