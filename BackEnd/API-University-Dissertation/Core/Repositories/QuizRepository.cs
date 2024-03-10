using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Data;
using Microsoft.EntityFrameworkCore;

namespace API_University_Dissertation.Core.Repositories;

public interface IQuizRepository
{
    List<QuizQuestions> GetQuizQuestions();
}

public class QuizRepository : IQuizRepository
{
    private readonly ApplicationDbContext _context;

    public QuizRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<QuizQuestions> GetQuizQuestions()
    {
        return _context.QuizQuestions
            .Include(q => q.QuestionChoices)
            .Where(q => q.Id == 1 || q.Id == 2 || q.Id == 3)
            .ToList();
    }
}