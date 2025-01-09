using System.Reflection;
using JheyPassword.Business.Entities;
using JheyPassword.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Maui.Storage;
using System.IO;
using Microsoft.Maui.Devices;

namespace JheyPassword.Data;

public class AppDbContext : DbContext
{
    private string _path;
    
    public AppDbContext()
    {

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            _path = Path.Combine(FileSystem.AppDataDirectory, "simple-db.db");
        }
        else if (DeviceInfo.Platform == DevicePlatform.iOS)
        {
            _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "simple-db.db");
        }
        else
        {
            var fullPath = AppDomain.CurrentDomain.BaseDirectory;

            DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);
            while (directoryInfo != null && directoryInfo.Name != "JheyPassword")
            {
                directoryInfo = directoryInfo.Parent;
            }
            
            _path = Path.Combine(directoryInfo?.FullName ?? string.Empty, "simple-db.db") ;
        }
        
        //_path = Path.GetDirectoryName(Directory.GetCurrentDirectory()) ?? string.Empty;
        // var fullPath = AppDomain.CurrentDomain.BaseDirectory;
        //
        // DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);
        // while (directoryInfo != null && directoryInfo.Name != "JheyPassword")
        // {
        //     directoryInfo = directoryInfo.Parent;
        // }


        // Console.WriteLine($"Diretório do assembly: {assemblyLocation}");
        // _path = Path.Combine(AppContext., "app2.db");
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