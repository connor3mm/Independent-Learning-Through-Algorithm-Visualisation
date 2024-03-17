namespace API_University_Dissertation.Application.DTO;

public class ProfileStatisticsDto
{
    public int TotalScore { get; set; }
    public int TotalQuestions { get; set; }
    public int GamesPlayed { get; set; }
    public double AverageScore { get; set; }
    public int ProficiencyScore { get; set; }
}