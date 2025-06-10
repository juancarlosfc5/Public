using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace ApiPublic.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CategoryCatalog, CategoryCatalogDto>().ReverseMap();
        CreateMap<CategoryOption, CategoryOptionDto>().ReverseMap();
        CreateMap<Chapter, ChapterDto>().ReverseMap();
        CreateMap<OptionResponse, OptionResponseDto>().ReverseMap();
        CreateMap<OptionQuestion, OptionQuestionDto>().ReverseMap();
        CreateMap<Question, QuestionDto>().ReverseMap();
        CreateMap<SubQuestion, SubQuestionDto>().ReverseMap();
        CreateMap<SumaryOption, SumaryOptionDto>().ReverseMap();
        CreateMap<Survey, SurveyDto>().ReverseMap();
    }
}