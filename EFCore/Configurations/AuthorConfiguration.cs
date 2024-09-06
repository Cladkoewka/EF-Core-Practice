using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<AuthorEntity>
{
    public void Configure(EntityTypeBuilder<AuthorEntity> builder)
    {
        builder.HasKey(a => a.Id);
        builder
            .HasOne(a => a.Course)
            .WithOne(c => c.Author)
            .HasForeignKey<AuthorEntity>(a => a.CourseId);
    }
}