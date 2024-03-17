using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Data;
using Microsoft.EntityFrameworkCore;

namespace API_University_Dissertation.Core.Repositories;

public interface IUserProfileRepository
{
    void Add(UserProfile profile);
    void UpdateUserProfile(UserProfile user);
    UserProfile GetByUuid(string uuid);
    void SaveUserStatistics(UserQuizStatistics userQuizStatistics);
}

public class UserProfileRepository : IUserProfileRepository
{
    private readonly ApplicationDbContext _context;

    public UserProfileRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(UserProfile profile)
    {
        _context.UserProfiles.Add(profile);
        _context.SaveChanges();
    }

    public UserProfile GetByUuid(string uuid)
    {
        return _context.UserProfiles.Include(q => q.UserQuizStatistics).SingleOrDefault(u => u.UserUUID == uuid) ?? throw new InvalidOperationException();
    }

    public void SaveUserStatistics(UserQuizStatistics userQuizStatistics)
    {
        _context.UserQuizStatistics.Add(userQuizStatistics);
        _context.SaveChanges();
    }

    public void UpdateUserProfile(UserProfile user)
    {
        _context.UserProfiles.Update(user);
        _context.SaveChanges();
    }
}