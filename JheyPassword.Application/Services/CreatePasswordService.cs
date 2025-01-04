using AutoMapper;
using JheyPassword.Business.Entities;
using JheyPassword.Business.Interfaces.Repositories;
using JheyPassword.Business.Interfaces.Services;
using JheyPassword.Business.Responses;
using JheyPassword.Business.ViewModels;

namespace JheyPassword.Application.Services;

public class CreatePasswordService(IMapper mapper, IPasswordRepository passwordRepository) : ICreatePasswordService
{
    public async Task<CreatedPasswordResponse> CreateAsync(CreatePasswordViewModel model)
    {
        var password = new PasswordEntity
        {
            Title = model.Title,
            Password = model.Password,
            User = model.UserOrEmail
        };
        
        await passwordRepository.CreateAsync(password);

        var response = mapper.Map<CreatedPasswordResponse>(password);

        return response;
    }
}