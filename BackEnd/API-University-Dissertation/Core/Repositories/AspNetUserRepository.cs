using API_University_Dissertation.Data;

namespace API_University_Dissertation.Core.Repositories;

public interface IAspNetUserRepository
{
    string GetByEmail(string email);
}

public class AspNetUserRepository : IAspNetUserRepository
{
    private readonly DataContext _context;

    public AspNetUserRepository(DataContext context)
    {
        _context = context;
    }


    public string GetByEmail(string email)
    {
        //Find find user with the same email in Database, if not found throw exception
        var user = _context.Users.SingleOrDefault(u => u.Email == email);
        if (user == null) throw new InvalidOperationException();
        return user.Id;
    }
}