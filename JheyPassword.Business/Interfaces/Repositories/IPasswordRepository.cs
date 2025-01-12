using JheyPassword.Business.Entities;

namespace JheyPassword.Business.Interfaces.Repositories;

public interface IPasswordRepository
{
    Task CreateAsync(PasswordEntity passwordEntity);
    Task CreateAsync(List<PasswordEntity> passwordEntity);
    Task<List<PasswordEntity>> GetAllAsync();
    Task<PasswordEntity?> GetByIdAsync(Guid id);
    Task DeleteAsync(PasswordEntity passwordEntity);
}