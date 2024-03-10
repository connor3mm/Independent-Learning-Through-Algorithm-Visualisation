using API_University_Dissertation.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_University_Dissertation.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<ProficiencyLevel> ProficiencyLevels { get; set; }
    public DbSet<UserQuizStatistics> UserQuizStatistics { get; set; }
    public DbSet<QuizQuestions> QuizQuestions { get; set; }
    public DbSet<QuestionChoices> QuestionChoices { get; set; }
}