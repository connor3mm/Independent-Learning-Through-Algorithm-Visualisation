using API_University_Dissertation.Core.Data.DataContexts;
using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Testing.Repositories
{
    [TestFixture]
    public class QuizRepositoryTests
    {
        private DbContextOptions<ApplicationDbContext> _options;
        private ApplicationDbContext _context;

        [SetUp]
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
            var quizQuestions = new List<QuizQuestions>
            {
                new QuizQuestions { Id = 1, QuestionTypeId = 1, Question = "Sample question 1", QuestionChoices = new List<QuestionChoices>() },
                new QuizQuestions { Id = 2, QuestionTypeId = 2, Question = "Sample question 2", QuestionChoices = new List<QuestionChoices>() },
                new QuizQuestions { Id = 3, QuestionTypeId = 3, Question = "Sample question 3", QuestionChoices = new List<QuestionChoices>() },
                new QuizQuestions { Id = 4, QuestionTypeId = 1, Question = "Sample question 4", QuestionChoices = new List<QuestionChoices>() },
                new QuizQuestions { Id = 5, QuestionTypeId = 2, Question = "Sample question 5", QuestionChoices = new List<QuestionChoices>() }
            };
            _context.AddRange(quizQuestions);
            _context.SaveChanges();
        }

        [Test]
        public void GetQuizQuestions_ReturnsCorrectNumberOfQuestions()
        {
            // Arrange
            var repository = new QuizRepository(_context);
            var quizTypeIds = new[] { 1, 2, 3 }; 
            const int count = 5; 

            // Act
            var result = repository.GetQuizQuestions(quizTypeIds, count);

            // Assert
            Assert.AreEqual(count, result.Count());
        }
    }
}