using AutoMapper;
using JheyPassword.Business.Entities;
using JheyPassword.Business.Responses;

namespace JheyPassword.Application.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<PasswordEntity, CreatedPasswordResponse>().ReverseMap();
    }
}