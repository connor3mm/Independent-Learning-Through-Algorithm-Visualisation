using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Core.Repositories;

namespace API_University_Dissertation.Core.Services.Services;

public interface IUserProfileService
{
    void AddNewProfile(UserProfile entity);
    UserProfile GetRecordByEmail(string email);
    void UpdateProficiency(string proficiencyLevel, string userEmail);
}

public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileRepository _userProfileRepository;

    public UserProfileService(IUserProfileRepository userProfileRepository)
    {
        _userProfileRepository = userProfileRepository;
    }

    public void AddNewProfile(UserProfile entity)
    {
        _userProfileRepository.Add(entity);
    }

    public UserProfile GetRecordByEmail(string email)
    {
        return _userProfileRepository.GetByEmail(email);
    }

    public void UpdateProficiency(string proficiencyLevel, string userEmail)
    {
        var user = _userProfileRepository.GetByEmail(userEmail);
        user.ProficiencyLevel = proficiencyLevel;
        _userProfileRepository.UpdateProficiencyLevel(user);
    }
}