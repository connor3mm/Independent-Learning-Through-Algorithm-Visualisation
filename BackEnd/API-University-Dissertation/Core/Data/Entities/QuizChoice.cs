using System.ComponentModel.DataAnnotations.Schema;
namespace API_University_Dissertation.Core.Data.Entities;

public class QuestionChoices
{
    public int ID { get; set; }
    public int QuestionId { get; set; }
    public string Choice { get; set; }
    public bool IsCorrect { get; set; }

    [ForeignKey("QuestionId")] 
    public QuizQuestions QuizQuestion { get; set; }
}
