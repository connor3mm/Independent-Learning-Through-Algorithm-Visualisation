using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Data;

namespace API_University_Dissertation.Core.Repositories;

public interface IUserProfileRepository
{
    void Add(UserProfile profile);
    void UpdateProficiencyLevel(UserProfile user);
    UserProfile GetByUuid(string uuid);
    void SaveUserStatistics(UserQuizStatistics userQuizStatistics);
    IEnumerable<UserQuizStatistics> GetUserStatistics(string userUuid);
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
        return _context.UserProfiles.SingleOrDefault(u => u.UserUUID == uuid) ?? throw new InvalidOperationException();
    }

    public void SaveUserStatistics(UserQuizStatistics userQuizStatistics)
    {
        _context.UserQuizStatistics.Add(userQuizStatistics);
        _context.SaveChanges();
    }

    public IEnumerable<UserQuizStatistics> GetUserStatistics(string userUuid)
    {
        return _context.UserQuizStatistics.Where(u => u.UserUUID == userUuid);
    }

    public void UpdateProficiencyLevel(UserProfile user)
    {
        _context.UserProfiles.Update(user);
        _context.SaveChanges();
    }
}