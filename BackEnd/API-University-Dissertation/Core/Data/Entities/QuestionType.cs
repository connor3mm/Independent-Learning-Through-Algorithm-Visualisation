namespace API_University_Dissertation.Core.Data.Entities;

public class QuestionType
{
    public int Id { get; set; }
    public string Type { get; set; }
    public ICollection<QuizQuestions> QuizQuestions { get; set; }
}