using JheyPassword.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JheyPassword.Data.Mappings;

public class PasswordMapping : IEntityTypeConfiguration<PasswordEntity>
{
    public void Configure(EntityTypeBuilder<PasswordEntity> builder)
    {
        builder.ToTable("password");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id);
        builder.Property(t => t.CreatedAt);
        builder.Property(t => t.DeletedAt)
            .IsRequired(false);
        builder.Property(t => t.Title)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(400);
        builder.Property(t => t.Password)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(400);
    }
}