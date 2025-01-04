using JheyPassword.Business.Entities;

namespace JheyPassword.Business.Interfaces.Repositories;

public interface IPasswordRepository
{
    Task CreateAsync(PasswordEntity passwordEntity);
    Task<List<PasswordEntity>> GetAllAsync();
}