using API_University_Dissertation.Core.Repositories;

namespace API_University_Dissertation.Core.Services.Services;

public interface IQuizService
{
    void GenerateQuiz();
}

public class QuizService : IQuizService
{
    private readonly IQuizRepository _quizRepository;

    public QuizService(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public void GenerateQuiz()
    {
        _quizRepository.GenerateQuiz();
    }
}