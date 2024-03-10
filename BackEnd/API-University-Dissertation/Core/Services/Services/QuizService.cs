using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Core.Repositories;
using AutoMapper;

namespace API_University_Dissertation.Core.Services.Services;

public interface IQuizService
{
    List<QuizQuestionsDTO> GenerateQuiz();
}

public class QuizService : IQuizService
{
    private readonly IQuizRepository _quizRepository;
    private readonly IMapper _mapper;

    public QuizService(IQuizRepository quizRepository, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _mapper = mapper;
    }

    public List<QuizQuestionsDTO> GenerateQuiz()
    {
        var quizQuestions = _quizRepository.GetQuizQuestions();

        return quizQuestions.Select(questions => _mapper.Map<QuizQuestionsDTO>(questions)).ToList();
    }
}