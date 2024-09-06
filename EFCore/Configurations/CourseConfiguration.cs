using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder.HasKey(c => c.Id);
        builder
            .HasOne(c => c.Author)
            .WithOne(c => c.Course)
            .HasForeignKey<CourseEntity>(c => c.AuthorId);
        builder
            .HasMany(c => c.Lessons)
            .WithOne(l => l.Course)
            .HasForeignKey(l => l.CourseId);
        builder
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses);
    }
}