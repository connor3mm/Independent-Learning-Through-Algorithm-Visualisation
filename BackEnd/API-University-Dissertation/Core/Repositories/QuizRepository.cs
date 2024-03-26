using API_University_Dissertation.Core.Data.DataContexts;
using API_University_Dissertation.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_University_Dissertation.Core.Repositories;

public interface IQuizRepository
{
    IEnumerable<QuizQuestions> GetQuizQuestions(int[] quizTypeIds, int count);
}

public class QuizRepository : IQuizRepository
{
    private readonly ApplicationDbContext _context;

    public QuizRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<QuizQuestions> GetQuizQuestions(int[] quizTypeIds, int count)
    {
        //Using LINQ to take the count of random questions from the database based on quiz IDs
        return _context.QuizQuestions
            .Include(q => q.QuestionChoices)
            .Where(q => quizTypeIds.Contains(q.QuestionTypeId))
            .OrderBy(q => EF.Functions.Random())
            .Take(count)
            .ToList();
    }
}