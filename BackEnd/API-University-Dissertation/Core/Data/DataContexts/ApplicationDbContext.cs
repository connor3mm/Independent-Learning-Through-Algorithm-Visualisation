using API_University_Dissertation.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_University_Dissertation.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<UserProfile> UserProfiles { get; set; }
}