using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Core.Repositories;
using AutoMapper;

namespace API_University_Dissertation.Core.Services.Services;

public interface IUserProfileService
{
    void AddNewProfile(UserProfileDto userProfileDto);
    UserProfileDto GetRecordByUuid(string uuid, string email);
    void UpdateProficiency(string proficiencyLevel, string userEmail);
}

public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IAspNetUserRepository _aspNetUserRepository;
    private readonly IMapper _mapper;

    public UserProfileService(IUserProfileRepository userProfileRepository,
        IAspNetUserRepository aspNetUserRepository, IMapper mapper)
    {
        _userProfileRepository = userProfileRepository;
        _aspNetUserRepository = aspNetUserRepository;
        _mapper = mapper;
    }

    public void AddNewProfile(UserProfileDto userProfileDto)
    {
        var userUuid = _aspNetUserRepository.GetByEmail(userProfileDto.Email);
        var user = _mapper.Map<UserProfile>(userProfileDto);
        user.UserUUID = userUuid;
        _userProfileRepository.Add(user);
    }

    public UserProfileDto GetRecordByUuid(string uuid, string email)
    {
        var user = _userProfileRepository.GetByUuid(uuid);
        var userDto = _mapper.Map<UserProfileDto>(user);
        userDto.Email = email;
        return userDto;
    }

    public void UpdateProficiency(string proficiencyLevel, string uuid)
    {
        var user = _userProfileRepository.GetByUuid(uuid);
        user.ProficiencyLevel = proficiencyLevel;
        _userProfileRepository.UpdateProficiencyLevel(user);
    }
}