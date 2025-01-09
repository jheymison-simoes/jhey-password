using AutoMapper;
using JheyPassword.Business.Entities;
using JheyPassword.Business.Responses;

namespace JheyPassword.Application.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<PasswordEntity, CreatedPasswordResponse>().ReverseMap();
        CreateMap<PasswordEntity, GetAllPasswordResponse>()
            .ForMember(dest => dest.UserOrEmail, opt => opt.MapFrom(src => src.User))
            .ReverseMap();
    }
}