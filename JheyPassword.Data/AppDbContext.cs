using JheyPassword.Business.Entities;
using JheyPassword.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Storage;

namespace JheyPassword.Data;

public class AppDbContext : DbContext
{
    private string _dbPath { get; set; }

    public AppDbContext()
    {
        _dbPath = Path.Combine(FileSystem.AppDataDirectory, "app2.db");
    }
    
    public DbSet<PasswordEntity> Passwords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PasswordMapping());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={_dbPath}");
    }
}