namespace API_University_Dissertation.Core.Data.Entities;

public class UserProfile
{
    public int ID { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProficiencyLevel { get; set; }
    public DateOnly CreatedOn { get; set; }
}