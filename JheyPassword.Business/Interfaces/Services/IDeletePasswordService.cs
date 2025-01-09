namespace JheyPassword.Business.Interfaces.Services;

public interface IDeletePasswordService
{
    Task DeleteAsync(Guid id);
}