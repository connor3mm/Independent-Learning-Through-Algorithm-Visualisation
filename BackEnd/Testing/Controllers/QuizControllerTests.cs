using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Core.Services.Services;
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

    [Test]
    public void GenerateQuiz_ReturnsOkResult_WhenQuizGeneratedSuccessfully()
    {
        // Arrange
        _quizServiceMock.Setup(x => x.GenerateQuiz())
            .Returns(new List<QuizQuestionsDTO> { });

        // Act
        var result = _controller.GenerateQuiz() as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result.StatusCode);
    }

    [Test]
    public void GenerateQuiz_ReturnsBadRequest_WhenExceptionOccurs()
    {
        // Arrange
        _quizServiceMock.Setup(x => x.GenerateQuiz())
            .Throws(new Exception("Test error"));

        // Act
        var result = _controller.GenerateQuiz() as BadRequestObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result.StatusCode);
        Assert.AreEqual("An error occurred: Test error", result.Value);
    }
}