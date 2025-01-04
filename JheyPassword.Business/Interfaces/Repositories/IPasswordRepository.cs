using JheyPassword.Business.Entities;

namespace JheyPassword.Business.Interfaces.Repositories;

public interface IPasswordRepository
{
    Task CreateAsync(PasswordEntity passwordEntity);
}