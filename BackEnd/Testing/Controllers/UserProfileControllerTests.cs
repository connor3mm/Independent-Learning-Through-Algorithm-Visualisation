using System.Security.Claims;
using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Application.Services.Services;
using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Presentation.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Testing.Controllers;

[TestFixture]
public class UserProfileControllerTests
{
    private UserProfileController _controller;
    private Mock<IUserProfileService> _mockProfileService;
    private Mock<ILogger<UserProfileController>> _mockLogger;

    [SetUp]
    public void Setup()
    {
        _mockProfileService = new Mock<IUserProfileService>();
        _mockLogger = new Mock<ILogger<UserProfileController>>();
        _controller = new UserProfileController(_mockLogger.Object, _mockProfileService.Object);
    }


    private void SetupControllerContext(IEnumerable<Claim> claims)
    {
        var identity = new ClaimsIdentity(claims, "TestAuthType");
        var user = new ClaimsPrincipal(identity);

        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };
    }

    [Test]
    public void Profile_ReturnsOkObjectResult_WithValidData()
    {
        // Arrange
        var userEmail = "test@example.com";
        var userUuid = "123456";
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, userEmail),
            new Claim(ClaimTypes.NameIdentifier, userUuid),
        };

        SetupControllerContext(claims);

        var expectedData =
            new UserProfileDto { Email = userEmail };

        _mockProfileService.Setup(x => x.GetRecordByUuid(userUuid, userEmail)).Returns(expectedData);

        // Act
        var result = _controller.Profile() as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result?.StatusCode);
        Assert.AreEqual(expectedData, result?.Value);
    }

    [Test]
    public void Profile_ReturnsBadRequest_WhenExceptionOccurs()
    {
        var userEmail = "test@example.com";
        var userUuid = "123456";
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, userEmail),
            new Claim(ClaimTypes.NameIdentifier, userUuid),
        };

        SetupControllerContext(claims);

        _mockProfileService.Setup(x => x.GetRecordByUuid(userUuid, userEmail)).Throws(new Exception("Test error"));

        // Act
        var result = _controller.Profile() as BadRequestObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result?.StatusCode);
        Assert.AreEqual("An error occurred: Test error", result?.Value);
    }

    [Test]
    public void Profile_ReturnsBadRequest_WhenUserClaimsAreMissing()
    {
        // Arrange
        var claims = new Claim[] { };
        SetupControllerContext(claims);

        // Act
        var result = _controller.Profile() as BadRequestResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result?.StatusCode);
        _mockProfileService.Verify(x => x.GetRecordByUuid(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
    }

    [Test]
    public void SaveProfile_ReturnsOkResult_WhenProfileAddedSuccessfully()
    {
        // Arrange
        var userProfileDto = new UserProfileDto
        {
            ID = 1,
            Email = "tester@gmail.com",
            FirstName = "Test",
            LastName = "Test",
            ProficiencyLevelId = 1,
        };

        _mockProfileService.Setup(x => x.AddNewProfile(userProfileDto));

        // Act
        var result = _controller.SaveProfile(userProfileDto) as OkResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result?.StatusCode);
    }

    [Test]
    public void SaveProfile_ReturnsBadRequest_WhenExceptionOccurs()
    {
        // Arrange
        var userProfileDto = new UserProfileDto
        {
            ID = 1,
            Email = "tester@gmail.com",
            FirstName = "Test",
            LastName = "Test",
            ProficiencyLevelId = 1,
        };

        _mockProfileService.Setup(x => x.AddNewProfile(userProfileDto)).Throws(new Exception("Test error"));

        // Act
        var result = _controller.SaveProfile(userProfileDto) as BadRequestObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result?.StatusCode);
        Assert.AreEqual("An error occurred: Test error", result.Value);
    }

    [Test]
    public void UpdateProficiency_ReturnsOkResult_WhenProficiencyUpdatedSuccessfully()
    {
        // Arrange
        var proficiencyLevel = 1;

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "userUuid")
        };
        var proficiencyUpdateDto = new ProficiencyUpdateDto { Email = "test", ProficiencyLevelId = proficiencyLevel };

        SetupControllerContext(claims);

        _mockProfileService.Setup(x => x.UpdateProficiency(proficiencyLevel, "userUuid"));

        // Act
        var result = _controller.UpdateProficiency(proficiencyUpdateDto) as OkResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result?.StatusCode);
    }

    [Test]
    public void UpdateProficiency_ReturnsBadRequest_WhenExceptionOccurs()
    {
        // Arrange
        const int proficiencyLevel = 1;

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "userUuid")
        };
        var proficiencyUpdateDto = new ProficiencyUpdateDto
            { Email = "userUuid", ProficiencyLevelId = proficiencyLevel };
        SetupControllerContext(claims);

        _mockProfileService.Setup(x => x.UpdateProficiency(proficiencyLevel, "userUuid"))
            .Throws(new Exception("Test error"));

        // Act
        var result = _controller.UpdateProficiency(proficiencyUpdateDto) as BadRequestObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result?.StatusCode);
        Assert.AreEqual("An error occurred: Test error", result?.Value);
    }

    [Test]
    public void SaveUserStatistics_ReturnsOkResult_WhenStatisticsSavedSuccessfully()
    {
        // Arrange
        var userQuizStatistics = new UserQuizStatisticsDto
        {
            Score = 0,
            QuizLength = 0
        };

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "userUuid")
        };
        SetupControllerContext(claims);

        _mockProfileService.Setup(x => x.SaveUserStatistics(userQuizStatistics, "userUuid"));

        // Act
        var result = _controller.SaveUserStatistics(userQuizStatistics) as OkResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result?.StatusCode);
    }

    [Test]
    public void SaveUserStatistics_ReturnsBadRequest_WhenUserUuidIsMissing()
    {
        // Arrange
        var claims = new Claim[] { };
        SetupControllerContext(claims);

        var userQuizStatistics = new UserQuizStatisticsDto
        {
            Score = 0,
            QuizLength = 0
        };

        // Act
        var result = _controller.SaveUserStatistics(userQuizStatistics) as BadRequestResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result?.StatusCode);
    }

    [Test]
    public void SaveUserStatistics_ReturnsBadRequest_WhenExceptionOccurs()
    {
        // Arrange
        var userQuizStatistics = new UserQuizStatisticsDto
        {
            Score = 0,
            QuizLength = 0
        };

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "userUuid")
        };
        SetupControllerContext(claims);

        _mockProfileService.Setup(x => x.SaveUserStatistics(userQuizStatistics, "userUuid"))
            .Throws(new Exception("Test error"));

        // Act
        var result = _controller.SaveUserStatistics(userQuizStatistics) as BadRequestObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result?.StatusCode);
        Assert.AreEqual("An error occurred: Test error", result.Value);
    }

    [Test]
    public void UserStatistics_ReturnsOkResult_WhenStatisticsRetrievedSuccessfully()
    {
        // Arrange
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "userUuid")
        };
        SetupControllerContext(claims);

        _mockProfileService.Setup(x => x.GetUserStatistics("userUuid"))
            .Returns(new ProfileStatisticsDto { });

        // Act
        var result = _controller.UserStatistics() as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result?.StatusCode);
    }

    [Test]
    public void UserStatistics_ReturnsBadRequest_WhenUserUuidIsMissing()
    {
        // Arrange
        var claims = new Claim[] { };
        SetupControllerContext(claims);

        // Act
        var result = _controller.UserStatistics() as BadRequestResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result?.StatusCode);
    }

    [Test]
    public void UserStatistics_ReturnsBadRequest_WhenExceptionOccurs()
    {
        // Arrange
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "userUuid")
        };
        SetupControllerContext(claims);

        _mockProfileService.Setup(x => x.GetUserStatistics("userUuid"))
            .Throws(new Exception("Test error"));

        // Act
        var result = _controller.UserStatistics() as BadRequestObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result?.StatusCode);
        Assert.AreEqual("An error occurred: Test error", result?.Value);
    }

    [Test]
    public void LastFiveGamesStatistics_ReturnsOkResult_WhenStatisticsRetrievedSuccessfully()
    {
        // Arrange
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "userUuid")
        };
        SetupControllerContext(claims);

        _mockProfileService.Setup(x => x.GetLastFiveGamesStatistics("userUuid"))
            .Returns(new List<UserQuizStatistics> { });

        // Act
        var result = _controller.LastFiveGamesStatistics() as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(200, result?.StatusCode);
    }

    [Test]
    public void LastFiveGamesStatistics_ReturnsBadRequest_WhenUserUuidIsMissing()
    {
        // Arrange
        var claims = new Claim[] { };
        SetupControllerContext(claims);

        // Act
        var result = _controller.LastFiveGamesStatistics() as BadRequestResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result?.StatusCode);
    }

    [Test]
    public void LastFiveGamesStatistics_ReturnsBadRequest_WhenExceptionOccurs()
    {
        // Arrange
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "userUuid")
        };
        SetupControllerContext(claims);

        _mockProfileService.Setup(x => x.GetLastFiveGamesStatistics("userUuid"))
            .Throws(new Exception("Test error"));

        // Act
        var result = _controller.LastFiveGamesStatistics() as BadRequestObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(400, result?.StatusCode);
        Assert.AreEqual("An error occurred: Test error", result?.Value);
    }
}