using API_University_Dissertation.Core.Data.DataContexts;
using API_University_Dissertation.Core.Data.Entities;
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

    //Add user profile to Db
    public void Add(UserProfile profile)
    {
        _context.UserProfiles.Add(profile);
        _context.SaveChanges();
    }

    //Returns First user that makes the UUID provided 
    public UserProfile GetByUuid(string uuid)
    {
        return _context.UserProfiles.Include(q => q.UserQuizStatistics).SingleOrDefault(u => u.UserUUID == uuid) ?? throw new InvalidOperationException();
    }

    //Saves Single user statistic to Db
    public void SaveUserStatistics(UserQuizStatistics userQuizStatistics)
    {
        _context.UserQuizStatistics.Add(userQuizStatistics);
        _context.SaveChanges();
    }

    //Updates the user profile with any changes
    public void UpdateUserProfile(UserProfile user)
    {
        _context.UserProfiles.Update(user);
        _context.SaveChanges();
    }
}