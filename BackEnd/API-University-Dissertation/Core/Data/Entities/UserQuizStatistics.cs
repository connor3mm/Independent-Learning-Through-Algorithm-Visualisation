using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_University_Dissertation.Core.Data.Entities;

public class UserQuizStatistics
{
    public int ID { get; set; }
    public int Score { get; set; }
    public int QuizLength { get; set; }
    public DateTime CreatedOn { get; set; }
    
    [JsonIgnore]
    public UserProfile UserProfile { get; set; }
}