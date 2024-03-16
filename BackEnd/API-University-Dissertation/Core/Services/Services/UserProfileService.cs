using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Core.Repositories;
using AutoMapper;
using API_University_Dissertation.Core.Data.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using ProficiencyLevel = API_University_Dissertation.Core.Data.Enums.ProficiencyLevel;

namespace API_University_Dissertation.Core.Services.Services;

public interface IUserProfileService
{
    void AddNewProfile(UserProfileDto userProfileDto);
    UserProfileDto GetRecordByUuid(string uuid, string email);
    void UpdateProficiency(int proficiencyLevel, string userEmail);
    void SaveUserStatistics(UserQuizStatisticsDto userQuizStatistics, string userUuid);
    ProfileStatisticsDto GetUserStatistics(string userUuid);
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

    public void UpdateProficiency(int proficiencyLevel, string userEmail)
    {
        var aspUserId = _aspNetUserRepository.GetByEmail(userEmail);
        if (aspUserId == null) throw new Exception("User with uuid" + aspUserId + "not found");

        var user = _userProfileRepository.GetByUuid(aspUserId);
        if (user == null) throw new Exception("User with uuid" + aspUserId + "not found");

        user.ProficiencyLevelId = proficiencyLevel;
        _userProfileRepository.UpdateProficiencyLevel(user);
    }

    public void SaveUserStatistics(UserQuizStatisticsDto userQuizStatistics, string userUuid)
    {
        var user = _userProfileRepository.GetByUuid(userUuid);
        if (user.ProficiencyLevelId == (int)ProficiencyLevel.Undetermined)
        {
            user.ProficiencyLevelId = (int)ProficiencyLevel.Beginner;
            _userProfileRepository.UpdateProficiencyLevel(user);
        }

        var quizStats = new UserQuizStatistics
        {
            UserUUID = userUuid,
            Score = userQuizStatistics.Score,
            QuizLength = userQuizStatistics.QuizLength,
        };

        _userProfileRepository.SaveUserStatistics(quizStats);
    }

    public ProfileStatisticsDto GetUserStatistics(string userUuid)
    {
        var userStatistics = _userProfileRepository.GetUserStatistics(userUuid).ToList();
        var numberOfGames = userStatistics.Count();
        var totalScore = userStatistics.Sum(e => e.Score);
        var totalQuestions = userStatistics.Sum(e => e.QuizLength);
        var result = new ProfileStatisticsDto
        {
            TotalScore = totalScore,
            TotalQuestions = totalQuestions,
            GamesPlayed = userStatistics.Count,
            AverageScore = totalScore != 0 ? Math.Round((double)totalScore / numberOfGames, 2) : 0,
        };
        return result;
    }
}