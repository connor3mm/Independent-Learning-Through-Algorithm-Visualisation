// using API_University_Dissertation.Application.DTO;
// using API_University_Dissertation.Core.Data.Entities;
// using API_University_Dissertation.Core.Repositories;
// using AutoMapper;
// using Moq;
//
//
// namespace API_University_Dissertation.Core.Services.Services.Tests
// {
//     [TestFixture]
//     public class QuizServiceTests
//     {
//         private Mock<IQuizRepository> _quizRepositoryMock;
//         private Mock<IMapper> _mapperMock;
//         private IQuizService _quizService;
//
//         [SetUp]
//         public void Setup()
//         {
//             _quizRepositoryMock = new Mock<IQuizRepository>();
//             _mapperMock = new Mock<IMapper>();
//             _quizService = new QuizService(_quizRepositoryMock.Object, _mapperMock.Object);
//         }
//
//         [Test]
//         public void GenerateQuiz_ShouldReturnMappedQuizQuestions()
//         {
//             // Arrange
//             var quizQuestions = new List<QuizQuestions>{new() {Question = "Testing", Id = 1}};
//             var mappedQuizQuestions = new List<QuizQuestionsDTO>{new() {Question = "Testing", Id = 1 }};
//
//             _quizRepositoryMock.Setup(repo => repo.GetQuizQuestions()).Returns(quizQuestions);
//             _mapperMock.Setup(mapper => mapper.Map<QuizQuestionsDTO>(It.IsAny<QuizQuestions>()))
//                 .Returns((QuizQuestions q) => mappedQuizQuestions.FirstOrDefault(questions => questions.Id == q.Id));
//
//             // Act
//             var result = _quizService.GenerateQuiz();
//
//             // Assert
//             Assert.IsNotNull(result);
//             Assert.AreEqual(mappedQuizQuestions.Count, result.Count);
//         }
//     }
// }