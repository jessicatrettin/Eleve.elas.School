using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Model.Entities;

namespace School.Model.Infra.Mappings
{
    public class EnrollmentMapping : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable(EnrollmentNames.TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.EnrollmentDate)
                .HasColumnName(EnrollmentNames.EnrollmentDate)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName(EnrollmentNames.Status)
                .IsRequired();

            builder.Property(x => x.StudentId)
                .HasColumnName(EnrollmentNames.StudentId)
                .IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Enrollments);

            builder.Property(x => x.CourseId)
                .HasColumnName(EnrollmentNames.CourseId)
                .IsRequired();

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Enrollments);
        }
    }

    public static class EnrollmentNames
    {
        public const string TableName = "Enrollments";
        public const string EnrollmentDate = "EnrollmentDate";
        public const string Status = "Status";
        public const string StudentId = "StudentId";
        public const string CourseId = "CourseId";
    }
}
