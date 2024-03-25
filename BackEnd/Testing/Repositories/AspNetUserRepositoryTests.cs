using API_University_Dissertation.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using API_University_Dissertation.Data;

namespace Testing.Repositories
{
    [TestFixture]
    public class AspNetUserRepositoryTests
    {
        private const string Email = "test@example.com";
        private const string UserId = "1";

        [Test]
        public void GetByEmail_When_Email_Exists_Returns_UserId()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new DataContext(options))
            {
                context.Users.Add(new IdentityUser { Id = UserId, Email = Email });
                context.SaveChanges();
            }

            using (var context = new DataContext(options))
            {
                var userRepository = new AspNetUserRepository(context);

                // Act
                var result = userRepository.GetByEmail(Email);

                // Assert
                Assert.AreEqual(UserId, result);
            }
        }

        [Test]
        public void GetByEmail_When_Email_Does_Not_Exist_Throws_Invalid_Operation_Exception()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new DataContext(options);
            var userRepository = new AspNetUserRepository(context);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => userRepository.GetByEmail(Email));
        }
    }
}