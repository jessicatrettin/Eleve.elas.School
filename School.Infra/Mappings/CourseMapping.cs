using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Model.Entities;

namespace School.Model.Infra.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable(CourseNames.TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasColumnName(CourseNames.Title)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName(CourseNames.Description)
                .IsRequired();

            builder.HasMany(x => x.Enrollments)
                .WithOne(x => x.Course);

            builder.Property(x => x.TeacherId)
                .HasColumnName(CourseNames.TeacherId)
                .IsRequired();

            builder.HasOne(x => x.Teacher)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.TeacherId);
        }
    }

    public static class CourseNames
    {
        public const string TableName = "Courses";
        public const string Title = "Title";
        public const string Description = "Description";
        public const string TeacherId = "TeacherId";
    }
}
