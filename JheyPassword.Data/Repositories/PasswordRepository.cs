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
    
    public async Task CreateAsync(List<PasswordEntity> passwordEntity)
    {
        await db.Passwords.AddRangeAsync(passwordEntity);
        await db.SaveChangesAsync();
    }
    
    public async Task<List<PasswordEntity>> GetAllAsync()
    {
        return await db.Passwords.ToListAsync();
    } 
    
    public async Task<PasswordEntity?> GetByIdAsync(Guid id)
    {
        return await db.Passwords.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task DeleteAsync(PasswordEntity passwordEntity)
    {
        db.Passwords.Remove(passwordEntity);
        await db.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        db.Dispose();
    }
}