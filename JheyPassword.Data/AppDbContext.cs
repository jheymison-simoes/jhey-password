using JheyPassword.Business.Entities;
using JheyPassword.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Storage;

namespace JheyPassword.Data;

public class AppDbContext : DbContext
{
    private string _path;
    
    public AppDbContext()
    {
        _path = Path.Combine(AppContext.BaseDirectory, "app2.db");
    }
    
    public DbSet<PasswordEntity> Passwords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PasswordMapping());
        modelBuilder.Entity<PasswordEntity>(x => x.HasQueryFilter(q => !q.DeletedAt.HasValue));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // var path = Path.Combine(Directory.GetCurrentDirectory(), "app2.db");
        // var path = "app2.db";
        optionsBuilder.UseSqlite($"Data Source={_path}");
    }
}