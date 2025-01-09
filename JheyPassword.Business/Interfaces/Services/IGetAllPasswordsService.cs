using JheyPassword.Business.Responses;

namespace JheyPassword.Business.Interfaces.Services;

public interface IGetAllPasswordsService
{
    Task<List<GetAllPasswordResponse>> GetAllAsync();
}