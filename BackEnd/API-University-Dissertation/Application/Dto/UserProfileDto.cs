namespace API_University_Dissertation.Application.DTO;

public class UserProfileDto
{
    public int ID { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProficiencyLevel { get; set; }
    public DateOnly CreatedOn { get; set; }
}