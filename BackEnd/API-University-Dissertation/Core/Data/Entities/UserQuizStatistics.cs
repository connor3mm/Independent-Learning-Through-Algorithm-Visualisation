using System.ComponentModel.DataAnnotations.Schema;

namespace API_University_Dissertation.Core.Data.Entities;

public class UserQuizStatistics
{
    public int ID { get; set; }
    public int Score { get; set; }
    public int QuizLength { get; set; }
    public DateTime CreatedOn { get; set; }
    
    public UserProfile UserProfile { get; set; }
}