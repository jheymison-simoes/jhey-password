using JheyPassword.Business.Entities;
using JheyPassword.Business.Interfaces.Repositories;

namespace JheyPassword.Data.Repositories;

public class PasswordRepository(AppDbContext db) : IPasswordRepository, IDisposable
{
    public async Task CreateAsync(PasswordEntity passwordEntity)
    {
        await db.Passwords.AddAsync(passwordEntity);
        await db.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        db.Dispose();
    }
}