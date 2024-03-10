using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Core.Repositories;
using API_University_Dissertation.Core.Services.Services;
using AutoMapper;
using Moq;

namespace Testing.Services
{
    [TestFixture]
    public class UserProfileServiceTests
    {
        private Mock<IUserProfileRepository> _userProfileRepositoryMock;
        private Mock<IAspNetUserRepository> _aspNetUserRepositoryMock;
        private Mock<IMapper> _mapperMock;

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
            var userProfileDto = new UserProfileDto { Email = "tester@gmail.com"};
            var userUuid = "user_uuid";

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
            var uuid = "user_uuid";
            var email = "user@example.com";

            _userProfileRepositoryMock.Setup(repo => repo.GetByUuid(uuid))
                .Returns(new UserProfile());
            
            _mapperMock.Setup(mapper => mapper.Map<UserProfileDto>(It.IsAny<UserProfile>()))
                .Returns((UserProfile userProfile) => new UserProfileDto()
                {
                     Email = email,
                });
            
            // Act
            var result = _userProfileService.GetRecordByUuid(uuid, email);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(email, result.Email);
        }
    }
}