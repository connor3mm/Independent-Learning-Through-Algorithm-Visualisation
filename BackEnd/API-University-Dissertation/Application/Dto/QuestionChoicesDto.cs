namespace API_University_Dissertation.Application.DTO;

public class QuestionChoicesDTO
{
    public int ID { get; set; }
    public int QuestionId { get; set; }
    public string Choice { get; set; }
    public bool IsCorrect { get; set; }
}

public class QuizQuestionsDTO
{
    public int Id { get; set; }
    public string Question { get; set; }
    public List<QuestionChoicesDTO> QuestionChoices { get; set; }
}