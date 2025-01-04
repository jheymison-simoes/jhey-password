using AutoMapper;
using JheyPassword.Business.Interfaces.Repositories;
using JheyPassword.Business.Interfaces.Services;

namespace JheyPassword.Application.Services;

public class GetAllPasswordsService(IMapper mapper, IPasswordRepository passwordRepository) : IGetAllPasswordsService
{
    public async Task GetAllAsync()
    {
        var passwords = await passwordRepository.GetAllAsync();
    }
}