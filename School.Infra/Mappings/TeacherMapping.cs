using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using School.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model.Infra.Mappings
{
    public class TeacherMapping : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable(TeacherNames.TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName(TeacherNames.Name)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName(TeacherNames.Email)
                .IsRequired();

            builder.HasMany(x => x.Courses)
                .WithOne(x => x.Teacher)
                .HasForeignKey(x => x.TeacherId);
        }
    }

    public static class TeacherNames
    {
        public const string TableName = "Teachers";
        public const string Name = "Name";
        public const string Email = "Email";
    }
}
