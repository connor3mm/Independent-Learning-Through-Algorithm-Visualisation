using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Core.Data.Entities;
using API_University_Dissertation.Core.Repositories;
using AutoMapper;

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

    public void UpdateProficiency(int proficiencyLevel, string uuid)
    {
        var user = _userProfileRepository.GetByUuid(uuid);
        user.ProficiencyLevelId = proficiencyLevel;
        _userProfileRepository.UpdateProficiencyLevel(user);
    }

    public void SaveUserStatistics(UserQuizStatisticsDto userQuizStatistics, string userUuid)
    {
        var quizStats = new UserQuizStatistics
        {
            UserUUID = userUuid,
            Score = userQuizStatistics.score,
            QuizLength = userQuizStatistics.quizLength,
        };

        _userProfileRepository.SaveUserStatistics(quizStats);
    }

    public ProfileStatisticsDto GetUserStatistics(string userUuid)
    {
        var userStatistics = _userProfileRepository.GetUserStatistics(userUuid).ToList();
        var totalScore = userStatistics.Sum(e => e.Score);
        var totalQuestions = userStatistics.Sum(e => e.QuizLength);
        var result = new ProfileStatisticsDto
        {
            TotalScore = totalScore,
            TotalQuestions = totalQuestions,
            GamesPlayed = userStatistics.Count,
            AverageScore = Math.Round((double) totalQuestions / totalScore, 2),
        };
        return result;
    }
}