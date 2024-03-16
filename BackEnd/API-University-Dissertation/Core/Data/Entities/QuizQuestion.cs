using System.ComponentModel.DataAnnotations.Schema;

namespace API_University_Dissertation.Core.Data.Entities;
public class QuizQuestions
{
    public int Id { get; set; }
    public string Question { get; set; }
    [ForeignKey("QuestionType")]
    public int QuestionTypeId { get; set; }
    public List<QuestionChoices> QuestionChoices { get; set; }
    
    public QuestionType QuestionType { get; set; }
}
