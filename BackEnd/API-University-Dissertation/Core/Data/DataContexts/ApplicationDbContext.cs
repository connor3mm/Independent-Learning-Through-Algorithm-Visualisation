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
    public DbSet<QuestionType> QuestionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuestionType>().HasData(
            new QuestionType { Id = 1, Type = "Complexity" },
            new QuestionType { Id = 2, Type = "Sorting Algorithms" },
            new QuestionType { Id = 3, Type = "Searching Algorithms" },
            new QuestionType { Id = 4, Type = "Other" }
        );
        
        modelBuilder.Entity<ProficiencyLevel>().HasData(
            new ProficiencyLevel { LevelId = 1, LevelName = "Undetermined" },
            new ProficiencyLevel { LevelId = 2, LevelName = "Beginner" },
            new ProficiencyLevel { LevelId = 3, LevelName = "Intermediate" },
            new ProficiencyLevel { LevelId = 4, LevelName = "Advanced" },
            new ProficiencyLevel { LevelId = 5, LevelName = "Expert" }
        );

        base.OnModelCreating(modelBuilder);
    }
}