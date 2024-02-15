using API_University_Dissertation.Core.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_University_Dissertation.Presentation.Controllers;

[ApiController]
[Route("quiz")]
public class QuizController : ControllerBase
{
    private readonly ILogger<QuizController> _logger;
    private readonly IQuizService _quizService;


    public QuizController(ILogger<QuizController> logger, IQuizService quizService)
    {
        _logger = logger;
        _quizService = quizService;
    }

    [HttpGet("generatequiz", Name = "generatequiz")]
    public IActionResult GenerateQuiz()
    {
        try
        {
            _quizService.GenerateQuiz();
            return Ok();
        }
        catch (Exception ex)
        {
            var errorMessage = $"An error occurred: {ex.Message}";
            _logger.LogError(errorMessage);
            return BadRequest(errorMessage);
        }
    }
}