using JheyPassword.Business.Exceptions;
using JheyPassword.Business.Interfaces.Repositories;
using JheyPassword.Business.Interfaces.Services;

namespace JheyPassword.Application.Services;

public class DeletePasswordService(IPasswordRepository passwordRepository) : BaseService, IDeletePasswordService
{
    public async Task DeleteAsync(Guid id)
    {
        var password = await passwordRepository.GetByIdAsync(id);
        if (password is null) throw NotFound("Ops! Acho que essa chave já foi deletada.");
        
        await passwordRepository.DeleteAsync(password);
    }
}