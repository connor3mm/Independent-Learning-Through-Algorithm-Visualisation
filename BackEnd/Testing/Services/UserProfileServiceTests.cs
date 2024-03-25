using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Application.Services.Services;
using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Core.Repositories;
using AutoMapper;
using Moq;
using ProficiencyLevel = API_University_Dissertation.Core.Data.Enums.ProficiencyLevel;

namespace Testing.Services
{
    [TestFixture]
    public class UserProfileServiceTests
    {
        private Mock<IUserProfileRepository> _userProfileRepositoryMock;
        private Mock<IAspNetUserRepository> _aspNetUserRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private const string userUuid = "user_uuid";

        private IUserProfileService _userProfileService;

        [SetUp]
        public void Setup()
        {
            _userProfileRepositoryMock = new Mock<IUserProfileRepository>();
            _aspNetUserRepositoryMock = new Mock<IAspNetUserRepository>();
            _mapperMock = new Mock<IMapper>();

            _userProfileService = new UserProfileService(
                _userProfileRepositoryMock.Object,
                _aspNetUserRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Test]
        public void AddNewProfile_ShouldAddUserProfileToRepository()
        {
            // Arrange
            var userProfileDto = new UserProfileDto { Email = "tester@gmail.com" };

            _aspNetUserRepositoryMock.Setup(repo => repo.GetByEmail(userProfileDto.Email))
                .Returns(userUuid);

            _mapperMock.Setup(mapper => mapper.Map<UserProfile>(It.IsAny<UserProfileDto>()))
                .Returns((UserProfileDto dto) => new UserProfile
                {
                    UserUUID = userUuid
                });

            // Act
            _userProfileService.AddNewProfile(userProfileDto);

            // Assert
            _userProfileRepositoryMock.Verify(repo => repo.Add(It.IsAny<UserProfile>()), Times.Once);
        }

        [Test]
        public void GetRecordByUuid_ShouldReturnUserProfileDto()
        {
            // Arrange
            var email = "user@example.com";

            _userProfileRepositoryMock.Setup(repo => repo.GetByUuid(userUuid))
                .Returns(new UserProfile());

            _mapperMock.Setup(mapper => mapper.Map<UserProfileDto>(It.IsAny<UserProfile>()))
                .Returns((UserProfile userProfile) => new UserProfileDto()
                {
                    Email = email,
                });

            // Act
            var result = _userProfileService.GetRecordByUuid(userUuid, email);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(email, result.Email);
        }


        [Test]
        public void UpdateProficiency_ShouldThrowException_WhenUserEmailNotFound()
        {
            // Arrange
            var userEmail = "nonexistent@example.com";
            _aspNetUserRepositoryMock.Setup(repo => repo.GetByEmail(userEmail))
                .Returns((string)null);

            // Act & Assert
            Assert.Throws<Exception>(() => _userProfileService.UpdateProficiency(2, userEmail));
        }

        [Test]
        public void SaveUserStatistics_ShouldUpdateProficiencyLevel_WhenProficiencyLevelIsUndetermined()
        {
            // Arrange
            var userQuizStatisticsDto = new UserQuizStatisticsDto { Score = 0, QuizLength = 10 };
            var userProfile = new UserProfile { ProficiencyLevelId = (int)ProficiencyLevel.Undetermined };
            _userProfileRepositoryMock.Setup(repo => repo.GetByUuid(userUuid)).Returns(userProfile);

            // Act
            _userProfileService.SaveUserStatistics(userQuizStatisticsDto, userUuid);

            // Assert
            Assert.AreEqual((int)ProficiencyLevel.Beginner, userProfile.ProficiencyLevelId);
        }

        [Test]
        public void SaveUserStatistics_ShouldUpdateProficiencyLevel_WhenProficiencyScoreIs50()
        {
            // Arrange
            var userQuizStatisticsDto = new UserQuizStatisticsDto { Score = 50, QuizLength = 10 };
            var userProfile = new UserProfile { ProficiencyLevelId = (int)ProficiencyLevel.Undetermined };
            _userProfileRepositoryMock.Setup(repo => repo.GetByUuid(userUuid)).Returns(userProfile);

            // Act
            _userProfileService.SaveUserStatistics(userQuizStatisticsDto, userUuid);

            // Assert
            Assert.AreEqual((int)ProficiencyLevel.Intermediate, userProfile.ProficiencyLevelId);
        }

        [Test]
        public void SaveUserStatistics_ShouldNotUpdateProficiencyLevel_WhenProficiencyLevelIsExpert()
        {
            // Arrange
            var userQuizStatisticsDto = new UserQuizStatisticsDto { Score = 50, QuizLength = 10 };
            var userProfile = new UserProfile { ProficiencyLevelId = (int)ProficiencyLevel.Expert };
            _userProfileRepositoryMock.Setup(repo => repo.GetByUuid(userUuid)).Returns(userProfile);

            // Act
            _userProfileService.SaveUserStatistics(userQuizStatisticsDto, userUuid);

            // Assert
            Assert.AreEqual((int)ProficiencyLevel.Expert, userProfile.ProficiencyLevelId);
        }

        [Test]
        public void GetUserStatistics_ShouldReturnCorrectStatistics()
        {
            // Arrange

            var userProfile = new UserProfile
            {
                UserQuizStatistics = new List<UserQuizStatistics>
                {
                    new UserQuizStatistics { Score = 70, QuizLength = 10 },
                    new UserQuizStatistics { Score = 80, QuizLength = 10 },
                    new UserQuizStatistics { Score = 90, QuizLength = 10 }
                }
            };
            _userProfileRepositoryMock.Setup(repo => repo.GetByUuid(userUuid)).Returns(userProfile);

            // Act
            var result = _userProfileService.GetUserStatistics(userUuid);

            // Assert
            Assert.AreEqual(3, result.GamesPlayed);
            Assert.AreEqual(240, result.TotalScore);
            Assert.AreEqual(30, result.TotalQuestions);
            Assert.AreEqual(80, result.AverageScore);
            Assert.AreEqual(0, result.ProficiencyScore);
        }

        [Test]
        public void GetLastFiveGamesStatistics_ShouldReturnLastFiveStatistics_WhenMoreThanFiveStatisticsExist()
        {
            // Arrange
            var userProfile = new UserProfile
            {
                UserQuizStatistics = new List<UserQuizStatistics>
                {
                    new UserQuizStatistics { Score = 70, QuizLength = 10, CreatedOn = DateTime.UtcNow.AddDays(-10) },
                    new UserQuizStatistics { Score = 80, QuizLength = 10, CreatedOn = DateTime.UtcNow.AddDays(-9) },
                    new UserQuizStatistics { Score = 90, QuizLength = 10, CreatedOn = DateTime.UtcNow.AddDays(-8) },
                    new UserQuizStatistics { Score = 100, QuizLength = 10, CreatedOn = DateTime.UtcNow.AddDays(-7) },
                    new UserQuizStatistics { Score = 110, QuizLength = 10, CreatedOn = DateTime.UtcNow.AddDays(-6) },
                    new UserQuizStatistics { Score = 120, QuizLength = 10, CreatedOn = DateTime.UtcNow.AddDays(-5) },
                    new UserQuizStatistics { Score = 130, QuizLength = 10, CreatedOn = DateTime.UtcNow.AddDays(-4) }
                }
            };
            _userProfileRepositoryMock.Setup(repo => repo.GetByUuid(userUuid)).Returns(userProfile);

            // Act
            var result = _userProfileService.GetLastFiveGamesStatistics(userUuid);

            // Assert
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual(90, result.First().Score);
            Assert.AreEqual(130, result.Last().Score);
        }

        [Test]
        public void GetLastFiveGamesStatistics_ShouldReturnAllStatistics_WhenLessThanFiveStatisticsExist()
        {
            // Arrange
            var userProfile = new UserProfile
            {
                UserQuizStatistics = new List<UserQuizStatistics>
                {
                    new UserQuizStatistics { Score = 70, QuizLength = 10, CreatedOn = DateTime.UtcNow.AddDays(-4) },
                    new UserQuizStatistics { Score = 80, QuizLength = 10, CreatedOn = DateTime.UtcNow.AddDays(-3) },
                    new UserQuizStatistics { Score = 90, QuizLength = 10, CreatedOn = DateTime.UtcNow.AddDays(-2) }
                }
            };
            _userProfileRepositoryMock.Setup(repo => repo.GetByUuid(userUuid)).Returns(userProfile);

            // Act
            var result = _userProfileService.GetLastFiveGamesStatistics(userUuid);

            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void UpdateProficiency_ShouldThrowException_WhenUserNotFoundInUserProfileRepository()
        {
            // Arrange
            var userEmail = "nonexistent@example.com";
            var aspUserId = "nonexistent_id";
            _aspNetUserRepositoryMock.Setup(repo => repo.GetByEmail(userEmail)).Returns(aspUserId);
            _userProfileRepositoryMock.Setup(repo => repo.GetByUuid(aspUserId)).Returns((UserProfile)null);

            // Act & Assert
            Assert.Throws<Exception>(() => _userProfileService.UpdateProficiency(2, userEmail));
        }
        [Test]
        public void UpdateProficiency_ShouldUpdateProficiencyLevelAndCallUpdateMethod_WhenUserExists()
        {
            // Arrange
            var userEmail = "existing@example.com";
            var aspUserId = "existing_id";
            var userProfile = new UserProfile(); // Existing user profile
            _aspNetUserRepositoryMock.Setup(repo => repo.GetByEmail(userEmail)).Returns(aspUserId);
            _userProfileRepositoryMock.Setup(repo => repo.GetByUuid(aspUserId)).Returns(userProfile);

            // Act
            _userProfileService.UpdateProficiency(2, userEmail);

            // Assert
            Assert.AreEqual(2, userProfile.ProficiencyLevelId); // Ensure ProficiencyLevelId is updated
            _userProfileRepositoryMock.Verify(repo => repo.UpdateUserProfile(userProfile), Times.Once); // Verify that UpdateUserProfile is called once with the userProfile object
        }

    }
}