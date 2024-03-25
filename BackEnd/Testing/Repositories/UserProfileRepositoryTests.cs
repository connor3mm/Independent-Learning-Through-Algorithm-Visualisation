using API_University_Dissertation.Core.Data.DataContexts;
using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Testing.Repositories;

[TestFixture]
public class UserProfileRepositoryTests
{
    private DbContextOptions<ApplicationDbContext> _options;
    private ApplicationDbContext _context;
    private readonly string _guid;

    public UserProfileRepositoryTests()
    {
        _guid = Guid.NewGuid().ToString();
    }

    [OneTimeSetUp]
    public void Setup()
    {
        // Configure in-memory database
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new ApplicationDbContext(_options);
        SeedTestData();
    }

    private void SeedTestData()
    {
        var userProfiles = new List<UserProfile>
        {
            new UserProfile()
            {
                ID = 1,
                UserUUID = _guid,
                FirstName = "Test",
                LastName = "test",
                ProficiencyScore = 0,
                ProficiencyLevelId = 1,
                CreatedOn = new DateOnly()
            },
            new UserProfile()
            {
                ID = 2,
                UserUUID = Guid.NewGuid().ToString(),
                FirstName = "AnotherTest",
                LastName = "anothertest",
                ProficiencyScore = 0,
                ProficiencyLevelId = 1,
                CreatedOn = new DateOnly()
            },
        };
        _context.AddRange(userProfiles);
        _context.SaveChanges();
    }

    [Test]
    public void AddUser_Should_Add_To_db_and_Return_OK()
    {
        // Arrange
        var repository = new UserProfileRepository(_context);
        var guid = new Guid().ToString();
        var userProfile = new UserProfile
        {
            ID = 3,
            UserUUID = guid,
            FirstName = "Tester",
            LastName = "tester",
            ProficiencyScore = 0,
            ProficiencyLevelId = 1,
            CreatedOn = new DateOnly()
        };

        // Act
        repository.Add(userProfile);

        // Assert
        Assert.IsTrue(_context.UserProfiles.Contains(userProfile));
    }

    [Test]
    public void getByUUid_Should_Return_Profile_from_db()
    {
        // Arrange
        var repository = new UserProfileRepository(_context);

        // Act
        var user = repository.GetByUuid(_guid);
        var dbUser = _context.UserProfiles.FirstOrDefault(u => u.UserUUID == _guid);
        // Assert
        Assert.AreEqual(user, dbUser);
    }

    [Test]
    public void SaveUserStatistics_Should_Save_To_db()
    {
        // Arrange
        var repository = new UserProfileRepository(_context);
        var userQuizStatistics = new UserQuizStatistics
        {
            ID = 1,
            QuizLength = 5,
            Score = 1,
            CreatedOn = DateTime.Now
        };

        // Act
        repository.SaveUserStatistics(userQuizStatistics);

        // Assert
        Assert.IsTrue(_context.UserQuizStatistics.Contains(userQuizStatistics));
    }

    [Test]
    public void UpdateUserProfile_Should_Update_In_db()
    {
        // Arrange
        var repository = new UserProfileRepository(_context);
        var userProfileToUpdate = _context.UserProfiles.First();
        var updatedFirstName = "UpdatedFirstName";
        userProfileToUpdate.FirstName = updatedFirstName;

        // Act
        repository.UpdateUserProfile(userProfileToUpdate);

        // Assert
        var updatedUser = _context.UserProfiles.FirstOrDefault(u => u.ID == userProfileToUpdate.ID);
        Assert.NotNull(updatedUser);
        Assert.AreEqual(updatedFirstName, updatedUser.FirstName);
    }
}