using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Core.Data.Entities;
using AutoMapper;

namespace API_University_Dissertation.Application.Mappers;

public class UserProfileMapper : Profile

{
    public UserProfileMapper()
    {
        CreateMap<UserProfile, UserProfileDto>();
        CreateMap<UserProfileDto, UserProfile>();
        CreateMap<QuestionChoices, QuestionChoicesDTO>();
        CreateMap<QuizQuestions, QuizQuestionsDTO>();
    }
}