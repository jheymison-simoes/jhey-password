using JheyPassword.Business.Entities;
using JheyPassword.Business.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JheyPassword.Data.Repositories;

public class PasswordRepository(AppDbContext db) : IPasswordRepository, IDisposable
{
    public async Task CreateAsync(PasswordEntity passwordEntity)
    {
        await db.Passwords.AddAsync(passwordEntity);
        await db.SaveChangesAsync();
    }
    
    public async Task<List<PasswordEntity>> GetAllAsync()
    {
        return await db.Passwords.ToListAsync();
    } 
    
    public void Dispose()
    {
        db.Dispose();
    }
}