using JheyPassword.Business.Responses;
using JheyPassword.Business.ViewModels;

namespace JheyPassword.Business.Interfaces.Services;

public interface ICreatePasswordService
{
    Task<CreatedPasswordResponse> CreateAsync(CreatePasswordViewModel model);
}