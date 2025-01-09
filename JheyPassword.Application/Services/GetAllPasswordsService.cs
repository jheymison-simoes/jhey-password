using AutoMapper;
using JheyPassword.Business.Interfaces.Repositories;
using JheyPassword.Business.Interfaces.Services;
using JheyPassword.Business.Responses;

namespace JheyPassword.Application.Services;

public class GetAllPasswordsService(
    IMapper mapper,
    IPasswordRepository passwordRepository
) : IGetAllPasswordsService
{
    public async Task<List<GetAllPasswordResponse>> GetAllAsync()
    {
        var passwords = await passwordRepository.GetAllAsync();
        if (passwords.Count == 0) return [];
        
        var response = mapper.Map<List<GetAllPasswordResponse>>(passwords);
        return response;
    }
}