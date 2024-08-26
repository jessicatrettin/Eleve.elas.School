using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Model.Entities;

namespace School.Model.Infra.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(StudentNames.TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName(StudentNames.Name)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName(StudentNames.Email)
                .IsRequired();

            builder.Property(x => x.AddressId)
                .HasColumnName(StudentNames.AddressId)
                .IsRequired();

            builder.HasOne(x => x.Address)
                .WithOne(x => x.Student);

            builder.Property(x => x.Active)
                .HasColumnName(StudentNames.Active)
                .IsRequired();
        }

        public static class StudentNames
        {
            public const string TableName = "Students";
            public const string Name = "Name";
            public const string Email = "Email";
            public const string AddressId = "Address";
            public const string Active = "Active";
            public const string Enrollments = "Students";
        }
    }
}
