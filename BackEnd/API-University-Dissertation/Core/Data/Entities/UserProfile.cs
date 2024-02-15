using System.ComponentModel.DataAnnotations.Schema;

namespace API_University_Dissertation.Core.Data.Entities;

public class UserProfile
{
    public int ID { get; set; }
    [ForeignKey("AspNetUsers")]
    public string UserUUID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [ForeignKey("ProficiencyLevel")]
    public int ProficiencyLevelId { get; set; }
    public DateOnly CreatedOn { get; set; }
}