// using API_University_Dissertation.Core.Repositories;
// using API_University_Dissertation.Data;
// using Microsoft.AspNetCore.Identity;
// using Moq;
//
// namespace Testing.Repositories
// {
//     [TestFixture]
//     public class AspNetUserRepositoryTests
//     {
//         private const string email = "test@example.com";
//         private const string userId = "1";
//         
//         [Test]
//         public void GetByEmail_When_Email_Exists_Returns_UserId()
//         {
//             // Arrange
//             var dbContextMock = new Mock<DataContext>();
//
//             dbContextMock.Setup(m => m.Users)
//                 .Returns(new List<IdentityUser>());
//
//             var userRepository = new AspNetUserRepository(dbContextMock.Object);
//
//             // Act
//             var result = userRepository.GetByEmail(email);
//
//             // Assert
//             Assert.AreEqual(userId, result);
//         }
//
//         [Test]
//         public void GetByEmail_When_Email_Does_Not_Exist_Throws_Invalid_Operation_Exception()
//         {
//             // Arrange
//             var mockContext = new Mock<DataContext>();
//             mockContext.Setup(c => c.Users.SingleOrDefault(It.IsAny<Func<IdentityUser, bool>>()))
//                 .Returns((IdentityUser)null);
//
//             var userRepository = new AspNetUserRepository(mockContext.Object);
//
//             // Act & Assert
//             Assert.Throws<InvalidOperationException>(() => userRepository.GetByEmail(email));
//         }
//     }
// }