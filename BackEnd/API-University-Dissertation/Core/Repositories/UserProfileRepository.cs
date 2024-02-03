using System.Runtime.InteropServices.JavaScript;
using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Npgsql;

namespace API_University_Dissertation.Core.Repositories;

public interface IUserProfileRepository
{
    void Add(UserProfile profile);
    UserProfile GetByEmail(string email);
    void UpdateProficiencyLevel(UserProfile user);
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

    public UserProfile GetByEmail(string email)
    {
        return _context.UserProfiles.SingleOrDefault(u => u.Email == email);
    }

    public void UpdateProficiencyLevel(UserProfile user)
    {
        _context.UserProfiles.Update(user);
        _context.SaveChanges();
    }
}