namespace API_University_Dissertation.Core.Data.Entities;
public class QuizQuestions
{
    public int Id { get; set; }
    public string Question { get; set; }
    public List<QuestionChoices> QuestionChoices { get; set; }
}
