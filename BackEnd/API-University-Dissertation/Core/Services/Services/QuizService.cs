using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Core.Repositories;
using AutoMapper;

namespace API_University_Dissertation.Core.Services.Services;

public interface IQuizService
{
    List<QuizQuestionsDTO> GenerateQuiz(int[] quizTypeIds);
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

    public List<QuizQuestionsDTO> GenerateQuiz(int[] quizTypeIds)
    {
        const int questionCount = 5;
        var quizQuestions = _quizRepository.GetQuizQuestions(quizTypeIds, questionCount);

        return quizQuestions.Select(questions => _mapper.Map<QuizQuestionsDTO>(questions)).ToList();
    }
}