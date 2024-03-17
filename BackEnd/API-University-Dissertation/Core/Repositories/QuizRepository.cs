using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Data;
using Microsoft.EntityFrameworkCore;

namespace API_University_Dissertation.Core.Repositories;

public interface IQuizRepository
{
    List<QuizQuestions> GetQuizQuestions(int[] quizTypeIds, int count);
}

public class QuizRepository : IQuizRepository
{
    private readonly ApplicationDbContext _context;

    public QuizRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<QuizQuestions> GetQuizQuestions(int[] quizTypeIds, int count)
    {
        return _context.QuizQuestions
            .Include(q => q.QuestionChoices)
            .Where(q => quizTypeIds.Contains(q.QuestionTypeId))
            .OrderBy(q => EF.Functions.Random())
            .Take(count)
            .ToList();
    }
}